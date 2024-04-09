using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using SCHQ_Shared.Protos;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.Serialization;
using static Star_Citizen_Handle_Query.Classes.Logging;

namespace Star_Citizen_Handle_Query.Classes;
internal static class RPC_Wrapper {

  private static string _url = string.Empty;

  public static void SetURL(string url) {
    _url = url;
  }

  public static bool CreateChannel(string channel, string password, ChannelPermissions permissions) {
    bool rtnVal = false;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = Task.FromResult(gRPC_Client.CreateChannel(new ChannelRequest() { Channel = channel, Password = password, Permissons = permissions })).Result.Success;
      }
    } catch (Exception ex) {
      Log($"{_url} - CreateChannel({channel}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static List<ChannelInfo> GetChannels() {
    List<ChannelInfo> rtnVal = [];
    try {
      if (!string.IsNullOrWhiteSpace(_url)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = [.. Task.FromResult(gRPC_Client.GetChannels(new Empty())).Result.Channels];
      }
    } catch (Exception ex) {
      Log($"{_url} - GetChannels() Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static ChannelReply GetChannel(string channel) {
    ChannelReply rtnVal = new();
    try {
      if (!string.IsNullOrWhiteSpace(_url)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = Task.FromResult(gRPC_Client.GetChannel(new() { Channel = channel })).Result;
      }
    } catch (Exception ex) {
      Log($"{_url} - GetChannels() Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static bool DeleteChannel(string channel, string password) {
    bool rtnVal = false;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = Task.FromResult(gRPC_Client.DeleteChannel(new ChannelRequest() { Channel = channel, Password = password })).Result.Success;
      }
    } catch (Exception ex) {
      Log($"{_url} - DeleteChannel({channel}) Exception: {ex.Message}, Inner Exception: {ex.InnerException?.Message ?? "Empty"}");
    }
    return rtnVal;
  }

  public static RelationInfos GetRelations(string channel, string password) {
    RelationInfos rtnVal = new();
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        var result = Task.FromResult(gRPC_Client.GetRelations(new ChannelRequest() { Channel = channel, Password = password })).Result;
        foreach (var relation in result.Relations) {
          rtnVal.Relations.Add(new RelationInformation() {
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

  public static bool SetRelation(string channel, string password, RelationType type, string name, RelationValue relation) {
    bool rtnVal = false;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel) && !string.IsNullOrWhiteSpace(name)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        rtnVal = Task.FromResult(gRPC_Client.SetRelation(new() {
          Channel = channel,
          Password = password,
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

  public static RelationValue GetRelation(string channel, string password, RelationType type, string name) {
    RelationValue rtnVal = RelationValue.NotAssigned;
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel) && !string.IsNullOrWhiteSpace(name)) {
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        var result = Task.FromResult(gRPC_Client.GetRelation(new RelationRequest() {
          Channel = channel,
          Password = password,
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

  public static async void SyncRelations(FormRelations frm, string channel, string password, CancellationTokenSource cts) {
    try {
      if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
        frm.ChangeSync(FormRelations.SyncStatus.Connecting);
        using var gRPC_Channel = GrpcChannel.ForAddress(_url);
        var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
        using var streamingCall = gRPC_Client.SyncRelations(new ChannelRequest() { Channel = channel, Password = password }, cancellationToken: cts.Token);
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
