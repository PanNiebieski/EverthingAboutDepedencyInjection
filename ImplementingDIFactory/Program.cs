var builder = WebApplication.CreateBuilder(args);

bool featureEnabled = false; 

if (featureEnabled)
{
    builder.Services.AddScoped
        <IImplementation, NewImplementation>();
}
else
{
    builder.Services.AddScoped
        <IImplementation, OldImplementation>();
}



var app = builder.Build();

app.MapGet("/", 
    (IImplementation ser) => ser.Message());

app.Run();



public interface IImplementation
{
    string Message();
}
public class NewImplementation : IImplementation
{
    public string Message()
    {
        Console.WriteLine("NewImplementation");
        return "NewImplementation";
    }
}
public class OldImplementation : IImplementation
{
    public string Message()
    {
        Console.WriteLine("OldImplementation");
        return "OldImplementation";
    }
}
