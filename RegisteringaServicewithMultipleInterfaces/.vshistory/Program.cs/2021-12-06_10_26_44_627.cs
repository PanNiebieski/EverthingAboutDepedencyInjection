var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IReset, Storage>();
builder.Services.AddSingleton<IWriteNumber, Storage>();

var app = builder.Build();


app.MapGet("/r", (IReset ser) => ser.Message());
app.MapGet("/s", (IWriteNumber ser) => ser.Message());


app.Run();







public interface IReset
{
    object Rest();
}

public interface IWriteNumber
{
    void Write(object data);
}

public class Storage : IReset, IWriteNumber
{
    private 

    public object Rest()
    {
        Console.WriteLine
    }

    public void Write(object data)
    {
        throw new NotImplementedException();
    }
}
