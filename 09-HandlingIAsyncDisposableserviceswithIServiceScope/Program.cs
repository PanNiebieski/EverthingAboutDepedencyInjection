var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<Foo>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


await using (var scope = app.Services.CreateAsyncScope())
{
    var foo = scope.ServiceProvider.GetRequiredService<Foo>();
} // doesn't throw if container supports DisposeAsync()s


app.Run();


class Foo : IAsyncDisposable
{
    public ValueTask DisposeAsync() => default;
}
