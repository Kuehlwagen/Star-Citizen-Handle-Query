using Grpc.Core;
using Grpc.Net.Client;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.gRPC;
using Star_Citizen_Handle_Query.Serialization;
using static Star_Citizen_Handle_Query.Classes.Logging;

namespace Star_Citizen_Handle_Query.Classes;
internal static class RPC_Wrapper {

  private static string _url = string.Empty;

  public static void SetURL(string url) {
    _url = url;
  }

  public static RelationInfos GetRelations(string channel) {
    RelationInfos rtnVal = new();
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        var result = Task.FromResult(gRPC_Client.GetRelations(new ChannelRequest() { Channel = channel })).Result;
        foreach (var relation in result.Relations) {
          rtnVal.Relations.Add(new Serialization.RelationInformation() {
            Name = relation.Name,
            Type = relation.Type,
            Relation = relation.Relation
          });
        }
      }
    } catch (Exception ex) {
      Log($"{_url} - GetRelations({channel}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static bool SetRelation(string channel, RelationType type, string name, RelationValue relation) {
    bool rtnVal = false;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel) && !string.IsNullOrWhiteSpace(name)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = Task.FromResult(gRPC_Client.SetRelation(new FullRelationInfo() {
          Channel = channel,
          Relation = new RelationInfo() {
            Type = type,
            Name = name,
            Relation = relation
          }
        })).Result.Success;
      }
    } catch (Exception ex) {
      Log($"{_url} - SetRelation({channel}, {type}, {relation}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static RelationValue GetRelation(string channel, RelationType type, string name) {
    RelationValue rtnVal = RelationValue.NotAssigned;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel) && !string.IsNullOrWhiteSpace(name)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        var result = Task.FromResult(gRPC_Client.GetRelation(new RelationRequest() {
          Channel = channel,
          Type = type,
          Name = name
        })).Result;
        rtnVal = (RelationValue)(result.Found ? result.Relation : RelationValue.NotAssigned);
      }
    } catch (Exception ex) {
      Log($"{_url} - GetRelation({channel}, {type}, {name}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static bool RemoveRelations(string channel) {
    bool rtnVal = false;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = Task.FromResult(gRPC_Client.RemoveRelations(new ChannelRequest() {
          Channel = channel
        })).Result.Success;
      }
    } catch (Exception ex) {
      Log($"{_url} - RemoveRelations({channel}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static bool RestoreRelations(string channel) {
    bool rtnVal = false;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
       rtnVal = Task.FromResult(gRPC_Client.RestoreRelations(new ChannelRequest() {
         Channel = channel
       })).Result.Success;
      }
    } catch (Exception ex) {
      Log($"{_url} - RemoveRelations({channel}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static async void SyncRelations(FormRelations frm, string channel, CancellationTokenSource cts) {
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        frm.ChangeSync(FormRelations.SyncStatus.Connecting);
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        using var streamingCall = gRPC_Client.SyncRelations(new ChannelRequest() { Channel = channel }, cancellationToken: cts.Token);
        try {
          await Task.Run(() => gRPC_Channel.WaitForStateChangedAsync(gRPC_Channel.State, cts.Token));
          if (gRPC_Channel.State == ConnectivityState.Ready || gRPC_Channel.State == ConnectivityState.Idle) {
            frm.ChangeSync(FormRelations.SyncStatus.Connected);
            await foreach (var rel in streamingCall.ResponseStream.ReadAllAsync(cancellationToken: cts.Token)) {
              frm.UpdateRelation(rel.Relation.Name, rel.Relation.Type, rel.Relation.Relation, true);
            }
          }
        } catch (RpcException ex) {
          if (ex.StatusCode != StatusCode.Cancelled) {
            Log($"{_url} - SyncRelations(..., {channel}) RpcException: {ex.Message} [{ex.Status} / {ex.StatusCode}], Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
          }
        }
      }
    } catch (Exception ex) {
      Log($"{_url} - SyncRelations(..., {channel}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    frm.ChangeSync(FormRelations.SyncStatus.Disconnected);
  }

}
