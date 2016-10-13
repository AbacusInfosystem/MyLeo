using MyLeoRetailer.Common;
using MyLeoRetailer.Filters;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
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

        public ReceivableRepo rRepo;

        public ReceivableController()
        {
            rRepo = new ReceivableRepo();

        }

        public ActionResult Pay(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            try
            {
                //if (TempData["rViewModel"] != null)
                //{
                //    rViewModel = (ReceivableViewModel)TempData["rViewModel"];
                //}

                //rRepo.Get_Credit_Note_Details_By_Id(rViewModel.Receivable.Sales_Credit_Note_Id);

                //rViewModel.Receivable = rRepo.Get_Receivable_Details_By_Id(rViewModel.Receivable.Sales_Invoice_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Receivable Controller - Pay  " + ex.Message);  //Added by vinod mane on 06/10/2016
            }

            return View("Pay", rViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Receivable_Management_Access)]
        public ActionResult Index(ReceivableViewModel rViewModel)
        {
            try
            {
                ReceivableRepo rRepo = new ReceivableRepo();
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Receivable Controller - Index  " + ex.Message);
            }
            //End

            return View("Index", rViewModel);
        }

        public JsonResult Get_Receivable(ReceivableViewModel rViewModel)
        {
            try
            {

            ReceivableRepo _rRepo = new ReceivableRepo();

            rViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            Pagination_Info pager = new Pagination_Info();

            pager = rViewModel.Grid_Detail.Pager;

            rViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Invoice_No,Created_Date,Customer_Name,Customer_Mobile1,Net_Amount,status", "Sales_Invoice_Id,Customer_Id,Branch_Id"); // Set grid info for front end listing

            rViewModel.Grid_Detail.Records = rRepo.Get_Receivable_Search_Details(rViewModel.Receivable, rViewModel.Cookies.Branch_Ids); // Call repo method 

            Set_Pagination(pager, rViewModel.Grid_Detail); // set pagination for grid

            rViewModel.Grid_Detail.Pager = pager;
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Receivable Controller - Get_Receivable  " + ex.Message);
            }
            //End

            return Json(JsonConvert.SerializeObject(rViewModel));

        }

        [AuthorizeUserAttribute(AppFunction.Receivable_Management_View)]
        public ActionResult Get_Receivable_Details_By_Id(ReceivableViewModel rViewModel)
        {

            try
            {
                rViewModel.Receivables1 = rRepo.Get_Gift_Voucher_Details_By_Id();

                rViewModel.Receivable = rRepo.Get_Receivable_Details_By_Id(rViewModel.Receivable.Sales_Invoice_Id);

                rViewModel.Credit_Notes = rRepo.Get_Credit_Note_Details_By_Id(rViewModel.Receivable.Customer_Id, rViewModel.Receivable.Receivable_Id);

                rViewModel.Receivables = rRepo.Get_Receivable_Items_By_Id(rViewModel.Receivable.Receivable_Id);

            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Receivable Controller - Get_Receivable_Details_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }


            return View("Pay", rViewModel);
        }

        public JsonResult Get_Credit_Note_Amount_By_Id(ReceivableViewModel rViewModel)
        {

            try
            {
                rViewModel.Receivable = rRepo.Get_Credit_Note_Amount_By_Id(rViewModel.Receivable.Sales_Credit_Note_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Receivable Controller - Get_Credit_Note_Amount_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

        public JsonResult Get_Gift_Voucher_Amount_By_Id(ReceivableViewModel rViewModel)
        {
           

            try
            {
                rViewModel.Receivable = rRepo.Get_Gift_Voucher_Amount_By_Id(rViewModel.Receivable.Gift_Voucher_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Receivable Controller - Get_Gift_Voucher_Amount_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Receivable_Management_Create)]
        public JsonResult Insert_Receivable(ReceivableViewModel rViewModel)
        {
            //Set_Date_Session(rViewModel.GiftVoucher);

            rViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            rViewModel.Receivable.Created_By = rViewModel.Cookies.User_Id;

            rViewModel.Receivable.Created_On = DateTime.Now;

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
                Logger.Error("Receivable Controller - Insert_Receivable  " + ex.Message);//Added by vinod mane on 06/10/2016

            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Receivable_Management_Edit)]
        public JsonResult Update_Receivable(ReceivableViewModel rViewModel)
        {

            rViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            rViewModel.Receivable.Updated_By = rViewModel.Cookies.User_Id;

            rViewModel.Receivable.Updated_On = DateTime.Now;

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
                Logger.Error("Receivable Controller - Update_Receivable  " + ex.Message);//Added by vinod mane on 06/10/2016

            }

            //TempData["pViewModel"] = pViewModel;

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

       

    }
}
