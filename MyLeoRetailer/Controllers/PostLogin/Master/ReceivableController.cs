using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
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

        public ActionResult Pay(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
                if (TempData["rViewModel"] != null)
                {
                    rViewModel = (ReceivableViewModel)TempData["rViewModel"];
                }

                rRepo.Get_Credit_Note_Details_By_Id(rViewModel.Receivable.Sales_Credit_Note_Id);

                rViewModel.Receivable = rRepo.Get_Receivable_Details_By_Id(rViewModel.Receivable.Sales_Invoice_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Pay", rViewModel);
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

        public ActionResult Get_Receivable_Details_By_Id(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
               rViewModel.Receivables = rRepo.Get_Credit_Note_Details_By_Id(rViewModel.Receivable.Sales_Credit_Note_Id);

                rViewModel.Receivables = rRepo.Get_Gift_Voucher_Details_By_Id();

                rViewModel.Receivable = rRepo.Get_Receivable_Details_By_Id(rViewModel.Receivable.Sales_Invoice_Id);


            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            TempData["rViewModel"] = (ReceivableViewModel)rViewModel;

            return RedirectToAction("Pay", rViewModel);
        }

        public JsonResult Get_Credit_Note_Amount_By_Id(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
                rViewModel.Receivable = rRepo.Get_Credit_Note_Amount_By_Id(rViewModel.Receivable.Sales_Credit_Note_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

        public JsonResult Get_Gift_Voucher_Amount_By_Id(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
                rViewModel.Receivable = rRepo.Get_Gift_Voucher_Amount_By_Id(rViewModel.Receivable.Gift_Voucher_No);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }



    }
}
