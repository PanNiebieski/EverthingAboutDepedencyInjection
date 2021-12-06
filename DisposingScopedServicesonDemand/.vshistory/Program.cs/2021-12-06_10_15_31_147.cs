var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IComputationService, ComputationService>();

var app = builder.Build();





app.MapGet("/", () => "Hello World!");



app.Run();




public class SomeService
{
    private readonly IServiceProvider _serviceProvider;

    public SomeService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public void ShowTwoNumbers()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var computationService1 = 
                scope.ServiceProvider.GetRequiredService<IComputationService>();

            Console.WriteLine(computationService1.GiveNumber());
        }
        //computationService1 will be disposed here

        using (var scope = _serviceProvider.CreateScope())
        {
            var computationService2 = 
                scope.ServiceProvider.GetRequiredService<IComputationService>();

            Console.WriteLine(computationService2.GiveNumber());
        }
        //computationService2 will be disposed here
    }
}
