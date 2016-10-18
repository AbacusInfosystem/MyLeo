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
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin
{
    public class SalesOrderController : BaseController
    {

        public SalesOrderRepo siRepo;

        public ReceivableRepo rRepo;

        public SalesOrderController()
        {
            siRepo = new SalesOrderRepo();

            rRepo = new ReceivableRepo();
        }

        public ActionResult Index(SalesInvoiceViewModel siViewModel)
        {
            try
            {
                if (TempData["siViewModel"] != null)
                {
                    siViewModel = (SalesInvoiceViewModel)TempData["siViewModel"];
                }
                siViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                siViewModel.SalesInvoice.Branch_IDS = siViewModel.Cookies.Branch_Ids.TrimEnd();

                siViewModel.GiftVoucherDetails = siRepo.Get_Gift_Voucher_Details_By_Id(); //Added by vinod mane on 10/10/2016
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Index  " + ex.Message);
            }
            //end


            return View("Index", siViewModel);
        }

        public JsonResult Get_Customer_Name_By_Mobile_No(string MobileNo)
        {
            //string Customer_Name;

            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();
            try
            {
                siViewModel.SalesInvoice = siRepo.Get_Customer_Name_By_Mobile_No(MobileNo);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_Customer_Name_By_Mobile_No  " + ex.Message);
            }
            //end
            return Json(siViewModel.SalesInvoice, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Sales_Order_Items_By_SKU_Code(string SKU_Code)
        {

            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();
            try
            {
                siViewModel.SalesInvoice = siRepo.Get_Sales_Order_Items_By_SKU_Code(SKU_Code);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_Sales_Order_Items_By_SKU_Code  " + ex.Message);
            }
            //end
            return Json(siViewModel.SalesInvoice, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Get_Credit_Note_Details_By_Id_abc(int cust_Id)
        {
            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();
            try
            {
                siViewModel.CreditNote = siRepo.Get_Credit_Note_Data_By_Id(cust_Id);
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_Credit_Note_Details_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(siViewModel.CreditNote, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Gift_Voucher_Details()
        {
            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();

            try
            {
                siViewModel.ReceivableItem = siRepo.Get_Gift_Voucher_Details();
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_Gift_Voucher_Details  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(siViewModel.ReceivableItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Credit_Note_Amount_By_Id(SalesInvoiceViewModel siViewModel)
        {

            try
            {
                siViewModel.CreditNote = siRepo.Get_Credit_Note_Amount_By_Id(siViewModel.SalesInvoice.Sales_Credit_Note_Id);
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_Credit_Note_Amount_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(siViewModel.CreditNote, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Gift_Voucher_Amount_By_Id(SalesInvoiceViewModel siViewModel)
        {

            try
            {
                siViewModel.SalesInvoice = siRepo.Get_Gift_Voucher_Amount_By_Id(siViewModel.SalesInvoice.Gift_Voucher_Id);
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_Gift_Voucher_Amount_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016

            }

            return Json(JsonConvert.SerializeObject(siViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Sales_Order_Management_Access)]
        public ActionResult Search(SalesInvoiceViewModel siViewModel)
        {

            try
            {
                if (TempData["siViewModel"] != null)
                {
                    siViewModel = (SalesInvoiceViewModel)TempData["siViewModel"];
                }
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Search  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return View("Search", siViewModel);
        }

        public JsonResult Get_SalesOrder(SalesInvoiceViewModel siViewModel)
        {

            siViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            CommonManager cMan = new CommonManager();

            Pagination_Info pager = new Pagination_Info();

            try
            {

                pager = siViewModel.Grid_Detail.Pager;

                siViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Invoice_No,Branch_Name,Total_Quantity,Total_MRP_Amount,Total_Discount_Amount,Gross_Amount,Tax_Percentage,Net_Amount", "Sales_Invoice_Id,Branch_Id"); // Set grid info for front end listing

                siViewModel.Grid_Detail.Records = siRepo.Get_Sales_Order_Search_Details(siViewModel.SalesInvoice, siViewModel.Cookies.Branch_Ids, siViewModel.Filter.Sales_Invoice_No); // Call repo method 

                Set_Pagination(pager, siViewModel.Grid_Detail); // set pagination for grid

                siViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("SalesOrder Controller - Get_SalesOrder  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(siViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Sales_Order_Management_Create)]
        public ActionResult Insert_SalesOrder(SalesInvoiceViewModel siViewModel)
        {
            //string arr [] ;

            try
            {
                Set_Date_Session(siViewModel.SalesInvoice);

                //siViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                //string[] arr  = siViewModel.Cookies.Branch_Ids.Split(',');  Multiple Branches Refer to the Commented Code

                //string Branch_Id = siViewModel.Cookies.Branch_Ids.TrimEnd();

                //siViewModel.SalesInvoice.Branch_Id = siViewModel.Cookies.Branch_Ids;

                //for (int i = 0; i < arr.Length; i++)
                //{
                //Set_Date_Session(siViewModel.SalesInvoice);

                siViewModel.SalesInvoice.Sales_Invoice_No = Utility.Generate_Ref_No("SI-", "Sales_Invoice_No", "4", "15", "Sales_Invoice");

                siViewModel.SalesInvoice.Sales_Invoice_Id = siRepo.Insert_SalesOrder(siViewModel.SalesInvoice, siViewModel.SaleOrderItemList, siViewModel.ReceivableItem);   //arr[i] instead of Branch_Id

                //}

                siViewModel.FriendlyMessages.Add(MessageStore.Get("SI01"));
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Insert_SalesOrder  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            TempData["siViewModel"] = (SalesInvoiceViewModel)siViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Invoice(SalesInvoiceViewModel siViewModel)
        {

            siViewModel.SalesInvoice.Logo_Path = ConfigurationManager.AppSettings["LogoPath"].ToString();

            return View("Invoice", siViewModel);
        }

        public ActionResult View_Sales_Invoice(SalesInvoiceViewModel siViewModel)
        {
            try
            {
                if (TempData["siViewModel"] != null)
                {
                    siViewModel = (SalesInvoiceViewModel)TempData["siViewModel"];
                }
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - View_Sales_Invoice  " + ex.Message);//Added by vinod mane on 06/10/2016
            }
            return View("SalesInvoiceView", siViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Sales_Order_Management_View)]
        public ActionResult Get_SalesOrder_By_Id(SalesInvoiceViewModel siViewModel)
        {
            bool CheckFlag = false;


            try
            {
                CheckFlag = siViewModel.SalesInvoice.Flag;


                siViewModel.SalesInvoice = siRepo.Get_SalesOrder_By_Id(siViewModel.Filter.Sales_Invoice_Id);
                siViewModel.SaleOrderItemList = siRepo.Get_SalesOrder_Items_By_Id(siViewModel.Filter.Sales_Invoice_Id);


            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Get_SalesOrder_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            if (CheckFlag == true)
            {
                return Invoice(siViewModel);
            }
            else
            {

                TempData["siViewModel"] = siViewModel;

                return RedirectToAction("View_Sales_Invoice", "SalesOrder");
            }

        }

        public JsonResult Check_Mobile_No(string MobileNo)
        {

            bool check = false;
            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();
            try
            {
                check = siRepo.Check_Mobile_No(MobileNo);
            }

            catch (Exception ex)
            {
                // throw ex;
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Check_Mobile_No  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Quantity(int Quantity, int Branch_Id, string SKU_Code)
        {

            bool check = false;

            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();
            try
            {
                check = siRepo.Check_Quantity(Quantity, Branch_Id, SKU_Code);
            }

            catch (Exception ex)
            {
                // throw ex;

                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("SalesOrder Controller - Check_Mobile_No  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //Added by vinod mane on 29/09/2016
        public ActionResult Report(SalesInvoiceViewModel siViewModel)
        {

            try
            {
                if (TempData["siViewModel"] != null)
                {
                    siViewModel = (SalesInvoiceViewModel)TempData["siViewModel"];
                }
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("SalesOrder Controller - Report  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return View("Search1", siViewModel);
        }
        //End

        public JsonResult Get_Sales_Report(SalesInvoiceViewModel siViewModel)
        {
            try
            {
                Pagination_Info pager = new Pagination_Info();

                pager = siViewModel.Grid_Detail.Pager;

                siViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Invoice_No,Total_Quantity,Total_MRP_Amount,Total_Discount_Amount,Gross_Amount,Tax_Percentage,Net_Amount", "Sales_Invoice_Id"); // Set grid info for front end listing

                siViewModel.Grid_Detail.Records = siRepo.Get_Sales_Report(siViewModel.Filter); // Call repo method 

                Set_Pagination(pager, siViewModel.Grid_Detail); // set pagination for grid

                siViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("SalesOrder Controller - Get_SalesOrder  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(siViewModel));
        }

    }
}
