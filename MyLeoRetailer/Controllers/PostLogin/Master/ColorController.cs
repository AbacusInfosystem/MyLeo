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

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    [SessionExpireAttribute]
    public class ColorController :BaseController
    {
        ColorRepo cRepo;

        public ColorController()
        {
            cRepo = new ColorRepo();
        }

        [AuthorizeUserAttribute(AppFunction.Color_Management_Access)]
        public ActionResult Index(ColorViewModel cViewModel)
        {
            try
            {
                if (TempData["cViewModel"] != null)
                {
                    cViewModel = (ColorViewModel)TempData["cViewModel"];
                }
               
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Color Controller - Index " + ex.Message);
            }

            return View("Index",cViewModel);
        }

        public JsonResult Insert_Color(ColorViewModel cViewModel)
        {
            //ColorRepo cRepo = new ColorRepo();

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Color_Management_Create))
                {
                    Set_Date_Session(cViewModel.Color);

                    cViewModel.Color.Colour_Id = cRepo.Insert_Color(cViewModel.Color);

                    cViewModel.FriendlyMessages.Add(MessageStore.Get("COL1"));
                }
                else
                {
                    cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Color Controller - Insert_Color " + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public JsonResult Update_Color(ColorViewModel cViewModel)
        {
            //ColorRepo cRepo = new ColorRepo();

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Color_Management_Edit))
                {
                    Set_Date_Session(cViewModel.Color);

                    cRepo.Update_Color(cViewModel.Color);

                    cViewModel.FriendlyMessages.Add(MessageStore.Get("COL2"));
                }
                else
                {
                    cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Color Controller - Update_Color " + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public JsonResult Get_Colors(ColorViewModel cViewModel)
        {
            //ColorRepo cRepo = new ColorRepo();

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = cViewModel.Filter.Color; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                cViewModel.Query_Detail = Set_Query_Details(false, "Colour_Name,Colour_Id", "", "Colour", "Colour_Name", filter, dataOperator); // Set query for grid

                pager = cViewModel.Grid_Detail.Pager;

                cViewModel.Grid_Detail = Set_Grid_Details(false, "Colour_Name", "Colour_Id"); // Set grid info for front end listing

                cViewModel.Grid_Detail.Records = cRepo.Get_Colors(cViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, cViewModel.Grid_Detail); // set pagination for grid

                cViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Color Controller - Get_Colors " + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public JsonResult Get_Colors_By_Id(int color_Id)
        {
            ColorViewModel cViewModel = new ColorViewModel();
            
            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Color_Management_View))
                {
                    cViewModel.Color = cRepo.Get_Colors_By_Id(Convert.ToInt32(color_Id));
                }
                else
                {
                    cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            { 
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Color Controller - Get_Colors_By_Id " + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public JsonResult Get_Colors_By_Name_Autocomplete(string color_Name)
        {

            ColorViewModel cViewModel = new ColorViewModel();
            List<AutocompleteInfo> brandList = new List<AutocompleteInfo>();

            try
            {

                brandList = cRepo.Get_Colors_By_Name_Autocomplete(color_Name);

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Color Controller - Get_Colors_By_Name_Autocomplete " + ex.Message);
            }

            return Json(brandList, JsonRequestBehavior.AllowGet);
        }

        //Added By Vinod Mane on 23/09/2016
        public JsonResult Check_Existing_Colour_Name(string color_Name)
        {
            bool check = false;
            ColorViewModel cViewModel = new ColorViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = cRepo.Check_Existing_Colour_Name(color_Name);
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Colour Controller - Check_Existing_Colour_Name : " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        //End
    }
}
