namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable]
  public class RelationInfos {

    public Filter FilterVisibility { get; set; } = new();

    public List<RelationInfo> Relations { get; set; } = new();

  }

  [Serializable]
  public class Filter {

    public bool Friendly { get; set; }

    public bool Neutral { get; set; }

    public bool Bogey { get; set; }

    public bool Bandit { get; set; }

  }

  [Serializable]
  public class RelationInfo {

    public string Handle { get; set; }

    public Relation Relation { get; set; }

  }

}
