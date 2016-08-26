using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerInfo;
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
    public class TaxController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Insert_Tax(TaxViewModel tViewModel)
        {
            TaxRepo tRepo = new TaxRepo();

            try
            {
                Set_Date_Session(tViewModel.Tax);

                tViewModel.Tax.Tax_Id = tRepo.Insert_Tax(tViewModel.Tax);

                tViewModel.FriendlyMessages.Add(MessageStore.Get("TCAT01"));
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(tViewModel));
        }

        public JsonResult Update_Tax(TaxViewModel tViewModel)
        {
            TaxRepo tRepo = new TaxRepo();

            try
            {
                Set_Date_Session(tViewModel.Tax);

                tRepo.Update_Tax(tViewModel.Tax);

                tViewModel.FriendlyMessages.Add(MessageStore.Get("TCAT02"));
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
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
                tViewModel.Tax.Tax_Value = tRepo.Get_Tax_By_Id(Convert.ToInt32(Tax_Id));
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(tViewModel));
        }

    }
}
