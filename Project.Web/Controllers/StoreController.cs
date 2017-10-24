using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Web.Models;
using Project.Web.DAL;

namespace Project.Web.Controllers
{
    public class StoreController : Controller
    {
        private IStoreDAL dal;

        public StoreController(IStoreDAL InventoryDal)
        {
            this.dal = InventoryDal;
        }
        // GET: Store
        public ActionResult StoreGeneral()
        {
            int sort = 0;
            List<StoreModel> model = dal.GetStoreInventory(sort);
            return View("StoreGeneral", model);
        }

        public ActionResult Weapons()
        {
            int sort = 1;
            List<StoreModel> model = dal.GetStoreInventory(sort);
            return View("StoreGeneral", model);
        }

        public ActionResult Armor()
        {
            int sort = 2;
            List<StoreModel> model = dal.GetStoreInventory(sort);
            return View("StoreGeneral", model);
        }

        public ActionResult Ingredients()
        {
            int sort = 3;
            List<StoreModel> model = dal.GetStoreInventory(sort);
            return View("StoreGeneral", model);
        }

        public ActionResult MagicalItems()
        {
            int sort = 4;
            List<StoreModel> model = dal.GetStoreInventory(sort);
            return View("StoreGeneral", model);
        }

        public ActionResult Misc()
        {
            int sort = 5;
            List<StoreModel> model = dal.GetStoreInventory(sort);
            return View("StoreGeneral", model);
        }
    }
}