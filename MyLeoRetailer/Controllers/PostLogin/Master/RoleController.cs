using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
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

                if (rViewModel.role.Role_Id == 0)
                {
                    rViewModel.role.Role_Id = _rRepo.Insert_Role(rViewModel.role);

                    rViewModel.FriendlyMessages.Add(MessageStore.Get("RL01"));
                }
                else
                {
                    _rRepo.Update_Role(rViewModel.role);

                    rViewModel.FriendlyMessages.Add(MessageStore.Get("RL02"));
                }

            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(rViewModel));
        }


    }
}
