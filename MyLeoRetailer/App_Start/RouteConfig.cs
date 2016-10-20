using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyLeoRetailer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Autocomplete Lookup

            routes.MapRoute(
            name: "AutocompleteLookup-1",
            url: "autocomplete/autocomplete-get-lookup-data",
            defaults: new { controller = "AutocompleteLookup", action = "Load_Modal_Data", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "AutocompleteLookup-2",
            url: "autocompleteLookup/get-lookup-data-by-id",
            defaults: new { controller = "AutocompleteLookup", action = "Get_Lookup_Data_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            #region Brand

            routes.MapRoute(
            name: "brand-1",
            url: "brand/get-brand-list-by-name/{brand_Name}",
            defaults: new { controller = "Brand", action = "Get_Brands_By_Name_Autocomplete", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            //Added By Vinod Mane on 23/09/2016
            routes.MapRoute(
           name: "brand-2",
           url: "brand/check-brand-name/{brand_Name}",
           defaults: new { controller = "Brand", action = "Check_Existing_Brand_Name", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            #endregion

            #region Colour

            routes.MapRoute(
            name: "color-1",
            url: "colour/get-color-list-by-name/{color_Name}",
            defaults: new { controller = "Color", action = "Get_Colors_By_Name_Autocomplete", color_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            //Added By Vinod Mane on 23/09/2016
            routes.MapRoute(
           name: "color-2",
           url: "colour/check-colour-name/{color_Name}",
           defaults: new { controller = "Color", action = "Check_Existing_Colour_Name", color_Name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End
            #endregion

            #region Category

            routes.MapRoute(
            name: "category-1",
            url: "category/get-category-by-id/{Category_Id}",
            defaults: new { controller = "Category", action = "Get_Category_By_Id", Category_Id = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "category-2",
            url: "category/get-sub-category-by-id/{Sub_category_Id}",
            defaults: new { controller = "Category", action = "Get_Sub_Category_By_Id", Sub_category_Id = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            //Added By Vinod Mane on 23/09/2016
            routes.MapRoute(
           name: "category-3",
           url: "category/check-category-name/{category_Name}",
           defaults: new { controller = "Category", action = "Check_Existing_Category_Name", category_Name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            //Added By Vinod Mane on 23/09/2016
            routes.MapRoute(
           name: "category-4",
           url: "sub-category/check-sub-category-name/{sub_category_Name}",
           defaults: new { controller = "Category", action = "Check_Existing_Sub_Category_Name", sub_category_Name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            #endregion

            #region Size

            //Added By Vinod Mane on 27/09/2016
            routes.MapRoute(
           name: "size-1",
           url: "size/check-size-group-name/{size_group_name}",
           defaults: new { controller = "Size", action = "Check_Existing_Size_Group_Name", size_group_name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            #endregion

            #region Tax
          
            //Added By Vinod Mane on 27/09/2016
            routes.MapRoute(
           name: "Tax-1",
           url: "Tax/check-tax-name/{Tax_name}",
           defaults: new { controller = "Tax", action = "Check_Existing_Tax_name", Tax_name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End
                      

            #endregion

            #region Cusatomer
            //Added By Vinod Mane on 27/09/2016
            routes.MapRoute(
           name: "customer-1",
           url: "customer/check-customer-name/{customer_name}",
           defaults: new { controller = "Customer", action = "Check_Existing_Customer_Name", customer_name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End
            #endregion

            #region Vendor
            //Added By Vinod Mane on 27/09/2016
            routes.MapRoute(
           name: "vendor-1",
           url: "vendor/check-vendor-name/{vendor_name}",
           defaults: new { controller = "Vendor", action = "Check_Existing_Vendor_Name", vendor_name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End
            #endregion

            #region Branch

            //Added By Vinod Mane on 27/09/2016
            routes.MapRoute(
           name: "Branch-1",
           url: "Branch/check-Branch-name/{Branch_Name}",
           defaults: new { controller = "Branch", action = "Check_Existing_Branch_Name", Branch_Name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            #endregion

            #region Employee

            routes.MapRoute(
            name: "employee-1",
            url: "employee/check-user-name/{user_Name}",
            defaults: new { controller = "Employee", action = "Check_Existing_User_Name", user_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            //Addition by swapnali | Date:16/09/2016
            //routes.MapRoute(
            //name: "employee-2",
            //url: "employee/save-branch",
            //defaults: new { controller = "Employee", action = "Save_Employee_Branch_Id", user_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            //namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            //Added By Vinod Mane on 27/09/2016
            routes.MapRoute(
           name: "employee-2",
           url: "employee/check-employee-name/{employee_Name}",
           defaults: new { controller = "Employee", action = "Check_Existing_Employee_Name", employee_Name = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            //Added By Vinod Mane on 18/10/2016
            routes.MapRoute(
           name: "employee-3",
           url: "employee/check-Email_ID/{Email_ID}",
           defaults: new { controller = "Employee", action = "Check_Existing_Email_ID", Email_ID = UrlParameter.Optional, id = UrlParameter.Optional },
           namespaces: new string[] { "MyLeoRetailer.Controllers" });
            //End

            #endregion

            #region Role

            routes.MapRoute(
            name: "Role-1",
            url: "role/save-role",
            defaults: new { controller = "Role", action = "Save_Role", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Role-2",
            url: "role/get-roles",
            defaults: new { controller = "Role", action = "Get_Roles", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Role-3",
            url: "role/get-role-by-id",
            defaults: new { controller = "Role", action = "Get_Role_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Role-4",
            url: "role/get-role-access-functions/",
            defaults: new { controller = "Role", action = "Get_Role_Access_Functions", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Role-5",
            url: "role/check-role-name/{role_Name}",
            defaults: new { controller = "Role", action = "Check_Existing_Role_Name", role_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            #region Product

            routes.MapRoute(
            name: "Product-1",
            url: "Product/Insert_Product",
            defaults: new { controller = "Product", action = "Insert_Product", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-2",
            url: "Product/Update_Product",
            defaults: new { controller = "Product", action = "Update_Product", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-3",
            url: "Product/Get_Product_By_Id",
            defaults: new { controller = "Product", action = "Get_Product_By_Id", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-4",
            url: "Product/Get_Products",
            defaults: new { controller = "Product", action = "Get_Products", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-5",
            url: "Product/Get_Sizes_By_SizeGroupId",
            defaults: new { controller = "Product", action = "Get_Sizes_By_SizeGroupId", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" }); 

            routes.MapRoute(
            name: "Product-6",
            url: "Product/Get_Colours_By_ColourId",
            defaults: new { controller = "Product", action = "Get_Colours_By_ColourId", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "Product-7",
            url: "Product/serch-ProductPrizing",
            defaults: new { controller = "Product", action = "Search_ProductPrizing", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" }); 
            
                routes.MapRoute(
            name: "Product-8",
            url: "Product/MRP-ProductPrizing",
            defaults: new { controller = "Product", action = "ProductPrizing", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

                routes.MapRoute(
               name: "Product-9",
               url: "Product/Insert_ProductMRP",
               defaults: new { controller = "Product", action = "Insert_ProductMRP", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
               namespaces: new string[] { "MyLeoRetailer.Controllers" }); 

              routes.MapRoute(
               name: "Product-10",
               url: "Product/Product_Image_Upload",
               defaults: new { controller = "Product", action = "Product_Image_Upload", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
               namespaces: new string[] { "MyLeoRetailer.Controllers" });

              routes.MapRoute(
        name: "Product-11",
        url: "product/check-article-no",
        defaults: new { controller = "Product", action = "Check_Existing_Article_No", color_Name = UrlParameter.Optional, id = UrlParameter.Optional },
        namespaces: new string[] { "MyLeoRetailer.Controllers" });
            
            #endregion

            #region Login

            routes.MapRoute(
            name: "login-1",
            url: "login/get-employee-branches",
            defaults: new { controller = "Login", action = "Get_Employee_Branches", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });



            #endregion


            #region Purchase Return Request

            routes.MapRoute(
            name: "purchase-return-request-1",
            url: "purchase-return-request/get-purchase-return-request",
            defaults: new { controller = "PurchaseReturnRequest", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "purchase-return-request-2",
            url: "purchase-return-request/create-purchase-return-request",
            defaults: new { controller = "PurchaseReturnRequest", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "purchase-return-request-3",
            url: "purchase-return-request/get-purchase-return-request-item-by-sku-code",
            defaults: new { controller = "PurchaseReturnRequest", action = "Get_Purchase_Return_Item_By_SKU_Code", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" }); 

            routes.MapRoute(
            name: "purchase-return-request-4",
            url: "purchase-return-request/save-purchase-return-request",
            defaults: new { controller = "PurchaseReturnRequest", action = "Save_Purchase_Return_Request", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "purchase-return-request-5",
            url: "purchase-return-request/get-vendor-and-purchase-invoices",
            defaults: new { controller = "PurchaseReturnRequest", action = "Get_Vendor_Details_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "purchase-return-request-6",
            url: "purchase-return-request/seatch-purchase-return-request",
            defaults: new { controller = "PurchaseReturnRequest", action = "Get_Purchase_Return_Requests", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

            routes.MapRoute(
            name: "purchase-return-request-7",
            url: "purchase-return-request/view-purchase-return-request",
            defaults: new { controller = "PurchaseReturnRequest", action = "Get_Purchase_Return_Request_Details_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });


            routes.MapRoute(
      name: "purchase-return-request-8",
      url: "purchase-return-request/get-quantity-item-by-sku-code",
      defaults: new { controller = "PurchaseReturnRequest", action = "Get_Quantity_By_SKU_Code", id = UrlParameter.Optional },
      namespaces: new string[] { "MyLeoRetailer.Controllers" });

            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}