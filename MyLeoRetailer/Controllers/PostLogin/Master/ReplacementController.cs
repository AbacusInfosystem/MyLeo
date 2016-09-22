using MyLeoRetailer.Models;
using MyLeoRetailerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ReplacementController : Controller
    {
        VendorRepo vRepo = new VendorRepo();
        ReplacementRepo rRepo = new ReplacementRepo();


        #region View Actions
        public ActionResult Index(ReplacementViewModel rViewmodel)
        {
         rViewmodel.Vendors =  vRepo.Get_Vendors();
         rViewmodel.PurchaseInvoices = rRepo.Get_Purchase_Invoice();

            return View(rViewmodel);
        }

        public ActionResult Search()
        {
            return View();
        }


        public ActionResult Insert(ReplacementViewModel rViewmodel)
        {


            return RedirectToAction("Index");
        }

        #endregion

    }
}
