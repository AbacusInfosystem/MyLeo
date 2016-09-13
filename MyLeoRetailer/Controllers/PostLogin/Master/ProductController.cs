using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerInfo.Product;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerManager;
using MyLeoRetailerRepo;
using Newtonsoft.Json;
using MyLeoRetailerInfo;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ProductController : BaseController
    {
        //
        // GET: /Product/
        public ProductRepo _ProductRepo;
        //public CategoryRepo _categoryRepo;
        ////public VendorManager _vendorManager;
        //public ColorRepo _colorRepo;
        //public BrandRepo _brandRepo;
        //public SizeGroupRepo _sizeGroupRepo;

        public ProductController()
        {
            _ProductRepo = new ProductRepo(); 
        }

        public ActionResult Index(ProductViewModel pViewModel)
        {
            try
            {
                 if (TempData["pViewModel"] != null)
                {
                    pViewModel = (ProductViewModel)TempData["pViewModel"];
                }
            }
            catch (Exception)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01")); 
            }
            return View("Index", pViewModel);
        }

        public ActionResult Search(ProductViewModel pViewModel)
        {
            try
            {
                if (TempData["pViewModel"] != null)
                {
                    pViewModel = (ProductViewModel)TempData["pViewModel"];
                }
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", pViewModel);
        }

        public ActionResult _ProductPrizing(ProductViewModel pViewModel)
        {
            try
            {
                if (TempData["pViewModel"] != null)
                {
                    pViewModel = (ProductViewModel)TempData["pViewModel"];
                }
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            } 
            return View("_ProductPrizing", pViewModel);
        }

        public ActionResult ProductPrizing(ProductViewModel pViewModel)
        { 
            try
            {
                pViewModel.Color.ProductMRP_N_WSR = _ProductRepo.Get_Sizes_By_SizeGroupId(pViewModel.Product.Product_Id);  
            }
            catch (Exception ex)
            { 
                throw;
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel; 
            return RedirectToAction("_ProductPrizing", pViewModel);
        }
        

        public JsonResult Get_Products(ProductViewModel pViewModel)
        {  
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            //int IsActive = 1;

            try
            {

                filter = pViewModel.Filter.Article_No;//+ "," + IsActive.ToString(); // Set filter comma seprated 

                dataOperator = DataOperator.Like.ToString();// +"," + DataOperator.Equal.ToString(); // set operator for where clause as comma seprated

                pViewModel.Query_Detail = Set_Query_Details(false, "Center_Size,Size_Difference,Product_Id,Size_Group_Id", "", "Product", "Article_No", filter, dataOperator); // Set query for grid

                pager = pViewModel.Grid_Detail.Pager;

                pViewModel.Grid_Detail = Set_Grid_Details(false, "Center_Size,Size_Difference", "Product_Id,Size_Group_Id"); // Set grid info for front end listing

                pViewModel.Grid_Detail.Records = _ProductRepo.Get_Products(pViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

                pViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public ActionResult Insert_Product(ProductViewModel pViewModel)
        {
           // ProductViewModel prViewModel = new ProductViewModel();
            try
            {
                Set_Date_Session(pViewModel.Product);

                pViewModel.Product.Product_Id = _ProductRepo.Insert_Product(pViewModel.Product);

                pViewModel.FriendlyMessages.Add(MessageStore.Get("PROD01"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Index", pViewModel); 
        }

        public ActionResult Update_Product(ProductViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.Product);

                _ProductRepo.Update_Product(pViewModel.Product);

                pViewModel.FriendlyMessages.Add(MessageStore.Get("PROD02"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search", pViewModel);
        }

        //public JsonResult Insert_ProductMRP(ProductViewModel pViewModel)
        //{
        //    try
        //    {
        //        Set_Date_Session(pViewModel.ProductMRP);

        //        //pViewModel.ProductMRP.Brand_Id =
        //        _ProductRepo.Insert_Product_MRP(pViewModel.ProductMRP);

        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("BRND01"));
        //    }
        //    catch (Exception ex)
        //    {
        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(pViewModel));
        //}

        //public JsonResult Update_ProductMRP(ProductViewModel pViewModel)
        //{
        //    try
        //    {
        //        Set_Date_Session(pViewModel.ProductMRP);

        //        _ProductRepo.Update_Product_MRP(pViewModel.ProductMRP);

        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("BRND02"));
        //    }
        //    catch (Exception ex)
        //    {
        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }

        //    return Json(JsonConvert.SerializeObject(pViewModel));
        //}

        public ActionResult Get_Product_By_Id(ProductViewModel pViewModel)
        { 
            try
            {
                pViewModel.Product = _ProductRepo.Get_Product_By_Id(pViewModel.Product.Product_Id);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["pViewModel"] = (ProductViewModel)pViewModel;
            return RedirectToAction("Index", pViewModel);
        }

        //public JsonResult Get_Sizes_By_SizeGroupId(ProductViewModel pViewModel)
        //{
        //    try
        //    {
        //        pViewModel.Product.ProductMRP_N_WSR = _ProductRepo.Get_Sizes_By_SizeGroupId(pViewModel.Product.Size_Group_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }
        //    return Json(JsonConvert.SerializeObject(pViewModel));
        //}

        //public JsonResult Get_Colours_By_ColourId(ProductViewModel pViewModel)
        //{
        //    try
        //    {
        //        pViewModel.ProductMRPs = _ProductRepo.Get_Colours_By_ColourId(pViewModel.Product.Colour_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //    }
        //    return Json(JsonConvert.SerializeObject(pViewModel));
        //}
        
    }
}
