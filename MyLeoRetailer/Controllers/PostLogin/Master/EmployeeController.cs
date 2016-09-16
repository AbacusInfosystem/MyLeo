using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerManager;
using MyLeoRetailerRepo;
using Newtonsoft.Json;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class EmployeeController : BaseController
    {
        EmployeeRepo eRepo;

        public EmployeeController()
        {
            eRepo = new EmployeeRepo();
        }

        public ActionResult Index(EmployeeViewModel eViewModel)
        {
            try
            {
                if (TempData["eViewModel"] != null)
                {
                    eViewModel = (EmployeeViewModel)TempData["eViewModel"];
                }
                RoleRepo _rRepo = new RoleRepo();

                eViewModel.Role_List = _rRepo.Get_Role_List();

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

            }

            return View("Index", eViewModel);
        }

        public ActionResult Search(EmployeeViewModel eViewModel)
        {
            try
            {
                if (TempData["eViewModel"] != null)
                {
                    eViewModel = (EmployeeViewModel)TempData["eViewModel"];
                }
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", eViewModel);
        }

        public ActionResult Insert_Employee(EmployeeViewModel eViewModel)
        {
            //EmployeeRepo eRepo = new EmployeeRepo();

            try
            {
                Set_Date_Session(eViewModel.Employee);

                eViewModel.Employee.Employee_Id = eRepo.Insert_Employee(eViewModel.Employee);

                eViewModel.FriendlyMessages.Add(MessageStore.Get("EMP01"));
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult Update_Employee(EmployeeViewModel eViewModel)
        {
            //EmployeeRepo eRepo = new EmployeeRepo();

            try
            {
                Set_Date_Session(eViewModel.Employee);

                eRepo.Update_Employee(eViewModel.Employee);

                eViewModel.FriendlyMessages.Add(MessageStore.Get("EMP02"));
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;
            return RedirectToAction("Search");
        }

        public JsonResult Get_Employees(EmployeeViewModel eViewModel)
        {
            //EmployeeRepo eRepo = new EmployeeRepo();

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            int IsActive = 1;

            try
            {
                 
                filter = eViewModel.Filter.Employee + "," + IsActive.ToString(); // Set filter comma seprated 

                dataOperator = DataOperator.Like.ToString() + "," + DataOperator.Equal.ToString(); // set operator for where clause as comma seprated

                eViewModel.Query_Detail = Set_Query_Details(false, "Employee_Name,Employee_Address,Employee_City,Employee_EmailId,Employee_Id", "", "Employee", "Employee_Name,IsActive", filter, dataOperator); // Set query for grid

                pager = eViewModel.Grid_Detail.Pager;

                eViewModel.Grid_Detail = Set_Grid_Details(false, "Employee_Name,Employee_Address,Employee_City,Employee_EmailId", "Employee_Id"); // Set grid info for front end listing

                eViewModel.Grid_Detail.Records = eRepo.Get_Employees(eViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, eViewModel.Grid_Detail); // set pagination for grid

                eViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(eViewModel));
        }

        public ActionResult Get_Employee_By_Id(EmployeeViewModel eViewModel)
        { 
            //EmployeeRepo cRepo = new EmployeeRepo();
            try
            {
                eViewModel.Employee = eRepo.Get_Employee_By_Id(eViewModel.Employee.Employee_Id);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;
            return RedirectToAction("Index",eViewModel);
        }

        public JsonResult Check_Existing_User_Name(string user_Name)
        {
            bool check = false;
            try
            {
                //check = eRepo.Check_Existing_User_Name(user_Name);
            }
            catch (Exception ex)
            {
                
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //Addition by swapnali | Date:14/09/2016
        public ActionResult ChangeBranch()
        {
            EmployeeViewModel eViewModel = new EmployeeViewModel();
            eViewModel.Employee_Branch_List = eRepo.Get_Branch_By_Id(1);
            return View("ChangeBranch", eViewModel);
        }

        //public ActionResult Get_Branch_By_Employee(EmployeeViewModel eViewModel)
        //{
        //    eViewModel.Employee_Branch_List = eRepo.Get_Branch_By_Id(1);

        //    return View("ChangeBranch", eViewModel);
        //}


        //public JsonResult Get_Branch_By_Employee(EmployeeViewModel eViewModel)
        //{
        //    string filter = "";

        //    string dataOperator = "";

        //    Pagination_Info pager = new Pagination_Info();

        //    try
        //    {

        //        int EmployeeId = eViewModel.Employee.Employee_Id;// Set filter comma seprated

        //        dataOperator = DataOperator.Equal.ToString(); // set operator for where clause as comma seprated

        //        eViewModel.Query_Detail = Set_Query_Details(false, "a.Branch_Name,b.Branch_ID", "a,b", "Branch a left join Employee_Branch_Mapping b on a.Branch_ID = b.Branch_Id ", "b.Employee_Id,b.Is_Active", "1,true", "Equal,Equal"); // Set query for grid

        //        pager = eViewModel.Grid_Detail.Pager;

        //        eViewModel.Grid_Detail = Set_Grid_Details(false, "Branch_Name", "Branch_ID"); // Set grid info for front end listing

        //        eViewModel.Grid_Detail.Records = eRepo.Get_Branches(eViewModel.Query_Detail); // Call repo method 

        //        Set_Pagination(pager, eViewModel.Grid_Detail); // set pagination for grid

        //        eViewModel.Grid_Detail.Pager = pager;
        //    }
        //    catch (Exception ex)
        //    {
        //        eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(eViewModel));
        //}

        //end


    }
}
