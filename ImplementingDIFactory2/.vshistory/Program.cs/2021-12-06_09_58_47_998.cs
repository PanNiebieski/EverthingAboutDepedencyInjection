var builder = WebApplication.CreateBuilder(args);



services.AddTransient<NewImplementation>();
services.AddTransient<OldImplementation>();

services.AddTransient<ImplementationFactory>
    (serviceProvider => featureEnabled =>
{
    return featureEnabled switch
    {
        true => serviceProvider.GetRequiredService<NewImplementation>(),
        _ => serviceProvider.GetRequiredService<OldImplementation>()
    };
});










var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
