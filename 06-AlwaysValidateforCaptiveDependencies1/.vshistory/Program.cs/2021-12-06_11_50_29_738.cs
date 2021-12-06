var builder = WebApplication.CreateBuilder(args);

//builder.Services.BuildServiceProvider(new ServiceProviderOptions
//{
//    ValidateScopes = true
//});


builder.Services.AddSingleton<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run();



public class UserService
{
    public UserService(IUserRepository userRepository)
    {
    }
}
public class UserRepository : IUserRepository
{
}
