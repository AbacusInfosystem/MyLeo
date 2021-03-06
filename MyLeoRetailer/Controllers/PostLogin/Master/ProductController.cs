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
using MyLeoRetailerHelper.Logging;
using System.Transactions;
using MyLeoRetailer.Filters;
//using BarcodeLib.Barcode;
//using Barcode_Generator;

namespace MyLeoRetailer.Controllers.PostLogin.Master
{
    public class ProductController : BaseController
    {
        //
        // GET: /Product/
       
        public ProductRepo _ProductRepo;

        public ProductController()
        {
            _ProductRepo = new ProductRepo();
        }

        //[AuthorizeUserAttribute(AppFunction.Product_Management_Edit)]
        //[AuthorizeUserAttribute(AppFunction.Product_Management_Create)]
        public ActionResult Index(ProductViewModel pViewModel)
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
                Logger.Error("Product Index  " + ex.Message);
            }
            return View("Index", pViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Product_Management_Access)]
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
                Logger.Error("Product Search  " + ex.Message);
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
                Logger.Error("Product _ProductPrizing  " + ex.Message);
            }
            return View("_ProductPrizing", pViewModel);
        }

        public ActionResult Search_ProductPrizing(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.Colors = _ProductRepo.Get_ProductMRP_By_ProductId(pViewModel.Product.Product_Id);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Product Search_ProductPrizing  " + ex.Message);
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel;
            return RedirectToAction("_ProductPrizing", pViewModel);
        }

        public JsonResult ProductPrizing(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.ProductDescription = _ProductRepo.Get_Sizes_By_SizeGroupId(pViewModel.Product.Product_Id, pViewModel.Product.Colour_Id);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Product Product Prizing  " + ex.Message);
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel;
            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public JsonResult Get_Products(ProductViewModel pViewModel)
        {
            string filter = "";

            string dataOperator = "";

            Pagination_Info pager = new Pagination_Info();

            try
            {

                filter = pViewModel.Filter.Article_No;  // Set filter comma seprated 

                dataOperator = DataOperator.Like.ToString();  // set operator for where clause as comma seprated

                pViewModel.Query_Detail = Set_Query_Details(false, "Article_No,Brand_Name,Category,Sub_Category,Product_Id,Size_Group_Id", "", "VProduct_Brand_Category_SubC_Color", "Article_No", filter, dataOperator); // Set query for grid

                pager = pViewModel.Grid_Detail.Pager;

                pViewModel.Grid_Detail = Set_Grid_Details(false, "Article_No,Brand_Name,Category,Sub_Category", "Product_Id,Size_Group_Id"); // Set grid info for front end listing

                pViewModel.Grid_Detail.Records = _ProductRepo.Get_Products(pViewModel.Query_Detail); // Call repo method 

                Set_Pagination(pager, pViewModel.Grid_Detail); // set pagination for grid

                pViewModel.Grid_Detail.Pager = pager;
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Product Get_Products  " + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        [AuthorizeUserAttribute(AppFunction.Product_Management_Create)]
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

                            if (convert != "")
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
                Logger.Error("Product Insert_Product  " + ex.Message);
              
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Index", pViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Product_Management_Edit)]
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
                            if (pViewModel.Product.ProductImage.Product_Image[i].IndexOf(pViewModel.Product.Article_No) > -1)
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
                Logger.Error("Product Update_Product  " + ex.Message);
            }
            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search", pViewModel);
        }

        public ActionResult Insert_ProductMRP(ProductViewModel pViewModel)
        { 
            try
            { 
                _ProductRepo.Insert_Product_MRP(pViewModel.Colors); 
                pViewModel.FriendlyMessages.Add(MessageStore.Get("PROD03"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Product Insert_ProductMRP  " + ex.Message); 
            }

            TempData["pViewModel"] = pViewModel;
            return RedirectToAction("Search", pViewModel);
        }

        [AuthorizeUserAttribute(AppFunction.Product_Management_View)]
        public ActionResult Get_Product_By_Id(ProductViewModel pViewModel)
        {
            try
            {
                pViewModel.Product = _ProductRepo.Get_Product_By_Id(pViewModel.Product.Product_Id);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
                Logger.Error("Product Get_Product_By_Id " + ex.Message);
            }

            TempData["pViewModel"] = (ProductViewModel)pViewModel;
            return RedirectToAction("Index", pViewModel);
        }

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
                Logger.Error("Product Delete Image  " + ex.Message);
            }
            TempData["pViewModel"] = (ProductViewModel)pViewModel;
            return Json(JsonConvert.SerializeObject(pViewModel));
        }

        public JsonResult Check_Existing_Article_No(string Article_No)
        {
            bool check = false;
            ColorViewModel cViewModel = new ColorViewModel();//Added by vinod mane on 06/10/2016
            try
            {
                check = _ProductRepo.Check_Existing_Article_No(Article_No);
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));//Added by vinod mane on 06/10/2016
                Logger.Error("Product Controller - Check_Existing_Article_No : " + ex.ToString());
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Get_All_Barcodes_toPrint(ProductViewModel pViewModel)
        //{
        //    try
        //    {
        //        pViewModel.ProductMRPs = _ProductRepo.Get_All_Barcodes_toPrint(pViewModel.Product.Product_Id,pViewModel.Product.Colour_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        pViewModel.FriendlyMessages.Add(MessageStore.Get("SYS01"));
        //        Logger.Error("Product Product Prizing  " + ex.Message);
        //    } 

        //    return View("PrintBarcode", pViewModel);
        //}
    }
}
