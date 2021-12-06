using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace LifeCyclesOfDepedencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICezTransientService _myTransientService;
        private readonly ICezScopedService _myScopedService;
        private readonly ICezSingletonService _mySingletonService;
        private readonly ICezSubLayer _cezSubLayer;

        public HomeController(
            ICezTransientService myTransientService,
            ICezScopedService myScopedService,
            ICezSingletonService mySingletonService,
            ICezSubLayer cezSubLayer,
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

            _cezSubLayer = cezSubLayer ??
                throw new ArgumentNullException(nameof(cezSubLayer));
        }

        [HttpGet]
        public string Index()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"HomeController Transient: {_myTransientService.InstanceId}");
            _logger.LogInformation($"Transient: {_myTransientService.InstanceId}");

            sb.AppendLine($"HomeController Scoped: {_myScopedService.InstanceId}");
            _logger.LogInformation($"Scoped: {_myScopedService.InstanceId}");

            _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);


            sb.AppendLine($"HomeController Singleton: {_mySingletonService.InstanceId}");
            _logger.LogInformation($"Singleton: {_mySingletonService.InstanceId}");

            sb.AppendLine("");
            sb.AppendLine(_cezSubLayer.Get());

            return sb.ToString();
        }


    }
}