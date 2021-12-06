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

    // snip for brevity
}
