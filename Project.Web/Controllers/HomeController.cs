using Project.Web.DAL;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPlayerDAL dal;

        public HomeController(IPlayerDAL PlayerDal)
        {
            this.dal = PlayerDal;
        }
        // GET: Home
        public ActionResult Home()
        {
            PlayerModel model = new PlayerModel();
            return View("Home", model);
        }

        public ActionResult CreatePlayer()
        {
            return View("CreatePlayer");
        }

        [HttpPost]
        public ActionResult CreatePlayer(PlayerModel player)
        {
            PlayerModel model = player;
            string name = dal.CreateNewPlayer(model);
            return RedirectToAction("PlayerHome", name);
        }

        public ActionResult PlayerHome(string name)
        {
            PlayerModel model = dal.GetPlayer(name);
            return View("PlayerHome", model);
        }
    }
}