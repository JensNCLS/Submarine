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
            return View();
        }

        public IActionResult Lobby()
        {
            return View();
        }

        public IActionResult JoinLobby()
        {
            LobbyModel model = new LobbyModel();
            return View(model);
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
                return RedirectToAction("Lobby");
            }
        }
    }
}