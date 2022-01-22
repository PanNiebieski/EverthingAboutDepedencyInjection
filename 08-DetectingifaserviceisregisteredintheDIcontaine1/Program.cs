var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICeasarService, CeasarService>();

var app = builder.Build();

// IServiceProviderIsService exist in .NET 6
var serviceProviderIsService = 
    app.Services.GetService<IServiceProviderIsService>();

// The ICeasarService is registered so this will return true
app.MapGet("/", () => 
serviceProviderIsService.IsService(typeof(ICeasarService)));

// The CeasarService is NOT registered directly, so this will return false
app.MapGet("/C", () => 
serviceProviderIsService.IsService(typeof(CeasarService)));

app.Run();



public class CeasarService : ICeasarService
{
    public string SayHello() => "Hellow World!";
}
public interface ICeasarService
{
    string SayHello();
}