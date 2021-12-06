var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
services.AddTransient<IMyTransientService, MyService>();
services.AddScoped<IMyScopedService, MyService>();
services.AddSingleton<IMySingletonService, MyService>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
