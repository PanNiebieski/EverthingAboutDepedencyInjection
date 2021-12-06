var builder = WebApplication.CreateBuilder(args);

var service2 = new Service2();

builder.Services.AddSingleton(new Service());
builder.Services.AddSingleton(service2);


//builder.Services.AddSingleton<Service>();
//builder.Services.AddSingleton<Service2>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



public class Service
{

}


public class Service2
{

}