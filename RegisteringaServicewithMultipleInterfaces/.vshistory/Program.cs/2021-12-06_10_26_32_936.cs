var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IReset, Storage>();
builder.Services.AddSingleton<IWriteStorage, Storage>();

var app = builder.Build();


app.MapGet("/r", (IReset ser) => ser.Message());
app.MapGet("/s", (IWriteStorage ser) => ser.Message());


app.Run();







public interface IReset
{
    object Rest();
}

public interface IWriteStorage
{
    void Write(object data);
}

public class Storage : IReset, IWriteStorage
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
