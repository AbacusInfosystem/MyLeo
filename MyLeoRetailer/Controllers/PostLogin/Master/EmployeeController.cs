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
using MyLeoRetailer.Filters;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo.Employee;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    [SessionExpireAttribute]
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
                else
                {
                    eViewModel.Employee.IsActive = true;
                }
                RoleRepo _rRepo = new RoleRepo();

                eViewModel.Role_List = _rRepo.Get_Role_List();

               
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Employee Controller - Index" + ex.Message);
            }

            return View("Index", eViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Employee_Management_Access)]
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

                Logger.Error("Employee Controller - Search" + ex.Message);
            }
            return View("Search", eViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Employee_Management_Create)]
        public ActionResult Insert_Employee(EmployeeViewModel eViewModel)
        {
            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Employee_Management_Create))
                {
                Set_Date_Session(eViewModel.Employee);

                eViewModel.Employee.Employee_Id = eRepo.Insert_Employee(eViewModel.Employee);

                eViewModel.FriendlyMessages.Add(MessageStore.Get("EMP01"));
            }
                else
                {
                    eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Employee Controller - Insert_Employee" + ex.Message);
            }

            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;

            return RedirectToAction("Search");
        }

        [AuthorizeUserAttribute(AppFunction.Employee_Management_Edit)]
        public ActionResult Update_Employee(EmployeeViewModel eViewModel)
        {
            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Employee_Management_Edit))
                {
                Set_Date_Session(eViewModel.Employee);

                eRepo.Update_Employee(eViewModel.Employee);

                eViewModel.FriendlyMessages.Add(MessageStore.Get("EMP02"));
            }
                else
                {
                    eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Employee Controller - Update_Employee" + ex.Message);
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

           // int IsActive = 1;

            try
            {

                filter = eViewModel.Filter.Employee; //+ "," + IsActive.ToString(); // Set filter comma seprated 

                dataOperator = DataOperator.Like.ToString() + "," + DataOperator.Equal.ToString(); // set operator for where clause as comma seprated

                eViewModel.Query_Detail = Set_Query_Details(false, "Employee_Name,Employee_Address,Employee_City,Employee_EmailId,Employee_Id", "", "Employee", "Employee_Name", filter, dataOperator); // Set query for grid

                pager = eViewModel.Grid_Detail.Pager;

                eViewModel.Grid_Detail = Set_Grid_Details(false, "Employee_Name,Employee_Address,Employee_City,Employee_EmailId", "Employee_Id"); // Set grid info for front end listing

                eViewModel.Grid_Detail.Records = eRepo.Get_Employees(eViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, eViewModel.Grid_Detail); // set pagination for grid

                eViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Employee Controller - Get_Employees" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(eViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Employee_Management_View)]
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

                Logger.Error("Employee Controller - Get_Employee_By_Id" + ex.Message);
            }

            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;
            return RedirectToAction("Index", eViewModel);
        }

        public JsonResult Check_Existing_User_Name(string user_Name)
        {
            bool check = false;
            EmployeeViewModel eViewModel = new EmployeeViewModel();
            try
            {
                check = eRepo.Check_Existing_User_Name(user_Name);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Employee Controller - Check_Existing_User_Name" + ex.Message);
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

                Logger.Error("Employee Controller - Employee_Branch_Mapping" + ex.Message);
            }
            return View("Employee_Branch_Mapping", eViewModel);
        }

        public ActionResult Insert_Employee_Mapping(EmployeeViewModel eViewModel)
        {
            try
            {
                Set_Date_Session(eViewModel.Employee);

                eRepo.Insert_Employee_Mapping(eViewModel.Employee, eViewModel.List_Branch);

               eViewModel.FriendlyMessages.Add(MessageStore.Get("EMPM01"));
               
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Employee Controller - Insert_Employee_Mapping" + ex.Message);
            }
            TempData["eViewModel"] = (EmployeeViewModel)eViewModel;
            return RedirectToAction("Search");
        }

        #endregion

        #region Change Branch
        //Addition by swapnali | Date:14/09/2016
        public PartialViewResult ChangeBranch()
        {
            EmployeeViewModel eViewModel = new EmployeeViewModel();

            try
            {
            if (Request.Cookies["MyLeoLoginInfo"] != null)
            {
                //var barchid = Request.Cookies["LoginInfo"].Value;
                    MyLeoRetailer.Models.PreLogin.LoginViewModel lViewModel = new Models.PreLogin.LoginViewModel();
                lViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                    eViewModel.Employee_Branch_List = eRepo.Get_Branch_By_Id(lViewModel.Cookies.User_Id, lViewModel.Cookies.Branch_Ids);

                    eViewModel.Employee.Employee_Id = lViewModel.Cookies.User_Id;

            }
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Employee Controller - ChangeBranch" + ex.Message);
            }
            //End
            return PartialView("_ChangeBranch", eViewModel);
        }

        public ActionResult Save_Employee_Branch_Id(EmployeeViewModel eViewModel)
        {
            var controller = "";

            var method = "";

            try
            {
                var url = Convert.ToString(eViewModel.Page_URL);

                var Branch_Ids = eRepo.Save_Change_BranchId(eViewModel.Employee_Branch_List);

                var Branch_List = eRepo.Change_Branch_List(eViewModel.Employee_Branch_List);

                eViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                var User_Id = eViewModel.Cookies.User_Id;

                Set_Branch_Cookies(User_Id, Branch_Ids, Branch_List);

                eViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                eViewModel.FriendlyMessages.Add(MessageStore.Get("EMP03"));

                eViewModel.Employee_Branch_List = eViewModel.Employee_Branch_List;

                eViewModel.Cookies.Branch_Ids = Branch_Ids;




                //eViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                eViewModel.Cookies.Page_URL = url;

               
                var split = url.Replace("http://", "");//Added by vinod mane 18/10/2016

               // var split = url.Substring(23); 
               

                if (split == "")
                {
                    split = " / /";
                }


                var temp = split.Split('/');


                foreach (var item in temp)
                {
                    for (int i = 1; i < 2; i++)
                    {
                        if (i == 1)
                        {
                            controller = temp[i];
                            break;
                        }
                        else if (i == 2)
                        {
                            method = temp[i];
                        }

                    }

                }

                //foreach (var item in temp)
                //{
                //    for (int i = 0; i < 2; i++)
                //    {
                //        if (i == 0)
                //        {
                //            controller = temp[i];
                //            break;
                //        }
                //        else if (i == 1)
                //        {
                //            method = temp[i];
                //        }

                //    }

                //}


                if (controller == "")
                {
                    controller = "Dashboard";
                    method = "Index";
                }

                if (controller == "dashboard")
                {
                    method = "Index";
                }


                if (method == "")
                {
                    method = "Search";
                }

            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Employee Controller - Set_Branch_Cookies" + ex.Message);
            }
           //End
            return RedirectToAction(method, controller);

            //return View("Search", eViewModel);
        }

        public void Set_Branch_Cookies(int User_Id, string Branch_Ids, List<EmployeeInfo> Branch_List)
        {
            MyLeoRetailer.Models.PreLogin.LoginViewModel loginViewModel = new Models.PreLogin.LoginViewModel();
            LoginRepo _loginRepo = new LoginRepo();
            EmployeeViewModel eViewModel = new EmployeeViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                if (Request.Cookies["MyLeoLoginInfo"] == null)
                {
                    HttpCookie cookies = new HttpCookie("MyLeoLoginInfo");

                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    cookies.Values.Add("MyLeoToken", cookie_Token);

                    cookies.Values.Add("Branch_Ids", Branch_Ids);

                    cookies.Expires = DateTime.Now.AddDays(2);

                    Response.Cookies.Add(cookies);
                }
                else
                {
                    //string branch_list = Branch_List;  

                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    System.Web.HttpContext.Current.Response.Cookies["MyLeoLoginInfo"]["MyLeoToken"] = cookie_Token;

                    System.Web.HttpContext.Current.Response.Cookies["MyLeoLoginInfo"]["Branch_Ids"] = Branch_Ids.ToString();

                    //Response.Cookies["MyLeoLoginInfo"]["Branch_List"] = branch_list;             

                }
            }
            catch (Exception ex)
            {
                HttpContext.Request.Cookies.Clear();
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Employee Controller - Set_Branch_Cookies" + ex.Message);
            }
        }

        //end

        //GAURAVI 5-10-2016

        public PartialViewResult Change_Branch(string Url)
        {
            EmployeeViewModel eViewModel = new EmployeeViewModel();

            if (Request.Cookies["MyLeoLoginInfo"] != null)
            {
                //var barchid = Request.Cookies["LoginInfo"].Value;

                eViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                eViewModel.Employee_Branch_List = eRepo.Get_Branch_By_Id(eViewModel.Cookies.User_Id, eViewModel.Cookies.Branch_Ids);

                eViewModel.Employee.Employee_Id = eViewModel.Cookies.User_Id;

                var branch = eViewModel.Cookies.Branch_Ids;

               
            }

            eViewModel.Page_URL = Url;

            return PartialView("_ChangeBranch", eViewModel);
        }

        //END

        #endregion 

        //Added By Vinod Mane on 27/09/2016
        public JsonResult Check_Existing_Employee_Name(string employee_Name)
        {
            bool check = false;
            EmployeeViewModel eViewModel = new EmployeeViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = eRepo.Check_Existing_Employee_Name(employee_Name);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Employee Controller - Check_Existing_Employee_Name " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //Added By Vinod Mane on 18/10/2016
        public JsonResult Check_Existing_Email_ID(string Email_ID)
        {
            bool check = false;
            EmployeeViewModel eViewModel = new EmployeeViewModel();
            try
            {
                check = eRepo.Check_Existing_Email_ID(Email_ID);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Employee Controller - Check_Existing_Email_ID " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //Added by vinod mane on 17/10/2016
        public JsonResult Compare_Dates(DateTime DOB_Date)
        {
            bool check = true;
            EmployeeViewModel eViewModel = new EmployeeViewModel();
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
                eViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Employee Controller - Compare_Dates " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        // END
    }
}
