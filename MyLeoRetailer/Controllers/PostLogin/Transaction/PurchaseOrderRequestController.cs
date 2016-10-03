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
    public class PurchaseOrderRequestController : BaseController
    {
        public PurchaseOrderRequestRepo _purchaseorderrequestRepo;

        public PurchaseOrderRepo _purchaseorderRepo;
        
        public SizeGroupRepo _sizeGroupRepo;

        public VendorRepo _vendorRepo;

        public BranchRepo _branchRepo;


        public PurchaseOrderRequestController()
        {
            _purchaseorderRepo = new PurchaseOrderRepo();

            _purchaseorderrequestRepo = new PurchaseOrderRequestRepo();

            _sizeGroupRepo = new SizeGroupRepo();

            _vendorRepo = new VendorRepo();

            _branchRepo = new BranchRepo();

        }

        public ActionResult Index(PurchaseOrderRequestViewModel poreqViewModel)
        {
            try
            {                
                if (TempData["poreqViewModel"] != null)
                {
                    poreqViewModel = (PurchaseOrderRequestViewModel)TempData["poreqViewModel"];
                }
                
                poreqViewModel.PurchaseOrderRequest.SizeGroups = _sizeGroupRepo.Get_All_SizeGroups();

                poreqViewModel.PurchaseOrderRequest.Vendors = _vendorRepo.Get_Vendors();

            }
            catch (Exception ex)
            {
                poreqViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", poreqViewModel);
        }        

        public ActionResult Search(PurchaseOrderRequestViewModel poreqViewModel)
        {
            try
            {
                if (TempData["poreqViewModel"] != null)
                {
                    poreqViewModel = (PurchaseOrderRequestViewModel)TempData["poreqViewModel"];
                }

                poreqViewModel.PurchaseOrderRequest.Vendors = _vendorRepo.Get_Vendors();
            }
            catch (Exception ex)
            {
                poreqViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", poreqViewModel);
        }       

        public ActionResult Insert_Purchase_Order_Request(PurchaseOrderRequestViewModel poreqViewModel)
        {
            try
            {                
                Set_Date_Session(poreqViewModel.PurchaseOrderRequest);

                foreach (var item in poreqViewModel.PurchaseOrderRequest.PurchaseOrderRequests)
                {
                    Set_Date_Session(item);
                }

                if (poreqViewModel.PurchaseOrderRequest.Purchase_Order_Request_Id == 0)
                {
                    poreqViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                 //   poreqViewModel.PurchaseOrderRequest.Branch_Id = Convert.ToInt32(poreqViewModel.Cookies.Branch_Ids.TrimEnd());

                    poreqViewModel.PurchaseOrderRequest.Purchase_Order_Request_Id = _purchaseorderrequestRepo.Insert_Purchase_Order_Request(poreqViewModel.PurchaseOrderRequest);

                    poreqViewModel = new PurchaseOrderRequestViewModel();

                    poreqViewModel.FriendlyMessages.Add(MessageStore.Get("POREQ01"));
                }
                else
                {

                }

               
            }
            catch (Exception ex)
            {
                poreqViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["poreqViewModel"] = poreqViewModel;

            return RedirectToAction("Search", poreqViewModel);
        }

        public JsonResult Get_Purchase_Order_Requests(PurchaseOrderRequestViewModel poreqViewModel)
        {
            try
            {
                poreqViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                Pagination_Info pager = new Pagination_Info();

                pager = poreqViewModel.Pager;

                poreqViewModel.PurchaseOrderRequest.PurchaseOrderRequests = _purchaseorderrequestRepo.Get_Purchase_Order_Requests(ref pager, poreqViewModel.Cookies.Branch_Ids, poreqViewModel.Filter.Vendor_Id);

                poreqViewModel.Pager = pager;

                poreqViewModel.Pager.PageHtmlString = PageHelper.NumericPagerForAtlant(poreqViewModel.Pager.TotalRecords, poreqViewModel.Pager.CurrentPage, poreqViewModel.Pager.PageSize, poreqViewModel.Pager.PageLimit, poreqViewModel.Pager.StartPage, poreqViewModel.Pager.EndPage, poreqViewModel.Pager.IsFirst, poreqViewModel.Pager.IsPrevious, poreqViewModel.Pager.IsNext, poreqViewModel.Pager.IsLast, poreqViewModel.Pager.IsPageAndRecordLabel, poreqViewModel.Pager.DivObject, poreqViewModel.Pager.CallBackMethod);
            }
            catch (Exception ex)
            {
                poreqViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrderRequest Controller - Get_Purchase_Order_Requests : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poreqViewModel));
        }

        public ActionResult Get_Purchase_Order_Request_By_Id(PurchaseOrderRequestViewModel poreqViewModel)
        {          
            try
            {
                if (TempData["poreqViewModel"] != null)
                {
                    poreqViewModel = (PurchaseOrderRequestViewModel)TempData["poreqViewModel"];
                }

                poreqViewModel.PurchaseOrderRequest = _purchaseorderrequestRepo.Get_Purchase_Order_Request_Details_By_Id(poreqViewModel.PurchaseOrderRequest.Purchase_Order_Request_Id);

                poreqViewModel.PurchaseOrderRequest.PurchaseOrderRequestItems = _purchaseorderrequestRepo.Get_Purchase_Order_Request_Items(poreqViewModel.PurchaseOrderRequest.Purchase_Order_Request_Id);

            }
            catch (Exception ex)
            {
                poreqViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrder Controller - Get_Purchase_Order_Details_By_Id : " + ex.ToString());
            }

            return View("View", poreqViewModel);
        }


        //public JsonResult Get_Purchase_Order_Requests(PurchaseOrderRequestViewModel poreqViewModel)
        //{
        //    string filter = "";

        //    string dataOperator = "";

        //    Pagination_Info pager = new Pagination_Info();

        //    poreqViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

        //    try
        //    {

        //        filter = Convert.ToString(poreqViewModel.Filter.Vendor_Id) + "," + poreqViewModel.Cookies.Branch_Ids.TrimEnd();// Set filter comma seprated

        //        dataOperator = DataOperator.Like.ToString() + "," + DataOperator.In.ToString();

        //        filter = Convert.ToString(poreqViewModel.Filter.Vendor_Id);// Set filter comma seprated

        //        dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

        //        poreqViewModel.Query_Detail = Set_Query_Details(true, "Vendor_Id,Purchase_Order_Request_Id", "", "Purchase_Order_Request", "Vendor_Id,Branch_Id", filter, dataOperator); // Set query for grid

        //        pager = poreqViewModel.Grid_Detail.Pager;

        //        poreqViewModel.Grid_Detail = Set_Grid_Details(false, "Vendor_Id,Branch_Id", "Purchase_Order_Request_Id"); // Set grid info for front end listing

        //        poreqViewModel.Grid_Detail.Records = _purchaseorderRepo.Get_Purchase_Orders(poreqViewModel.Query_Detail); // Call repo method 

        //        Set_Pagination(pager, poreqViewModel.Grid_Detail); // set pagination for grid

        //        poreqViewModel.Grid_Detail.Pager = pager;
        //    }
        //    catch (Exception ex)
        //    {
        //        poreqViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(poreqViewModel));
        //}

        public JsonResult Get_Sizes(int size_group_Id)
        {
            PurchaseOrderRequestViewModel poreqViewModel = new PurchaseOrderRequestViewModel();

            poreqViewModel.PurchaseOrderRequest.SizeGroups = _sizeGroupRepo.Get_Sizes(size_group_Id);

            return Json(JsonConvert.SerializeObject(poreqViewModel));
        }

        public JsonResult Get_Details_By_Vendor_Id(int Vendor_Id)
        {
            PurchaseOrderRequestViewModel poreqViewModel = new PurchaseOrderRequestViewModel();

            poreqViewModel.PurchaseOrderRequest.Vendors = _purchaseorderRepo.Get_Article_No_By_Vendor_Id(Vendor_Id);

            poreqViewModel.PurchaseOrderRequest.Brands = _purchaseorderRepo.Get_Brand_By_Vendor_Id(Vendor_Id);

            poreqViewModel.PurchaseOrderRequest.Categories = _purchaseorderRepo.Get_Category_By_Vendor_Id(Vendor_Id);

            poreqViewModel.PurchaseOrderRequest.Colors = _purchaseorderRepo.Get_Color_By_Vendor_Id(Vendor_Id);

            return Json(JsonConvert.SerializeObject(poreqViewModel));
        }

        public JsonResult Get_Details_By_Category_Vendor_Id(int Vendor_Id, int Category_Id)
        {
            PurchaseOrderRequestViewModel poreqViewModel = new PurchaseOrderRequestViewModel();

            poreqViewModel.PurchaseOrderRequest.SubCategories = _purchaseorderRepo.Get_Sub_Category_By_Vendor_Id(Vendor_Id, Category_Id);

            return Json(JsonConvert.SerializeObject(poreqViewModel));
        }
    }
}