using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using SCHQ_Protos;
using SCHQ_Server.Classes;
using SCHQ_Server.Models;

namespace SCHQ_Server.Services;
public class SCHQ_Service(ILogger<SCHQ_Service> logger) : SCHQ_Relations.SCHQ_RelationsBase {

  private readonly ILogger<SCHQ_Service> _logger = logger;
  private readonly RelationsContext _db = new();
  private DateTime SyncTimestamp = DateTime.MinValue;

  #region Channels
  public override Task<SuccessReply> CreateChannel(ChannelRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} CreateChannel Request] Channel: {Channel}, Password: {Password}",
      guid, request.Channel, !string.IsNullOrWhiteSpace(request.Password) ? "Yes" : "No");
    SuccessReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      try {
        if (!_db.Channels.Any(c => c.Name != null && c.Name == request.Channel)) {
          _db.Add(new Channel() {
            Name = request.Channel,
            DecryptedPassword = request.Password,
            Permissions = request.Permissons
          });
          rtnVal.Success = _db.SaveChanges() > 0;
          if (!rtnVal.Success) {
            rtnVal.Info = "No entries written";
          }
        } else {
          rtnVal.Info = "Channel already exists";
        }
      } catch (Exception ex) {
        rtnVal.Info = $"Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}";
        _logger.LogWarning("[{Guid} CreateChannel Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} CreateChannel Reply] Success: {Success}, Info: {Info}", guid, rtnVal.Success, rtnVal.Info);
    return Task.FromResult(rtnVal);
  }

  public override Task<ChannelsReply> GetChannels(Empty request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} GetChannels Request]", guid);
    ChannelsReply rtnVal = new();

    try {
      IOrderedQueryable<Channel> results = from c in _db.Channels
                                           orderby c.Name
                                           select c;
      foreach (Channel c in results.ToListAsync().Result) {
        rtnVal.Channels.Add(new ChannelInfo() {
          Name = c.Name,
          HasPassword = c.Password?.Length > 0,
          Permissions = c.Permissions
        });
      }
    } catch (Exception ex) {
      _logger.LogWarning("[{Guid} GetChannels Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
        guid, ex.Message, ex.InnerException?.Message ?? "Empty");
    }

    _logger.LogInformation("[{Guid} GetChannels Reply] Count: {Count}", guid, rtnVal.Channels.Count);
    return Task.FromResult(rtnVal);
  }

  public override Task<ChannelReply> GetChannel(ChannelNameRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} GetChannel Request] Channel: {Channel}", guid, request.Channel);
    ChannelReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      try {
        if (_db.Channels.FirstOrDefault(c => c.Name == request.Channel) is Channel channel) {
          rtnVal = new ChannelReply() {
            Found = true,
            Channel = new() {
              Name = channel.Name,
              HasPassword = channel.Password?.Length > 0,
              Permissions = channel.Permissions
            }
          };
        }
      } catch (Exception ex) {
        _logger.LogWarning("[{Guid} GetChannel Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} GetChannel Reply] Found: {Found}, Channel: {Channel}",
      guid, rtnVal.Found, rtnVal.Channel);
    return Task.FromResult(rtnVal);
  }

  public override Task<SuccessReply> DeleteChannel(ChannelRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} DeleteChannel Request] Channel: {Channel}, Password: {Password}",
      guid, request.Channel, !string.IsNullOrWhiteSpace(request.Password) ? "Yes" : "No");
    SuccessReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      request.Password = !string.IsNullOrWhiteSpace(request.Password) ? Encryption.EncryptText(request.Password) : string.Empty;
      try {
        Channel? channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel);
        if (channel != null) {
          if (channel.Password == request.Password) {
            _db.Remove(channel);
            rtnVal.Success = _db.SaveChanges() > 0;
            if (!rtnVal.Success) {
              rtnVal.Info = "No entries written";
            }
          } else {
            rtnVal.Info = "Access denied";
          }
        } else {
          rtnVal.Info = "Channel not found";
        }
      } catch (Exception ex) {
        rtnVal.Info = $"Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}";
        _logger.LogWarning("[{Guid} DeleteChannel Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} DeleteChannel Reply] Success: {Success}, Info: {Info}", guid, rtnVal.Success, rtnVal.Info);
    return Task.FromResult(rtnVal);
  }
  #endregion

  #region Relations
  public override Task<SuccessReply> SetRelations(SetRelationsRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} SetRelations Request] Channel: {Channel}, Password: {Password}, Relations: {Relations}",
      guid, request.Channel, request.Password?.Length > 0 ? "Yes" : "No", request?.Relations?.Count);
    SuccessReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request?.Channel) && request?.Relations?.Count > 0) {
      request.Channel = request.Channel.Trim();
      request.Password = !string.IsNullOrWhiteSpace(request.Password) ? Encryption.EncryptText(request.Password) : string.Empty;
      try {
        Channel? channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel);
        if (channel != null) {
          if (channel.Permissions >= ChannelPermissions.Write || channel.Password == request.Password) {
            List<Relation?> relations = [];
            foreach (RelationInfo relationInfo in request.Relations) {
              Relation? relation = _db.Relations.FirstOrDefault(r => r.Type == relationInfo.Type && r.ChannelId == channel.Id && r.Name == relationInfo.Name);
              relation ??= new() {
                ChannelId = channel.Id,
                Type = relationInfo.Type,
                Name = relationInfo.Name,
              };
              relation.Timestamp = DateTime.UtcNow;
              relation.Value = relationInfo.Relation;
              relations.Add(relation);
            }
            _db.UpdateRange(relations!);
            rtnVal.Success = _db.SaveChanges() > 0;
            if (!rtnVal.Success) {
              rtnVal.Info = "No entries written";
            }
          } else {
            rtnVal.Info = "Access denied";
          }
        } else {
          rtnVal.Info = "Channel not found";
        }
      } catch (Exception ex) {
        rtnVal.Info = $"Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}";
        _logger.LogWarning("[{Guid} SetRelations Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} SetRelations Reply] Success: {Success}, Info: {Info}", guid, rtnVal.Success, rtnVal.Info);
    return Task.FromResult(rtnVal);
  }

  public override Task<SuccessReply> SetRelation(SetRelationRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} SetRelation Request] Channel: {Channel}, Password: {Password}, Type: {Type}, Name: {Name}, Relation: {Relation}",
      guid, request.Channel, request.Password?.Length > 0 ? "Yes" : "No", request.Relation.Type, request.Relation.Name, request.Relation.Relation);
    SuccessReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel) && !string.IsNullOrWhiteSpace(request.Relation?.Name)) {
      request.Channel = request.Channel.Trim();
      request.Relation.Name = request.Relation.Name.Trim();
      request.Password = !string.IsNullOrWhiteSpace(request.Password) ? Encryption.EncryptText(request.Password) : string.Empty;
      try {
        Channel? channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel);
        if (channel != null) {
          if (channel.Permissions >= ChannelPermissions.Write || channel.Password == request.Password) {
            Relation? relation = _db.Relations.FirstOrDefault(r => r.Type == request.Relation.Type && r.ChannelId == channel.Id && r.Name == request.Relation.Name);
            relation ??= new() {
              ChannelId = channel.Id,
              Type = request.Relation.Type,
              Name = request.Relation.Name,
            };
            relation.Timestamp = DateTime.UtcNow;
            relation.Value = request.Relation.Relation;
            _db.Update(relation);
            rtnVal.Success = _db.SaveChanges() > 0;
            if (!rtnVal.Success) {
              rtnVal.Info = "No entries written";
            }
          } else {
            rtnVal.Info = "Access denied";
          }
        } else {
          rtnVal.Info = "Channel not found";
        }
      } catch (Exception ex) {
        rtnVal.Info = $"Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}";
        _logger.LogWarning("[{Guid} SetRelation Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} SetRelation Reply] Success: {Success}, Info: {Info}", guid, rtnVal.Success, rtnVal.Info);
    return Task.FromResult(rtnVal);
  }

  public override Task<RelationsReply> GetRelations(ChannelRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} GetRelations Request] Channel: {Channel}, Password: {Password}",
      guid, request.Channel, request.Password?.Length > 0 ? "Yes" : "No");
    RelationsReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      request.Password = !string.IsNullOrWhiteSpace(request.Password) ? Encryption.EncryptText(request.Password) : string.Empty;
      try {
        Channel? channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel && (c.Permissions >= ChannelPermissions.Read || c.Password == request.Password));
        if (channel != null) {
          IOrderedQueryable<Relation> results = from rel in _db.Relations
                                                where rel.ChannelId == channel.Id
                                                orderby rel.Type descending, rel.Name
                                                select rel;
          foreach (Relation rel in results.ToListAsync().Result) {
            rtnVal.Relations.Add(new RelationInfo() {
              Type = rel.Type,
              Name = rel.Name,
              Relation = rel.Value
            });
          }
        }
      } catch (Exception ex) {
        _logger.LogWarning("[{Guid} GetRelations Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} GetRelations Reply] Count: {Count}", guid, rtnVal.Relations.Count);
    return Task.FromResult(rtnVal);
  }

  public override Task<RelationReply> GetRelation(RelationRequest request, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} GetRelation Request] Channel: {Channel}, Password: {Password}, Type: {Type}, Name: {Name}",
      guid, request.Channel, request.Password?.Length > 0 ? "Yes" : "No", request.Type, request.Name);
    RelationReply rtnVal = new();

    if (!string.IsNullOrWhiteSpace(request.Channel) && !string.IsNullOrWhiteSpace(request.Name)) {
      request.Channel = request.Channel.Trim();
      request.Name = request.Name.Trim();
      request.Password = !string.IsNullOrWhiteSpace(request.Password) ? Encryption.EncryptText(request.Password) : string.Empty;
      try {
        Channel? channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel && (c.Permissions >= ChannelPermissions.Read || c.Password == request.Password));
        if (channel != null) {
          IQueryable<Relation> results = from rel in _db.Relations
                                         where rel.ChannelId == channel.Id && rel.Type == request.Type && rel.Name == request.Name
                                         select rel;
          foreach (Relation rel in results.ToListAsync().Result) {
            rtnVal = new RelationReply() {
              Found = true,
              Relation = rel.Value
            };
          }
        }
      } catch (Exception ex) {
        _logger.LogWarning("[{Guid} GetRelation Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}",
          guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} GetRelation Reply] Found: {Found}, Relation: {Relation}",
      guid, rtnVal.Found, rtnVal.Relation);
    return Task.FromResult(rtnVal);
  }

  public override async Task SyncRelations(ChannelRequest request, IServerStreamWriter<SyncRelationsReply> responseStream, ServerCallContext context) {
    Guid guid = Guid.NewGuid();
    _logger.LogInformation("[{Guid} SyncRelations Request] Channel: {Channel}, Password: {Password}",
      guid, request.Channel, request.Password?.Length > 0 ? "Yes" : "No");

    if (!string.IsNullOrWhiteSpace(request.Channel)) {
      request.Channel = request.Channel.Trim();
      request.Password = !string.IsNullOrWhiteSpace(request.Password) ? Encryption.EncryptText(request.Password) : string.Empty;
      SyncTimestamp = DateTime.UtcNow;
      try {
        Channel? channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel && (c.Permissions >= ChannelPermissions.Read || c.Password == request.Password));
        if (channel != null) {
          while (!context.CancellationToken.IsCancellationRequested && channel?.Id > 0) {
            IOrderedQueryable<Relation> results = from rel in _db.Relations
                                                  where rel.ChannelId == channel.Id && rel.Timestamp > SyncTimestamp
                                                  orderby rel.Timestamp
                                                  select rel;
            if (await results.AnyAsync()) {
              foreach (Relation rel in results.ToListAsync().Result) {
                // Reload() scheint nötig zu sein, da der Timestamp ansonsten den alten Wert enthält
                _db.Entry(rel).Reload();
                await responseStream.WriteAsync(new SyncRelationsReply() {
                  Channel = request.Channel,
                  Relation = new RelationInfo() {
                    Type = rel.Type,
                    Name = rel.Name,
                    Relation = rel.Value
                  }
                });
                SyncTimestamp = rel.Timestamp;
              }
            }
            await Task.Delay(500);
            channel = _db.Channels.FirstOrDefault(c => c.Name == request.Channel);
          }
        }
      } catch (Exception ex) {
        _logger.LogWarning("[{Guid} SyncRelations Exception] Message: {Message}, Inner Exception: {InnerExceptionMessage}", guid, ex.Message, ex.InnerException?.Message ?? "Empty");
      }
    }

    _logger.LogInformation("[{Guid} SyncRelations End]", guid);
  }
  #endregion

}
