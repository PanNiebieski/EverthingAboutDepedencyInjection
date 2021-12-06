using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

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
            StringBuilder sb = new StringBuilder();

            foreach (var logger in loggers)
            {
                sb.AppendLine(logger.W)
            }
        }


    }
}