using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
