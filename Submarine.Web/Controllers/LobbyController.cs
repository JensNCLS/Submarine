using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Submarine.Web.Models;

namespace Submarine.Web.Controllers
{
    public class LobbyController : Controller
    {
        public IActionResult LobbyHost()
        {
            LobbyModel model = new LobbyModel();
            return View(model);
        }

        public IActionResult Lobby(LobbyModel model)
        {
            return View(model);
        }

        public IActionResult JoinLobby()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JoinLobby(LobbyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Lobby", model); 
            }
        }
    }
}