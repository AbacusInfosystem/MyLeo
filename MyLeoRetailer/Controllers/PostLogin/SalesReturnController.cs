using MyLeoRetailer.Common;
using MyLeoRetailer.Filters;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerManager;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin
{
    public class SalesReturnController : BaseController
    {
        public SalesReturnRepo srRepo;

        public SalesReturnController()
        {
            srRepo = new SalesReturnRepo();
        }

        public ActionResult Index(SalesReturnViewModel srViewModel)
        {
            try
            {
                if (TempData["srViewModel"] != null)
                {
                    srViewModel = (SalesReturnViewModel)TempData["srViewModel"];
                }
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesReturn Controller - Index  " + ex.Message);
            }
            return View("Index", srViewModel);
        }

        public JsonResult Get_Customer_Name_By_Mobile_No(string MobileNo)
        {
            //string Customer_Name;

            SalesReturnViewModel srViewModel = new SalesReturnViewModel();
            try
            {
                srViewModel.SalesReturn = srRepo.Get_Customer_Name_By_Mobile_No(MobileNo);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesReturn Controller - Get_Customer_Name_By_Mobile_No  " + ex.Message);
            }
            return Json(srViewModel.SalesReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Sales_Return_Items_By_SKU_Code( int Sales_Invoice_Id, string SKU_Code)
        {

            SalesReturnViewModel srViewModel = new SalesReturnViewModel();
            try
            {
                srViewModel.SalesReturn = srRepo.Get_Sales_Return_Items_By_SKU_Code(Sales_Invoice_Id, SKU_Code );
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesReturn Controller - Get_Sales_Return_Items_By_SKU_Code  " + ex.Message);
            }

            return Json(srViewModel.SalesReturn, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUserAttribute(AppFunction.Sales_Return_Management_Access)]
        public ActionResult Search(SalesReturnViewModel srViewModel)
        {

            try
            {
                if (TempData["srViewModel"] != null)
                {
                    srViewModel = (SalesReturnViewModel)TempData["srViewModel"];
                }
            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesReturn Controller - Search  " + ex.Message); //Added by vinod mane on 06/10/2016
            }

            return View("Search", srViewModel);
        }

        public JsonResult Get_SalesReturn(SalesReturnViewModel srViewModel)
        {

            srViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            CommonManager cMan = new CommonManager();

            Pagination_Info pager = new Pagination_Info();

            try
            {              
                pager = srViewModel.Grid_Detail.Pager;

                srViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Return_No,Branch_Name,Total_Quantity,Gross_Amount,Total_Amount_Return_By_Cash,Total_Amount_Return_By_Credit_Note", "Sales_Return_Id,Branch_Id"); // Set grid info for front end listing

                srViewModel.Grid_Detail.Records = srRepo.Get_Sales_Return_Search_Details(srViewModel.SalesReturn, srViewModel.Cookies.Branch_Ids,srViewModel.Filter.Sales_Return_No); // Call repo method 
                
                Set_Pagination(pager, srViewModel.Grid_Detail); // set pagination for grid

                srViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                
                Logger.Error("SalesReturn Controller - Get_SalesReturn  " + ex.Message); //Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(srViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Sales_Return_Management_Create)]
        public ActionResult Insert_SalesReturn(SalesReturnViewModel srViewModel)
        {

            try
            {
                Set_Date_Session(srViewModel.SalesReturn);

                //srViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                //string[] arr = srViewModel.Cookies.Branch_Ids.Split(',');

                //string Branch_Id = srViewModel.Cookies.Branch_Ids.TrimEnd();

                //siViewModel.SalesInvoice.Branch_Id = siViewModel.Cookies.Branch_Ids;

                //for (int i = 0; i < arr.Length; i++)
                //{

                srViewModel.SalesReturn.Sales_Return_No = Utility.Generate_Ref_No("SR-", "Sales_Return_No", "4", "15", "Sales_Return");

                //srViewModel.SalesReturn.Sales_Return_Id = srRepo.Insert_SalesReturn(srViewModel.SalesReturn, srViewModel.SaleReturnItemList);

                srViewModel.SalesReturn.Sales_Return_Id = srRepo.Insert_SalesReturn(srViewModel.SalesReturn, srViewModel.SaleReturnItemList);
                //}

                srViewModel.FriendlyMessages.Add(MessageStore.Get("SR01"));
            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesReturn Controller - Insert_SalesReturn  " + ex.Message); //Added by vinod mane on 06/10/2016
            }

            TempData["srViewModel"] = (SalesReturnViewModel)srViewModel;

            return RedirectToAction("Search");
        }

        public JsonResult Check_Mobile_No(string MobileNo)
        {

            bool check = false;
            SalesReturnViewModel srViewModel = new SalesReturnViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = srRepo.Check_Mobile_No(MobileNo);
            }

            catch (Exception ex)
            {
                // throw ex;
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("SalesReturn Controller - Check_Mobile_No  " + ex.Message); //Added by vinod mane on 06/10/2016
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUserAttribute(AppFunction.Sales_Return_Management_View)]
        public ActionResult Get_Sales_Return_By_Id(SalesReturnViewModel srViewModel)
        {

            try
            {

                srViewModel.SalesReturn = srRepo.Get_Sales_Return_By_Id(srViewModel.Filter.Sales_Return_Id);

                srViewModel.SaleReturnItemList = srRepo.Get_Sales_Return_Items_By_Id(srViewModel.Filter.Sales_Return_Id);

            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesReturn Controller - Get_Sales_Return_By_Id  " + ex.Message); //Added by vinod mane on 06/10/2016
            }

            TempData["srViewModel"] = srViewModel;

            return RedirectToAction("View_Sales_Return", "SalesReturn");
        }

        public ActionResult View_Sales_Return(SalesReturnViewModel srViewModel)
        {
            try
            {
                if (TempData["srViewModel"] != null)
                {
                    srViewModel = (SalesReturnViewModel)TempData["srViewModel"];
                }
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("SalesReturn Controller - View_Sales_Return  " + ex.Message);
            }
            //End
            return View("SalesReturnView", srViewModel);
        }

        public JsonResult Check_Quantity(int Quantity, int Branch_Id, string SKU_Code)
        {

            bool check = false;

            SalesReturnViewModel srViewModel = new SalesReturnViewModel();
            try
            {
                check = srRepo.Check_Quantity(Quantity, Branch_Id, SKU_Code);
            }

            catch (Exception ex)
            {
                // throw ex;

                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("SalesReturn Controller - Check_Quantity  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

    }
}
