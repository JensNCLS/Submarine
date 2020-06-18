﻿using System;
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
        ConvertGridModel convertGridModel = new ConvertGridModel();

        public IActionResult PlaceShipsP1()
        {
            return View();
        }
        public IActionResult PlaceShipsP2()
        {
            return View();
        }

        public IActionResult Game()
        {
            GameModel game = new GameModel();
            game.NewGame(2);
            game.SetShipsOfPlayer(game.Players[0], convertGridModel.shipList);
            game.SetShipsOfPlayer(game.Players[1], convertGridModel.shipList);
            game.StartBattle();
            return View();
        }

        [HttpPost]
        public JsonResult GridP1(IEnumerable<string> grid)
        {
            convertGridModel.ConvertGrid(grid);
            return Json(grid);
        }
        [HttpPost]
        public JsonResult GridP2(IEnumerable<string> grid)
        {
            convertGridModel.ConvertGrid(grid);
            return Json(grid);
        }
    }
}