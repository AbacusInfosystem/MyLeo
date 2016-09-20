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

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class PurchaseOrderController : BaseController
    {
        public PurchaseOrderRepo _purchaseorderRepo;

        public SizeGroupRepo _sizeGroupRepo;

        public VendorRepo _vendorRepo;

        public BranchRepo _branchRepo;


        public PurchaseOrderController()
        {
            _purchaseorderRepo = new PurchaseOrderRepo();

            _sizeGroupRepo = new SizeGroupRepo();

            _vendorRepo = new VendorRepo();

            _branchRepo = new BranchRepo();

        }

        public ActionResult Index(PurchaseOrderViewModel poViewModel)
        {
            try
            {                
                if (TempData["poViewModel"] != null)
                {
                    poViewModel = (PurchaseOrderViewModel)TempData["poViewModel"];
                }
                
                poViewModel.PurchaseOrder.SizeGroups = _sizeGroupRepo.Get_All_SizeGroups();

                poViewModel.PurchaseOrder.Vendors = _vendorRepo.Get_Vendors();

                poViewModel.PurchaseOrder.Agents = _vendorRepo.Get_Agents();

                poViewModel.PurchaseOrder.Transporters = _vendorRepo.Get_Transporters();

                poViewModel.PurchaseOrder.Branches = _branchRepo.Get_Branches();


            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", poViewModel);
        }        

        public ActionResult Search(PurchaseOrderViewModel poViewModel)
        {
            try
            {
                if (TempData["poViewModel"] != null)
                {
                    poViewModel = (PurchaseOrderViewModel)TempData["poViewModel"];
                }
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", poViewModel);
        }

        public ActionResult Get_Purchase_Order_By_Id(PurchaseOrderViewModel poViewModel)
        {  
            poViewModel.PurchaseOrder = _purchaseorderRepo.Get_Purchase_Order_By_Id(poViewModel.PurchaseOrder.Purchase_Order_Id);
            
            poViewModel.PurchaseOrder.SizeGroups = _sizeGroupRepo.Get_All_SizeGroups();

            poViewModel.PurchaseOrder.Vendors = _vendorRepo.Get_Vendors();

            poViewModel.PurchaseOrder.Agents = _vendorRepo.Get_Agents();

            poViewModel.PurchaseOrder.Transporters = _vendorRepo.Get_Transporters();

            poViewModel.PurchaseOrder.Branches = _branchRepo.Get_Branches();

            
            return View("Index", poViewModel);
        }

        public ActionResult Insert_Purchase_Order(PurchaseOrderViewModel poViewModel)
        {
            try
            {                
                Set_Date_Session(poViewModel.PurchaseOrder);

                poViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                poViewModel.PurchaseOrder.Created_By = poViewModel.Cookies.User_Id;

                poViewModel.PurchaseOrder.Created_Date = DateTime.Now;

                poViewModel.PurchaseOrder.Updated_By = poViewModel.Cookies.User_Id;

                poViewModel.PurchaseOrder.Updated_Date = DateTime.Now;

                poViewModel.PurchaseOrder.Purchase_Order_Id = _purchaseorderRepo.Insert_Purchase_Order(poViewModel.PurchaseOrder);

                poViewModel.FriendlyMessages.Add(MessageStore.Get("PO01"));
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["poViewModel"] = poViewModel;

            return RedirectToAction("Search", poViewModel);
        }

        public ActionResult Update_Purchase_Order(PurchaseOrderViewModel poViewModel)
        {
            try
            {
                Set_Date_Session(poViewModel.PurchaseOrder);

                _purchaseorderRepo.Update_Purchase_Order(poViewModel.PurchaseOrder);

                poViewModel.FriendlyMessages.Add(MessageStore.Get("PO02"));
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["poViewModel"] = poViewModel;

            return RedirectToAction("Search", poViewModel);
        }

        public JsonResult Get_Purchase_Orders(PurchaseOrderViewModel poViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = poViewModel.Filter.Purchase_Order_No;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

                poViewModel.Query_Detail = Set_Query_Details(true, "Purchase_Order_No,Purchase_Order_Id", "", "Purchase_Order", "Purchase_Order_No", filter, dataOperator); // Set query for grid

                pager = poViewModel.Grid_Detail.Pager;

                poViewModel.Grid_Detail = Set_Grid_Details(false, "Purchase_Order_No", "Purchase_Order_Id"); // Set grid info for front end listing

                poViewModel.Grid_Detail.Records = _purchaseorderRepo.Get_Purchase_Orders(poViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, poViewModel.Grid_Detail); // set pagination for grid

                poViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }


        public JsonResult Get_Sizes(int size_group_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            poViewModel.PurchaseOrder.SizeGroups = _sizeGroupRepo.Get_Sizes(size_group_Id);

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Details_By_Vendor_Id(int Vendor_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            poViewModel.PurchaseOrder.Vendors = _purchaseorderRepo.Get_Article_No_By_Vendor_Id(Vendor_Id);

            poViewModel.PurchaseOrder.Brands = _purchaseorderRepo.Get_Brand_By_Vendor_Id(Vendor_Id);

            poViewModel.PurchaseOrder.Categories = _purchaseorderRepo.Get_Category_By_Vendor_Id(Vendor_Id);

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Details_By_Category_Vendor_Id(int Vendor_Id, int Category_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            poViewModel.PurchaseOrder.SubCategories = _purchaseorderRepo.Get_Sub_Category_By_Vendor_Id(Vendor_Id, Category_Id);

            return Json(JsonConvert.SerializeObject(poViewModel));
        }
    }
}
