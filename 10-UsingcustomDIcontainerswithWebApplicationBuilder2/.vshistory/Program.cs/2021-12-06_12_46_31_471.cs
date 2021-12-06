var builder = WebApplication.CreateBuilder(args);

builder.Host

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
