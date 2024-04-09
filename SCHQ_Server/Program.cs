using Microsoft.EntityFrameworkCore;
using SCHQ_Server.Models;
using SCHQ_Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
// Use Windows service
/*
  sc create SCHQ_Server binPath="c:\Path\To\SCHQ_Server.exe" displayName="SCHQ Server"
  sc description SCHQ_Server "Star Citizen Handle Query gRPC-Server"
  sc delete SCHQ_Server
*/
builder.Host.UseWindowsService();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<SCHQ_Service>();
app.MapGet("/", () => Results.Redirect("https://github.com/Kuehlwagen/Star-Citizen-Handle-Query", true, true));

// Create / migrate SQLite database
RelationsContext context = new();
if (context.Database.GetPendingMigrations().Any()) {
  /*
    Developer-PowerShell:
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet tool update --global dotnet-ef
    dotnet ef migrations add MigrationName
    dotnet ef migrations remove
  */
  await context.Database.MigrateAsync();
}
await context.Database.EnsureCreatedAsync();

app.Run();
