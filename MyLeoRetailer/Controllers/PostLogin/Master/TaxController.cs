using MyLeoRetailer.Common;
using MyLeoRetailer.Filters;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerManager;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    [SessionExpireAttribute]
    public class TaxController : BaseController
    {

        [AuthorizeUserAttribute(AppFunction.Tax_Management_Access)]
        public ActionResult Index(TaxViewModel tViewModel)
        {
            //return View("Index", tViewModel);

            try
            {
                if (TempData["tViewModel"] != null)
                {
                    tViewModel = (TaxViewModel)TempData["tViewModel"];
                }
                
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Tax Controller - Index  " + ex.Message);//Added by vinod mane on 06/10/2016
            }
            return View("Index", tViewModel);
        }

        public JsonResult Insert_Tax(TaxViewModel tViewModel)
        {
            TaxRepo tRepo = new TaxRepo();

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Tax_Management_Create))
                {
                    Set_Date_Session(tViewModel.Tax);

                    tViewModel.Tax.Tax_Id = tRepo.Insert_Tax(tViewModel.Tax);

                    tViewModel.FriendlyMessages.Add(MessageStore.Get("TCAT01"));
                }
                else
                {
                    tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - Insert_Tax" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(tViewModel));
        }

        public JsonResult Update_Tax(TaxViewModel tViewModel)
        {
            TaxRepo tRepo = new TaxRepo();

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Tax_Management_Edit))
                {
                    Set_Date_Session(tViewModel.Tax);

                    tRepo.Update_Tax(tViewModel.Tax);

                    tViewModel.FriendlyMessages.Add(MessageStore.Get("TCAT02"));
                }
                else
                {
                    tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - Update_Tax" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(tViewModel));
        }

        public JsonResult Get_Taxes(TaxViewModel tViewModel)
        {
            TaxRepo tRepo = new TaxRepo();

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            //int Is_Active = 1;

            try
            {
                filter = tViewModel.Filter.Tax_Name; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                tViewModel.Query_Detail = Set_Query_Details(false, "Tax_Name,Tax_Id,Tax_Value", "", "Tax", "Tax_Name", filter, dataOperator); // Set query for grid

                pager = tViewModel.Grid_Detail.Pager;

                tViewModel.Grid_Detail = Set_Grid_Details(false, "Tax_Name", "Tax_Id"); // Set grid info for front end listing

                tViewModel.Grid_Detail.Records = tRepo.Get_Taxes(tViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, tViewModel.Grid_Detail); // set pagination for grid

                tViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - Get_Taxes" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(tViewModel));
        }

        //public JsonResult Get_Tax_By_Id(TaxViewModel tViewModel)
        //{
        //    //TaxViewModel tViewModel = new TaxViewModel();
        //    TaxRepo tRepo = new TaxRepo();
        //    try
        //    {
        //        tViewModel.Tax.Tax_Value = tRepo.Get_Tax_By_Id(tViewModel.Tax.Tax_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(tViewModel));
        //}

        public JsonResult Get_Tax_By_Id(int Tax_Id)
        {
            TaxViewModel tViewModel = new TaxViewModel();
            TaxRepo tRepo = new TaxRepo();
            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Tax_Management_View))
                {
                    tViewModel.Tax = tRepo.Get_Tax_By_Id(Convert.ToInt32(Tax_Id));
                }
                else
                {
                    tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - Get_Tax_By_Id" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(tViewModel));
        }

        //Added By Vinod Mane on 27/09/2016
        public JsonResult Check_Existing_Tax_name(string Tax_name)
        {
            TaxRepo tRepo = new TaxRepo();
            TaxViewModel tViewModel = new TaxViewModel();//Added by vinod mane on 06/10/2016
            bool check = false;
            try
            {
                check = tRepo.Check_Existing_Tax_name(Tax_name);
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Tax Controller - Check_Existing_Tax_name : " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        //End

    }
}
