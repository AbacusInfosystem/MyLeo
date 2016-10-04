using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerInfo;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index(ProductDispatchViewModel pViewModel)
        {
            var is_View = pViewModel.product_Dispatch.Is_View;

            pViewModel.product_Dispatch = pRepo.Get_Product_To_Dispatch_By_Id(pViewModel.product_Dispatch.Request_Id,pViewModel.product_Dispatch.SKU);

            pViewModel.product_Dispatch.Is_View = is_View;

            return View(pViewModel);
        }
       
        public ActionResult Search()
        {
            return View();
        }

        public JsonResult Get_Product_To_Dispatch(ProductDispatchViewModel pViewModel)
        {
            Pagination_Info pager = new Pagination_Info();

            pager = pViewModel.Grid_Detail.Pager;

            pViewModel.Grid_Detail = Set_Grid_Details(false, "SKU_Code,Purcahse_Order_Request_Date,Branch_Name,Quantity,Balance_Quantity,Status", "Purchase_Order_Request_Id,Status,SKU_Code"); // Set grid info for front end listing

            pViewModel.Grid_Detail.Records = pRepo.Get_Product_To_Dispatch(pViewModel.Filter); // Call repo method 

            Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

            pViewModel.Grid_Detail.Pager = pager;

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public ActionResult Insert(ProductDispatchViewModel pViewModel)
        {
            Set_Date_Session(pViewModel.product_Dispatch);

            pRepo.Insert(pViewModel.product_Dispatch, pViewModel.List_product_Dispatch);
           
            return RedirectToAction("Search");
        }

        public JsonResult Delete_Dispatch_Product(ProductDispatchViewModel pViewModel)
        {
            pRepo.Delete_Dispatch_Product(pViewModel.product_Dispatch);

            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dispatched_Product_Listing(ProductDispatchViewModel pViewModel)
        {
           return View(pViewModel);
        }

        public JsonResult Dispatched_Product_Listing_binding(ProductDispatchViewModel pViewModel)
        {

            Pagination_Info pager = new Pagination_Info();

            pViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            pViewModel.Grid_Detail = Set_Grid_Details(false, "SKU,Quantity,Dispatch_Date", "Dispatch_Id,Request_Id,Branch_Id"); // Set grid info for front end listing

            pViewModel.Grid_Detail.Records = pRepo.Dispatched_Product_Listing(pViewModel.Cookies.Branch_Ids.TrimEnd()); // Call repo method 

            Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

            pViewModel.Grid_Detail.Pager = pager;

            return Json(JsonConvert.SerializeObject(pViewModel));
        }
       


    }
}
