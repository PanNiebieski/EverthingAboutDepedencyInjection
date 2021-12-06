namespace LifeCyclesOfDepedencyInjection
{
    public class CezMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public readonly ICezSingletonService _mySingletonService;
        public MyMiddleware(RequestDelegate next, ILogger<CezMiddleware> logger,
            ICezSingletonService mySingletonService)
        {
            _logger = logger;
            _mySingletonService = mySingletonService;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context,
            ICezScopedService myScopedService, ICezTransientService myTransientService)
        {
            _logger.LogInformation("Transient: " + myTransientService.InstanceId);
            _logger.LogInformation("Scoped: " + myScopedService.InstanceId);
            _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);
            await _next(context);
        }
    }
}
