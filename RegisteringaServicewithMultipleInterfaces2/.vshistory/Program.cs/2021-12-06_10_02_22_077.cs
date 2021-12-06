var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();





public interface IReadStorage
{
    object Read();
}

public interface IWriteStorage
{
    void Write(object data);
}

public class Storage : IReadStorage, IWriteStorage
{
    public object Read()
    {
        throw new NotImplementedException();
    }

    public void Write(object data)
    {
        throw new NotImplementedException();
    }
}
