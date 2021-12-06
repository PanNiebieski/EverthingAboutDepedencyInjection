var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();




public class SomeService
{
    private readonly IServiceProvider _serviceProvider;

    public SomeService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public void DoSomething()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var computationService1 = scope.ServiceProvider.GetRequiredService<IComputationService>();
            //TODO: logic
        }//computationService1 will be disposed here

        using (var scope = _serviceProvider.CreateScope())
        {
            var computationService2 = scope.ServiceProvider.GetRequiredService<IComputationService>();
            //TODO: logic
        }//computationService2 will be disposed here
    }
}
