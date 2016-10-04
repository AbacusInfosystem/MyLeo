﻿using MyLeoRetailer.Common;
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

namespace MyLeoRetailer.Controllers.PostLogin
{
    public class SalesReturnController : BaseController
    {
        public SalesReturnRepo srRepo; 

        public SalesReturnController()
        {
            srRepo = new SalesReturnRepo();
        }

        public ActionResult Index(SalesReturnViewModel srViewModel)
        {

            if (TempData["srViewModel"] != null)
            {
                srViewModel = (SalesReturnViewModel)TempData["srViewModel"];
            }
            
            return View("Index", srViewModel);
        }

        public JsonResult Get_Customer_Name_By_Mobile_No(string MobileNo)
        {
            //string Customer_Name;

            SalesReturnViewModel srViewModel = new SalesReturnViewModel();

            srViewModel.SalesReturn = srRepo.Get_Customer_Name_By_Mobile_No(MobileNo);

            return Json(srViewModel.SalesReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Sales_Return_Items_By_SKU_Code(string SKU_Code)
            {

            SalesReturnViewModel srViewModel = new SalesReturnViewModel();

            srViewModel.SalesReturn = srRepo.Get_Sales_Order_Items_By_SKU_Code(SKU_Code);

            return Json(srViewModel.SalesReturn, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Search(SalesReturnViewModel srViewModel)
        {

            try
            {
                if (TempData["srViewModel"] != null)
                {
                    srViewModel = (SalesReturnViewModel)TempData["srViewModel"];
                }
            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Search", srViewModel);
        }

        public JsonResult Get_SalesReturn(SalesReturnViewModel srViewModel)
        {

            srViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = srViewModel.Cookies.Branch_Ids + "," + srViewModel.Filter.Sales_Return_No; // Set filter comma seprated

                dataOperator = DataOperator.In.ToString() + "," + DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                srViewModel.Query_Detail = Set_Query_Details(false, "Sales_Return_No,Total_Quantity,Gross_Amount,Total_Amount_Return_By_Cash,Total_Amount_Return_By_Credit_Note,Sales_Return_Id", "", "Sales_Return", "Branch_ID,Sales_Return_No", filter, dataOperator); // Set query for grid

                pager = srViewModel.Grid_Detail.Pager;

                //srViewModel.Query_Detail.Input_Params.Add(new WhereInfo() { Key = "Branch_ID", Value = filter, DataOperator = DataOperator.In.ToString() });

                srViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Return_No,Total_Quantity,Gross_Amount,Total_Amount_Return_By_Cash,Total_Amount_Return_By_Credit_Note", "Sales_Return_Id"); // Set grid info for front end listing

                srViewModel.Grid_Detail.Records = srRepo.Get_SalesOrder(srViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, srViewModel.Grid_Detail); // set pagination for grid

                srViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(srViewModel));
        }

        public ActionResult Insert_SalesReturn(SalesReturnViewModel srViewModel)
        {

            try
            {
                Set_Date_Session(srViewModel.SalesReturn);

                //srViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                //string[] arr = srViewModel.Cookies.Branch_Ids.Split(',');

                //string Branch_Id = srViewModel.Cookies.Branch_Ids.TrimEnd();

                //siViewModel.SalesInvoice.Branch_Id = siViewModel.Cookies.Branch_Ids;

                //for (int i = 0; i < arr.Length; i++)
                //{

                srViewModel.SalesReturn.Sales_Return_No = Utility.Generate_Ref_No("SR-", "Sales_Return_No", "4", "15", "Sales_Return");

                //srViewModel.SalesReturn.Sales_Return_Id = srRepo.Insert_SalesReturn(srViewModel.SalesReturn, srViewModel.SaleReturnItemList);

                srViewModel.SalesReturn.Sales_Return_Id = srRepo.Insert_SalesReturn(srViewModel.SalesReturn, srViewModel.SaleReturnItemList);
                //}

                srViewModel.FriendlyMessages.Add(MessageStore.Get("SR01"));
            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
            }

            TempData["srViewModel"] = (SalesReturnViewModel)srViewModel;

            return RedirectToAction("Search");
        }

        public JsonResult Check_Mobile_No(string MobileNo)
        {

            bool check = false;

            try
            {
                check = srRepo.Check_Mobile_No(MobileNo);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Sales_Return_By_Id(SalesReturnViewModel srViewModel)
        {
           
            try
            {
               
                srViewModel.SalesReturn = srRepo.Get_Sales_Return_By_Id(srViewModel.Filter.Sales_Return_Id);

                srViewModel.SaleReturnItemList = srRepo.Get_Sales_Return_Items_By_Id(srViewModel.Filter.Sales_Return_Id);

            }
            catch (Exception ex)
            {
                srViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["srViewModel"] = srViewModel;

            return RedirectToAction("View_Sales_Return", "SalesReturn");          
        }

        public ActionResult View_Sales_Return(SalesReturnViewModel srViewModel)
        {

            if (TempData["srViewModel"] != null)
            {
                srViewModel = (SalesReturnViewModel)TempData["srViewModel"];
            }

            return View("SalesReturnView", srViewModel);
        }

    }
}
