namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable]
  public class RelationInfos {

    public Filter FilterVisibility { get; set; } = new();

    public List<RelationInfo> Relations { get; set; } = new();

  }

  [Serializable]
  public class Filter {

    public bool Organization { get; set; } = true;

    public bool Friendly { get; set; } = true;

    public bool Neutral { get; set; } = true;

    public bool Bogey { get; set; } = true;

    public bool Bandit { get; set; } = true;

  }

  [Serializable]
  public class RelationInfo {

    public RelationType Type { get; set; }

    public string Name { get; set; }

    public Relation Relation { get; set; }

  }

  [Serializable]
  public enum RelationType {
    Handle,
    Organization
  }

}
