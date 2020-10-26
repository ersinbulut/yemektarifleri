using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YemekTarifleri.Controllers
{
    public class TarifsController : Controller
    {
        // GET: Tarifs
        public ActionResult TarifOner()
        {
            return View();
        }
    }
}