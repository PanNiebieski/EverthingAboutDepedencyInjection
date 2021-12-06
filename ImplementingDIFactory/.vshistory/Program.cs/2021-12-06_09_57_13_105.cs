var builder = WebApplication.CreateBuilder(args);



bool featureEnabled = true; //Read from config

if (featureEnabled)
{
    services.AddScoped<IImplementation, NewImplementation>();
}
else
{
    services.AddScoped<IImplementation, OldImplementation>();
}





var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
