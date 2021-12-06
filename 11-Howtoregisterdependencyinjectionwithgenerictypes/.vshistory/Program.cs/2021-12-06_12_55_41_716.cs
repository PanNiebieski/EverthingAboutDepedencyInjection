var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

app.MapGet("/", (IGenericRepository<string> repository) => "Hello World!");




app.Run();


public class Cezary
{
    public override string ToString()
    {
        return "Cezary";
    }

}
