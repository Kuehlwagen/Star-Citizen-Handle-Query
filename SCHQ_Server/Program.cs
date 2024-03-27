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
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
