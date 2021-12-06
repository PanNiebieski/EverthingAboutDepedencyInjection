var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

app.MapGet("/", (IGenericRepository<Cezary> repository) => repository.Get().ToString());




app.Run();


public class Cezary
{
    public override string ToString()
    {
        return "Cezary";
    }

}
