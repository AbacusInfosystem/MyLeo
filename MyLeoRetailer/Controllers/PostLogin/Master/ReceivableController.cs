﻿using MyLeoRetailer.Common;
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

                //rRepo.Get_Credit_Note_Details_By_Id(rViewModel.Receivable.Sales_Credit_Note_Id);

                //rViewModel.Receivable = rRepo.Get_Receivable_Details_By_Id(rViewModel.Receivable.Sales_Invoice_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Pay", rViewModel);
        }

        public ActionResult Index(ReceivableViewModel rViewModel)
        {
           ReceivableRepo rRepo = new ReceivableRepo();


           rViewModel.Receivables = rRepo.Get_Receivable_Search_Details(rViewModel.Receivable);

            return View("Index", rViewModel);
        }

        public ActionResult Get_Receivable(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            rViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            string Branch_Id = rViewModel.Cookies.Branch_Ids.TrimEnd();

                rViewModel.Receivables = rRepo.Get_Receivable_Search_Details(rViewModel.Receivable);

            return Index(rViewModel);
        }

        public ActionResult Get_Receivable_Details_By_Id(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
                rViewModel.Receivables1 = rRepo.Get_Gift_Voucher_Details_By_Id();

                rViewModel.Receivable = rRepo.Get_Receivable_Details_By_Id(rViewModel.Receivable.Sales_Invoice_Id);

                rViewModel.Credit_Notes = rRepo.Get_Credit_Note_Details_By_Id(rViewModel.Receivable.Customer_Id);

                rViewModel.Receivables = rRepo.Get_Receivable_Items_By_Id(rViewModel.Receivable.Receivable_Id);

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
                rViewModel.Receivable = rRepo.Get_Gift_Voucher_Amount_By_Id(rViewModel.Receivable.Gift_Voucher_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

        public JsonResult Insert_Receivable(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();


            try
            {

                rViewModel.Receivable.Receivable_Id = rRepo.Insert_Receivable(rViewModel.Receivable);

                rViewModel.Receivable.Receivable_Item_Id = rRepo.Insert_Receivable_Item_Data(rViewModel.Receivable);

                rViewModel.Receivable = rRepo.Get_Receivable_Data_By_Id(rViewModel.Receivable.Sales_Invoice_Id);

                rViewModel.Receivables = rRepo.Get_Receivable_Items_By_Id(rViewModel.Receivable.Receivable_Id);

                rViewModel.FriendlyMessages.Add(MessageStore.Get("RECI01"));

            }

            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));


            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

        public JsonResult Update_Receivable(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();


            try
            {
                int Sales_Invoice_Id = rViewModel.Receivable.Sales_Invoice_Id;

                rRepo.Insert_Receivable(rViewModel.Receivable);

                rViewModel.Receivable.Sales_Invoice_Id = rRepo.Update_Receivable_Items_Data(rViewModel.Receivable);

                rViewModel.Receivable = rRepo.Get_Receivable_Data_By_Id(Sales_Invoice_Id);

                rViewModel.Receivables = rRepo.Get_Receivable_Items_By_Id(rViewModel.Receivable.Receivable_Id);

                rViewModel.FriendlyMessages.Add(MessageStore.Get("RECI02"));

            }

            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));


            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

       

    }
}
