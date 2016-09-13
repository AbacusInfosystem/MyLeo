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

            #endregion

            #region Colour

            routes.MapRoute(
            name: "color-1",
            url: "colour/get-color-list-by-name/{color_Name}",
            defaults: new { controller = "Color", action = "Get_Colors_By_Name_Autocomplete", color_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

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

            #endregion

            #region Employee

            routes.MapRoute(
            name: "employee-1",
            url: "employee/check-user-name/{user_Name}",
            defaults: new { controller = "Employee", action = "Check_Existing_User_Name", user_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" });

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
            defaults: new { controller = "Product", action = "ProductPrizing", brand_Name = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "MyLeoRetailer.Controllers" }); 
            

            #endregion


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Branch", action = "Search", id = UrlParameter.Optional }
            );
        }
    }
}