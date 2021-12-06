var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public interface ICezService
{
    string InstanceId { get; }
}

public interface ICezTransientService 
    : ICezService
{

}
public interface ICezScopedService : 
    ICezService
{

}