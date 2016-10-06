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
using MyLeoRetailer.Models.Report;

namespace MyLeoRetailer.Controllers.PostLogin.Report
{
    public class InventoryController : BaseController
    {
        public InventoryRepo _inventoryRepo;


        public InventoryController()
        {
            _inventoryRepo = new InventoryRepo();
        }

		
        public ActionResult Search(InventoryViewModel iViewModel)
        {
            try
            {
                if (TempData["poViewModel"] != null)
                {
                    iViewModel = (InventoryViewModel)TempData["poViewModel"];
                }
            }
            catch (Exception ex)
            {
                iViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnRequestController - Search : " + ex.ToString());
            }
            return View("Search", iViewModel);
        }

        public JsonResult Get_Inventories(InventoryViewModel iViewModel)
		{	
			try
			{
                Pagination_Info pager = new Pagination_Info();

                pager = iViewModel.Grid_Detail.Pager;

                iViewModel.Grid_Detail = Set_Grid_Details(false, "Product_SKU,Branch_Name,Product_Quantity", "Inventory_Id"); 

                iViewModel.Grid_Detail.Records = _inventoryRepo.Get_Inventories(iViewModel.Filter); 

                Set_Pagination(pager, iViewModel.Grid_Detail); 

                iViewModel.Grid_Detail.Pager = pager;
			}
			catch(Exception ex)
			{
				iViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));

                Logger.Error("PurchaseReturnRequestController - Get_Inventories : " + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(iViewModel));
		}
              

    }
}
