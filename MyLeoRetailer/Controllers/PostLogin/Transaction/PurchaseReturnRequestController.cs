using MyLeoRetailer.Common;
using MyLeoRetailer.Filters;
using MyLeoRetailer.Models.Transaction;
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

namespace MyLeoRetailer.Controllers.PostLogin.Transaction
{
    [SessionExpireAttribute]
    public class PurchaseReturnRequestController : BaseController
    {

        public VendorRepo _vRepo = null;

        public PurchaseReturnRequestRepo _prRepo = null;

        public PurchaseInvoiceRepo _pRepo = null;

        public PurchaseReturnRequestController()
        {
            _vRepo = new VendorRepo();

            _prRepo = new PurchaseReturnRequestRepo();

            _pRepo = new PurchaseInvoiceRepo();

        }

        public ActionResult Search(PurchaseReturnRequestViewModel prViewModel)
        {
            try
            {
                if (TempData["prViewModel"] != null)
                {
                    prViewModel = (PurchaseReturnRequestViewModel)TempData["prViewModel"];
                }

                Pagination_Info pager = new Pagination_Info();

                prViewModel.PurchaseReturnRequests = _prRepo.Get_Purchase_Return_Requests(ref pager);
                    
            }
            catch(Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnRequest Controller - Search : " + ex.ToString());
            }
            return View("Search", prViewModel);
        }

        public ActionResult Index(PurchaseReturnRequestViewModel prViewModel)
        {
            try
            {
                prViewModel.PurchaseReturnRequest.Vendors = _vRepo.Get_Vendors();
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnRequest Controller - Index : " + ex.ToString());
            }
            return View("Index", prViewModel);
        }

        public ActionResult Save_Purchase_Return_Request(PurchaseReturnRequestViewModel prViewModel)
        {
            try
            {
                LoginInfo Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                prViewModel.PurchaseReturnRequest.Branch_Id = Convert.ToInt32(Cookies.Branch_Ids);
                //prViewModel.PurchaseReturnRequest.Branch_Id = 1;

                Set_Date_Session(prViewModel.PurchaseReturnRequest);

                foreach (var item in prViewModel.PurchaseReturnRequest.PurchaseReturnRequestItems)
                {
                    Set_Date_Session(item);
                }                

                if (prViewModel.PurchaseReturnRequest.Purchase_Return_Request_Id == 0)
                {
                    prViewModel.PurchaseReturnRequest.Purchase_Return_Request_Id = _prRepo.Insert_Purchase_Return_Request(prViewModel.PurchaseReturnRequest);

                    prViewModel.FriendlyMessages.Add(MessageStore.Get("PRR01"));
                }
                else
                {
                    //_prRepo.Update_Purchase_Return_Request(prViewModel.PurchaseReturnRequest);

                    //prViewModel.FriendlyMessages.Add(MessageStore.Get("PRR02"));
                }

            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));

                Logger.Error("PurchaseReturnRequest Controller - Save_Purchase_Return_Request : " + ex.ToString());
            }

            TempData["prViewModel"] = (PurchaseReturnRequestViewModel)prViewModel;

            return RedirectToAction("Search", prViewModel);
        }

        public JsonResult Get_Purchase_Return_Item_By_SKU_Code(string SKU_Code)
        {
            PurchaseReturnRequestViewModel prViewModel = new PurchaseReturnRequestViewModel();

            try
            {
                prViewModel.PurchaseReturnRequest.PurchaseReturnRequestItem = _prRepo.Get_Purchase_Return_Item_By_SKU_Code(SKU_Code);
            }
            catch(Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnRequest Controller - Get_Purchase_Return_Item_By_SKU_Code : " + ex.ToString());
            }
            

            return Json(prViewModel.PurchaseReturnRequest.PurchaseReturnRequestItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Vendor_Details_By_Id(int Vendor_Id)
        {
            PurchaseReturnRequestViewModel prViewModel = new PurchaseReturnRequestViewModel();

            try
            {
                prViewModel.PurchaseReturnRequest.Vendor = _vRepo.Get_Vendor_By_Id(Vendor_Id);

                prViewModel.PurchaseReturnRequest.PurchaseInvoices = _pRepo.Get_Purchase_Invoice_No_By_Id(Vendor_Id);

            }
            catch(Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnRequest Controller - Get_Vendor_Details_By_Id : " + ex.ToString());
            }
           
            return Json(prViewModel.PurchaseReturnRequest, JsonRequestBehavior.AllowGet);
        }


    }
}
