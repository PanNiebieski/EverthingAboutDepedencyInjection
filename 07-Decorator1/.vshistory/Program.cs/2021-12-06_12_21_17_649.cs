using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGameData, StaticClassGameData>();
builder.Services.Decorate<IGameData, CachedGameData>();

var app = builder.Build();




app.Run();
