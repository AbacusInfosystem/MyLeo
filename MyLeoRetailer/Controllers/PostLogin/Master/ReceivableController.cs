using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ReceivableController : BaseController
    {
        //
        // GET: /Receivable/

        public ActionResult Pay()
        {
            return View();
        }

        public ActionResult Index(ReceivableViewModel rViewModel)
        {
            return View("Index", rViewModel);
        }

        public ActionResult Get_Receivable(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
                rViewModel.Receivables = rRepo.Get_Receivable_Search_Details(rViewModel.Receivable);


            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return Index(rViewModel);
        }

    }
}
