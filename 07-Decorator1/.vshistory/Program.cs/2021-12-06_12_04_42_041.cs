var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();




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

  
}


public class RestaurantCountViewComponent : ViewComponent
{
    private readonly IRestaurantData _restaurantData;

    public RestaurantCountViewComponent(IRestaurantData restaurantData)
    {
        _restaurantData = restaurantData;
    }

    public IViewComponentResult Invoke()
    {
        // ViewComponent does not care what it gets as long as it implements the interface and gives the answer
        var count = _restaurantData.GetCountOfRestaurants();
        return View(count);
    }
}
