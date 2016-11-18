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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Transaction
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

                //poViewModel.PurchaseOrder.SizeGroups = _sizeGroupRepo.Get_All_SizeGroups();

                poViewModel.PurchaseOrder.Vendors = _vendorRepo.Get_Vendors();

                poViewModel.PurchaseOrder.Agents = _vendorRepo.Get_Agents();

                poViewModel.PurchaseOrder.Transporters = _vendorRepo.Get_Transporters();

                poViewModel.PurchaseOrder.Branches = _branchRepo.Get_Branches();

            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Index : " + ex.ToString());
            }
            return View("Index", poViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Order_Management_Access)]
        public ActionResult Search(int PurchaseReport_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            poViewModel.PurchaseOrder.PurchaseReport_Id = PurchaseReport_Id;

            //poViewModel.PurchaseOrder.PurchaseOrder_Id = PurchaseOrder_Id;
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

                Logger.Error(" PurchaseOrderController - Search : " + ex.ToString());
            }
            return View("Search", poViewModel);
        }


        public JsonResult Get_Purchase_Orders(PurchaseOrderViewModel poViewModel)
        {
            try
            {
                Pagination_Info pager = new Pagination_Info();

                pager = poViewModel.Grid_Detail.Pager;

                poViewModel.Grid_Detail = Set_Grid_Details(false, "Purchase_Order_No,Purchase_Order_Date,Vendor_Name,Shipping_Address,Total_Quantity,Net_Amount,Agent_Name,Transporter_Name,Start_Supply_Date,Stop_Supply_Date", "Purchase_Order_Id"); // Set grid info for front end listing

                poViewModel.Grid_Detail.Records = _purchaseorderRepo.Get_Purchase_Order(poViewModel.Filter);

                Set_Pagination(pager, poViewModel.Grid_Detail);

                poViewModel.Grid_Detail.Pager = pager;

            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Get_Purchase_Orders : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Purchase_Order_List(PurchaseOrderViewModel poViewModel)
        {
            try
            {
                poViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                Pagination_Info pager = new Pagination_Info();

                pager = poViewModel.Pager;

                poViewModel.PurchaseOrder.PurchaseOrders = _purchaseorderRepo.Get_Purchase_Order_List(ref pager, poViewModel.Filter.Purchase_Order_No);

                poViewModel.Pager = pager;

                poViewModel.Pager.PageHtmlString = PageHelper.NumericPagerForAtlant(poViewModel.Pager.TotalRecords, poViewModel.Pager.CurrentPage, poViewModel.Pager.PageSize, poViewModel.Pager.PageLimit, poViewModel.Pager.StartPage, poViewModel.Pager.EndPage, poViewModel.Pager.IsFirst, poViewModel.Pager.IsPrevious, poViewModel.Pager.IsNext, poViewModel.Pager.IsLast, poViewModel.Pager.IsPageAndRecordLabel, poViewModel.Pager.DivObject, poViewModel.Pager.CallBackMethod);
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrder Controller - Get_Purchase_Order_List : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Consolidate_Purchase_Orders(int Vendor_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            try
            {
                poViewModel.PurchaseOrder.PurchaseOrders = _purchaseorderRepo.Get_Consolidate_Purchase_Order_Item(Vendor_Id);

            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Get_Consolidate_Purchase_Orders : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }


        public JsonResult Get_Sizes(int size_group_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            try
            {
                poViewModel.PurchaseOrder.SizeGroups = _sizeGroupRepo.Get_Sizes(size_group_Id);
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Get_Sizes : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Details_By_Vendor_Id(int Vendor_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            try
            {
                poViewModel.PurchaseOrder.Vendors = _purchaseorderRepo.Get_Article_No_By_Vendor_Id(Vendor_Id);


            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Get_Details_By_Vendor_Id : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Details_By_Article_No(string Article_No)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            try
            {
                poViewModel.PurchaseOrder.SizeGroups = _purchaseorderRepo.Get_Size_Group_By_Article_No(Article_No);

                poViewModel.PurchaseOrder.Brands = _purchaseorderRepo.Get_Brand_By_Article_No(Article_No);

                poViewModel.PurchaseOrder.Categories = _purchaseorderRepo.Get_Category_By_Article_No(Article_No);

                poViewModel.PurchaseOrder.Colors = _purchaseorderRepo.Get_Color_By_Article_No(Article_No);

            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Get_Details_By_Article_No : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        public JsonResult Get_Details_By_Category_Article_No(string Article_No, int Category_Id)
        {
            PurchaseOrderViewModel poViewModel = new PurchaseOrderViewModel();

            try
            {
                poViewModel.PurchaseOrder.SubCategories = _purchaseorderRepo.Get_Sub_Category_By_Article_No(Article_No, Category_Id);
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error(" PurchaseOrderController - Get_Details_By_Category_Article_No : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(poViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Order_Management_Create)]
        public ActionResult Insert_Purchase_Order(PurchaseOrderViewModel poViewModel)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Set_Date_Session(poViewModel.PurchaseOrder);

                    foreach (var item in poViewModel.PurchaseOrder.PurchaseOrders)
                    {
                        Set_Date_Session(item);
                    }

                    if (poViewModel.PurchaseOrder.Purchase_Order_Id == 0)
                    {

                        poViewModel.PurchaseOrder.Purchase_Order_No = Utility.Generate_Ref_No("PO-", "Purchase_Order_No", "4", "15", "Purchase_Order");

                        _purchaseorderRepo.Insert_Purchase_Order(poViewModel.PurchaseOrder);

                        poViewModel = new PurchaseOrderViewModel();

                        poViewModel.FriendlyMessages.Add(MessageStore.Get("PO01"));
                    }
                    else
                    {
                        poViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
                    }

                    scope.Complete();

                }
                catch (Exception ex)
                {
                    poViewModel = new PurchaseOrderViewModel();

                    poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                    Logger.Error(" PurchaseOrderController - Insert_Purchase_Order : " + ex.ToString());

                    scope.Dispose();
                }

                TempData["poViewModel"] = (PurchaseOrderViewModel)poViewModel;

                return RedirectToAction("Search", poViewModel);

            }
        }

        public ActionResult Get_Purchase_Order_Details(PurchaseOrderViewModel poViewModel)
        {
            try
            {
                if (TempData["poViewModel"] != null)
                {
                    poViewModel = (PurchaseOrderViewModel)TempData["poViewModel"];
                }

                poViewModel.PurchaseOrder = _purchaseorderRepo.Get_Purchase_Order_Details_By_Id(poViewModel.Filter.Purchase_Order_Id);

                poViewModel.PurchaseOrder.PurchaseOrderItems = _purchaseorderRepo.Get_Purchase_Order_Items(poViewModel.Filter.Purchase_Order_Id);

                poViewModel.PurchaseOrder.Total_Amount_In_Word = Utility.ConvertDecimalNumbertoWords(poViewModel.PurchaseOrder.PurchaseOrderItems.Sum(a => a.Total_Amount));

            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrderController - Get_Purchase_Order_Details : " + ex.ToString());
            }

            return PrintPO(poViewModel);

            //return View("Print", poViewModel);
        }

        public ActionResult Send_Purchase_Order_Invoice(PurchaseOrderViewModel poViewModel)
        {
            try
            {
                if (poViewModel.PurchaseOrder.Purchase_Order_Id != 0)
                {
                    poViewModel.PurchaseOrder = _purchaseorderRepo.Get_Purchase_Order_Details_By_Id(poViewModel.PurchaseOrder.Purchase_Order_Id);
                    poViewModel.PurchaseOrder.PurchaseOrderItems = _purchaseorderRepo.Get_Purchase_Order_Items(poViewModel.PurchaseOrder.Purchase_Order_Id);
                    poViewModel.PurchaseOrder.Total_Amount_In_Word = Utility.ConvertDecimalNumbertoWords(poViewModel.PurchaseOrder.PurchaseOrderItems.Sum(a => a.Total_Amount));

                    MemoryStream attachment = _purchaseorderRepo.Create_Purchase_Order_Invoice_PDf(poViewModel.PurchaseOrder);

                    var FileExtension = ".pdf";

                    var fileName = "Purchase_Order_Invoice_" + poViewModel.PurchaseOrder.Purchase_Order_Id + "_" + poViewModel.PurchaseOrder.Purchase_Order_No;

                    string DirectoryPath = "Invoice";

                    bool directoryExists = System.IO.Directory.Exists(Server.MapPath("/UploadFiles/" + DirectoryPath));

                    if (!directoryExists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("/UploadFiles/" + DirectoryPath));
                    }

                    string ServerPath = Server.MapPath("/UploadFiles/" + DirectoryPath + "//").ToString();
                    string folderPath = (ServerPath + fileName + FileExtension);

                    if (System.IO.File.Exists(folderPath))
                    {
                        System.IO.File.Delete(folderPath);
                    }

                    System.IO.File.WriteAllBytes(folderPath, attachment.ToArray());

                    _purchaseorderRepo.SendDemoEmail(poViewModel.PurchaseOrder, folderPath);

                    poViewModel.FriendlyMessages.Add(MessageStore.Get("PO04"));

                }

            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrderController - Send_Purchase_Order_Invoice : " + ex.ToString());
            }

            TempData["poViewModel"] = (PurchaseOrderViewModel)poViewModel;

            return RedirectToAction("Search", poViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Order_Management_View)]
        public ActionResult Get_Purchase_Order_By_Id(PurchaseOrderViewModel poViewModel)
        {
            int Id = poViewModel.PurchaseOrder.PurchaseReport_Id;
            try
            {
                if (TempData["poViewModel"] != null)
                {
                    poViewModel = (PurchaseOrderViewModel)TempData["poViewModel"];
                }

                poViewModel.PurchaseOrder = _purchaseorderRepo.Get_Purchase_Order_Details_By_Id(poViewModel.Filter.Purchase_Order_Id);

                poViewModel.PurchaseOrder.PurchaseOrderItems = _purchaseorderRepo.Get_Purchase_Order_Items(poViewModel.Filter.Purchase_Order_Id);

                poViewModel.PurchaseOrder.PurchaseReport_Id = Id;
            }
            catch (Exception ex)
            {
                poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrderController - Get_Purchase_Order_Details_By_Id : " + ex.ToString());
            }

            return View("View", poViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Order_Management_Edit)]
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

                Logger.Error("PurchaseOrderController - Update_Purchase_Order : " + ex.ToString());
            }

            TempData["poViewModel"] = poViewModel;

            return RedirectToAction("Search", poViewModel);
        }

        public ActionResult PrintPO(PurchaseOrderViewModel poViewModel)
        {

            poViewModel.PurchaseOrder.Logo_Path = ConfigurationManager.AppSettings["LogoPath"].ToString();

            return View("Print", poViewModel);
        }


        ////***************************************************************************////


        //public JsonResult Get_Purchase_Orders(PurchaseOrderViewModel poViewModel)
        //{
        //    string filter = "";

        //    string dataOperator = "";

        //    Pagination_Info pager = new Pagination_Info();

        //    try
        //    {

        //        filter = poViewModel.Filter.Purchase_Order_No;// Set filter comma seprated

        //        dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

        //        poViewModel.Query_Detail = Set_Query_Details(true, "Purchase_Order_No,Purchase_Order_Id", "", "Purchase_Order", "Purchase_Order_No", filter, dataOperator); // Set query for grid

        //        pager = poViewModel.Grid_Detail.Pager;

        //        poViewModel.Grid_Detail = Set_Grid_Details(false, "Purchase_Order_No", "Purchase_Order_Id"); // Set grid info for front end listing

        //        poViewModel.Grid_Detail.Records = _purchaseorderRepo.Get_Purchase_Orders(poViewModel.Query_Detail); // Call repo method 

        //        Set_Pagination(pager, poViewModel.Grid_Detail); // set pagination for grid

        //        poViewModel.Grid_Detail.Pager = pager;
        //    }
        //    catch (Exception ex)
        //    {
        //        poViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(poViewModel));
        //}
    }

}
