using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IGameData, StaticClassGameData>();
builder.Services.AddScoped<IGameData, StaticClassGameData>();
builder.Services.Decorate<IGameData, CachedGameData>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
