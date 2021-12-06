var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<NumberStorage>();

builder.Services.AddSingleton<IReset>
    (x => x.GetRequiredService<NumberStorage>());
builder.Services.AddSingleton<IWriteNumber>
    (x => x.GetRequiredService<NumberStorage>());


var app = builder.Build();

app.MapGet("/r", (IReset ser) => ser.Reset());
app.MapGet("/s", (IWriteNumber ser) => ser.Write());


app.Run();





public interface IReset
{
    string Reset();
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

    public string Reset()
    {
        string m = $"You reset {_random}";
        Console.WriteLine(m);
        _random = new Random().Next(1, 100000);
        return $"{m}, New number {_random}";
    }

    public string Write()
    {
        Console.WriteLine($"You write {_random}");
        return $"You write {_random}";
    }
}
