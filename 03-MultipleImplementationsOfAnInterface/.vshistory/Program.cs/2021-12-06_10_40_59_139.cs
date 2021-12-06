var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomLogger, FileLogger>();
builder.Services.AddScoped<ICustomLogger, DbLogger>();
builder.Services.AddScoped<ICustomLogger, EventLogger>();


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
        return true;
    }
}
public class DbLogger : ICustomLogger
{
    public bool Write(string data)
    {
        return true;
    }
}
public class EventLogger : ICustomLogger
{
    public bool Write(string data)
    {
        return true;
    }
}
