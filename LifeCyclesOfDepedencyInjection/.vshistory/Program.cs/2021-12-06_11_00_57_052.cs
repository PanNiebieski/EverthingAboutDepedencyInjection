var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public class CezService : 
    ICezTransientService, 
    ICezScopedService, 
    ICezSingletonService
{
    public string InstanceId { get; } = 
        Guid.NewGuid().ToString();
}