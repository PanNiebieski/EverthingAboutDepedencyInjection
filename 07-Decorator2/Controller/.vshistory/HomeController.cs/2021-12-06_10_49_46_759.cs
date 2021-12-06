using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace MultipleImplementationsOfAnInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<ICustomLogger> _loggers;

        public HomeController(IEnumerable<ICustomLogger> loggers)
        {
            _loggers = loggers;
        }

        public string Index()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var logger in _loggers)
            {
                sb.AppendLine(logger.Write
                ("Test").ToString());
            }

            return sb.ToString();
        }


    }
}