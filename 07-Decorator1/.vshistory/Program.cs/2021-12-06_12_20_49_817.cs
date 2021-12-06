using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGameData, StaticClassGameData>();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
