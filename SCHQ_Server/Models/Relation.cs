using Microsoft.EntityFrameworkCore;
using SCHQ_Protos;
using SCHQ_Server.Classes;
using SQLite;
using System.Reflection;
using DAS = System.ComponentModel.DataAnnotations.Schema;

namespace SCHQ_Server.Models;

public class RelationsContext : DbContext {

  public DbSet<Relation> Relations { get; set; }
  public DbSet<Channel> Channels { get; set; }

  public string? DbPath { get; }

  public RelationsContext() {
    DbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "Relations.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    => configurationBuilder.Properties<string>().UseCollation("NOCASE");

}

[Table("Relations"), Index("ChannelId", new string[] { "Type", "Name" }, IsUnique = true, Name = "RelationID")]
public class Relation {
  [SQLite.PrimaryKey, AutoIncrement]
  public int Id { get; set; }
  public DateTime Timestamp { get; set; }
  public int ChannelId { get; set; }
  public Channel? Channel { get; set; }
  public RelationType Type { get; set; }
  public string? Name { get; set; }
  public RelationValue Value { get; set; }
}

[Table("Channels"), Index("Name", new string[] {}, IsUnique = true, Name = "ChannelName")]
public class Channel {
  [SQLite.PrimaryKey, AutoIncrement]
  public int Id { get; set; }
  public string? Name { get; set; }
  [DAS.NotMapped]
  public string? DecryptedPassword {
    get { return Encryption.DecryptText(Password); }
    set { Password = !string.IsNullOrEmpty(value) ? Encryption.EncryptText(value) : string.Empty; }
  }
  public string? Password { get; set; }
  public ChannelPermissions Permissions { get; set; }
}
