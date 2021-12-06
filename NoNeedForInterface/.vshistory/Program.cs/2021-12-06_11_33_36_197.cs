var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CubeClass>();
builder.Services.AddSingleton<CircleService>();

var app = builder.Build();



app.MapGet("/", (CircleService service) => "Hello World!");

app.Run();



public class CubeClass
{
    public string Get()
    {
        return "Cube";
    }
}


public class CircleService
{
    private readonly CubeClass _cube;

    public CircleService(CubeClass cube)
    {
        _cube = cube;
    }

    public string Get()
    {
        return _cube.Get();
    }
}