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
    public void Reset()
    {
        throw new NotImplementedException();
    }

    public string Write()
    {
        throw new NotImplementedException();
    }
}
