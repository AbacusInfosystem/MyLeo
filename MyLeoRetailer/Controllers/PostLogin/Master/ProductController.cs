﻿using System;
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
using System.IO;
using System.Configuration;

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

        public ActionResult Search_ProductPrizing(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.ProductMRPs = _ProductRepo.Get_ProductMRP_By_ProductId(pViewModel.Product.Product_Id);
                //List<Int32> copy = pViewModel.Color.ProductMRP_N_WSR.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel;
            return RedirectToAction("_ProductPrizing", pViewModel);
        }

        public JsonResult ProductPrizing(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.ProductMRPs = _ProductRepo.Get_Sizes_By_SizeGroupId(pViewModel.Product.Product_Id, pViewModel.Product.Colour_Id);
            }
            catch (Exception ex)
            {
                throw;
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel; 
            return Json(JsonConvert.SerializeObject(pViewModel));
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
            try
            {
                for (var i = 0; i < pViewModel.Product.ProductImage.Product_Image.Length; i++)
                {
                    if (pViewModel.Product.ProductImage.Product_Image[i] != null && pViewModel.Product.ProductImage.Product_Image[i] != "")
                    {
                        string replace = "";

                        int l = pViewModel.Product.ProductImage.Image_Src[i].IndexOf("base64,");
                        if (l > 0)
                        {
                            replace = pViewModel.Product.ProductImage.Image_Src[i].Substring(0, l) + "base64,";
                        }

                        string convert = pViewModel.Product.ProductImage.Image_Src[i].Replace(replace, " ");

                        string folder_Name = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString());

                        var actual_FileName = "";

                        var path = "";

                        actual_FileName = pViewModel.Product.Article_No + "_" + pViewModel.Product.ProductImage.Product_Image[i];
                        pViewModel.Product.ProductImage.Product_Image[i] = actual_FileName;

                        path = Path.Combine(folder_Name, actual_FileName);

                        System.IO.File.WriteAllBytes(path, Convert.FromBase64String(convert));
                    }
                }

                Set_Date_Session(pViewModel.Product);

                pViewModel.Product.Product_Id = _ProductRepo.Insert_Product(pViewModel.Product, pViewModel.ProductImage);

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
                for (var i = 0; i < pViewModel.Product.ProductImage.Product_Image.Length; i++)
                {
                    if (pViewModel.Product.ProductImage.Product_Image[i] != null && pViewModel.Product.ProductImage.Product_Image[i] != "")
                    {
                        string replace = "";
                        string convert = "";
                        int l = pViewModel.Product.ProductImage.Image_Src[i].IndexOf("base64,");
                        if (l > 0 && l != -1)
                        {
                            replace = pViewModel.Product.ProductImage.Image_Src[i].Substring(0, l) + "base64,"; 
                            convert = pViewModel.Product.ProductImage.Image_Src[i].Replace(replace, " ");
                        }
                        string folder_Name = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString());

                        var actual_FileName = "";

                        var path = "";
                        if(pViewModel.Product.ProductImage.Product_Image[i].IndexOf(pViewModel.Product.Article_No)>-1  )
                            actual_FileName = pViewModel.Product.ProductImage.Product_Image[i];
                        else
                            actual_FileName = pViewModel.Product.Article_No + "_" + pViewModel.Product.ProductImage.Product_Image[i];
                            
                        pViewModel.Product.ProductImage.Product_Image[i] = actual_FileName;

                        path = Path.Combine(folder_Name, actual_FileName);

                        if (convert != "")
                            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(convert));
                    }
                }

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

        public ActionResult Insert_ProductMRP(ProductViewModel pViewModel)
        {
            try
            {
                //string Product_Desc = pViewModel.ProductMRP.Description;
                //Set_Date_Session(pViewModel.ProductMRP);

                _ProductRepo.Insert_Product_MRP(pViewModel.Colors);//, pViewModel.ProductMRP);

                pViewModel.FriendlyMessages.Add(MessageStore.Get("PROD03"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
            }

            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search", pViewModel);
            //return Json(JsonConvert.SerializeObject(pViewModel));
        }

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

        //public ActionResult Product_Image_Upload(ProductViewModel pViewModel)
        //{ 
        //    HttpPostedFileBase fileBase = null;
        //    var actualFileName = "";
        //    var fileName = "";
        //    var path = "";
        //    //bool is_Error = false;    

        //    if (Request.Files.Count > 0)
        //    {
        //        fileBase = Request.Files[0];
        //    }

        //    //string Product_Id = Request.Form.Get("Product_Id");
        //    bool Is_Default = Convert.ToBoolean(Request.Form.Get("Is_Default"));
        //    //if (pViewModel.ProductImage.Count == 0)
        //    //{
        //    //    Is_Default = true;
        //    //}

        //    pViewModel.ProductImage.File = fileBase;

        //    try
        //    {
        //        if (pViewModel.ProductImage.File.ContentLength > 0)
        //        {

        //            fileName = Path.GetFileName(fileBase.FileName);
        //            //actualFileName = "P" + Product_Id + "_" + fileName;

        //            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        //            //path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["BrandLogoPath"].ToString()), actualFileName);
        //            if (Directory.Exists(tempDirectory))
        //            { 
        //                Directory.CreateDirectory(tempDirectory); 
        //            }
        //            pViewModel.ProductImage.File.SaveAs(tempDirectory);
        //            //pViewModel.ProductImage.Product_Id = Convert.ToInt32(Product_Id);
        //            pViewModel.ProductImage.Image_Code = actualFileName;
        //            pViewModel.ProductImage.Is_Default = Is_Default;
        //            //_productManager.Insert_Product_Image(pViewModel.ProductImage, pViewModel.Cookies.User_Id);

        //            //pViewModel.ImagesList = _productManager.Get_Product_Images(Convert.ToInt32(Product_Id));
        //            //pViewModel.Product.Product_Id = Convert.ToInt32(Product_Id);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //       // Logger.Error("Error uploading Product Images  " + ex.Message);
        //    }
        //    TempData["pViewModel"] = pViewModel;
        //    return RedirectToAction("Index", pViewModel);
        //}

        public JsonResult Delete_Product_Image(int Product_Image_Id, int Product_Id, string Product_Image_Name)
        {
            string path = "";
            ProductViewModel pViewModel = new ProductViewModel();
            try
            {
                _ProductRepo.Delete_Product_Image(Product_Image_Id);

                path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ProductImgPath"].ToString()), Product_Image_Name);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                pViewModel.Product = _ProductRepo.Get_Product_Images(Product_Id);
                pViewModel.Product.Product_Id = Product_Id;
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                //Logger.Error("Error Deleting Product Image  " + ex.Message);
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel; 
            return Json(JsonConvert.SerializeObject(pViewModel));
        }
    }
}
