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

app.MapGet("/", (ImplementationFactory fact) => 
    fact(true).Message());

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

public delegate IImplementation 
    ImplementationFactory(bool featureEnabled);

public interface IImplementation
{
    string Message();
}
public class NewImplementation : IImplementation
{
    public string Message()
    {
        Console.WriteLine("NewImplementation");
        return "NewImplementation";
    }
}
public class OldImplementation : IImplementation
{
    public string Message()
    {
        Console.WriteLine("OldImplementation");
        return "OldImplementation";
    }
}