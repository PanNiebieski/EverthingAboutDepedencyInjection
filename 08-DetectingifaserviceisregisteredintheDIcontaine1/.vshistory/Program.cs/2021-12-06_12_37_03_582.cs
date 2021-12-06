var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGreeterService, GreeterService>();

var app = builder.Build();






// try and get the new interface. 
// This will return null if the feature isn't yet supported by the container
var serviceProviderIsService = app.Services.GetService<IServiceProviderIsService>();

// The IGreeterService is registered in the DI container



// The GreeterService is NOT registered directly in the DI container.



app.MapGet("/", () => serviceProviderIsService.IsService(typeof(IGreeterService)));

app.MapGet("/C", () => serviceProviderIsService.IsService(typeof(GreeterService)));

app.Run();



public class GreeterService : IGreeterService
{
    public string SayHello() => "Hellow World!";
}
public interface IGreeterService
{
    string SayHello();
}