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
            ICezTransientService myTransientService,
            ICezScopedService myScopedService,
            ICezSingletonService mySingletonService)
        {
            _logger = logger;
            _mySingletonService = mySingletonService;
            _myScopedService = myScopedService;
            _myTransientService= myTransientService;

            _next = next;
        }
        public async Task InvokeAsync(HttpContext context,
            ICezScopedService myScopedService, ICezTransientService myTransientService)
        {

            _logger.LogInformation($"In CezMiddleware Transient: {_myTransientService.InstanceId}");
            _logger.LogInformation($"In CezMiddleware Scoped: {_myScopedService.InstanceId}");
            _logger.LogInformation($"In CezMiddleware Singleton: {_mySingletonService.InstanceId}");

            await _next(context);
        }
    }
}
