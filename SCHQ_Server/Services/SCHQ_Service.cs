using Grpc.Core;
using SQLite;
using System.Reflection;

namespace SCHQ_Server.Services;
public class SCHQ_Service : SCHQ_Relations.SCHQ_RelationsBase {

  private readonly ILogger<SCHQ_Service> _logger;
  private readonly SQLiteAsyncConnection _db = new(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "Relations.db"));
  private DateTime SyncTimestamp = DateTime.MinValue;

  public SCHQ_Service(ILogger<SCHQ_Service> logger) {
    _logger = logger;
    CreateTableResult result = _db.CreateTableAsync<Models.Relation>().Result;
    _logger.LogInformation("[SQLite CreateTable] Result: {Result}", result);
  }

  public override Task<SuccessReply> SetRelation(FullRelationInfo request, ServerCallContext context) {
    _logger.LogInformation("[SetRelation Request] Channel: {Channel}, Type: {Type}, Name: {Name}, Relation: {Relation}", request.Channel, request.Relation.Type, request.Relation.Name, request.Relation.Relation);
    bool rtnVal = false;

    if (!string.IsNullOrWhiteSpace(request.Channel) && !string.IsNullOrWhiteSpace(request.Relation?.Name)) {
      request.Channel = request.Channel.Trim();
      request.Relation.Name = request.Relation.Name.Trim();
      try {
        int count = _db.GetConnection().InsertOrReplace(new Models.Relation() {
          Timestamp = DateTime.UtcNow,
          Channel = request.Channel,
          Type = (int)request.Relation.Type,
          Name = request.Relation.Name,
          Value = (int)request.Relation.Relation
        });
        rtnVal = count == 1;
      } catch (Exception ex) {
        _logger.LogInformation("[SetRelation Exception] Message: {Message}", ex.Message);
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
        AsyncTableQuery<Models.Relation> results = from rel in _db.Table<Models.Relation>()
                                                   where rel.Channel == request.Channel && rel.Value > 0
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
        _logger.LogInformation("[GetRelations Exception] Message: {Message}", ex.Message);
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
        AsyncTableQuery<Models.Relation> results = from rel in _db.Table<Models.Relation>()
                                                   where rel.Type == (int)request.Type && rel.Channel == request.Channel && rel.Name == request.Name
                                                   select rel;
        foreach (Models.Relation rel in results.ToListAsync().Result) {
          rtnVal = new RelationReply() {
            Found = true,
            Relation = (Relation)rel.Value
          };
        }
      } catch (Exception ex) {
        _logger.LogInformation("[GetRelation Exception] Message: {Message}", ex.Message);
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
        int count = _db.GetConnection().Table<Models.Relation>().Delete(rel => rel.Channel == request.Channel);
        rtnVal = count > 0;
      } catch (Exception ex) {
        _logger.LogInformation("[RemoveRelations Exception] Message: {Message}", ex.Message);
      }
    }

    _logger.LogInformation("[RemoveRelations Reply] Success: {Success}", rtnVal);
    return Task.FromResult(new SuccessReply() { Success = rtnVal });
  }

  public override async Task SyncRelations(ChannelRequest request, IServerStreamWriter<FullRelationInfo> responseStream, ServerCallContext context) {
    _logger.LogInformation("[SyncRelations Request] Channel: {Channel}", request.Channel);

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      SyncTimestamp = DateTime.UtcNow;
      try {
        while (!context.CancellationToken.IsCancellationRequested) {
          AsyncTableQuery<Models.Relation> results = from rel in _db.Table<Models.Relation>()
                                                     where rel.Channel == request.Channel && rel.Timestamp > SyncTimestamp
                                                     orderby rel.Timestamp
                                                     select rel;
          if (await results.CountAsync() > 0) {
            foreach (Models.Relation rel in results.ToListAsync().Result) {
              await responseStream.WriteAsync(new FullRelationInfo() {
                Channel = rel.Channel,
                Relation = new RelationInfo() {
                  Type = (RelationType)rel.Type,
                  Name = rel.Name,
                  Relation = (Relation)rel.Value
                }
              });
              SyncTimestamp = rel.Timestamp;
            }
          } else {
            SyncTimestamp = DateTime.UtcNow;
          }
          await Task.Delay(500);
        }
      } catch (Exception ex) {
        _logger.LogInformation("[SyncRelations Exception] Message: {Message}", ex.Message);
      }
    }

    _logger.LogInformation("[SyncRelations End]");
  }

}
