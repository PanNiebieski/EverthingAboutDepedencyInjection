var builder = WebApplication.CreateBuilder(args);

//builder.Services.BuildServiceProvider(new ServiceProviderOptions
//{
//    ValidateScopes = true
//});

try
{
    builder.Services.AddSingleton<UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

}
catch (Exception ex)
{

    Console.WriteLine(ex);
}


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
