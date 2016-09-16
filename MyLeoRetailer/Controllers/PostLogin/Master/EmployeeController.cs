﻿using System;
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

        #region Employee Branch mapping

        public ActionResult Employee_Branch_Mapping(EmployeeViewModel eViewModel)
        {
            try
            {
                eViewModel.Employee = eRepo.Get_Employee_By_Id(eViewModel.Employee.Employee_Id);
                eViewModel.Map_Branches = eRepo.Get_Employee_MapBranch_ById(eViewModel.Employee.Employee_Id); 
                eViewModel.List_Branch = eRepo.Get_Branches();
               
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Employee_Branch_Mapping", eViewModel);
        }

        public ActionResult Insert_Employee_Mapping(EmployeeViewModel eViewModel)
        {
            try
            {
                Set_Date_Session(eViewModel.Employee);

               eRepo.Insert_Employee_Mapping(eViewModel.Employee,eViewModel.List_Branch);

               eViewModel.FriendlyMessages.Add(MessageStore.Get("EMPM01"));
               
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;
            return RedirectToAction("Search");
        }

        #endregion

        #region Change Branch
        //Addition by swapnali | Date:14/09/2016
        public ActionResult ChangeBranch()
        {
            EmployeeViewModel eViewModel = new EmployeeViewModel();
            if (Request.Cookies["LoginInfo"] != null)
            {
                //var barchid = Request.Cookies["LoginInfo"].Value;
                MyLeoRetailer.Models.PreLogin.LoginViewModel lViewModel=new Models.PreLogin.LoginViewModel ();
                lViewModel.Cookies = Utility.Get_Login_User("LoginInfo", "Token", "Branch_Ids");

                eViewModel.Employee_Branch_List = eRepo.Get_Branch_By_Id(lViewModel.Cookies.User_Id,lViewModel.Cookies.Branch_Ids);

                eViewModel.Employee.Employee_Id=lViewModel.Cookies.User_Id;

            }
            return View("ChangeBranch", eViewModel);
        }

        public ActionResult Save_Employee_Branch_Id(EmployeeViewModel eViewModel)
        {
            //Response.Cookies["LoginInfo"]["Branch_Ids"] = Branch_Ids;

           var Branch_Ids= eRepo.Save_Change_BranchId(eViewModel.Employee_Branch_List);

           Set_Branch_Cookies(eViewModel.Employee.Employee_Id, Branch_Ids);

           eViewModel.FriendlyMessages.Add(MessageStore.Get("EMP03"));
        
           eViewModel.Employee_Branch_List = eViewModel.Employee_Branch_List;

           return View("ChangeBranch", eViewModel);
        }

        public void Set_Branch_Cookies(int User_Id, string Branch_Ids)
        {
            MyLeoRetailer.Models.PreLogin.LoginViewModel loginViewModel = new Models.PreLogin.LoginViewModel();
            LoginRepo _loginRepo = new LoginRepo();
            try
            {
                if (Request.Cookies["LoginInfo"] == null)
                {
                    HttpCookie cookies = new HttpCookie("LoginInfo");

                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    cookies.Values.Add("Token", cookie_Token);

                    cookies.Values.Add("Branch_Ids", Branch_Ids);

                    cookies.Expires = DateTime.Now.AddDays(2);

                    Response.Cookies.Add(cookies);
                }
                else
                {
                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    Response.Cookies["LoginInfo"]["Token"] = cookie_Token;

                    Response.Cookies["LoginInfo"]["Branch_Ids"] = Branch_Ids;

                }
            }
            catch (Exception ex)
            {
                HttpContext.Request.Cookies.Clear();

                //Logger.Error("Error at Login Controller - SetUsersCookies : " + ex.Message);
            }
        }


        //end

        #endregion 

    }
}
