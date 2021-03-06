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
using MyLeoRetailer.Models.PreLogin;
using MyLeoRetailerInfo.Branch;
using Newtonsoft.Json;
using MyLeoRetailerHelper.Logging;

namespace MyLeoRetailer.Controllers.PreLogin
{
    public class LoginController : Controller
    {
        
        public LoginRepo _loginRepo;

        public LoginController()
        {
            _loginRepo = new LoginRepo();
        }

        public ActionResult Index(LoginViewModel lViewModel)
        {
            try
            {

                if (Request.Cookies["MyLeoLoginInfo"] != null)
                {
                    lViewModel.Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

                    if (lViewModel.Cookies == null)
                    {
                        lViewModel.FriendlyMessages.Add(MessageStore.Get("SYS02"));
                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                else
                {
                    if (TempData["FriendlyMessages"] != null)
                    {
                        lViewModel.FriendlyMessages.Add((FriendlyMessage)TempData["FriendlyMessages"]);
                    }
                }

            }
            catch (Exception ex)
            {
                lViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Login Controller - Index  " + ex.Message);//Added by vinod mane on 06/10/2016

                return View("Index", lViewModel);
            }

            return View("Index", lViewModel);

        }

        public JsonResult Get_Employee_Branches(string user_Name)
        {
            List<BranchInfo> branch_List = new List<BranchInfo>();
            LoginViewModel lViewModel = new LoginViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                branch_List = _loginRepo.Get_Branches(user_Name);
            }
            catch (Exception ex)
            {
                lViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Login Controller - Get_Employee_Branches  " + ex.Message);//Added by vinod mane on 06/10/2016
            }
            return Json(JsonConvert.SerializeObject(branch_List));
        }

        public ActionResult Authenticate(LoginViewModel lViewModel)
        {
            try
            {
                string role_name = "";
               
                LoginInfo cookies = _loginRepo.AuthenticateUser(lViewModel.Cookies.User_Name, lViewModel.Cookies.Password);
                
                if (cookies.User_Id != 0 && cookies.Is_Online)
                {
                    if (cookies.User_Name == lViewModel.Cookies.User_Name)
                    {
                        SetUsersCookies(cookies.User_Id, lViewModel.Cookies.Branch_Ids);

                        role_name = _loginRepo.Get_Role_Name_By_User_Id(cookies.User_Id);

                        if (role_name == "Sales Manager")
                        {
                            return RedirectToAction("Index", "SalesOrder");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }                        
                    }
                    else
                    {
                        lViewModel.FriendlyMessages.Add(MessageStore.Get("SYS02"));

                        return View("Index", lViewModel);
                    }
                }
                else
                {
                    if (cookies.User_Id != 0 && !cookies.Is_Online)
                    {
                        TempData["FriendlyMessages"] = MessageStore.Get("SYS06");
                    }
                    else
                    {
                        TempData["FriendlyMessages"] = MessageStore.Get("SYS03");
                    }
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {

                lViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Login Controller - Authenticate  " + ex.Message);//Added by vinod mane on 06/10/2016
                HttpContext.Request.Cookies.Clear();

                return RedirectToAction("Index", "Login", lViewModel);
            }

        }

        private void SetUsersCookies(int User_Id, string Branch_Ids)
        {
            LoginViewModel loginViewModel = new LoginViewModel();

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
                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    Response.Cookies["MyLeoLoginInfo"]["MyLeoToken"] = cookie_Token;

                    Response.Cookies["MyLeoLoginInfo"]["Branch_Ids"] = Branch_Ids;

                }
            }
            catch (Exception ex)
            {
                HttpContext.Request.Cookies.Clear();

                loginViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Login Controller - SetUsersCookies  " + ex.Message);//Added by vinod mane on 06/10/2016
                //Logger.Error("Error at Login Controller - SetUsersCookies : " + ex.Message);
            }
        }

        public ActionResult Logout()
        {
            //LoginInfo Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

            LoginViewModel lViewModel = new LoginViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                LogoutUser();

                TempData["FriendlyMessages"] = MessageStore.Get("SYS010");

            }
            catch (Exception ex)
            {
                //Logger.Error("Error at Login Controller - Logout: " + ex.ToString());
                lViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Login Controller - Logout  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return RedirectToAction("Index", "login");
        }

        private void LogoutUser()
        {
            Response.Cookies["MyLeoLoginInfo"].Expires = DateTime.Now.AddYears(-1);

            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";

            Response.AddHeader("Cache-Control", "no-cache");

            Response.Cache.SetNoStore();

            Response.AddHeader("Pragma", "no-cache");
        }

    }
}
