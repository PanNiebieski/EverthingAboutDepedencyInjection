using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();




public class CachedRestaurantData : IGameData
{
    private readonly IGameData _repository;
    private readonly IDistributedCache _cache;
    private readonly RestaurantCacheSettings _settings;

    public CachedRestaurantData(IGameData repository,
        IDistributedCache cache,
        RestaurantCacheSettings settings)
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


public class CachedRestaurantData : IRestaurantData
{
    private readonly IRestaurantData _repository;
    private readonly IDistributedCache _cache;
    private readonly RestaurantCacheSettings _settings;

    public CachedRestaurantData(IRestaurantData repository,
        IDistributedCache cache,
        RestaurantCacheSettings settings)
    {
        _repository = repository;
        _cache = cache;
        _settings = settings;
    }

    // snip for brevity
}