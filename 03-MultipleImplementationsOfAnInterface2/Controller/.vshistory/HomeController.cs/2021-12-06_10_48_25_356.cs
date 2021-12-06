using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MultipleImplementationsOfAnInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<ICustomLogger> _logger;

        public HomeController(IEnumerable<ICustomLogger> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            foreach (var logger in loggers)
            {
                var objType = logger.GetType();
            }
        }


    }
}