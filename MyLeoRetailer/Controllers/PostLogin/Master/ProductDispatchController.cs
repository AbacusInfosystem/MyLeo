using MyLeoRetailer.Common;
using MyLeoRetailer.Filters;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ProductDispatchController : BaseController
    {
        public ProductDispatchController()
        {
            pRepo = new ProductDispatchRepo();
        }

        ProductDispatchRepo pRepo;

        [AuthorizeUserAttribute(AppFunction.Product_Dispatch_Management_View)]
        public ActionResult Index(ProductDispatchViewModel pViewModel)
        {
            try
            {
                pViewModel.product_Dispatch = pRepo.Get_Product_To_Dispatch_By_Id(pViewModel.product_Dispatch.Request_Id, pViewModel.product_Dispatch.SKU);
            }
            catch(Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("ProductDispatch Controller - Index : " + ex.ToString());
            }

            return View(pViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Product_Dispatch_Management_Access)]
        public ActionResult Search(ProductDispatchViewModel pViewModel)
        {
            if (TempData["pViewModel"] != null)
            {
                pViewModel = (ProductDispatchViewModel)TempData["pViewModel"];
            
            }

            return View(pViewModel);
        }

        public JsonResult Get_Product_To_Dispatch(ProductDispatchViewModel pViewModel)
        {
            Pagination_Info pager = new Pagination_Info();

            try
            {
                pager = pViewModel.Grid_Detail.Pager;

                pViewModel.Grid_Detail = Set_Grid_Details(false, "SKU_Code,Purcahse_Order_Request_Date,Branch_Name,Quantity,Balance_Quantity,Status", "Purchase_Order_Request_Id,Status,SKU_Code"); // Set grid info for front end listing

                pViewModel.Grid_Detail.Records = pRepo.Get_Product_To_Dispatch(pViewModel.Filter); // Call repo method 

                Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

                pViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("ProductDispatch Controller - Get_Product_To_Dispatch : " + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Product_Dispatch_Management_Create)]
        public ActionResult Insert(ProductDispatchViewModel pViewModel)
        {
            TransactionScope scope = new TransactionScope();
            try
            {
                using (scope)
                {
                    Set_Date_Session(pViewModel.product_Dispatch);

                    pRepo.Insert(pViewModel.product_Dispatch, pViewModel.List_product_Dispatch);

                    pViewModel.FriendlyMessages.Add(MessageStore.Get("PD01"));

                    scope.Complete();
                }
            }
            catch(Exception ex)
            {
                Logger.Error("ProductDispatch Controller - Insert : " + ex.ToString());

                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                scope.Dispose();
            }

            TempData["pViewModel"] = pViewModel;

            return RedirectToAction("Search");
        }

        public JsonResult Delete_Dispatch_Product(ProductDispatchViewModel pViewModel)
        {
            try
            {
                pRepo.Delete_Dispatch_Product(pViewModel.product_Dispatch);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("ProductDispatch Controller - Delete_Dispatch_Product : " + ex.ToString());
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUserAttribute(AppFunction.Product_Inward_Management_Access)]
        public ActionResult Dispatched_Product_Listing(ProductDispatchViewModel pViewModel)
        {
            if (TempData["pViewModel"] != null)
            {
                pViewModel = (ProductDispatchViewModel)TempData["pViewModel"];

            }
           return View(pViewModel);
        }

        public JsonResult Dispatched_Product_Listing_binding(ProductDispatchViewModel pViewModel)
        {

            Pagination_Info pager = new Pagination_Info();
            try
            {

                pager = pViewModel.Grid_Detail.Pager;

                pViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                pViewModel.Grid_Detail = Set_Grid_Details(false, "SKU,Quantity,Dispatch_Date", "Dispatch_Id,Request_Id,Branch_Id,Dispatch_Item_Id"); // Set grid info for front end listing

                pViewModel.Grid_Detail.Records = pRepo.Dispatched_Product_Listing(pViewModel.Cookies.Branch_Ids.TrimEnd()); // Call repo method 

                Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

                pViewModel.Grid_Detail.Pager = pager;

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("ProductDispatch Controller - Dispatched_Product_Listing_binding : " + ex.ToString());
            }
            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Product_Inward_Management_Edit)]
        public ActionResult Accept_Product_Dispatch(ProductDispatchViewModel pViewModel)
        {
            TransactionScope scope = new TransactionScope();
            try
            {
                 using (scope)
                {
                Set_Date_Session(pViewModel.product_Dispatch);

                pRepo.Accept_Product_Dispatch(pViewModel.List_product_Dispatch, pViewModel.product_Dispatch);

                pViewModel.FriendlyMessages.Add(MessageStore.Get("PD02"));

                scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("ProductDispatch Controller - Accept_Product_Dispatch : " + ex.ToString());

                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                scope.Dispose();
            
            }

            TempData["pViewModel"] = pViewModel;

           return RedirectToAction("Dispatched_Product_Listing");
        }

    }
}
