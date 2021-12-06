var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<ICustomLogger, FileLogger>();
builder.Services.AddScoped<ICustomLogger, DbLogger>();
builder.Services.AddScoped<ICustomLogger, EventLogger>();


var app = builder.Build();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


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
