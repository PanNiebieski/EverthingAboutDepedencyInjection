var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



public class CubeClass
{
}


public class CircleService
{
    public CircleService(SomeClass someClass)
    {
    }
}