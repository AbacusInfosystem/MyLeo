﻿using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper.Logging;
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
                Logger.Error("Payable Controller - Pay  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return View("Pay", pViewModel);
        }

        public ActionResult Index(PayableViewModel pViewModel)
        {
            try
            {
                PayableRepo pRepo = new PayableRepo();

                pViewModel.Payable.PurchaseInvoice_Details = pRepo.Get_PurchaseInvoice(pViewModel.Payable);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Payable Controller - Index  " + ex.Message);
            }
            //End
            return View("Index", pViewModel);
        }

        public ActionResult Get_Payable(PayableViewModel pViewModel)
        
        {
            try
            {
                PayableRepo pRepo = new PayableRepo();

                pViewModel.Payable.PurchaseInvoice_Details = pRepo.Get_PurchaseInvoice(pViewModel.Payable);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Payable Controller - Get_Payable  " + ex.Message);
            }
            //End
            return Index(pViewModel);
        }

        public ActionResult Get_Payable_Details_By_Id(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();

            try

            {
 

                pViewModel.CreditNote = pRepo.Get_Credit_Note_Details_By_Id(pViewModel.Payable.Purchase_Invoice_Id);

                pViewModel.Payable = pRepo.Get_Payable_Details_By_Id(pViewModel.Payable.Purchase_Invoice_Id);

                pViewModel.Payables = pRepo.Get_Payable_Items_By_Id(pViewModel.Payable.Payable_Id);

               
              
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Payable Controller - Get_Payable_Details_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
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
                Logger.Error("Payable Controller - Get_Credit_Note_Amount_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
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

                pViewModel.Payable = pRepo.Get_Payable_Data_By_Id(pViewModel.Payable.Purchase_Invoice_Id);

                pViewModel.Payables = pRepo.Get_Payable_Items_By_Id(pViewModel.Payable.Payable_Id);

                //pViewModel.Payable.Payable_Item_Id = pRepo.Update_Payable_Items_Data(pViewModel.Payable);

                pViewModel.FriendlyMessages.Add(MessageStore.Get("PYND01"));

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Payable Controller - Insert_Payable  " + ex.Message);//Added by vinod mane on 06/10/2016
                
            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public JsonResult Update_Payable(PayableViewModel pViewModel)
        {
            PayableRepo pRepo = new PayableRepo();


            try
            {
                int Purchase_Invoice_Id = pViewModel.Payable.Purchase_Invoice_Id;

               // pViewModel.Payable.Purchase_Invoice_Id = pRepo.Update_Payable_Items_Data(pViewModel.Payable);

                pRepo.Insert_Payable(pViewModel.Payable);

                pRepo.Update_Payable_Items_Data(pViewModel.Payable);

                pViewModel.Payable.Purchase_Invoice_Id = Purchase_Invoice_Id;

                pViewModel.Payables = pRepo.Get_Payable_Items_By_Id(pViewModel.Payable.Payable_Id);

                pViewModel.Payable = pRepo.Get_Payable_Data_By_Id(pViewModel.Payable.Purchase_Invoice_Id);

                pViewModel.FriendlyMessages.Add(MessageStore.Get("PYND02"));

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Payable Controller - Update_Payable  " + ex.Message);//Added by vinod mane on 06/10/2016

            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(pViewModel));
        }


    }
}
