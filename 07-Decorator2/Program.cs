var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<GamesCacheSettings>();
builder.Services.AddSingleton<StaticClassGameData,
    StaticClassGameData>();

builder.Services.AddSingleton<IGameData>(provider =>
    new CachedGameData(provider.
    GetRequiredService<StaticClassGameData>(),
    provider.GetRequiredService<GamesCacheSettings>()));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

