using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjyShop.UI.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult MenuList()
        {
            return View();
        }
    }
}