using SCHQ_Server.Models;
using SCHQ_Server.Services;
using System.Net;

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
//new RelationsContext().Database.EnsureCreated();
new RelationsContext().Database.EnsureCreated();

app.Run();
