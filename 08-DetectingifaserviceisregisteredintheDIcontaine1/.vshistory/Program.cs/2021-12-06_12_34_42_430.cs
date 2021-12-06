var collection = new ServiceCollection();
collection.AddTransient<IGreeterService, GreeterService>();
IServiceProvider provider = collection.Build();

// try and get the new interface. 
// This will return null if the feature isn't yet supported by the container
var serviceProviderIsService = provider.GetService<IServiceProviderIsService>();

// The IGreeterService is registered in the DI container
Assert.True(serviceProviderIsService.IsService(typeof(IGreeterService)));
// The GreeterService is NOT registered directly in the DI container.
Assert.False(serviceProviderIsService.IsService(typeof(GreeterService)));