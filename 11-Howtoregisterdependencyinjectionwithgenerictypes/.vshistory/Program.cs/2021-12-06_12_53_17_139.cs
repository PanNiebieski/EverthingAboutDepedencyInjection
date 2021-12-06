var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");




app.Run();
