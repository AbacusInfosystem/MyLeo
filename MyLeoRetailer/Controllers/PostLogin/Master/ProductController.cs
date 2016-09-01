using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLeoRetailer.Common;
using MyLeoRetailer.Models;
using MyLeoRetailerHelper;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerManager;
using MyLeoRetailerRepo;
using Newtonsoft.Json;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ProductController : BaseController
    {
        //
        // GET: /Product/
        public ProductRepo _productRepo;
        public CategoryRepo _categoryRepo;
        //public VendorManager _vendorManager;
        public ColorRepo _colorRepo;
        public BrandRepo _brandRepo;
        public SizeGroupRepo _sizeGroupRepo;

        public ProductController()
        {
            _productRepo = new ProductRepo();
            _categoryRepo = new CategoryRepo();
           // _vendorManager = new VendorManager();
            _colorRepo = new ColorRepo();
            _brandRepo = new BrandRepo();
            _sizeGroupRepo = new SizeGroupRepo();
        }

        public ActionResult Index(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.Categories = _categoryRepo.Get_Categorys();
                //pViewModel.Vendors = _vendorManager.Get_Vendors();
                pViewModel.Colors = _colorRepo.Get_Colours();
                pViewModel.Brands = _brandRepo.Get_All_Barnds();
                pViewModel.SizeGroups = _sizeGroupRepo.Get_All_SizeGroups();
            }
            catch (Exception)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01")); 
            }
            return View("Index", pViewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult Get_Products(ProductViewModel pViewModel)
        {
            ProductRepo pRepo = new ProductRepo();

            CommonManager cMan = new CommonManager();

            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            //int IsActive = 1;

            try
            {

                filter = pViewModel.Filter.SKU_Code;//+ "," + IsActive.ToString(); // Set filter comma seprated 

                dataOperator = DataOperator.Like.ToString();// +"," + DataOperator.Equal.ToString(); // set operator for where clause as comma seprated

                pViewModel.Query_Detail = Set_Query_Details(false, "Center_Size,Purchase_Price,Size_Difference,MRP_Price,Product_Id", "", "Product", "Center_Size", filter, dataOperator); // Set query for grid

                pager = pViewModel.Grid_Detail.Pager;

                pViewModel.Grid_Detail = Set_Grid_Details(false, "Product_Name,Product_Address,Product_City,Product_EmailId", "Product_Id"); // Set grid info for front end listing

                pViewModel.Grid_Detail.Records = pRepo.Get_Products(pViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

                pViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            return Json(JsonConvert.SerializeObject(pViewModel));
        }
    }
}
