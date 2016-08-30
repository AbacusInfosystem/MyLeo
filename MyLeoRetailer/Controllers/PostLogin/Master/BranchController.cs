using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Branch;
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
    public class BranchController : BaseController
    {
        public BranchRepo bRepo;

        public BranchController()
        {
            bRepo = new BranchRepo();
        }

        public ActionResult Index(BranchViewModel bViewModel)
        {
            try
            {
                if (TempData["bViewModel"] != null)
                {
                    bViewModel = (BranchViewModel)TempData["bViewModel"];
                }
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", bViewModel);
        }

        public ActionResult Search(BranchViewModel bViewModel)
        {
            try
            {
                if (TempData["bViewModel"] != null)
                {
                    bViewModel = (BranchViewModel)TempData["bViewModel"];
                }
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", bViewModel);
        }

        public ActionResult Get_Branch_By_Id(BranchViewModel bViewModel)
        {  
            bViewModel.Branch = bRepo.Get_Branch_By_Id(bViewModel.Branch.Branch_ID);

            bViewModel.Branch.NearLocationDetailsList = bRepo.Get_Near_Branch_Location_By_Id(bViewModel.Branch.Branch_ID);

            bViewModel.Branch.FarLocationDetailsList = bRepo.Get_Far_Branch_Location_By_Id(bViewModel.Branch.Branch_ID);

            return View("Index", bViewModel);
        }

        public ActionResult Insert_Branch(BranchViewModel bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.Branch);

                bViewModel.Branch.Branch_ID = bRepo.Insert_Branch(bViewModel.Branch);                
                
                bRepo.Insert_Near_Branch_Location(bViewModel.Branch);

                bRepo.Insert_Far_Branch_Location(bViewModel.Branch);

                bViewModel.FriendlyMessages.Add(MessageStore.Get("BRNCH01"));                
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["bViewModel"] = bViewModel;

            //return View("Search", bViewModel);   
            return RedirectToAction("Search", bViewModel);
        }

        public ActionResult Update_Branch(BranchViewModel bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.Branch);

                bRepo.Update_Branch(bViewModel.Branch);

                bRepo.Update_Near_Branch_Location(bViewModel.Branch);

                bRepo.Update_Far_Branch_Location(bViewModel.Branch);

                bViewModel.FriendlyMessages.Add(MessageStore.Get("BRNCH02"));                
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["bViewModel"] = bViewModel;

            //return View("Search", bViewModel);
            return RedirectToAction("Search", bViewModel);
        }

        public JsonResult Get_Branchs(BranchViewModel bViewModel)
        {  
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = bViewModel.Filter.Branch_Name;// Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                bViewModel.Query_Detail = Set_Query_Details(true, "Branch_Name,Branch_ID", "", "Branch", "Branch_Name", filter, dataOperator); // Set query for grid

                pager = bViewModel.Grid_Detail.Pager;

                bViewModel.Grid_Detail = Set_Grid_Details(false, "Branch_Name,Branch_Address", "Branch_ID"); // Set grid info for front end listing

                bViewModel.Grid_Detail.Records = bRepo.Get_Branchs(bViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, bViewModel.Grid_Detail); // set pagination for grid

                bViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(bViewModel));
        }
    }
}
