using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerInfo;
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
            }

            return View("Pay", rViewModel);
        }

        public ActionResult Index()
        {

            ReceivableViewModel rViewModel = new ReceivableViewModel();
          // ReceivableRepo rRepo = new ReceivableRepo();


           //rViewModel.Grid_Detail.Records = rRepo.Get_Receivable_Search_Details(rViewModel.Receivable, rViewModel.Cookies.Branch_Ids);

            return View("Index", rViewModel);
        }

        public JsonResult Get_Receivable(ReceivableViewModel rViewModel)
        {
            ReceivableRepo rRepo = new ReceivableRepo();

            rViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            Pagination_Info pager = new Pagination_Info();

            pager = rViewModel.Grid_Detail.Pager;

            rViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Invoice_No,Created_Date,Customer_Name,Customer_Mobile1,Net_Amount,Balance_Amount,Payment_Status", "Sales_Invoice_Id,Customer_Id,Branch_Id"); // Set grid info for front end listing

            rViewModel.Grid_Detail.Records = rRepo.Get_Receivable_Search_Details(rViewModel.Receivable, rViewModel.Cookies.Branch_Ids); // Call repo method 

            Set_Pagination(pager, rViewModel.Grid_Detail); // set pagination for grid

            rViewModel.Grid_Detail.Pager = pager;

            return Json(JsonConvert.SerializeObject(rViewModel));

        }

        public JsonResult Get_Receivable_Details_By_Id(ReceivableViewModel rViewModel)
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

            //TempData["rViewModel"] = (ReceivableViewModel)rViewModel;

            return Json(JsonConvert.SerializeObject(rViewModel));
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
