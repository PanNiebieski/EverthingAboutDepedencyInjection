



public class CezService : 
    ICezTransientService, 
    ICezScopedService, 
    ICezSingletonService
{
    public string InstanceId { get; } = 
        Guid.NewGuid().ToString();
}