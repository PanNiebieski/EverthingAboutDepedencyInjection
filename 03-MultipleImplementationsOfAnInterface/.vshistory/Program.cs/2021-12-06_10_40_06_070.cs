var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



public interface ICustomLogger
{
    public bool Write(string data);
}


public class FileLogger : ICustomLogger
{
    public bool Write(string data)
    {
        throw new System.NotImplementedException();
    }
}
public class DbLogger : ICustomLogger
{
    public bool Write(string data)
    {
        throw new System.NotImplementedException();
    }
}
public class EventLogger : ICustomLogger
{
    public bool Write(string data)
    {
        throw new System.NotImplementedException();
    }
}
