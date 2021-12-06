using LifeCyclesOfDepedencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<ICezTransientService, CezService>();
builder.Services.AddScoped<ICezScopedService, CezService>();
builder.Services.AddSingleton<ICezSingletonService, CezService>();

//builder.Services.AddSingleton<ICezSubLayer, CezSubLayer>();
builder.Services.AddScoped<ICezSubLayer, CezSubLayer>();
//builder.Services.AddTransient<ICezSubLayer, CezSubLayer>();


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseCezMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
