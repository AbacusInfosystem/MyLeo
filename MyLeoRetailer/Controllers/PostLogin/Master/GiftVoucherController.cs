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
    public class GiftVoucherController : BaseController
    {
        GiftVoucherRepo gvRepo = new GiftVoucherRepo();

        public GiftVoucherController()
        {
            gvRepo = new GiftVoucherRepo();
        }

        public ActionResult Search()
        {
            GiftVoucherViewModel gvViewModel = new GiftVoucherViewModel();

            try
            {
                if (TempData["gvViewModel"] != null)
                {
                    gvViewModel = (GiftVoucherViewModel)TempData["vcViewModel"];
                }
            }
            catch (Exception ex)
            {
                gvViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }


            return View("Search", gvViewModel);
        }

        public ActionResult Index()
        {
           
            GiftVoucherViewModel gvViewModel = new GiftVoucherViewModel();

            try
            {
                if (TempData["vcViewModel"] != null)
                {
                    gvViewModel = (GiftVoucherViewModel)TempData["vcViewModel"];
                }
            }
            catch (Exception ex)
            {
                gvViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }


            return View("Index", gvViewModel);
        }

        public ActionResult Print(GiftVoucherViewModel gvViewModel)
        {

            try
            {
                gvViewModel.GiftVoucher = gvRepo.Get_Gift_Voucher_By_Id(gvViewModel.GiftVoucher.Gift_Voucher_Id);
            }
            catch (Exception ex)
            {
                gvViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return View("Print", gvViewModel);

        }

        public JsonResult Insert_Gift_Voucher(GiftVoucherViewModel gvViewModel)
        {

            try
            {
                //gvViewModel.GiftVoucher.Vendor_ID = 1;

                Set_Date_Session(gvViewModel.GiftVoucher);

                gvViewModel.GiftVoucher.Gift_Voucher_Id = gvRepo.Insert_Gift_Voucher(gvViewModel.GiftVoucher);

                gvViewModel.FriendlyMessages.Add(MessageStore.Get("GVAT01"));
            }
            catch (Exception ex)
            {
                gvViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(gvViewModel));
        }

        public JsonResult Update_Gift_Voucher(GiftVoucherViewModel gvViewModel)
        {

            try
            {
                Set_Date_Session(gvViewModel.GiftVoucher);

                gvRepo.Update_Gift_Voucher(gvViewModel.GiftVoucher);

                gvViewModel.FriendlyMessages.Add(MessageStore.Get("GVAT02"));
            }
            catch (Exception ex)
            {
                gvViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(gvViewModel));
        }

        public JsonResult Get_Gift_Vouchers(GiftVoucherViewModel gvViewModel)
        {
            

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = gvViewModel.Filter.Gift_Voucher_No; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                gvViewModel.Query_Detail = Set_Query_Details(true, "Gift_Voucher_Id,Gift_Voucher_No", "", "Gift_Voucher", "Gift_Voucher_No", filter, dataOperator); // Set query for grid

                pager = gvViewModel.Grid_Detail.Pager;

                gvViewModel.Grid_Detail = Set_Grid_Details(false, "Gift_Voucher_No,Person_Name,Gift_Voucher_Date,Gift_Voucher_Expiry_Date,Gift_Voucher_Amount,Payment_Mode,Bank_Name,Credit_Card_No", "Gift_Voucher_Id"); // Set grid info for front end listing

                gvViewModel.Grid_Detail.Records = gvRepo.Get_Gift_Vouchers(gvViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, gvViewModel.Grid_Detail); // set pagination for grid

                gvViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                gvViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(gvViewModel));
        }

        public ActionResult Get_Gift_Voucher_By_Id(GiftVoucherViewModel gvViewModel)
        {

            gvViewModel.GiftVoucher = gvRepo.Get_Gift_Voucher_By_Id(gvViewModel.GiftVoucher.Gift_Voucher_Id);

            return View("Index", gvViewModel);
        }

    }
}
