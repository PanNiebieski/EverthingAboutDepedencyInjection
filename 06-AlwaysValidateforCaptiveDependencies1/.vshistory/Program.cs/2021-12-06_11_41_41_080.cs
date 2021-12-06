var builder = WebApplication.CreateBuilder(args);
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
