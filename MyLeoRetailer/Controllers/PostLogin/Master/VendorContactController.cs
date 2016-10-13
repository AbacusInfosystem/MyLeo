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
    public class VendorContactController : BaseController
    {
        [AuthorizeUserAttribute(AppFunction.Vendor_Management_Access)]
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
                Logger.Error("VendorContact Controller - Search  " + ex.Message);//Added by vinod mane on 06/10/2016
            }


            return View("Search", vcViewModel);
        }

        public ActionResult Index(VendorContactViewModel vcViewModel)
        {
            //Added by Vinod Mane on 21/09/2016

            //VendorRepo vcRepo = new VendorRepo(); 

          //  vcViewModel.Vendors = vcRepo.Get_Vendors();
            
            VendorContactRepo vcRepo = new VendorContactRepo();
            vcViewModel.Vendor_Contact = vcRepo.Get_Vendors();
            //End
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
                Logger.Error("VendorContact Controller - Index  " + ex.Message);//Added by vinod mane on 06/10/2016
            }


            return View("Index", vcViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_Create)]
        public ActionResult Insert_Vendor_Contact(VendorContactViewModel vcViewModel)
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
                Logger.Error("VendorContact Controller - Insert_Vendor_Contact  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            TempData["vcViewModel"] = (VendorContactViewModel)vcViewModel;
            return RedirectToAction("Search");
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_Edit)]
        public ActionResult Update_Vendor_Contact(VendorContactViewModel vcViewModel)
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
                Logger.Error("VendorContact Controller - Update_Vendor_Contact  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            TempData["vcViewModel"] = (VendorContactViewModel)vcViewModel;
            return RedirectToAction("Search");
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
                Logger.Error("VendorContact Controller - Get_Vendor_Contacts  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(vcViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Vendor_Management_View)]
        public ActionResult Get_Vendor_Contact_By_Id(VendorContactViewModel vcViewModel)
        {

            try
            {
                //   VendorRepo vRepo = new VendorRepo();
                VendorContactRepo vcRepo = new VendorContactRepo();
                //Added by Vinod Mane on 21/09/2016
                //  vcViewModel.Vendors = vRepo.Get_Vendors();
                vcViewModel.Vendor_Contact = vcRepo.Get_Vendors();
                //End

                vcViewModel.VendorContact = vcRepo.Get_Vendor_Contact_By_Id(vcViewModel.VendorContact.VendorContact_Id);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                vcViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("VendorContact Controller - Get_Vendor_Contact_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return View("Index", vcViewModel);
        }

    }
}
