using Grpc.Core;
using Grpc.Net.Client;
using Star_Citizen_Handle_Query.Dialogs;
using Star_Citizen_Handle_Query.gRPC;
using Star_Citizen_Handle_Query.Serialization;
using System.Diagnostics;

namespace Star_Citizen_Handle_Query.Classes;
internal static class RPC_Wrapper {

  private static string _url = string.Empty;

  public static void SetURL(string url) {
    _url = url;
  }

  public static RelationInfos GetRelations(string channel) {
    RelationInfos rtnVal = new();
    if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
      using var gRPC_Channel = GrpcChannel.ForAddress(_url);
      var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
      var result = Task.FromResult(gRPC_Client.GetRelations(new ChannelRequest() { Channel = channel })).Result;
      foreach (var relation in result.Relations) {
        rtnVal.Relations.Add(new Serialization.RelationInfo() {
          Name = relation.Name,
          Type = (Serialization.RelationType)relation.Type,
          Relation = (Serialization.Relation)relation.Relation
        });
      }
    }
    return rtnVal;
  }

  public static bool SetRelation(string channel, Serialization.RelationType type, string name, Serialization.Relation relation) {
    if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel) && !string.IsNullOrWhiteSpace(name)) {
      using var gRPC_Channel = GrpcChannel.ForAddress(_url);
      var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
      var result = Task.FromResult(gRPC_Client.SetRelation(new FullRelationInfo() {
        Channel = channel,
        Relation = new gRPC.RelationInfo() {
          Type = (gRPC.RelationType)type,
          Name = name,
          Relation = (gRPC.Relation)relation
        }
      })).Result;
      return result.Success;
    } else {
      return false;
    }
  }

  public static Serialization.Relation GetRelation(string channel, Serialization.RelationType type, string name) {
    if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel) && !string.IsNullOrWhiteSpace(name)) {
      using var gRPC_Channel = GrpcChannel.ForAddress(_url);
      var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
      var result = Task.FromResult(gRPC_Client.GetRelation(new RelationRequest() {
        Channel = channel,
        Type = (gRPC.RelationType)type,
        Name = name
      })).Result;
      return (Serialization.Relation)(result.Found ? result.Relation : gRPC.Relation.NotAssigned);
    } else {
      return Serialization.Relation.NotAssigned;
    }
  }

  public static bool RemoveRelations(string channel) {
    if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
      using var gRPC_Channel = GrpcChannel.ForAddress(_url);
      var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
      var result = Task.FromResult(gRPC_Client.RemoveRelations(new ChannelRequest() {
        Channel = channel
      })).Result;
      return result.Success;
    } else {
      return false;
    }
  }

  public static async void SyncRelations(FormRelations frm, string channel) {
    if (!string.IsNullOrWhiteSpace(_url) && !string.IsNullOrWhiteSpace(channel)) {
      var cts = new CancellationTokenSource();
      using var gRPC_Channel = GrpcChannel.ForAddress(_url);
      var gRPC_Client = new SCHQ_Relations.SCHQ_RelationsClient(gRPC_Channel);
      using var streamingCall = gRPC_Client.SyncRelations(new ChannelRequest() { Channel = channel }, cancellationToken: cts.Token);
      try {
        await foreach (var rel in streamingCall.ResponseStream.ReadAllAsync(cancellationToken: cts.Token)) {
          frm.UpdateRelation(rel.Relation.Name, (Serialization.RelationType)rel.Relation.Type, (Serialization.Relation)rel.Relation.Relation, true);
        }
      } catch (RpcException ex) {
        Debug.WriteLine($"RpcException: {ex.Message}, {ex.StatusCode}");
      } catch (Exception ex) {
        Debug.WriteLine($"Exception: {ex.Message}");
      }
      cts.Cancel();
    }
  }

}
