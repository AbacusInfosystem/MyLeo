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
    public class ColorController :BaseController
    {
        ColorRepo cRepo;

        public ColorController()
        {
            cRepo = new ColorRepo();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Insert_Color(ColorViewModel cViewModel)
        {
            //ColorRepo cRepo = new ColorRepo();

            try
            {
                Set_Date_Session(cViewModel.Color);

                cViewModel.Color.Colour_Id = cRepo.Insert_Color(cViewModel.Color);

                cViewModel.FriendlyMessages.Add(MessageStore.Get("COL"));
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public JsonResult Update_Color(ColorViewModel cViewModel)
        {
            //ColorRepo cRepo = new ColorRepo();

            try
            {
                Set_Date_Session(cViewModel.Color);

                cRepo.Update_Color(cViewModel.Color);

                cViewModel.FriendlyMessages.Add(MessageStore.Get("COL2"));
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
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
            }

            return Json(JsonConvert.SerializeObject(cViewModel));
        }

        public JsonResult Get_Colors_By_Id(int color_Id)
        {
            ColorViewModel cViewModel = new ColorViewModel();
            //ColorRepo cRepo = new ColorRepo();   
            try
            {
                cViewModel.Color.Colour_Code = cRepo.Get_Colors_By_Id(Convert.ToInt32(color_Id));
            }
            catch (Exception ex)
            { 
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
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

                //Logger.Error("Brand Controller - Get_Brands_By_Name_Autocomplete: " + ex.ToString());
            }

            return Json(brandList, JsonRequestBehavior.AllowGet);
        }

    }
}
