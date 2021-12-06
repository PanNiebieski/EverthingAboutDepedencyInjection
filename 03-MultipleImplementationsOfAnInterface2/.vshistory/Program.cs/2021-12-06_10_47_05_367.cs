var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();





public interface ICustomLogger
{
    public LoggerType Write(string data);
}


public class FileLogger : ICustomLogger
{
    public LoggerType Write(string data)
    {
        return LoggerType.FileLogger;
    }
}
public class DbLogger : ICustomLogger
{
    public LoggerType Write(string data)
    {
        return LoggerType.DbLogger;
    }
}
public class EventLogger : ICustomLogger
{
    public LoggerType Write(string data)
    {
        return LoggerType.EventLogger;
    }
}

public enum LoggerType
{
    FileLogger = 0,
    DbLogger = 1,
    EventLogger = 2
}
