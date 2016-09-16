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
    public class VendorContactController : BaseController
    {

        public ActionResult Search(VendorContactViewModel vcViewModel)
        {
            try
            {
                if (TempData["vcViewModel"] != null)
                {
                    vcViewModel = (VendorContactViewModel)TempData["vcViewModel"];
                }
            }
            catch (Exception ex)
            {
                vcViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }


            return View("Search", vcViewModel);
        }

        public ActionResult Index(VendorContactViewModel vcViewModel)
        {
            VendorRepo vcRepo = new VendorRepo();

            vcViewModel.Vendors = vcRepo.Get_Vendors();

            try
            {
                if (TempData["vcViewModel"] != null)
                {
                    vcViewModel = (VendorContactViewModel)TempData["vcViewModel"];
                }
            }
            catch (Exception ex)
            {
                vcViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }


            return View("Index", vcViewModel);
        }

        public JsonResult Insert_Vendor_Contact(VendorContactViewModel vcViewModel)
        {
            VendorContactRepo vcRepo = new VendorContactRepo();

            try
            {
                //vcViewModel.VendorContact.Vendor_ID = 1;

                Set_Date_Session(vcViewModel.VendorContact);

                vcViewModel.VendorContact.VendorContact_Id = vcRepo.Insert_Vendor_Contact(vcViewModel.VendorContact);

                vcViewModel.FriendlyMessages.Add(MessageStore.Get("VCAT01"));
            }
            catch (Exception ex)
            {
                vcViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(vcViewModel));
        }

        public JsonResult Update_Vendor_Contact(VendorContactViewModel vcViewModel)
        {
            VendorContactRepo vcRepo = new VendorContactRepo();

            try
            {
                Set_Date_Session(vcViewModel.VendorContact);

                vcRepo.Update_Vendor_Contact(vcViewModel.VendorContact);

                vcViewModel.FriendlyMessages.Add(MessageStore.Get("VCAT02"));
            }
            catch (Exception ex)
            {
                vcViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(vcViewModel));
        }

        public JsonResult Get_Vendor_Contacts(VendorContactViewModel vcViewModel)
        {
            VendorContactRepo vcRepo = new VendorContactRepo();

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = vcViewModel.Filter.Vendor_Contact_Name; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                vcViewModel.Query_Detail = Set_Query_Details(true, "VendorContact_Id,Vendor_Contact_Name", "", "VendorContact", "Vendor_Contact_Name", filter, dataOperator); // Set query for grid

                pager = vcViewModel.Grid_Detail.Pager;

                vcViewModel.Grid_Detail = Set_Grid_Details(false, "Vendor_Contact_Name,Address,City,State,Country,Pincode,Mobile1,Email_Id", "VendorContact_Id"); // Set grid info for front end listing

                vcViewModel.Grid_Detail.Records = vcRepo.Get_Vendor_Contacts(vcViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, vcViewModel.Grid_Detail); // set pagination for grid

                vcViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                vcViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(vcViewModel));
        }

        public ActionResult Get_Vendor_Contact_By_Id(VendorContactViewModel vcViewModel)
        {
            VendorContactRepo vcRepo = new VendorContactRepo();

            VendorRepo vRepo = new VendorRepo();

            vcViewModel.Vendors = vRepo.Get_Vendors();

            vcViewModel.VendorContact = vcRepo.Get_Vendor_Contact_By_Id(vcViewModel.VendorContact.VendorContact_Id);

            return View("Index", vcViewModel);
        }

    }
}
