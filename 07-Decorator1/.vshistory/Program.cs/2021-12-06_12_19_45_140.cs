using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


public class GamesCacheSettings
{
    public int Minutes { get; set; }
}


public class GameData : IGameData
{
    private Random _random = new Random();


    public int GetCountOfGames()
    {
        return _random.Next(1, 1000);
    }
}