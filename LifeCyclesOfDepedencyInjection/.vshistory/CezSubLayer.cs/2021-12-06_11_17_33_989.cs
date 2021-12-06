using System.Text;

namespace LifeCyclesOfDepedencyInjection
{
    public class CezSubLayer : ICezSubLayer
    {
        private readonly ILogger _logger;
        private readonly ICezTransientService _myTransientService;
        private readonly ICezScopedService _myScopedService;
        private readonly ICezSingletonService _mySingletonService;

        public CezSubLayer(
                ICezTransientService myTransientService,
                ICezScopedService myScopedService,
                ICezSingletonService mySingletonService,
                ILogger<HomeController> logger
            )
        {
            _logger = logger;

            _myTransientService = myTransientService ??
                throw new ArgumentNullException(nameof(myTransientService));

            _myScopedService = myScopedService ??
                throw new ArgumentNullException(nameof(myScopedService));

            _mySingletonService = mySingletonService ??
                throw new ArgumentNullException(nameof(mySingletonService));
        }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"In CezSubLayer Transient: {_myTransientService.InstanceId}");
            _logger.LogInformation($"In CezSubLayer Transient: {_myTransientService.InstanceId}");

            sb.AppendLine($"In CezSubLayer  Scoped: {_myScopedService.InstanceId}");
            _logger.LogInformation($"In CezSubLayer  Scoped: {_myScopedService.InstanceId}");

            _logger.LogInformation("In CezSubLayer  Singleton: " + _mySingletonService.InstanceId);


            sb.AppendLine($"In CezSubLayer  Singleton: {_mySingletonService.InstanceId}");
            _logger.LogInformation($"In CezSubLayer  Singleton: {_mySingletonService.InstanceId}");

            return sb.ToString();
        }
    }
}