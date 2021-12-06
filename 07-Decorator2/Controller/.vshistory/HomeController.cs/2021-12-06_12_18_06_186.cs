using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace LifeCyclesOfDepedencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        private readonly IGameData _gameData;

        public HomeController(

            ILogger<HomeController> logger
            )
        {
            _logger = logger;

        }

        [HttpGet]
        public string Index()
        {

        }


    }
}