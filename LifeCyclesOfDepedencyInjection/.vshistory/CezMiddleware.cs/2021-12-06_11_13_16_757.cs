namespace LifeCyclesOfDepedencyInjection
{
    public class CezMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly ICezTransientService _myTransientService;
        private readonly ICezScopedService _myScopedService;
        private readonly ICezSingletonService _mySingletonService;

        public CezMiddleware(RequestDelegate next, ILogger<CezMiddleware> logger,
            ICezSingletonService mySingletonService)
        {
            _logger = logger;
            _mySingletonService = mySingletonService;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context,
            ICezScopedService myScopedService, ICezTransientService myTransientService)
        {

            _logger.LogInformation($"Transient: {_myTransientService.InstanceId}");
            _logger.LogInformation($"Scoped: {_myScopedService.InstanceId}");
            _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);
            _logger.LogInformation($"Singleton: {_mySingletonService.InstanceId}");

            await _next(context);
        }
    }
}
