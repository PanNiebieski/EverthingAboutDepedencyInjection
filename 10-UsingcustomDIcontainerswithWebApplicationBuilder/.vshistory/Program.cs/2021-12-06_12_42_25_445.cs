using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new MyApplicationModule());
});

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();