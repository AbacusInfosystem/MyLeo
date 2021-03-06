﻿using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ReplacementController : BaseController
    {
        VendorRepo vRepo = new VendorRepo();
        ReplacementRepo rRepo = new ReplacementRepo();


        #region View Actions
        public ActionResult Index(ReplacementViewModel rViewmodel)
        {
            try
            {
                rViewmodel.Vendors = vRepo.Get_Vendors();
                rViewmodel.PurchaseInvoices = rRepo.Get_Purchase_Invoice();
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                rViewmodel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Replacement Controller - Index  " + ex.Message);
            }
            //End
            return View(rViewmodel);
        }

        public ActionResult Search(ReplacementViewModel rViewmodel)
        {
            return View(rViewmodel);
        }


        public ActionResult Insert(ReplacementViewModel rViewmodel)
        {
            try
            {
                Set_Date_Session(rViewmodel.Replacement);
                rRepo.Insert(rViewmodel.Replacement, rViewmodel.Replacements);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                rViewmodel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Replacement Controller - Insert  " + ex.Message);
            }
            //End
            return RedirectToAction("Index");
        }

        #endregion

        public JsonResult Get_Replacemant(ReplacementViewModel rViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = rViewModel.Filter.Replacement_No;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString();// set operator for where clause as comma seprated

                rViewModel.Query_Detail = Set_Query_Details(true, "Replacement_No,Replacement_Id", "", "Replacement", "Replacement_No", filter, dataOperator); // Set query for grid

                pager = rViewModel.Grid_Detail.Pager;

                rViewModel.Grid_Detail = Set_Grid_Details(false, "Replacement_No", "Replacement_Id"); // Set grid info for front end listing

                rViewModel.Grid_Detail.Records = rRepo.Get_Replacement(rViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, rViewModel.Grid_Detail); // set pagination for grid

                rViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Replacement Controller - Get_Replacemant  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }

    }
}
