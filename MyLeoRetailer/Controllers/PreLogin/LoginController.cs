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

namespace MyLeoRetailer.Controllers.PreLogin
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public LoginRepo _loginRepo;

        public LoginController()
        {
            _loginRepo = new LoginRepo();
        }

        public ActionResult Index(LoginViewModel lViewModel)
        {
            try
            {
                //if (Request.Cookies["UserInfo"] != null)
                //{
                //    lViewModel.Cookies = Utility.Get_Login_User("UserInfo", "Token");

                //    if (lViewModel.Cookies == null)
                //    {
                //        lViewModel.Friendly_Message.Add(MessageStore.Get("SYS02"));
                //    }
                //}
                //else
                //{
                //    if (TempData["FriendlyMessage"] != null)
                //    {
                //        lViewModel.Friendly_Message.Add((FriendlyMessage)TempData["FriendlyMessage"]);
                //    }
                //}
            }
            catch (Exception ex)
            {
                //Logger.Error("Error at Index : " + ex.Message);
                lViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                return View("Index", lViewModel);
            }

            return View("Index", lViewModel);

        }

        public ActionResult Authenticate(LoginViewModel lViewModel)
        {
            try
            {
                //LoginUserInfo cookies = _loginRepo.AuthenticateUser(lViewModel.Cookies.Username, Utility.Encrypt(lViewModel.Cookies.Password));

                //if (cookies.User_Id != 0 && cookies.Is_Active == true)
                //{
                //    if (cookies.Username == lViewModel.Cookies.Username)
                //    {
                //        SetUsersCookies(lViewModel.Cookies.Username, lViewModel.Cookies.Password);

                //        return RedirectToAction("Index", "Dashboard");
                //    }
                //    else
                //    {
                //        lViewModel.Friendly_Message.Add(MessageStore.Get("SYS02"));

                //        return View("Index", lViewModel);
                //    }
                //}
                //else
                //{
                //    if (cookies.User_Id != 0 && cookies.Is_Active == false)
                //    {
                //        TempData["FriendlyMessage"] = MessageStore.Get("SYS06");
                //    }
                //    else
                //    {
                //        TempData["FriendlyMessage"] = MessageStore.Get("SYS03");
                //    }
                //    return RedirectToAction("Index", "Login");
                //}
            }
            catch (Exception ex)
            { 
                //HttpContext.Request.Cookies.Clear();

                lViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                return RedirectToAction("Index", "Login", lViewModel);
            }

            return RedirectToAction("Index", "Dashboard");
        }

        private void SetUsersCookies(string userName, string password)
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    HttpCookie cookies = new HttpCookie("UserInfo");

                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(userName, password);

                    cookies.Values.Add("Token", cookie_Token);

                    cookies.Expires = DateTime.Now.AddDays(2);

                    Response.Cookies.Add(cookies);
                }
                else
                {
                    string cookie_Token = _loginRepo.Set_User_Token_For_Cookies(userName, password);

                    Response.Cookies["UserInfo"]["Token"] = cookie_Token;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Request.Cookies.Clear();

                //Logger.Error("Error at Login Controller - SetUsersCookies : " + ex.Message);
            }
        }

        public ActionResult Logout(string timeOut)
        {
            LoginUserInfo Cookies = Utility.Get_Login_User("UserInfo", "Token");

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
