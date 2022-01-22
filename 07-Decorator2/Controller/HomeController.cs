using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;


    public class HomeController : Controller
    {
        private readonly IGameData _gameData;
        public HomeController(IGameData gameData)
        {
            _gameData = gameData;
        }

        [HttpGet]
        public string Index()
        {
            var count = _gameData.GetCountOfGames();
            return $"Minute : {DateTime.Now.Minute} " +
            $": Number of Games {count}";
        }
    }
