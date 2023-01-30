namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable]
  public class RelationInfos {

    public bool FilterFriendlyChecked { get; set; }
    
    public bool FilterNeutralChecked { get; set; }
    
    public bool FilterBogeyChecked { get; set; }
    
    public bool FilterBanditChecked { get; set; }

    public List<RelationInfo> Relations { get; set; } = new();

  }

  [Serializable]
  public class RelationInfo {

    public string HandleName { get; set; }

    public Relation HandleRelation { get; set; }

  }

}
