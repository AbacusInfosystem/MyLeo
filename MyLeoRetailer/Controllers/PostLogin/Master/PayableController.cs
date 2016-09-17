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
    public class PayableController : BaseController
    {

        public PayableController()
        {
            
        }

        public ActionResult Pay(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();

            try
            {
                if (TempData["pViewModel"] != null)
                {
                    pViewModel = (PayableViewModel)TempData["pViewModel"];
                }

                 pViewModel.Payable = pRepo.Get_Payable_Details_By_Id(pViewModel.Payable.Purchase_Invoice_Id);

                 pRepo.Get_Credit_Note_Details_By_Id(pViewModel.Payable.Purchase_Credit_Note_Id);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Pay", pViewModel);
        }

        public ActionResult Index(PayableViewModel pViewModel)
        {
            return View("Index", pViewModel);
        }

        public ActionResult Get_Payable(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();

            try
            {
                pViewModel.Payable.PurchaseInvoice_Details = pRepo.Get_PurchaseInvoice_Details(pViewModel.Payable);

                
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return Index(pViewModel);
        }

        public ActionResult Get_Payable_Details_By_Id(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();

            try
            {
                pViewModel.Payables = pRepo.Get_Credit_Note_Details_By_Id(pViewModel.Payable.Purchase_Credit_Note_Id);

                pViewModel.Payable = pRepo.Get_Payable_Details_By_Id(pViewModel.Payable.Purchase_Invoice_Id);

                
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            TempData["pViewModel"] = (PayableViewModel)pViewModel;

            return RedirectToAction("Pay", pViewModel);
        }

        public JsonResult Get_Credit_Note_Amount_By_Id(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();

            try
            {
                pViewModel.Payable = pRepo.Get_Credit_Note_Amount_By_Id(pViewModel.Payable.Purchase_Credit_Note_Id);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public JsonResult Insert_Payable(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();


            try
            {

                pViewModel.Payable.Payable_Id = pRepo.Insert_Payable(pViewModel.Payable);

                pViewModel.Payable.Payable_Item_Id = pRepo.Insert_Payable_Item_Data(pViewModel.Payable);

                pViewModel.Payables = pRepo.Get_Payable_Items_By_Id(pViewModel.Payable.Payable_Id, pViewModel.Payable.Payable_Item_Id);

                pViewModel.Payable = pRepo.Get_Payable_Data_By_Id(pViewModel.Payable.Purchase_Invoice_Id);


                pViewModel.FriendlyMessages.Add(MessageStore.Get("PA001"));

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                
            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(pViewModel));
        }


    }
}
