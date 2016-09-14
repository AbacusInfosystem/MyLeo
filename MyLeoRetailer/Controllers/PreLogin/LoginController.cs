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
using MyLeoRetailer.Models.PreLogin;
using MyLeoRetailerInfo.Branch;
using Newtonsoft.Json;

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

            }
            catch (Exception ex)
            {
                lViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                return View("Index", lViewModel);
            }

            return View("Index", lViewModel);

        }

        public JsonResult Get_Employee_Branches(string user_Name)
        {
            List<BranchInfo> branch_List = new List<BranchInfo>();

            try
            {
                branch_List = _loginRepo.Get_Branches(user_Name);
            }
            catch (Exception ex)
            {

            }
            return Json(JsonConvert.SerializeObject(branch_List));
        }


        public ActionResult Authenticate(LoginViewModel lViewModel)
        {
            try
            {
                string Branches = lViewModel.Cookies.Branch_Ids;

                LoginInfo cookies = _loginRepo.AuthenticateUser(lViewModel.Cookies.User_Name, lViewModel.Cookies.Password);
                cookies.Branch_Ids = Branches;


                if (cookies.User_Id != 0 && cookies.Is_Online)
                {
                    if (cookies.User_Name == lViewModel.Cookies.User_Name)
                    {
                        SetUsersCookies(cookies.User_Id);

                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        lViewModel.Friendly_Message.Add(MessageStore.Get("SYS02"));

                        return View("Index", lViewModel);
                    }
                }
                else
                {
                    if (cookies.User_Id != 0 && !cookies.Is_Online)
                    {
                        TempData["FriendlyMessage"] = MessageStore.Get("SYS06");
                    }
                    else
                    {
                        TempData["FriendlyMessage"] = MessageStore.Get("SYS03");
                    }
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            { 

                lViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                HttpContext.Request.Cookies.Clear();

                return RedirectToAction("Index", "Login", lViewModel);
            }

            return RedirectToAction("Index", "Dashboard");
        }

        private void SetUsersCookies(int User_Id)
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    HttpCookie cookies = new HttpCookie("UserInfo");

                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    cookies.Values.Add("Token", cookie_Token);

                    cookies.Expires = DateTime.Now.AddDays(2);

                    Response.Cookies.Add(cookies);
                }
                else
                {
                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(User_Id);

                    Response.Cookies["UserInfo"]["Token"] = cookie_Token;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Request.Cookies.Clear();

                //Logger.Error("Error at Login Controller - SetUsersCookies : " + ex.Message);
            }
        }

        //work from here
        //redirect to dashboard page after login
        public ActionResult Logout(string timeOut)
        {
            LoginInfo Cookies = Utility.Get_Login_User("UserInfo", "Token");

            try
            {
                LogoutUser();

                TempData["FriendlyMessage"] = MessageStore.Get("SYS010");

                //TempData["BrandName"] = Cookies.Brand_Name;
            }
            catch (Exception ex)
            {
                //Logger.Error("Error at Login Controller - Logout: " + ex.ToString());
            }

            return RedirectToAction("Index", "login");
        }

        private void LogoutUser()
        {
            Response.Cookies["UserInfo"].Expires = DateTime.Now.AddYears(-1);

            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";

            Response.AddHeader("Cache-Control", "no-cache");

            Response.Cache.SetNoStore();

            Response.AddHeader("Pragma", "no-cache");
        }

    }
}
