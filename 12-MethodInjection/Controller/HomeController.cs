using _12_MethodInjection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;


    public class HomeController : Controller
    {
        [HttpGet]
        public string Index([FromServices] MessageRunner messageRunner)
        {
            return messageRunner.Get();
        }
    }
