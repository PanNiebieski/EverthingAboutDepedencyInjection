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
        public IActionResult Get()
        {
            _logger.LogInformation("Transient: " + _myTransientService.InstanceId);
            _logger.LogInformation("Scoped: " + _myScopedService.InstanceId);
            _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);

            return Ok();
        }


    }


    public class CezRepository
    {
        public readonly ILogger _logger;
        public readonly ICezTransientService _myTransientService;
        public readonly ICezScopedService _myScopedService;
        public readonly ICezSingletonService _mySingletonService;

        public CezRepository(
                ICezTransientService myTransientService,
                ICezScopedService myScopedService,
                ICezSingletonService mySingletonService,
                ILogger<HomeController> logger
            )
        {
        }

        public string 


    }

    public interface ICezRepository
    {

    }
}