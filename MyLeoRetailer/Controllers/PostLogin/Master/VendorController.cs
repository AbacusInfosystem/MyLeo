﻿using MyLeoRetailer.Common;
using MyLeoRetailer.Filters;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerHelper.Logging;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerManager;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class VendorController : BaseController
    {

        public VendorRepo vRepo;

        CategoryRepo _categoryRepo;

        BrandRepo _brandRepo;

        SubCategoryRepo _subcategoryRepo;

        TaxRepo _taxRepo;

        public VendorController()
        {

            vRepo = new VendorRepo();

            _categoryRepo = new CategoryRepo();

            _brandRepo = new BrandRepo();

            _subcategoryRepo = new SubCategoryRepo();

            _taxRepo = new TaxRepo();

        }

        public ActionResult Index(VendorViewModel vViewModel)
        {
            try
            {
                vViewModel.Categories = _categoryRepo.drp_Get_Categories();

                vViewModel.Brands = _brandRepo.drp_Get_Brands();

                // vViewModel.SubCategorys = _subcategoryRepo.drp_Get_Sub_Categories();//commented by Vinod on 21/09/2016

                vViewModel.VATS = _taxRepo.drp_Get_VAT();

                vViewModel.CSTS = _taxRepo.drp_Get_CST();
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Vendor Controller - Index : " + ex.ToString());//Added by vinod mane on 06/10/2016
            }
            return View("Index", vViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_Access)]
        public ActionResult Search(VendorViewModel vViewModel)
        {

            try
            {
                if (TempData["vViewModel"] != null)
                {
                    vViewModel = (VendorViewModel)TempData["vViewModel"];
                }
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Vendor Controller - Search : " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            return View("Search", vViewModel);
        }

        public JsonResult Get_Vendors(VendorViewModel vViewModel)
        {

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = vViewModel.Filter.Vendor_Name; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                vViewModel.Query_Detail = Set_Query_Details(false, "Vendor_Name,Vendor_Vat_No,Vendor_Vat_Rate,CST_No,CST_Rate,Vendor_Id", "", "Vendor", "Vendor_Name", filter, dataOperator); // Set query for grid (added by vinod mane on 20/09/2016 order by Vendor_Id desc)

                pager = vViewModel.Grid_Detail.Pager;

                vViewModel.Grid_Detail = Set_Grid_Details(false, "Vendor_Name,Vendor_Vat_No,Vendor_Vat_Rate,CST_No,CST_Rate", "Vendor_Id"); // Set grid info for front end listing

                vViewModel.Grid_Detail.Records = vRepo.Get_Vendors(vViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, vViewModel.Grid_Detail); // set pagination for grid

                vViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Vendor Controller - Get_Vendors : " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(vViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_Create)]
        public ActionResult Insert_Vendor(VendorViewModel vViewModel)
        {

            try
            {
                Set_Date_Session(vViewModel.Vendor);

                vViewModel.Vendor.Vendor_Id = vRepo.Insert_Vendor(vViewModel.Vendor);

                vViewModel.FriendlyMessages.Add(MessageStore.Get("V01"));
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));
                Logger.Error("Vendor Controller - Insert_Vendor : " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            //return Json(JsonConvert.SerializeObject(vViewModel));

            TempData["vViewModel"] = (VendorViewModel)vViewModel;

            return RedirectToAction("Search");
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_View)]
        public ActionResult Get_Vendor_By_Id(VendorViewModel vViewModel)
        {

            try
            {
                vViewModel.Vendor = vRepo.Get_Vendor_By_Id(vViewModel.Filter.Vendor_Id);

                vViewModel.Vendor.BankDetailsList = vRepo.Get_Vendor_Bank_Details(vViewModel.Filter.Vendor_Id);

                vViewModel.Vendor.BrandDetailsList = vRepo.Get_Vendor_Brand_Details(vViewModel.Filter.Vendor_Id);

                vViewModel.Vendor.CategoryDetailsList = vRepo.Get_Vendor_Category_Details(vViewModel.Filter.Vendor_Id);

                vViewModel.Vendor.SubCategoryDetailsList = vRepo.Get_Vendor_SubCategory_Details(vViewModel.Filter.Vendor_Id);

            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Vendor Controller - Get_Vendor_By_Id : " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            return Index(vViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_Edit)]
        public ActionResult Update_Vendor(VendorViewModel vViewModel)
        {

            try
            {
                Set_Date_Session(vViewModel.Vendor);

                vRepo.Update_Vendor(vViewModel.Vendor);

                vViewModel.FriendlyMessages.Add(MessageStore.Get("V02"));
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Vendor Controller - Update_Vendor : " + ex.ToString());//Added by vinod mane on 06/10/2016
            }

            TempData["vViewModel"] = (VendorViewModel)vViewModel;

            return RedirectToAction("Search");
        }

        //Added By Vinod Mane on 21/09/2016
        public JsonResult Get_SubCategorylist(int Caterory_id)
        {
            VendorViewModel vViewModel = new VendorViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                // VendorRepo vRepo = new VendorRepo();
                //var result = vRepo.Get_SubCategorylist(Caterory_id); 
                vViewModel.Vendors_Sub_Cat = vRepo.Get_SubCategorylist(Caterory_id);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Vendor Controller - Get_SubCategorylist : " + ex.ToString());
            }
            //End
            return Json(vViewModel.Vendors_Sub_Cat, JsonRequestBehavior.AllowGet);
        }
        //End

        //Added By Vinod Mane on 28/09/2016
        public JsonResult Check_Existing_Vendor_Name(string vendor_name)
        {
            bool check = false;
            VendorViewModel vViewModel = new VendorViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = vRepo.Check_Existing_Vendor_Name(vendor_name);
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Vendor Controller - Check_Existing_Vendor_Name : " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        //End
    }
}
