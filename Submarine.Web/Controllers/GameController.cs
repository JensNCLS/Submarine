using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Submarine.GameLogic.Models;
using Submarine.Web.Models;

namespace Submarine.Web.Controllers
{
    public class GameController : Controller
    {
        ConvertGridModel convertGridModelP1 = new ConvertGridModel();
        ConvertGridModel convertGridModelP2 = new ConvertGridModel();

        public IActionResult PlaceShipsP1()
        {
            return View();
        }
        public IActionResult PlaceShipsP2()
        {
            return View();
        }

        public IActionResult WinnerP1()
        {
            return View();
        }
        public IActionResult WinnerP2()
        {
            return View();
        }

        public IActionResult Game()
        {
            // create a game
            GameModel game = new GameModel();
            game.NewGame(2);
            game.SetShipsOfPlayer(game.Players[0], convertGridModelP1.shipList);
            game.SetShipsOfPlayer(game.Players[1], convertGridModelP2.shipList);
            game.StartBattle();
            return View();
        }

        [HttpPost]
        public JsonResult GridP1(IEnumerable<string> grid)
        {
            convertGridModelP1.ConvertGrid(grid);
            return Json(grid);
        }

        [HttpPost]
        public JsonResult GridP2(IEnumerable<string> grid)
        {
            convertGridModelP2.ConvertGrid(grid);
            return Json(grid);
        }
    }
}