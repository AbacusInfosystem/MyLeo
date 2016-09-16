using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
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
    public class RoleController : BaseController
    {
        RoleRepo _rRepo = null;

        public RoleController()
        {
            _rRepo = new RoleRepo();
        }

        public ActionResult Index(RoleViewModel rViewModel)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
            return View("Index", rViewModel);
        }


        public JsonResult Save_Role(RoleViewModel rViewModel)
        {
            try
            {
                Set_Date_Session(rViewModel.role);

                foreach (var item in rViewModel.accessFunctions)
                {
                    item.Is_Active = true;
                    Set_Date_Session(item);
                }

                if (rViewModel.role.Role_Id == 0)
                {
                    rViewModel.role.Role_Id = _rRepo.Insert_Role(rViewModel.role);

                    _rRepo.Save_Role_Access_Function(rViewModel.accessFunctions, rViewModel.role.Role_Id);

                    rViewModel.FriendlyMessages.Add(MessageStore.Get("RL01"));
                }
                else
                {
                    _rRepo.Update_Role(rViewModel.role);

                    _rRepo.Save_Role_Access_Function(rViewModel.accessFunctions, rViewModel.role.Role_Id);

                    rViewModel.FriendlyMessages.Add(MessageStore.Get("RL02"));
                }

            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }


        public JsonResult Get_Roles(RoleViewModel rViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {
                filter = rViewModel.Filter.Role; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

                rViewModel.Query_Detail = Set_Query_Details(false, "Role_Name,Role_Id", "", "Role", "Role_Name", filter, dataOperator); // Set query for grid

                pager = rViewModel.Grid_Detail.Pager;

                rViewModel.Grid_Detail = Set_Grid_Details(false, "Role_Name", "Role_Id"); // Set grid info for front end listing

                rViewModel.Grid_Detail.Records = _rRepo.Get_Roles(rViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, rViewModel.Grid_Detail); // set pagination for grid

                rViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }


        public JsonResult Get_Role_By_Id(int role_Id)
        {
            RoleViewModel rViewModel = new RoleViewModel();

            try
            {
                rViewModel.role = _rRepo.Get_Role_By_Id(Convert.ToInt32(role_Id));
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }


        public JsonResult Get_Role_Access_Functions(int role_Id)
        {

            RoleViewModel rViewModel = new RoleViewModel();

            try
            {
                rViewModel.accessFunctions = _rRepo.Get_Role_Access_Functions(role_Id);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }


        public JsonResult Check_Existing_Role_Name(string role_Name)
        {
            bool check = false;
            try
            {
                check = _rRepo.Check_Existing_Role_Name(role_Name);
            }
            catch (Exception ex)
            {

            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }


    }
}
