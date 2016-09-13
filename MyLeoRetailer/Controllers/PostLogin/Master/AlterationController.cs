using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
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
    public class AlterationController : BaseController
    {
        public AlterationRepo bRepo;

        public EmployeeRepo eRepo;

        public AlterationController()
        {
            bRepo = new AlterationRepo();

            eRepo = new EmployeeRepo();
        }

        public ActionResult Index(AlterationViewModel aViewModel)
        {
            try
            {
                if (TempData["aViewModel"] != null)
                {
                    aViewModel = (AlterationViewModel)TempData["aViewModel"];
                }

                //aViewModel.Employees = eRepo.Get_Employees();

                aViewModel.SalesInvoices = bRepo.Get_SalesInvoices();
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", aViewModel);
        }

        public ActionResult Search(AlterationViewModel aViewModel)
        {
            try
            {
                if (TempData["aViewModel"] != null)
                {
                    aViewModel = (AlterationViewModel)TempData["aViewModel"];
                }
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", aViewModel);
        }

        public ActionResult Insert_Alteration(AlterationViewModel aViewModel)
        {
            try
            {
                Set_Date_Session(aViewModel.Alteration);

                aViewModel.Alteration.Alteration_ID = bRepo.Insert_Alteration(aViewModel.Alteration);

                aViewModel.FriendlyMessages.Add(MessageStore.Get("ALT01"));
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["aViewModel"] = (AlterationViewModel)aViewModel;

            return RedirectToAction("Search");
        }

        public ActionResult Update_Alteration(AlterationViewModel aViewModel)
        {
            try
            {
                Set_Date_Session(aViewModel.Alteration);

                bRepo.Update_Alteration(aViewModel.Alteration);

                aViewModel.FriendlyMessages.Add(MessageStore.Get("ALT02"));
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

 
            TempData["aViewModel"] = (AlterationViewModel)aViewModel;

            return RedirectToAction("Search");
        }

        public JsonResult Get_Alterations(AlterationViewModel aViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = aViewModel.Filter.Customer_Mobile_No;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                aViewModel.Query_Detail = Set_Query_Details(true, "Alteration_ID,Customer_Mobile_No", "", "Alteration", "Customer_Mobile_No", filter, dataOperator); // Set query for grid

                pager = aViewModel.Grid_Detail.Pager;

                aViewModel.Grid_Detail = Set_Grid_Details(false, "Sales_Invoice_ID,Product_Name,Alteration_Date,Delivery_Date,Customer_Mobile_No,Job_Assigned_To,Additional_Info", "Alteration_ID"); // Set grid info for front end listing

                aViewModel.Grid_Detail.Records = bRepo.Get_Alterations(aViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, aViewModel.Grid_Detail); // set pagination for grid

                aViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(aViewModel));
        }

        public ActionResult Get_Alteration_By_Id(AlterationViewModel aViewModel)
        {
            try
            {
                aViewModel.Alteration = bRepo.Get_Alteration_By_Id(aViewModel.Alteration.Alteration_ID);

                //aViewModel.Employees = eRepo.Get_Employees();

                aViewModel.SalesInvoices = bRepo.Get_SalesInvoices();
            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", aViewModel);
        }

        //public JsonResult Get_Alteration_By_Id(int Alteration_ID)
        //{
        //    AlterationViewModel aViewModel = new AlterationViewModel();
        //    try
        //    {
        //        aViewModel.Alteration = bRepo.Get_Alteration_By_Id(Convert.ToInt32(Alteration_ID));
        //    }
        //    catch (Exception ex)
        //    {
        //        aViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(aViewModel));
        //}

     

    }
}