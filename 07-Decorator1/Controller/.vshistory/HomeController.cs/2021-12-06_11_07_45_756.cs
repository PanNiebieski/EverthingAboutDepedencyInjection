using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace MultipleImplementationsOfAnInterface.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger _logger;
        public readonly ICezTransientService _myTransientService;
        public readonly ICezScopedService _myScopedService;
        public readonly ICezSingletonService _mySingletonService;
        public HomeController(
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
        [HttpGet]
        public string Index()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Transient: {_myTransientService.InstanceId}");
            _logger.LogInformation($"Transient: {_myTransientService.InstanceId}");

            sb.AppendLine($"Scoped: {_myScopedService.InstanceId}");
            _logger.LogInformation($"Scoped: {_myScopedService.InstanceId}");

            _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);


            sb.AppendLine($"Singleton: {_mySingletonService.InstanceId}");
            _logger.LogInformation($"Singleton: {_mySingletonService.InstanceId}");

            return sb.ToString();
        }


    }


    public class CezSubLayer : ICezSubLayer
    {
        public readonly ILogger _logger;
        public readonly ICezTransientService _myTransientService;
        public readonly ICezScopedService _myScopedService;
        public readonly ICezSingletonService _mySingletonService;

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
            _logger.LogInformation($ "In CezSubLayer Transient: {_myTransientService.InstanceId}");

            sb.AppendLine($"In CezSubLayer  Scoped: {_myScopedService.InstanceId}");
            _logger.LogInformation($"In CezSubLayer  Scoped: {_myScopedService.InstanceId}");

            _logger.LogInformation("In CezSubLayer  Singleton: " + _mySingletonService.InstanceId);


            sb.AppendLine($"In CezSubLayer  Singleton: {_mySingletonService.InstanceId}");
            _logger.LogInformation($"In CezSubLayer  Singleton: {_mySingletonService.InstanceId}");

            return sb.ToString();
        }
    }

    public interface ICezSubLayer
    {
        string Get();
    }
}