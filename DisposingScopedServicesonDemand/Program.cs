var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton
    <IRandomNumberService, RandomService>();

var app = builder.Build();

NumberWriterService writerService =  
    new NumberWriterService(app.Services);


app.MapGet("/", 
    () => writerService.ShowTwoNumbers());



app.Run();




public class NumberWriterService
{
    private readonly IServiceProvider _serviceProvider;

    public NumberWriterService
        (IServiceProvider serviceProvider) 
        => _serviceProvider = serviceProvider;

    public void ShowTwoNumbers()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var numberService1 = 
                scope.ServiceProvider.
                GetRequiredService<IRandomNumberService>();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(numberService1.GiveNumber());
        }
        //numberService1 will be disposed here

        using (var scope = _serviceProvider.CreateScope())
        {
            var numberService2 = 
                scope.ServiceProvider.
                GetRequiredService<IRandomNumberService>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(numberService2.GiveNumber());
        }
        //numberService2 will be disposed here
    }
}
