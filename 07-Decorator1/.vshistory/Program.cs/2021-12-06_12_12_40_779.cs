using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();




public class CachedRestaurantData : IGameData
{
    private readonly IGameData _repository;
    private readonly IDistributedCache _cache;
    private readonly GamesCacheSettings _settings;

    public CachedRestaurantData(IGameData repository,
        IDistributedCache cache,
        GamesCacheSettings settings)
    {
        _repository = repository;
        _cache = cache;
        _settings = settings;
    }

  
}


public class GameCountViewComponent : ViewComponent
{
    private readonly IGameData _gameData;

    public GameCountViewComponent(IGameData gamedata)
    {
        _gameData = gamedata;
    }

    public IViewComponentResult Invoke()
    {
        var count = _gameData.GetCountOfRestaurants();
        return View(count);
    }
}


public interface IGameData
{
    int GetCountOfRestaurants();
}


public class CachedGameData : IGameData
{
    private readonly IGameData _repository;
    private readonly GamesCacheSettings _settings;

    public CachedGameData(IGameData repository,
        GamesCacheSettings settings)
    {
        _repository = repository;
        _settings = settings;
    }


    private int _count;
    public int GetCountOfRestaurants()
    {
        if (_count == 0 && 
            _settings.Minutes != DateTime.Now.Minute)
        {
            _count = _repository.GetCountOfRestaurants();
            _settings.Minutes = DateTime.Now.Minute;
        }

        return _count;
    }
}

public class GamesCacheSettings
{
    public int Minutes { get; set; }
}