using Hopital.DataLayer;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<HospitalContext>();

app.MapGet("/", () => "Hello World!");

app.Run();
