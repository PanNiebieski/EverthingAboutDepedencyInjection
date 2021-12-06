var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<NewImplementation>();
builder.Services.AddTransient<OldImplementation>();

builder.Services.AddTransient<ImplementationFactory>
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




public class SomeApplicationService
{
    private readonly IImplementation _implementation;

    public SomeApplicationService(ImplementationFactory factory)
    {
        var featureFlag = true; /*read from configuration*/
        _implementation = factory(featureFlag);
    }
}


public interface IImplementation
{
}
public class NewImplementation : IImplementation
{
}
public class OldImplementation : IImplementation
{
}
