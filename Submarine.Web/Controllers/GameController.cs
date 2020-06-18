using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Submarine.Web.Models;

namespace Submarine.Web.Controllers
{
    public class GameController : Controller
    {
        ConvertGridModel convertGridModel = new ConvertGridModel();

        public IActionResult PlaceShips()
        {
            return View();
        }

        public IActionResult Game()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult Grid(IEnumerable<string> grid)
        {
            convertGridModel.ConvertGrid(grid);
            return Json(grid);
        }
    }
}