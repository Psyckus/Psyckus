using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace capaPresentacionValidadorPerfiles.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult categoria()
        {
            return View();
        }

        public ActionResult interes()
        {
            return View();
        }

        public ActionResult preferencia()
        {
            return View();
        }
    }
}