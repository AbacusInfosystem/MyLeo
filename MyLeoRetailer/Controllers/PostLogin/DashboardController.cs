using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            try
            {

            }
            catch (Exception ex)
            {
               
            }

            return View("Index");
        }

    }
}
