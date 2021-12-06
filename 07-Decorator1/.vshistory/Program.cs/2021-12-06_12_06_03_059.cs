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


public class RestaurantCountViewComponent : ViewComponent
{
    private readonly IGameData _gameData;

    public RestaurantCountViewComponent(IGameData restaurantData)
    {
        _gameData = restaurantData;
    }

    public IViewComponentResult Invoke()
    {
        // ViewComponent does not care what it gets as long as it implements the interface and gives the answer
        var count = _gameData.GetCountOfRestaurants();
        return View(count);
    }
}


public interface IGameData
{

}
