using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
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
using MyLeoRetailerHelper.Logging;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class BrandController : BaseController
    {
        public BrandRepo bRepo;

        public BrandController()
        {
            bRepo = new BrandRepo();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(BrandViewModel bViewModel)
        {
            
            //Added by vinod mane on 06/10/2016
            try
            {
                if (TempData["bViewModel"] != null)
                {
                    bViewModel = (BrandViewModel)TempData["bViewModel"];
                }
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Brand Controller - Index : " + ex.ToString());
            }
            return View("Index", bViewModel);
            //End
        }

		public JsonResult Insert_Brand(BrandViewModel bViewModel)
		{
			try
			{
				Set_Date_Session(bViewModel.Brand);

				bViewModel.Brand.Brand_Id = bRepo.Insert_Brand(bViewModel.Brand);

                bViewModel.FriendlyMessages.Add(MessageStore.Get("BRND01"));
			}
			catch(Exception ex)
			{
				bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Brand Controller - Insert_Brand  " + ex.Message);//Added by vinod mane on 06/10/2016
			}

			return Json(JsonConvert.SerializeObject(bViewModel));
		}

		public JsonResult Update_Brand(BrandViewModel bViewModel)
		{
			try
			{
				Set_Date_Session(bViewModel.Brand);

				bRepo.Update_Brand(bViewModel.Brand);

                bViewModel.FriendlyMessages.Add(MessageStore.Get("BRND02"));

			}
			catch(Exception ex)
			{
				bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Brand Controller - Update_Brand  " + ex.Message);//Added by vinod mane on 06/10/2016
			}

			return Json(JsonConvert.SerializeObject(bViewModel));
		}

        public JsonResult Get_Barnds(BrandViewModel bViewModel)
		{
			string filter = "";

			string dataOperator = "";

			Pagination_Info pager = new Pagination_Info();

			try
			{
                filter = bViewModel.Filter.Brand_Name; // Set filter comma seprated
                //filter = bViewModel.Filter.Brand_Id; // Set filter comma seprated

                dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated
                //dataOperator = DataOperator.Equal.ToString(); // set operator for where clause as comma seprated

                bViewModel.Query_Detail = Set_Query_Details(false, "Brand_Name,Brand_Id", "", "Brand", "Brand_Name", filter, dataOperator); // Set query for grid

				pager = bViewModel.Grid_Detail.Pager;

				bViewModel.Grid_Detail = Set_Grid_Details(false, "Brand_Name", "Brand_Id"); // Set grid info for front end listing

                bViewModel.Grid_Detail.Records = bRepo.Get_Barnds(bViewModel.Query_Detail); // Call repo method 

				Set_Pagination(pager, bViewModel.Grid_Detail); // set pagination for grid

				bViewModel.Grid_Detail.Pager = pager;
			}
			catch(Exception ex)
			{
				bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Brand Controller - Get_Barnds  " + ex.Message);//Added by vinod mane on 06/10/2016
			}

			return Json(JsonConvert.SerializeObject(bViewModel));
		}

        public JsonResult Get_Brand_By_Id(int Brand_Id)
        {
            BrandViewModel bViewModel = new BrandViewModel();
            try
            {
                bViewModel.Brand = bRepo.Get_Brand_By_Id(Convert.ToInt32(Brand_Id));
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Brand Controller - Get_Brand_By_Id  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(JsonConvert.SerializeObject(bViewModel));
        }

        //Added By Vinod Mane on 26/09/2016
        public JsonResult Check_Existing_Brand_Name(string brand_Name)
        {
            bool check = false;
            BrandViewModel bViewModel = new BrandViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = bRepo.Check_Existing_Brand_Name(brand_Name);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Brand Controller - Check_Existing_Brand_Name : " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        //End


    }
}
