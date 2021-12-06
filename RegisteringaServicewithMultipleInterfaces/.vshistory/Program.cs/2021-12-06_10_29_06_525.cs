var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IReset, NumberStorage>();
builder.Services.AddSingleton<IWriteNumber, NumberStorage>();

var app = builder.Build();


app.MapGet("/r", (IReset ser) => ser.Message());
app.MapGet("/s", (IWriteNumber ser) => ser.Message());


app.Run();







public interface IReset
{
    void Reset();
}

public interface IWriteNumber
{
    string Write();
}

public class NumberStorage : IReset, IWriteNumber
{
    private int _random;

    public NumberStorage()
    {
        _random = new Random()
            .Next(1, 100000);
    }

    public void Reset()
    {
        Console.WriteLine($"You reset {_random}");
        _random = new Random().Next(1, 100000);
    }

    public string Write()
    {
        Console.WriteLine($"You write {_random}");
    }
}
