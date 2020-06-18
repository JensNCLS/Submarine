using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Submarine.Web.Models;

namespace Submarine.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            PlayerModel model = new PlayerModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(PlayerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("PlaceShïpsP1","Game");
            }
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Quit()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
