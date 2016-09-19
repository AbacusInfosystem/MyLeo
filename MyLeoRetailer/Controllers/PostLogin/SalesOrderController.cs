using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
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
    public class SalesOrderController : BaseController
    {

        public SalesOrderRepo siRepo; 

        public SalesOrderController()
        {
            siRepo = new SalesOrderRepo();
        }

        public ActionResult Index(SalesInvoiceViewModel siViewModel)
        {
            return View("Index", siViewModel);
        }

        public JsonResult Get_Customer_Name_By_Mobile_No(string MobileNo)
        {
            //string Customer_Name;

            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();

            siViewModel.SalesInvoice = siRepo.Get_Customer_Name_By_Mobile_No(MobileNo);

            return Json(siViewModel.SalesInvoice, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Sales_Order_Items_By_SKU_Code(string SKU_Code)
        {

            SalesInvoiceViewModel siViewModel = new SalesInvoiceViewModel();

            siViewModel.SalesInvoice = siRepo.Get_Sales_Order_Items_By_SKU_Code(SKU_Code);

            return Json(siViewModel.SalesInvoice, JsonRequestBehavior.AllowGet);

        }

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
            }

            return View("Search", siViewModel);
        }

        public JsonResult Get_SalesOrder(SalesInvoiceViewModel siViewModel)
        {

            siViewModel.Cookies = Utility.Get_Login_User("LoginInfo", "Token", "Branch_Ids");

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = siViewModel.Cookies.Branch_Ids; // Set filter comma seprated

                dataOperator = DataOperator.In.ToString(); // set operator for where clause as comma seprated

                siViewModel.Query_Detail = Set_Query_Details(false, "Sales_Invoice_No,Total_Quantity,Total_MRP_Amount,Total_Discount_Amount,Gross_Amount,Tax_Percentage,Net_Amount,Sales_Invoice_Id", "", "Sales_Invoice", "Branch_ID", filter, dataOperator); // Set query for grid             

                siViewModel.Query_Detail.Input_Params.Add(new WhereInfo() { Key = "Branch_ID", Value = filter, DataOperator= DataOperator.In.ToString() });

                pager = siViewModel.Grid_Detail.Pager;

                siViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Invoice_No,Total_Quantity,Total_MRP_Amount,Total_Discount_Amount,Gross_Amount,Tax_Percentage,Net_Amount", "Sales_Invoice_Id"); // Set grid info for front end listing

                siViewModel.Grid_Detail.Records = siRepo.Get_SalesOrder(siViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, siViewModel.Grid_Detail); // set pagination for grid

                siViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(siViewModel));
        }

        public ActionResult Insert_SalesOrder(SalesInvoiceViewModel siViewModel)
        {
            //string arr [] ;



            try
            {
                Set_Date_Session(siViewModel.SalesInvoice);

                siViewModel.Cookies = Utility.Get_Login_User("LoginInfo", "Token", "Branch_Ids");

                //string[] arr  = siViewModel.Cookies.Branch_Ids.Split(',');

                string Branch_Id = siViewModel.Cookies.Branch_Ids.TrimEnd();

                //siViewModel.SalesInvoice.Branch_Id = siViewModel.Cookies.Branch_Ids;

                //for (int i = 0; i < arr.Length; i++)
                //{
                    //Set_Date_Session(siViewModel.SalesInvoice);

                siViewModel.SalesInvoice.Sales_Invoice_Id = siRepo.Insert_SalesOrder(siViewModel.SalesInvoice, siViewModel.SaleOrderItemList, Branch_Id);
   
                //}

                siViewModel.FriendlyMessages.Add(MessageStore.Get("SI01"));
            }
            catch (Exception ex)
            {
                siViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

            TempData["siViewModel"] = (SalesInvoiceViewModel)siViewModel;

            return RedirectToAction("Search");
        }



    }
}
