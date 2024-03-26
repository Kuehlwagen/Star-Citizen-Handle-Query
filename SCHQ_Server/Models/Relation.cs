using SQLite;

namespace SCHQ_Server.Models;
[Table("Relations")]
public class Relation {
  public DateTime Timestamp { get; set; }
  [Indexed(Name = "RelationID", Order = 1, Unique = true)]
  public string? Channel { get; set; }
  [Indexed(Name = "RelationID", Order = 2, Unique = true)]
  public int Type { get; set; }
  [Indexed(Name = "RelationID", Order = 3, Unique = true)]
  public string? Name { get; set; }
  public int Value { get; set; }
}
