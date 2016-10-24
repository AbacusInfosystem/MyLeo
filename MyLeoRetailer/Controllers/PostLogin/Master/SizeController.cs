using MyLeoRetailer.Common;
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
    [SessionExpireAttribute]
    public class SizeController:BaseController
    {

        public SizeGroupRepo sgRepo;

        public SizeController()
        {
            sgRepo = new SizeGroupRepo();
        }

        [AuthorizeUserAttribute(AppFunction.Size_Management_Access)]
        public ActionResult Index(SizeGroupViewModel sgViewModel)
        {
            return View("Index", sgViewModel);            
        }

       

        public JsonResult Insert_Size_Group(SizeGroupViewModel sgViewModel)
        {

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Size_Management_Create))
                {
                    Set_Date_Session(sgViewModel.SizeGroup);

                    sgViewModel.SizeGroup.Size_Group_Id = sgRepo.Insert_Size_Group(sgViewModel.SizeGroup);

                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SIZEG1"));
                }
                else
                {
                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));

                }
                
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SY01"));

                Logger.Error("Size Controller - Insert_Size_Group" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sgViewModel));
        }

        public JsonResult Update_Size_Group(SizeGroupViewModel sgViewModel)
        {          

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Size_Management_Edit))
                {
                    Set_Date_Session(sgViewModel.SizeGroup);

                    sgRepo.Update_Size_Group(sgViewModel.SizeGroup);

                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SIZEG2"));
                }
                else
                {
                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Size Controller - Update_Size_Group" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sgViewModel));
        }

        public JsonResult Get_SizeGroups(SizeGroupViewModel sgViewModel)
        {        

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = sgViewModel.Filter.Size_Group_Name; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                sgViewModel.Query_Detail = Set_Query_Details(false, "Size_Group_Name,Size_Group_Id", "", "Size_Group", "Size_Group_Name", filter, dataOperator); // Set query for grid

                pager = sgViewModel.Grid_Detail.Pager;

                sgViewModel.Grid_Detail = Set_Grid_Details(false, "Size_Group_Name", "Size_Group_Id"); // Set grid info for front end listing

                sgViewModel.Grid_Detail.Records = sgRepo.Get_SizeGroups(sgViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, sgViewModel.Grid_Detail); // set pagination for grid

                sgViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Size Controller - Get_SizeGroups" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sgViewModel));
        }

        //public JsonResult Get_Size_Group_Name_By_Id(int size_group_Id, string size_group_name)
        //{
        //    SizeGroupViewModel sgViewModel = new SizeGroupViewModel();

        //    try
        //    {
        //        sgViewModel.SizeGroup.Size_Group_Name = size_group_name;

        //        sgViewModel.SizeGroup.Size_Group_Id = size_group_Id;

        //    }
        //    catch (Exception ex)
        //    {
        //        sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(sgViewModel));
        //}

        public JsonResult Get_SizeGroup_By_Id(int size_group_Id)
        {
            SizeGroupViewModel sgViewModel = new SizeGroupViewModel();           

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Size_Management_View))
                {
                    sgViewModel.SizeGroup = sgRepo.Get_SizeGroup_By_Id(Convert.ToInt32(size_group_Id));
                }
                else
                {
                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Size Controller - Get_SizeGroup_By_Id" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sgViewModel));
        }

        public JsonResult Get_Sizes(int size_group_Id)
        {
            SizeGroupViewModel sgViewModel = new SizeGroupViewModel();
            try
            {               
                sgViewModel.SizeList = sgRepo.Get_Sizes(size_group_Id);
            }
            //Added by vinod mane on 06/10/2016
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Size Controller - Get_Sizes" + ex.Message);
            }
            //End
            return Json(JsonConvert.SerializeObject(sgViewModel));
        }

        public JsonResult Insert_Size(SizeGroupViewModel sgViewModel)
        {         

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Size_Management_Create))
                {
                    Set_Date_Session(sgViewModel.SizeGroup);

                    sgRepo.Insert_Size(sgViewModel.SizeList, sgViewModel.SizeGroup);

                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SIZE1"));
                }
                else
                {
                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));
                }
                
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Size Controller - Insert_Size" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sgViewModel));
        }

        public JsonResult Update_Size(SizeGroupViewModel sgViewModel)
        {         

            try
            {
                if (Utility.Check_Access_Function_Authorization(AppFunction.Size_Management_Edit))
                {
                    Set_Date_Session(sgViewModel.SizeGroup);

                    sgRepo.Update_Size(sgViewModel.SizeList, sgViewModel.SizeGroup);

                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SIZE2"));
                }
                else
                {
                    sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS011"));

                }
                
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("Size Controller - Update_Size" + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sgViewModel));
        }
    
        //public JsonResult Delete_Size_By_Id(int size_Id)
        //{
        //    SizeGroupViewModel sgViewModel = new SizeGroupViewModel();

        //    SizeGroupRepo sgRepo = new SizeGroupRepo();

        //     sgRepo.Delete_Size_By_Id(size_Id);

        //    return Json(JsonConvert.SerializeObject(sgViewModel));
        //}   
        //End

        //Added By Vinod Mane on 23/09/2016

        public JsonResult Check_Existing_Size_Group_Name(string size_group_name)
        {
            bool check = false;
            SizeGroupViewModel sgViewModel = new SizeGroupViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = sgRepo.Check_Existing_Size_Group_Name(size_group_name);
            }
            catch (Exception ex)
            {
                sgViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Size Controller - Check_Existing_Size_Group : " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        //End

    }
}