var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRandomNumberService, RandomService>();

var app = builder.Build();

NumberWriterService writerService =  
    new NumberWriterService(app.Services);


app.MapGet("/", 
    () => writerService.ShowTwoNumbers());



app.Run();




public class NumberWriterService
{
    private readonly IServiceProvider _serviceProvider;

    public NumberWriterService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public void ShowTwoNumbers()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var numberService1 = 
                scope.ServiceProvider.GetRequiredService<IRandomNumberService>();

            Console.WriteLine(numberService1.GiveNumber());
        }
        //computationService1 will be disposed here

        using (var scope = _serviceProvider.CreateScope())
        {
            var computationService2 = 
                scope.ServiceProvider.GetRequiredService<IRandomNumberService>();

            Console.WriteLine(computationService2.GiveNumber());
        }
        //computationService2 will be disposed here
    }
}
