using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using SCHQ_Server.Models;

namespace SCHQ_Server.Services;
public class SCHQ_Service(ILogger<SCHQ_Service> logger) : SCHQ_Relations.SCHQ_RelationsBase {

  private readonly ILogger<SCHQ_Service> _logger = logger;
  private readonly RelationsContext _db = new();
  private readonly Guid _syncId = Guid.NewGuid();
  private DateTime SyncTimestamp = DateTime.MinValue;

  public override Task<SuccessReply> SetRelation(FullRelationInfo request, ServerCallContext context) {
    _logger.LogInformation("[SetRelation Request] Channel: {Channel}, Type: {Type}, Name: {Name}, Relation: {Relation}", request.Channel, request.Relation.Type, request.Relation.Name, request.Relation.Relation);
    bool rtnVal = false;

    if (!string.IsNullOrWhiteSpace(request.Channel) && !string.IsNullOrWhiteSpace(request.Relation?.Name)) {
      request.Channel = request.Channel.Trim();
      request.Relation.Name = request.Relation.Name.Trim();
      try {
        Models.Relation? relation = _db.Relations.FirstOrDefault(r => r.Type == (int)request.Relation.Type && r.Channel != null && r.Channel.Name == request.Channel && r.Name == request.Relation.Name);
        relation ??= new Models.Relation() {
          Type = (int)request.Relation.Type,
          Channel = _db.Channels.FirstOrDefault(c => c.Name ==  request.Channel) ?? new Channel() { Name = request.Channel },
          Name = request.Relation.Name,
        };
        relation.Timestamp = DateTime.UtcNow;
        relation.Value = (int)request.Relation.Relation;
        _db.Update(relation);
        rtnVal = _db.SaveChanges() > 0;
      } catch (Exception ex) {
        _logger.LogInformation("[SetRelation Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[SetRelation Reply] Success: {Success}", rtnVal);
    return Task.FromResult(new SuccessReply() { Success = rtnVal });
  }

  public override Task<RelationsReply> GetRelations(ChannelRequest request, ServerCallContext context) {
    _logger.LogInformation("[GetRelations Request] Channel: {Channel}", request.Channel);
    RelationsReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      try {
        IOrderedQueryable<Models.Relation> results = from rel in _db.Relations
                                                     where rel.Channel != null && rel.Channel.Name == request.Channel && rel.Value > 0
                                                     orderby rel.Type descending, rel.Name
                                                     select rel;
        foreach (Models.Relation rel in results.ToListAsync().Result) {
          rtnVal.Relations.Add(new RelationInfo() {
            Type = (RelationType)rel.Type,
            Name = rel.Name,
            Relation = (Relation)rel.Value
          });
        }
      } catch (Exception ex) {
        _logger.LogInformation("[GetRelations Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[GetRelations Reply] Count: {Count}", rtnVal.Relations.Count);
    return Task.FromResult(rtnVal);
  }

  public override Task<RelationReply> GetRelation(RelationRequest request, ServerCallContext context) {
    _logger.LogInformation("[GetRelation Request] Channel: {Channel}, Type: {Type}, Name: {Name}", request.Channel, request.Type, request.Name);
    RelationReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel) && !string.IsNullOrWhiteSpace(request.Name)) {
      request.Channel = request.Channel.Trim();
      request.Name = request.Name.Trim();
      try {
        IQueryable<Models.Relation> results = from rel in _db.Relations
                                              where rel.Type == (int)request.Type && rel.Channel != null && rel.Channel.Name == request.Channel && rel.Name == request.Name
                                              select rel;
        foreach (Models.Relation rel in results.ToListAsync().Result) {
          rtnVal = new RelationReply() {
            Found = true,
            Relation = (Relation)rel.Value
          };
        }
      } catch (Exception ex) {
        _logger.LogInformation("[GetRelation Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[GetRelation Reply] Found: {Found}, Relation: {Relation}", rtnVal.Found, rtnVal.Relation);
    return Task.FromResult(rtnVal);
  }

  public override Task<SuccessReply> RemoveRelations(ChannelRequest request, ServerCallContext context) {
    _logger.LogInformation("[RemoveRelations Request] Channel: {Channel}", request.Channel);
    bool rtnVal = false;

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      try {
        (from r in _db.Relations
         where r.Channel != null && r.Channel.Name == request.Channel && r.Value > (int)Relation.NotAssigned
         select r)
         .ToList()
         .ForEach( r => {
           r.Timestamp = DateTime.UtcNow;
           r.RemovedValue = r.Value;
           r.Value = (int)Relation.NotAssigned;
         });
        rtnVal = _db.SaveChanges() > 0;
      } catch (Exception ex) {
        _logger.LogInformation("[RemoveRelations Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[RemoveRelations Reply] Success: {Success}", rtnVal);
    return Task.FromResult(new SuccessReply() { Success = rtnVal });
  }

  public override Task<SuccessReply> RestoreRelations(ChannelRequest request, ServerCallContext context) {
    _logger.LogInformation("[RestoreRelations Request] Channel: {Channel}", request.Channel);
    bool rtnVal = false;

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      try {
        (from r in _db.Relations
         where r.Channel != null && r.Channel.Name == request.Channel && r.RemovedValue > (int)Relation.NotAssigned
         select r)
         .ToList()
         .ForEach(r => {
           r.Timestamp = DateTime.UtcNow;
           r.Value = r.RemovedValue;
           r.RemovedValue = (int)Relation.NotAssigned;
         });
        rtnVal = _db.SaveChanges() > 0;
      } catch (Exception ex) {
        _logger.LogInformation("[RestoreRelations Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[RestoreRelations Reply] Success: {Success}", rtnVal);
    return Task.FromResult(new SuccessReply() { Success = rtnVal });
  }

  public override async Task SyncRelations(ChannelRequest request, IServerStreamWriter<FullRelationInfo> responseStream, ServerCallContext context) {
    _logger.LogInformation("[SyncRelations {Id} Request] Channel: {Channel}", _syncId, request.Channel);

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      SyncTimestamp = DateTime.UtcNow;
      try {
        while (!context.CancellationToken.IsCancellationRequested) {
          IOrderedQueryable<Models.Relation> results = from rel in _db.Relations
                                                       where rel.Channel != null && rel.Channel.Name == request.Channel && rel.Timestamp > SyncTimestamp
                                                       orderby rel.Timestamp
                                                       select rel;
          if (await results.AnyAsync()) {
            foreach (Models.Relation rel in results.ToListAsync().Result) {
              // Reload() scheint nötig zu sein, da der Timestamp ansonsten den alten Wert enthält
              _db.Entry(rel).Reload();
              await responseStream.WriteAsync(new FullRelationInfo() {
                Channel = request.Channel,
                Relation = new RelationInfo() {
                  Type = (RelationType)rel.Type,
                  Name = rel.Name,
                  Relation = (Relation)rel.Value
                }
              });
              SyncTimestamp = rel.Timestamp;
            }
          }
          await Task.Delay(500);
        }
      } catch (Exception ex) {
        _logger.LogInformation("[SyncRelations {Id} Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", _syncId, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[SyncRelations {Id} End]", _syncId);
  }

}
