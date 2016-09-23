using MyLeoRetailer.Common;
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

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class PurchaseReturnController: BaseController
    {
        public PurchaseReturnRepo _purchaseReturnRepo;

        public PurchaseInvoiceRepo _purchaseinvoiceRepo;

        public PurchaseOrderRepo _purchaseorderRepo;

        public VendorRepo _vendorRepo;

        public PurchaseReturnController()
        {
            _purchaseReturnRepo = new PurchaseReturnRepo();

            _purchaseinvoiceRepo = new PurchaseInvoiceRepo();

            _purchaseorderRepo = new PurchaseOrderRepo();

            _vendorRepo = new VendorRepo();
        }

        public ActionResult Index(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                if (TempData["prViewModel"] != null)
                {
                    prViewModel = (PurchaseReturnViewModel)TempData["prViewModel"];
                }

              //  prViewModel.PurchaseReturn.Vendors = _vendorRepo.Get_Vendors();

                prViewModel.PurchaseReturn.Transporters = _vendorRepo.Get_Transporters();

            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", prViewModel);
        }

        public ActionResult Search(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                if (TempData["prViewModel"] != null)
                {
                    prViewModel = (PurchaseReturnViewModel)TempData["prViewModel"];
                }
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", prViewModel);
        }
       
        public JsonResult Get_Purchase_Return_Items_By_SKU_Code(string SKU_Code)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Purchase_Return_Items_By_SKU_Code(SKU_Code);

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Purchase_Return_PO_By_POI(int Purchase_Invoice_Id, string SKU_Code)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            prViewModel.PurchaseReturn.Purchase_Order_Id = _purchaseorderRepo.Get_Purchase_Order_Invoice_By_Id(Purchase_Invoice_Id, SKU_Code);
            
            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Get_Vendor_Details_By_Id(int Vendor_Id)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Vendor_Details_By_Id(Vendor_Id);

            prViewModel.PurchaseReturn.PurchaseInvoices = _purchaseinvoiceRepo.Get_Purchase_Invoice_No_By_Id(Vendor_Id);

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert_Purchase_Return(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                Set_Date_Session(prViewModel.PurchaseReturn);

                prViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                prViewModel.PurchaseReturn.Created_By = prViewModel.Cookies.User_Id;

                prViewModel.PurchaseReturn.Created_Date = DateTime.Now;

                prViewModel.PurchaseReturn.Updated_By = prViewModel.Cookies.User_Id;

                prViewModel.PurchaseReturn.Updated_Date = DateTime.Now;

                prViewModel.PurchaseReturn.Purchase_Return_Id = _purchaseReturnRepo.Insert_Purchase_Return(prViewModel.PurchaseReturn);

                prViewModel.FriendlyMessages.Add(MessageStore.Get("POI01"));
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

            TempData["prViewModel"] = (PurchaseReturnViewModel)prViewModel;

            return RedirectToAction("Search", prViewModel);
        }
        
        public JsonResult Get_Purchase_Returns(PurchaseReturnViewModel prViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = prViewModel.Filter.Debit_Note_No;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

                prViewModel.Query_Detail = Set_Query_Details(true, "Debit_Note_No,Purchase_Return_Id", "", "Purchase_Return", "Debit_Note_No", filter, dataOperator); // Set query for grid

                pager = prViewModel.Grid_Detail.Pager;

                prViewModel.Grid_Detail = Set_Grid_Details(false, "Debit_Note_No", "Purchase_Return_Id"); // Set grid info for front end listing

                prViewModel.Grid_Detail.Records = _purchaseReturnRepo.Get_Purchase_Returns(prViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, prViewModel.Grid_Detail); // set pagination for grid

                prViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(prViewModel));
        }


        public JsonResult Get_Purchase_Return_Items_By_Vendor_And_PO(int Vendor_Id, int Purchase_Invoice_Id)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.PurchaseReturn.PurchaseReturns = _purchaseReturnRepo.Get_Purchase_Return_Items_By_Vendor_And_PO(Vendor_Id, Purchase_Invoice_Id);
            }
            catch(Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturn Controller - Get_Purchase_Return_Items_By_Vendor_And_PO :" + ex.ToString());
            }
            
            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

    }
}
