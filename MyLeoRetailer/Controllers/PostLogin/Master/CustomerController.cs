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
    public class CustomerController : BaseController
    {
        public CustomerRepo cRepo;

        public CustomerController()
        {
            cRepo = new CustomerRepo();
        }

        public ActionResult Index(CustomerViewModel cViewModel)
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
            }
            return View("Index", cViewModel);
        }        

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
            }
            return View("Search", cViewModel);
        }

        public ActionResult Get_Customer_By_Id(CustomerViewModel cViewModel)
        {  
            cViewModel.Customer = cRepo.Get_Customer_By_Id(cViewModel.Customer.Customer_Id);            
            
            return View("Index", cViewModel);
        }

        public JsonResult Get_Customer_By_Mobile(CustomerViewModel cViewModel)
        {
            cViewModel.Customer = cRepo.Get_Customer_By_Mobile(Convert.ToString(cViewModel.Customer.Mobile));

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public ActionResult Insert_Customer(CustomerViewModel cViewModel)
        {
            try
            {                
                Set_Date_Session(cViewModel.Customer);

                cViewModel.Customer.Customer_Id = cRepo.Insert_Customer(cViewModel.Customer);

                cViewModel.FriendlyMessages.Add(MessageStore.Get("CUST01"));
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["cViewModel"] = cViewModel;

            return RedirectToAction("Search", cViewModel);
        }

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
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }
    }
}
