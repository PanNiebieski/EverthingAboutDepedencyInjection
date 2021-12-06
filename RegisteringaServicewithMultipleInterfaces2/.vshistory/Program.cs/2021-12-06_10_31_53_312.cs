var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Storage>();

builder.Services.AddSingleton<IReadStorage>
    (x => x.GetRequiredService<Storage>());
builder.Services.AddSingleton<IWriteStorage>
    (x => x.GetRequiredService<Storage>());


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

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
