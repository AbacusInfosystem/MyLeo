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
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class CustomerController : BaseController
    {
        public CustomerRepo cRepo;

        public CustomerController()
        {
            cRepo = new CustomerRepo();
        }

        public ActionResult Index(CustomerViewModel cViewModel, SalesInvoiceViewModel siViewModel, SalesReturnViewModel srViewModel)
        {

            bool CheckFlag = false;

            bool CheckFlag1 = false;

            string Mobile = "";

            string InvoiceDate = "";

            string ReturnDate = "";

            try
            {
                CheckFlag = siViewModel.SalesInvoice.CreateCustomerFlag;

                CheckFlag1 = srViewModel.SalesReturn.CreateCustomerFlag;

                if (CheckFlag == true)
                {
                    cViewModel.Customer.CreateCustomerFlag = CheckFlag;

                    Mobile = siViewModel.SalesInvoice.Mobile;

                    cViewModel.Customer.Customer_Mobile1 = Mobile;

                    InvoiceDate = siViewModel.SalesInvoice.Invoice_Date.ToString();

                    TempData["siViewModel"] = siViewModel;

                    return View("Index", cViewModel);
                }

                if (CheckFlag1 == true)
                {

                    Mobile = srViewModel.SalesReturn.Mobile;

                    ReturnDate = srViewModel.SalesReturn.Sales_Return_Date.ToString();

                    TempData["srViewModel"] = srViewModel;

                    return View("Index", cViewModel);
                }

                if (TempData["cViewModel"] != null)
                {
                    cViewModel = (CustomerViewModel)TempData["cViewModel"];
                }
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Index " + ex.ToString());//Added by vinod mane on 06/10/2016
            }
            return View("Index", cViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Customer_Management_Access)]
        public ActionResult Search(CustomerViewModel cViewModel)
        {
            try
            {
                if (TempData["cViewModel"] != null)
                {
                    cViewModel = (CustomerViewModel)TempData["cViewModel"];
                }
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Search " + ex.ToString());//Added by vinod mane on 06/10/2016
            }
            return View("Search", cViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Customer_Management_View)]
        public ActionResult Get_Customer_By_Id(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer = cRepo.Get_Customer_By_Id(cViewModel.Customer.Customer_Id);
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Get_Customer_By_Id " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            return View("Index", cViewModel);
        }

        public JsonResult Get_Customer_By_Mobile(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer = cRepo.Get_Customer_By_Mobile(Convert.ToString(cViewModel.Customer.Mobile));
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Get_Customer_By_Mobile " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Customer_Management_Create)]
        public ActionResult Insert_Customer(CustomerViewModel cViewModel, SalesInvoiceViewModel siViewModel)
        {
            try
            {
                string MobileNo = cViewModel.Customer.Customer_Mobile1;

                Set_Date_Session(cViewModel.Customer);

                cViewModel.Customer.Customer_Id = cRepo.Insert_Customer(cViewModel.Customer);

                cViewModel.FriendlyMessages.Add(MessageStore.Get("CUST01"));

                //TempData["MobileNo"] = MobileNo;
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Insert_Customer " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            if (cViewModel.Customer.CreateCustomerFlag == true)
            {
                return RedirectToAction("Index", "SalesOrder");
            }
            else
            {

                TempData["cViewModel"] = cViewModel;

                return RedirectToAction("Search", cViewModel);
            }

        }

        [AuthorizeUserAttribute(AppFunction.Customer_Management_Edit)]
        public ActionResult Update_Customer(CustomerViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Customer);

                cRepo.Update_Customer(cViewModel.Customer);

                cViewModel.FriendlyMessages.Add(MessageStore.Get("CUST02"));
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Update_Customer " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            TempData["cViewModel"] = cViewModel;

            return RedirectToAction("Search", cViewModel);
        }

        public JsonResult Get_Customers(CustomerViewModel cViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {            

                filter = cViewModel.Filter.Customer_Name + "," + cViewModel.Filter.Customer_Mobile1;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString() + "," + DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                cViewModel.Query_Detail = Set_Query_Details(true, "Customer_Name,Customer_Id", "", "Customer", "Customer_Name,Customer_Mobile1", filter, dataOperator); // Set query for grid

                pager = cViewModel.Grid_Detail.Pager;

                cViewModel.Grid_Detail = Set_Grid_Details(false, "Customer_Name,Customer_Billing_Address,Customer_Mobile1,Customer_Email1", "Customer_Id"); // Set grid info for front end listing

                cViewModel.Grid_Detail.Records = cRepo.Get_Customers(cViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, cViewModel.Grid_Detail); // set pagination for grid

                cViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Get_Customers " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }


        //Added By Vinod Mane on 28/09/2016
        public JsonResult Check_Existing_Customer_Name(string customer_name)
        {
            bool check = false;
            CustomerViewModel cViewModel = new CustomerViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = cRepo.Check_Existing_Customer_Name(customer_name);
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Customer Controller - Check_Existing_Customer_Name " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        //End

        //Added by vinod mane on 17/10/2016
        public JsonResult Compare_Dates(DateTime DOB_Date)
        {
            bool check = true;
            CustomerViewModel cViewModel = new CustomerViewModel();
            try
            {
                DateTime Today_Date = DateTime.Now.Date;

                if (Today_Date <= DOB_Date)
                {
                    check = false;
                }
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Customer Controller - Compare_Dates " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        // END
    }
}
