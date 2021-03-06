﻿using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
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

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ProductWarehouseController : BaseController
    {
        public PurchaseInvoiceRepo _purchaseinvoiceRepo;

        public ProductWarehouseController()
        {
            _purchaseinvoiceRepo = new PurchaseInvoiceRepo();
        }

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult Get_WarehouseProducts(ProductWarehouseViewModel pViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = pViewModel.Filter.Product_SKU;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

                pViewModel.Query_Detail = Set_Query_Details(true, "Product_Quntity,Product_SKU,Barcode,Product_Warehouse_Id", "", "Product_Warehouse", "Product_SKU", filter, dataOperator); // Set query for grid

                pager = pViewModel.Grid_Detail.Pager;

                pViewModel.Grid_Detail = Set_Grid_Details(false, "Product_SKU,Barcode,Product_Quntity", "Product_Warehouse_Id"); // Set grid info for front end listing

                pViewModel.Grid_Detail.Records = _purchaseinvoiceRepo.Get_WarehouseProducts(pViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

                pViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("ProductWarehouse Controller - Get_WarehouseProducts  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public PartialViewResult Warehouse_Notifiation(ProductWarehouseViewModel pViewModel)
        {

            LoginInfo Cookies = new LoginInfo();
            Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            pViewModel.List_product_warehouse = _purchaseinvoiceRepo.Warehouse_Notifiation(Cookies.Branch_Ids);

            return PartialView("_Warehouse_Notifiation", pViewModel);
        }

    }
}
