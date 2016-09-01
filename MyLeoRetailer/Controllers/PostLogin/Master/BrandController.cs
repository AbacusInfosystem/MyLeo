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

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class BrandController :BaseController
    {
        public BrandRepo bRepo;

        public BrandController()
        {
            bRepo = new BrandRepo();
        }

		public ActionResult Index()
        {
			return View();
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
			}

			return Json(JsonConvert.SerializeObject(bViewModel));
		}

        public JsonResult Get_Brand_By_Id(int Brand_Id)
        {
            BrandViewModel bViewModel = new BrandViewModel();
            try
            {
                bViewModel.Brand.IsActive = bRepo.Get_Brand_By_Id(Convert.ToInt32(Brand_Id));
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(bViewModel));
        }

        public JsonResult Get_Brands_By_Name_Autocomplete(string brand_Name)
        {

            BranchViewModel bViewModel = new BranchViewModel();
            List<AutocompleteInfo> brandList = new List<AutocompleteInfo>();

            try
            {

                brandList = bRepo.Get_Brands_By_Name_Autocomplete(brand_Name);

            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                //Logger.Error("Brand Controller - Get_Brands_By_Name_Autocomplete: " + ex.ToString());
            }

            return Json(brandList, JsonRequestBehavior.AllowGet);
        }

    }
}
