var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<ICezTransientService, CezService>();
builder.Services.AddScoped<ICezScopedService, CezService>();
builder.Services.AddSingleton<ICezSingletonService, CezService>();
builder.Services.AddSingleton<ICezSingletonService, CezService>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
