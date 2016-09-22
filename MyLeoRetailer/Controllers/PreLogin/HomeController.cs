using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PreLogin
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthorizationError()
        {
            return View();
        }

        public ActionResult System_Error()
        {
            return View("Error");
        }

    }
}
