var builder = WebApplication.CreateBuilder(args);



bool featureEnabled = true; //Read from config

if (featureEnabled)
{
    builder.Services.AddScoped<IImplementation, NewImplementation>();
}
else
{
    builder.Services.AddScoped<IImplementation, OldImplementation>();
}





var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



public interface IImplementation
{
}
public class NewImplementation : IImplementation
{
}
public class OldImplementation : IImplementation
{
}
