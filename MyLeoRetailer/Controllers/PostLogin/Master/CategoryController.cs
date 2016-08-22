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
    public class CategoryController:BaseController
    {
        //
        // GET: /Category/

		public ActionResult Index()
        {
			return View();
        }

		public JsonResult Insert_Category(CategoryViewModel cViewModel)
		{
			CategoryRepo cRepo = new CategoryRepo();

			try
			{
				Set_Date_Session(cViewModel.Category);

				cViewModel.Category.Category_Id = cRepo.Insert_Category(cViewModel.Category);

				cViewModel.FriendlyMessages.Add(MessageStore.Get("CAT01"));
			}
			catch(Exception ex)
			{
				cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return Json(JsonConvert.SerializeObject(cViewModel));
		}

		public JsonResult Update_Category(CategoryViewModel cViewModel)
		{
			CategoryRepo cRepo = new CategoryRepo();

			try
			{
				Set_Date_Session(cViewModel.Category);

				cRepo.Update_Category(cViewModel.Category);

				cViewModel.FriendlyMessages.Add(MessageStore.Get("CAT02"));
			}
			catch(Exception ex)
			{
				cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return Json(JsonConvert.SerializeObject(cViewModel));
		}

		public JsonResult Get_Catgories(CategoryViewModel cViewModel)
		{
			CategoryRepo cRepo = new CategoryRepo();

			CommonManager cMan = new CommonManager();

			string filter = "";

			string dataOperator = "";

			Pagination_Info pager = new Pagination_Info();

			try
			{
				filter = cViewModel.Filter.Category; // Set filter comma seprated

				dataOperator = DataOperator.Like.ToString(); // set operator for where clause as comma seprated

				cViewModel.Query_Detail = Set_Query_Details(false, "Category,Category_Id", "", "Category", "Category", filter, dataOperator); // Set query for grid

				pager = cViewModel.Grid_Detail.Pager;

				cViewModel.Grid_Detail = Set_Grid_Details(false, "Category", "Category_Id"); // Set grid info for front end listing

				cViewModel.Grid_Detail.Records = cRepo.Get_Categories(cViewModel.Query_Detail); // Call repo method 

				Set_Pagination(pager, cViewModel.Grid_Detail); // set pagination for grid

				cViewModel.Grid_Detail.Pager = pager;
			}
			catch(Exception ex)
			{
				cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return Json(JsonConvert.SerializeObject(cViewModel));
		}

		public PartialViewResult Get_Sub_Category_By_Category_Id(int catgeory_Id, string category)
		{
			SubCategoryViewModel sViewModel = new SubCategoryViewModel();

			try
			{
				sViewModel.SubCategory.Category = category;

				sViewModel.SubCategory.Category_Id = catgeory_Id;
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return PartialView("_SubCategory", sViewModel);
		}

		public JsonResult Insert_Sub_Category(SubCategoryViewModel sViewModel)
		{
			SubCategoryRepo sRepo = new SubCategoryRepo();

			try
			{
				Set_Date_Session(sViewModel.SubCategory);

				sViewModel.SubCategory.Sub_Category_Id = sRepo.Insert_Sub_Category(sViewModel.SubCategory);

				sViewModel.FriendlyMessages.Add(MessageStore.Get("SCAT01"));
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return Json(JsonConvert.SerializeObject(sViewModel));
		}

		public JsonResult Update_Sub_Category(SubCategoryViewModel sViewModel)
		{
			SubCategoryRepo sRepo = new SubCategoryRepo();

			try
			{
				Set_Date_Session(sViewModel.SubCategory);

				sRepo.Update_Sub_Category(sViewModel.SubCategory);

				sViewModel.FriendlyMessages.Add(MessageStore.Get("SCAT02"));
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return Json(JsonConvert.SerializeObject(sViewModel));
		}

		public JsonResult Get_Sub_Catgories(SubCategoryViewModel sViewModel)
		{
			SubCategoryRepo cRepo = new SubCategoryRepo();

			CommonManager cMan = new CommonManager();

			string filter = "";

			string dataOperator = "";

			Pagination_Info pager = new Pagination_Info();

			try
			{
				filter = sViewModel.Filter.Category_Id + "," + sViewModel.Filter.Sub_Category;

				dataOperator = DataOperator.Equal.ToString() + "," + DataOperator.Like.ToString();

				sViewModel.Query_Detail = Set_Query_Details(false, "Sub_Category,Sub_Category_Id,Category_Id", "", "Sub_Category", "Category_Id,Sub_Category", filter, dataOperator);

				pager = sViewModel.Grid_Detail.Pager;

				sViewModel.Grid_Detail = Set_Grid_Details(false, "Sub_Category", "Sub_Category_Id");

				sViewModel.Grid_Detail.Records = cRepo.Get_Sub_Categories(sViewModel.Query_Detail);

				Set_Pagination(pager, sViewModel.Grid_Detail);

				sViewModel.Grid_Detail.Pager = pager;
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
			}

			return Json(JsonConvert.SerializeObject(sViewModel));
		}

    }
}
