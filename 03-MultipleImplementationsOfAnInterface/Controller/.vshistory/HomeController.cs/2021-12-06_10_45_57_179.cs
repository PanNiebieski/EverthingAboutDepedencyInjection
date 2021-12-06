using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MultipleImplementationsOfAnInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLogger _logger;

        public HomeController(ICustomLogger logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            return _logger.Write("Test").ToString();
        }


    }
}