﻿using MyLeoRetailer.Common;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Transaction
{
    public class PurchaseReturnController : BaseController
    {
        public PurchaseReturnRepo _purchaseReturnRepo;

        public PurchaseReturnRequestRepo _purchaseReturnRequestRepo;

        public PurchaseInvoiceRepo _purchaseinvoiceRepo;

        public PurchaseOrderRepo _purchaseorderRepo;

        public VendorRepo _vendorRepo;


        public PurchaseReturnController()
        {
            _purchaseReturnRepo = new PurchaseReturnRepo();

            _purchaseReturnRequestRepo = new PurchaseReturnRequestRepo();

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

                prViewModel.PurchaseReturn.Vendors = _vendorRepo.Get_Vendors();

                prViewModel.PurchaseReturn.Transporters = _vendorRepo.Get_Transporters();

            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Index : " + ex.ToString());
            }

            return View("Index", prViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Return_Management_Access)]

        public ActionResult Search(int? PurchaseReport_Id)
        {

            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            if (PurchaseReport_Id == null)
            {
                PurchaseReport_Id = 1;
            }

            prViewModel.PurchaseReturn.PurchaseReturnReport_Id = Convert.ToInt32(PurchaseReport_Id);

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

                Logger.Error("PurchaseReturnController - Search : " + ex.ToString());
            }
            return View("Search", prViewModel);
        }


        public JsonResult Get_Purchase_Returns(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                Pagination_Info pager = new Pagination_Info();

                pager = prViewModel.Grid_Detail.Pager;

                prViewModel.Grid_Detail = Set_Grid_Details(false, "Debit_Note_No,Purchase_Invoice_No,Purchase_Return_Date,GR_No,Vendor_Name,Transporter_Name,Total_Quantity,Net_Amount,Logistics_Person_Name,Lr_No", "Purchase_Return_Id"); // Set grid info for front end listing

                prViewModel.Grid_Detail.Records = _purchaseReturnRepo.Get_Purchase_Returns(prViewModel.Filter);

                Set_Pagination(pager, prViewModel.Grid_Detail);

                prViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Returns : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(prViewModel));
        }

        public JsonResult Get_Purchase_Return_List(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                LoginInfo Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                Pagination_Info pager = new Pagination_Info();

                pager = prViewModel.Pager;

                prViewModel.PurchaseReturn.PurchaseReturns = _purchaseReturnRepo.Get_Purchase_Return_List(ref pager, prViewModel.Filter.Debit_Note_No);

                prViewModel.Pager = pager;

                prViewModel.Pager.PageHtmlString = PageHelper.NumericPagerForAtlant(prViewModel.Pager.TotalRecords, prViewModel.Pager.CurrentPage, prViewModel.Pager.PageSize, prViewModel.Pager.PageLimit, prViewModel.Pager.StartPage, prViewModel.Pager.EndPage, prViewModel.Pager.IsFirst, prViewModel.Pager.IsPrevious, prViewModel.Pager.IsNext, prViewModel.Pager.IsLast, prViewModel.Pager.IsPageAndRecordLabel, prViewModel.Pager.DivObject, prViewModel.Pager.CallBackMethod);
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Return_List : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(prViewModel));
        }


        public JsonResult Get_Purchase_Return_Items_By_SKU_Code(string SKU_Code)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Purchase_Return_Items_By_SKU_Code(SKU_Code);
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Return_Items_By_SKU_Code : " + ex.ToString());
            }

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Purchase_Return_Items_By_Barcode(string Barcode)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Purchase_Return_Items_By_Barcode(Barcode);
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Return_Items_By_Barcode : " + ex.ToString());
            }

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Purchase_Return_PO_By_POI(int Purchase_Invoice_Id, string SKU_Code)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.PurchaseReturn.Purchase_Order_Id = _purchaseorderRepo.Get_Purchase_Order_Invoice_By_Id(Purchase_Invoice_Id, SKU_Code);
            }
            //Added by vinod mane on 06/10/2016

            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Return_PO_By_POI : " + ex.ToString());
            }

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Vendor_Details_By_Id(int Vendor_Id)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Vendor_Details_By_Id(Vendor_Id);

                prViewModel.PurchaseReturn.PurchaseInvoices = _purchaseinvoiceRepo.Get_Purchase_Invoice_No_By_Id(Vendor_Id);
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Vendor_Details_By_Id : " + ex.ToString());
            }

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Purchase_Return_Items_By_Vendor_And_PO(int Vendor_Id, int Purchase_Invoice_Id)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.PurchaseReturn.PurchaseReturns = _purchaseReturnRepo.Get_Purchase_Return_Items_By_Vendor_And_PO(Vendor_Id, Purchase_Invoice_Id);
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Return_Items_By_Vendor_And_PO :" + ex.ToString());
            }

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Update_GR_No(int Id)
        {
            PurchaseReturnViewModel prViewModel = new PurchaseReturnViewModel();

            try
            {
                prViewModel.Filter.Purchase_Return_Id = Id;
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Update_GR_No : " + ex.ToString());
            }

            return PartialView("_Update_GR_No", prViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Return_Management_Create)]
        public ActionResult Insert_Purchase_Return(PurchaseReturnViewModel prViewModel)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Set_Date_Session(prViewModel.PurchaseReturn);

                    foreach (var item in prViewModel.PurchaseReturn.PurchaseReturns)
                    {
                        Set_Date_Session(item);
                    }

                    if (prViewModel.PurchaseReturn.Purchase_Return_Id == 0)
                    {
                        prViewModel.PurchaseReturn.Debit_Note_No = Utility.Generate_Ref_No("DBN-", "Debit_Note_No", "5", "15", "Purchase_Return");

                        _purchaseReturnRepo.Insert_Purchase_Return(prViewModel.PurchaseReturn);

                        prViewModel = new PurchaseReturnViewModel();

                        prViewModel.FriendlyMessages.Add(MessageStore.Get("POR01"));
                    }
                    else
                    {
                        prViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    prViewModel = new PurchaseReturnViewModel();

                    prViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));

                    Logger.Error("PurchaseReturnController - Insert_Purchase_Return : " + ex.ToString());

                    scope.Dispose();
                }

                TempData["prViewModel"] = (PurchaseReturnViewModel)prViewModel;

                return RedirectToAction("Search");
            }
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Return_Management_Edit)]
        public JsonResult Update_Purchase_Return(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                Set_Date_Session(prViewModel.PurchaseReturn);

                if (prViewModel.PurchaseReturn.Purchase_Return_Id != 0)
                {
                    _purchaseReturnRepo.Update_Purchase_Return(prViewModel.PurchaseReturn);

                    prViewModel = new PurchaseReturnViewModel();

                    prViewModel.FriendlyMessages.Add(MessageStore.Get("POI02"));
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                prViewModel = new PurchaseReturnViewModel();

                prViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));

                Logger.Error("PurchaseReturnController - Update_Purchase_Return : " + ex.ToString());
            }

            return Json(prViewModel.PurchaseReturn, JsonRequestBehavior.AllowGet);
        }


        //Added by vinod mane on 29/09/2016

        public ActionResult View_Page(PurchaseReturnViewModel prViewModel)
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

                Logger.Error("PurchaseReturnController - View_Page : " + ex.ToString());
            }

            return View("View_Purchase_Return_Details", prViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Purchase_Return_Management_View)]
        public ActionResult Get_Purchase_Return_Details_By_Id(PurchaseReturnViewModel prViewModel)
        {
            bool CheckFlag = false;

            int Id = prViewModel.PurchaseReturn.PurchaseReturnReport_Id;

            try
            {
                CheckFlag = prViewModel.PurchaseReturn.Flag;

                prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Purchase_Return_By_Purchase_Return_Id(prViewModel.Filter.Purchase_Return_Id);

                prViewModel.PurchaseReturn.PurchaseReturns = _purchaseReturnRepo.Get_Purchase_Return_Item_By_Id(prViewModel.Filter.Purchase_Return_Id);
                if (prViewModel.PurchaseReturn.PurchaseReturns.Count > 0)
                {
                    CheckFlag = true;
                }
                prViewModel.PurchaseReturn.PurchaseReturnReport_Id = Id;
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Get_Purchase_Return_Details_By_Id : " + ex.ToString());
            }

            if (CheckFlag == true)
            {
                return View("View_Purchase_Return_Details", prViewModel);
            }
            else
            {
                TempData["siViewModel"] = prViewModel;

                return RedirectToAction("Search", "PurchaseReturn");
            }

        }


        /*Added by Gauravi on 16-11-2016*/

        public ActionResult Print(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                if (TempData["prViewModel"] != null)
                {
                    prViewModel = (PurchaseReturnViewModel)TempData["prViewModel"];
                }

                prViewModel.PurchaseReturn.Logo_Path = ConfigurationManager.AppSettings["LogoPath"].ToString();
            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Print : " + ex.ToString());
            }         
            
            return View("Print", prViewModel);
        }

        public ActionResult Send_Purchase_Return_Invoice(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                if (prViewModel.PurchaseReturn.Purchase_Return_Id != 0)
                {
                    prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Purchase_Return_Details_By_Id(prViewModel.PurchaseReturn.Purchase_Return_Id);
                    prViewModel.PurchaseReturn.PurchaseReturns = _purchaseReturnRepo.Get_Purchase_Return_Item_By_Id(prViewModel.PurchaseReturn.Purchase_Return_Id);
                    prViewModel.PurchaseReturn.Total_Amount_In_Word = Utility.ConvertDecimalNumbertoWords(prViewModel.PurchaseReturn.PurchaseReturns.Sum(a => a.Amount));

                    MemoryStream attachment = _purchaseReturnRepo.Create_Purchase_Return_Invoice_PDf(prViewModel.PurchaseReturn);

                    var FileExtension = ".pdf";

                    var fileName = "Purchase_Return_Invoice_" + prViewModel.PurchaseReturn.Purchase_Order_Id + "_" + prViewModel.PurchaseReturn.Debit_Note_No;

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

                    _purchaseReturnRepo.SendDemoEmail(prViewModel.PurchaseReturn, folderPath);

                    prViewModel.FriendlyMessages.Add(MessageStore.Get("PO04"));

                }

            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnController - Send_Purchase_Return_Invoice : " + ex.ToString());
            }

            TempData["prViewModel"] = (PurchaseReturnViewModel)prViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Get_Purchase_Return_Details(PurchaseReturnViewModel prViewModel)
        {
            try
            {
                if (TempData["prViewModel"] != null)
                {
                    prViewModel = (PurchaseReturnViewModel)TempData["prViewModel"];
                }

                prViewModel.PurchaseReturn = _purchaseReturnRepo.Get_Purchase_Return_Details_By_Id(prViewModel.Filter.Purchase_Return_Id);

                prViewModel.PurchaseReturn.PurchaseReturns = _purchaseReturnRepo.Get_Purchase_Return_Item_By_Id(prViewModel.Filter.Purchase_Return_Id);

                prViewModel.PurchaseReturn.Total_Amount_In_Word = Utility.ConvertDecimalNumbertoWords(prViewModel.PurchaseReturn.PurchaseReturns.Sum(a => a.Amount));

            }
            catch (Exception ex)
            {
                prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseOrderController - Get_Purchase_Order_Details : " + ex.ToString());
            }

            //return Print(prViewModel);

            TempData["prViewModel"] = (PurchaseReturnViewModel)prViewModel;

            return RedirectToAction("Print", prViewModel);
        }

        /*END*/

        //public JsonResult Get_Purchase_Returns(PurchaseReturnViewModel prViewModel)
        //{
        //    string filter = "";

        //    string dataOperator = "";

        //    Pagination_Info pager = new Pagination_Info();

        //    try
        //    {

        //        filter = prViewModel.Filter.Debit_Note_No;// Set filter comma seprated

        //        dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

        //        prViewModel.Query_Detail = Set_Query_Details(true, "Debit_Note_No,Purchase_Return_Id", "", "Purchase_Return", "Debit_Note_No", filter, dataOperator); // Set query for grid

        //        pager = prViewModel.Grid_Detail.Pager;

        //        prViewModel.Grid_Detail = Set_Grid_Details(false, "Debit_Note_No", "Purchase_Return_Id"); // Set grid info for front end listing

        //        prViewModel.Grid_Detail.Records = _purchaseReturnRepo.Get_Purchase_Returns(prViewModel.Query_Detail); // Call repo method 

        //        Set_Pagination(pager, prViewModel.Grid_Detail); // set pagination for grid

        //        prViewModel.Grid_Detail.Pager = pager;
        //    }
        //    catch (Exception ex)
        //    {
        //        prViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(prViewModel));
        //}

    }
}
