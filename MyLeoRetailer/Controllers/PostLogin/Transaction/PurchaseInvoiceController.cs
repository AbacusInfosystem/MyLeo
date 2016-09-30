using MyLeoRetailer.Common;
using MyLeoRetailer.Models.Transaction;
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

namespace MyLeoRetailer.Controllers.PostLogin.Transaction
{
    public class PurchaseInvoiceController: BaseController
    {
        public PurchaseInvoiceRepo _purchaseinvoiceRepo;

        public PurchaseOrderRepo _purchaseorderRepo;

        public VendorRepo _vendorRepo;

        public PurchaseInvoiceController()
        {
            _purchaseinvoiceRepo = new PurchaseInvoiceRepo();

            _purchaseorderRepo = new PurchaseOrderRepo();

            _vendorRepo = new VendorRepo();
        }

        public ActionResult Index(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                if (TempData["piViewModel"] != null)
                {
                    piViewModel = (PurchaseInvoiceViewModel)TempData["piViewModel"];
                }

                piViewModel.PurchaseInvoice.PurchaseOrders = _purchaseorderRepo.Get_Purchase_Orders();

                piViewModel.PurchaseInvoice.Vendors = _vendorRepo.Get_Vendors();

                piViewModel.PurchaseInvoice.Transporters = _vendorRepo.Get_Transporters();

            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", piViewModel);
        }

        public ActionResult Search(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                if (TempData["piViewModel"] != null)
                {
                    piViewModel = (PurchaseInvoiceViewModel)TempData["piViewModel"];
                }
            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", piViewModel);
        }

        public ActionResult View(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                if (TempData["piViewModel"] != null)
                {
                    piViewModel = (PurchaseInvoiceViewModel)TempData["piViewModel"];
                }
            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("View", piViewModel);
        }
       
        public JsonResult Get_Purchase_Invoice_Items_By_SKU_Code(string SKU_Code)
        {
            PurchaseInvoiceViewModel piViewModel = new PurchaseInvoiceViewModel();

            piViewModel.PurchaseInvoice = _purchaseinvoiceRepo.Get_Purchase_Invoice_Items_By_SKU_Code(SKU_Code);

            return Json(piViewModel.PurchaseInvoice, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Vendor_Details_By_Id(int Vendor_Id)
        {
            PurchaseInvoiceViewModel piViewModel = new PurchaseInvoiceViewModel();

            piViewModel.PurchaseInvoice = _purchaseinvoiceRepo.Get_Vendor_Detalis_By_Id(Vendor_Id);

            return Json(piViewModel.PurchaseInvoice, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert_Purchase_Invoice(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                Set_Date_Session(piViewModel.PurchaseInvoice);

                foreach (var item in piViewModel.PurchaseInvoice.PurchaseInvoices)
                {
                    Set_Date_Session(item);
                }

                if (piViewModel.PurchaseInvoice.Purchase_Invoice_Id == 0)
                {
                    //piViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                    //piViewModel.PurchaseInvoice.Created_By = piViewModel.Cookies.User_Id;

                    //piViewModel.PurchaseInvoice.Created_Date = DateTime.Now;

                    //piViewModel.PurchaseInvoice.Updated_By = piViewModel.Cookies.User_Id;

                    //piViewModel.PurchaseInvoice.Updated_Date = DateTime.Now;

                    _purchaseinvoiceRepo.Insert_Purchase_Invoice(piViewModel.PurchaseInvoice);

                    piViewModel.FriendlyMessages.Add(MessageStore.Get("POI01"));
                }
                else
                {

                }
               
            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

            TempData["piViewModel"] = (PurchaseInvoiceViewModel)piViewModel;

            return RedirectToAction("Search", piViewModel);
        }

        public ActionResult Get_Purchase_Invoice_Details_By_Id(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {

                piViewModel.PurchaseInvoice.PurchaseInvoices = _purchaseinvoiceRepo.Get_Purchase_Invoice_Details_By_Id(piViewModel.PurchaseInvoice.Purchase_Invoice_Id);

            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

           // TempData["piViewModel"] = (PurchaseInvoiceViewModel)piViewModel;

            return View("View", piViewModel);
        }

        public ActionResult Update_Purchase_Invoice(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                Set_Date_Session(piViewModel.PurchaseInvoice);

                _purchaseinvoiceRepo.Update_Purchase_Invoice(piViewModel.PurchaseInvoice);

                piViewModel.FriendlyMessages.Add(MessageStore.Get("POI01"));
            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

            TempData["piViewModel"] = (PurchaseInvoiceViewModel)piViewModel;

            return RedirectToAction("Search", piViewModel);
        }

        public ActionResult Get_Purchase_Invoice_Details(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                Set_Date_Session(piViewModel.PurchaseInvoice);

                piViewModel.PurchaseInvoice = _purchaseinvoiceRepo.Get_Purchase_Invoice_By_Id(piViewModel.PurchaseInvoice.Purchase_Invoice_Id);

                //piViewModel.PurchaseInvoice.PurchaseInvoices = _purchaseinvoiceRepo.Get_Purchase_Invoice_Item_By_Id(piViewModel.PurchaseInvoice.Purchase_Invoice_Item_Id);

                piViewModel.FriendlyMessages.Add(MessageStore.Get("POI01"));
            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

            TempData["piViewModel"] = (PurchaseInvoiceViewModel)piViewModel;

            return RedirectToAction("Search", piViewModel);
        }

        public JsonResult Get_Purchase_Invoices(PurchaseInvoiceViewModel piViewModel)
        {
            Pagination_Info pager = new Pagination_Info();

            pager = piViewModel.Grid_Detail.Pager;

            piViewModel.Grid_Detail = Set_Grid_Details(false, "Purchase_Invoice_No,Challan_No,Purchase_Invoice_Date,Vendor_Name,Total_Quantity,Net_Amount,Transporter_Name,Lr_No", "Purchase_Invoice_Id"); // Set grid info for front end listing

            piViewModel.Grid_Detail.Records = _purchaseinvoiceRepo.Get_Purchase_Invoice(piViewModel.Filter); // Call repo method 

            Set_Pagination(pager, piViewModel.Grid_Detail); // set pagination for grid

            piViewModel.Grid_Detail.Pager = pager;

            return Json(JsonConvert.SerializeObject(piViewModel));
        }

        public JsonResult Get_Purchase_Invoices_List(PurchaseInvoiceViewModel piViewModel)
        {
            try
            {
                piViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                Pagination_Info pager = new Pagination_Info();

                pager = piViewModel.Pager;

                piViewModel.PurchaseInvoice.PurchaseInvoices = _purchaseinvoiceRepo.Get_Purchase_Invoices_List(ref pager, piViewModel.Filter.Purchase_Invoice_No);

                piViewModel.Pager = pager;

                piViewModel.Pager.PageHtmlString = PageHelper.NumericPagerForAtlant(piViewModel.Pager.TotalRecords, piViewModel.Pager.CurrentPage, piViewModel.Pager.PageSize, piViewModel.Pager.PageLimit, piViewModel.Pager.StartPage, piViewModel.Pager.EndPage, piViewModel.Pager.IsFirst, piViewModel.Pager.IsPrevious, piViewModel.Pager.IsNext, piViewModel.Pager.IsLast, piViewModel.Pager.IsPageAndRecordLabel, piViewModel.Pager.DivObject, piViewModel.Pager.CallBackMethod);
            }
            catch (Exception ex)
            {
                piViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrder Controller - Get_Purchase_Order_Requests : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(piViewModel));
        }

        //public JsonResult Get_Purchase_Invoices(PurchaseInvoiceViewModel piViewModel)
        //{
        //    string filter = "";

        //    string dataOperator = "";

        //    Pagination_Info pager = new Pagination_Info();

        //    try
        //    {

        //        filter = piViewModel.Filter.Purchase_Invoice_No;// Set filter comma seprated

        //        dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

        //        piViewModel.Query_Detail = Set_Query_Details(true, "Purchase_Invoice_No,Purchase_Invoice_Id", "", "Purchase_Invoice", "Purchase_Invoice_No", filter, dataOperator); // Set query for grid

        //        pager = piViewModel.Grid_Detail.Pager;

        //        piViewModel.Grid_Detail = Set_Grid_Details(false, "Purchase_Invoice_No", "Purchase_Invoice_Id"); // Set grid info for front end listing

        //        piViewModel.Grid_Detail.Records = _purchaseinvoiceRepo.Get_Purchase_Invoices(piViewModel.Query_Detail); // Call repo method 

        //        Set_Pagination(pager, piViewModel.Grid_Detail); // set pagination for grid

        //        piViewModel.Grid_Detail.Pager = pager;
        //    }
        //    catch (Exception ex)
        //    {
        //        piViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(piViewModel));
        //}



    }
}
