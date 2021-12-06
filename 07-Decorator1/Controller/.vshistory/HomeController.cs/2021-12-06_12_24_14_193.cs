using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;


    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        private readonly IGameData _gameData;

        public HomeController(ILogger<HomeController> logger
            , IGameData gameData)
        {
            _logger = logger;
            _gameData = gameData;
        }

        [HttpGet]
        public string Index()
        {
            var count = _gameData.GetCountOfGames();


        return $"Minuta : {DateTime.Now.Minute} : Liczba Gier {count}";
        }


    }
