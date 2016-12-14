using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
    public enum Storeprocedures
    { 
        #region Category
        sp_Get_Categorys,
        sp_Insert_Category,
        sp_Update_Category,
        sp_Get_Category_By_Id,

        sp_Get_Category,
        sp_drp_Get_Brands,
        sp_Check_Existing_Category_Name,//Added by vinod Mane on 26/09/2016
        sp_Check_Existing_Sub_Category_Name,//Added by vinod Mane on 26/09/2016

        #endregion

        #region SubCategory

        //SubCategory
        sp_drp_Get_Sub_Categories,
        sp_Insert_Sub_Category,
        sp_Update_Sub_Category,
        sp_Get_Sub_Category_By_Id,
        sp_Get_Sub_Category_By_Category_Id,//Added by Vinod on 21/09/2016

        //Gauravi  12-9-2016

        sp_Get_SubCategory_Category_By_Id,

        //End

        #endregion

        #region brand

        //brand
        sp_Get_Brands,
        sp_Insert_Brand,
        sp_Update_Brand,
        sp_Get_Brand_By_Id,
        Get_Brands_By_Name_Autocomplete_Sp,
        Get_Brands_Sp,
        sp_Check_Existing_Brand_Name,//Added by vinod mane on 26/09/2016

        #endregion
        
        #region tax
        sp_Insert_Tax,
        sp_Update_Tax,
        sp_Get_Tax_By_Id,
        sp_drp_Get_VAT,
        sp_drp_Get_CST,
        sp_Check_Existing_Tax_Name, //Added by Vinod Mane on 27/09/2016
         #endregion

        #region Vendor Contact
        sp_Insert_Vendor_Contact,
        sp_Update_Vendor_Contact,
        sp_Get_Vendor_Contact_By_Id,
        Get_Vendor_Sp,
        Get_Vendor_By_Id_Sp,
         #endregion

        #region Color
        sp_Get_Colors,
        sp_Insert_Color,
        sp_Update_Color,
        sp_Get_Colors_By_Id,
        Get_Colors_By_Name_Autocomplete_Sp,
        sp_Check_Existing_Colour_Name,//Added by Vinod Mane on 23/09/2016
        #endregion

        #region SizeGroup
        sp_Get_SizeGroup,
        sp_Insert_SizeGroup,
        sp_Update_Size_Group,
         #endregion

        #region Size
        sp_Insert_Size,
        sp_Update_Size,
        sp_Get_Sizes_By_Size_Group_Id,
        Sp_Delete_Size_By_Id,
        sp_Get_SizeGroup_By_Id,
        sp_Check_Existing_Size_Group_Name, //Added by Vinod Mane on 27/09/2016
        #endregion

        #region Employee

        sp_Insert_Employee,
        sp_Update_Employee,
        sp_Get_Employees_By_Id,
        sp_Check_Existing_User_Name,
        //Addition by swapnali | Date:15/09/2016
        sp_Get_Branch_By_EmployeeId,
        //End
        sp_Check_Existing_Employee_Name, //added by vinod mane on 27/09/2016
        sp_Check_Existing_Email_ID,//added by vinod mane on 18/10/2016

        #endregion

        #region Customer
        sp_Insert_Customer,
        sp_Update_Customer,
        sp_Get_Customer_By_Id,
        sp_Get_Customer_By_Mobile,
        Get_Employee_Sp,
        sp_Check_Existing_Customer_Name, //Added by vinod mane on 28/09/2016
         #endregion

        #region GiftVoucher
        sp_Insert_Gift_Voucher,
        sp_Update_Gift_Voucher,
        sp_Get_Gift_Voucher_By_Id,
        Check_Existing_Gift_Voucher_No,
        sp_Get_Gift_Vouchers,
        #endregion
     
        #region Branch

        sp_Insert_Branch,
        sp_Update_Branch,
        sp_Get_Branch_By_Id,
        sp_Insert_Branch_Location,
        //sp_Get_Far_Branch_Location_By_Id,
        //sp_Get_Near_Branch_Location_By_Id,
        sp_Update_Branch_Location,
        sp_Get_Branch_Location_By_Id,
        sp_Delete_Branch_Location_By_Id,
        sp_Get_Employee_Branches,
        sp_Get_Branch,
        sp_Check_Existing_Branch_Name, //Added by vinod mane on 27/09/2016

        #endregion

        #region Logion

        Get_User_Data_By_Token_sp,
        Authenticate_User_sp,
        Sp_Insert_Token_In_User_Table,

        #endregion
                 
        #region Alteration
        sp_Insert_Alteration,
        sp_Update_Alteration,
        sp_Get_Alteration_By_Id,
        sp_Get_Alterations,

        #endregion

        #region SalesInvoice
        Get_SalesInvoice_Sp,
        #endregion

        #region Vendor

        sp_Insert_Vendor,
        sp_Update_Vendor,
        sp_Get_Vendor_By_Id,
        sp_Insert_Vendor_Bank_Details,
        sp_Update_Vendor_Bank_Details,
        sp_Delete_Vendor_Bank_Details_By_Vendor_Id,
        sp_Get_Vendor_Bank_Details_By_Id,
        sp_Insert_Vendor_Brand_Mapping,
        sp_Update_Vendor_Brand_Mapping,
        sp_Delete_Vendor_Brand_Mapping_By_Vendor_Id,
        sp_Get_Vendor_Brand_Mapping_By_Id,
        sp_Insert_Vendor_Category_Mapping,
        sp_Update_Vendor_Category_Mapping,
        sp_Delete_Vendor_Category_Mapping_By_Vendor_Id,
        sp_Get_Vendor_Category_Mapping_By_Id,
        sp_Insert_Vendor_SubCategory_Mapping,
        sp_Update_Vendor_SubCategory_Mapping,
        sp_Delete_Vendor_SubCategory_Mapping_By_Vendor_Id,
        sp_Get_Vendor_SubCategory_Mapping_By_Id,
        sp_Get_Agent,
        sp_Get_Transporter,
        sp_Get_Vendor,
        sp_Get_Vendor_Details_By_Id,
        sp_Check_Existing_Vendor_Name, //Added by Vinod Mane on 28/09/2016

        #endregion

        #region Role

        sp_Insert_Role,
        sp_Update_Role,
        sp_Get_Role_By_Id,
        sp_Get_Role_Access_Functions,
        sp_Insert_Role_Access_Function,
        sp_Update_Role_Access_Function,
        sp_Check_Existing_Role_Name,
        sp_Get_Roles,

        #endregion

        #region Purchase Return

        sp_Insert_Purchase_Return_Item,
        sp_Insert_Purchase_Credit_Note,
        sp_Insert_Purchase_Return,
        sp_Get_Purchase_Return_Items_By_Vendor_And_PI,

        sp_Get_Purchase_Returns,

        sp_Update_Purchase_Return,

        sp_Get_Purchase_Return_Item_by_Purchase_Return_Id, //Added by vinod mane on 30/09/2016
        sp_Get_Purchase_Return_by_Purchase_Return_Id,//Added by vinod mane on 30/09/2016

        sp_Get_Purchase_Return_Details_By_Id,


        #endregion

        #region Purchase Order

        sp_Insert_Purchase_Order,
        sp_Insert_Purchase_Order_Item,
        sp_Update_Purchase_Order,
        sp_Update_Purchase_Order_Item,
        sp_Get_Purchase_Order_By_Id,
        sp_Insert_Purchase_Order_Item_Sizes,

        sp_Get_PurchaseOrderId_By_SKU_POI,

        sp_Get_Article_No_By_Vendor_Id,
        sp_Get_Brand_By_Vendor_Id,
        sp_Get_Category_By_Vendor_Id,
        sp_Get_Sub_Category_By_Vendor_Id,

        sp_Get_Consolidate_Purchase_Order_Item,
        sp_Get_Consolidate_Purchase_Order_Item_Sizes,

        sp_Get_Purchase_Order_Details_By_Id,
        sp_Get_Purchase_Order_Items,
        sp_Get_Purchase_Order_Item_Sizes,

        sp_Get_Purchase_Orders_Detalis,
        sp_Get_Color_By_Vendor_Id,

        //*****//
        sp_Get_Size_Group_By_Article_no,
        sp_Get_Brand_By_Article_no,
        sp_Get_Category_By_Article_no,
        sp_Get_Sub_Category_By_Article_no,

        sp_Get_Color_By_Article_No,

        //*****//
        #endregion

        #region Purchase Invoice

        sp_Insert_Purchase_Invoice,
        sp_Insert_Purchase_Invoice_Item,

        sp_Update_Purchase_Invoice,
        sp_Update_Purchase_Invoice_Item,

        sp_Get_Purchase_Invoice_By_Id,
        sp_Get_Purchase_Invoice_Item_By_Id,

        sp_Get_Purchase_Invoice_Items_By_SKU_Code,
        sp_Get_Purchase_Orders,

        sp_Get_Purchase_Invoice,
        sp_Get_Purchase_Invoices,
        Get_Purchase_Invoice_Data_By_Id_Sp1,



        #endregion

        #region Purchase Order Request

        sp_Insert_Purchase_Order_Request,
        sp_Insert_Purchase_Order_Request_Item,
        sp_Insert_Purchase_Order_Request_Item_Sizes,

        sp_Get_Purchase_Order_Requests,

        sp_Get_Purchase_Order_Request_Details_By_Id,
        sp_Get_Purchase_Order_Request_Items,
        sp_Get_Purchase_Order_Request_Item_Sizes,

        #endregion

        #region Product
        sp_Insert_Product_MRP,
        sp_Insert_Update_Product_MRP,
        sp_Insert_Product,
        sp_Update_Product,
        sp_Get_Sizes_On_SizeGroupId,
        sp_Insert_Vendor_Article_Mapping,
        sp_Get_Product_On_ProductId,
        sp_Get_Colours_On_ColourId,
        sp_Generate_SKU_Code,
        sp_Insert_Product_Images,
        sp_Get_Product_Images_On_ProductId,
        sp_Delete_Product_Image,
        sp_Update_Product_Images,
        sp_Get_Product_MRP_Exist_By_ProductId,
        sp_Get_Product_Description_By_ProductId,
        sp_Get_Product_Color_Exist_By_ProductId,
        sp_Insert_Update_Product_SKU_Map,
        sp_Check_Existing_Article_No,
        sp_Get_Barcodes_On_Product_Id,
        #endregion

        #region Pyable
        Get_Credit_Note_Details_By_Id_Sp,
        Get_Payable_Balance_Amount_By_Id_Sp,
        Get_Payable_Data_By_Id_Sp,
        Get_Payable_Data_Item_By_Id_Sp,
        Get_Payable_Details_By_Id_Sp,
        Insert_Payable_Data_Sp,
        sp_Insert_Payable_Item_Data,
        sp_Temp_Get_Payable_Detail_By_Id1,
        sp_Temp_Get_Payable_Detail,
        sp_Get_Payable_Search_Data12,
        Get_Credit_Note_Amount_By_Id_Sp,
        sp_Get_Payable_Search_Details,

        #endregion

        #region Employee Branch mapping
        //sp_Get_Branch,
        Insert_Employee_Mapping,
        sp_Get_Employee_MapBranch_ById,
        sp_Get_Branch_For_Employee_mapping,
        #endregion

        #region Sales Order

        sp_Get_Customer_Name_By_Mobile_No,
        sp_Get_Sales_Order_Items_By_SKU_Code,
        sp_Insert_Sales_Invoice,
        sp_Insert_Sales_Invoice_Item,
        Sp_Delete_Sales_Order_Items_By_Sales_Invoice_Id,

        sp_Get_Sales_Invoice_Items_By_Sales_Invoice_Id,
        sp_Get_Sales_Invoice_Details_And_Branch_Details_By_Sales_Invoice_Id,
        sp_Check_Mobile_No,
        sp_Get_Credit_Note_Details_By_Customer_Id,
        sp_Get_Gift_Voucher,
        sp_Check_Quantity,
        Get_Sales_Order_Search_Details,
        sp_Insert_Receivable_Item_Data_For_Sales_Order,
        sp_Get_Sales_Summary_Report,


         #endregion

        #region Sales_Report

        sp_Get_Sales_Report,

        #endregion

        #region Sales Return

        sp_Insert_Sales_Return,
        sp_Insert_Sales_Return_Item,
        sp_Insert_Sales_Credit_Notes,
        Sp_Delete_Sales_Return_Items_By_Sales_Return_Id,
        sp_Get_Sales_Return_Details_By_Sales_Return_Id,
        sp_Get_Sales_Return_Items_By_Sales_Return_Id,
        sp_Get_Sales_Return_Items_By_SKU_Code,
        Get_Sales_Return_Search_Details,
        #endregion

        #region Receivable
        sp_Get_Receivable_Search_Data,
        Get_Receivable_Details_By_Id_Sp,
        Get_Credit_Note_Details_By_Id_Sp1,
        sp_Update_Payable_Item,
        Giftvoucher_Data_sp,
        Get_Receivable_Balance_Amount_By_Id_Sp,
        Insert_Receivable_Data_Sp,
        sp_Insert_Receivable_Item_Data,
        sp_Update_Receivable_Item,
        Get_Receivable_Data_Item_By_Id_Sp,
        Get_Receivable_Data_By_Id_Sp,
        sp_Get_Receivables,
        sp_Get_Receivable_Search_Data_new,
        sp_Get_Receivable_Search_Data12,
        Get_Receivable_Credit_Note_Details_By_Id,
        sp_Get_Credit_Note_Details_By_Customer_Id1,
        sp_Get_Receivable_Search_Details,
        sp_Get_Receivable_Search_Details_new1,
        sp_Get_Credit_Note_Details,
        #endregion

        #region Purchase Return Request

        sp_Insert_Purchase_Return_Request,
        sp_Update_Purchase_Return_Request,
        sp_Get_Purchase_Return_Request_By_Id,
        sp_Insert_Purchase_Return_Request_Item,
        sp_Get_Purchase_Return_Requests,
        sp_Get_Purchase_Return_Request_Details,
        sp_Get_Purchase_Invoice_Items_Quantity_By_SKU_Code,

        #endregion
                
        #region Replacement
        //sp_Get_Purchase_Invoice,
        sp_Insert_Replacement,
        sp_Insert_Replacement_Item,
        #endregion

        #region Product warehouse
        sp_Insert_Product_Warehouse,
        sp_Get_SKU_By_ArticleNo_ColorId_SizeId,
        sp_Insert_Purchase_Order_Request_Consolidation,
        sp_Warehouse_Notifiation,
        #endregion

        #region Product Dispatch
        sp_Get_Product_To_Dispatch,
        sp_Get_Product_To_Dispatch_By_Id,
        sp_Insert_Product_Dispatch,
        sp_Insert_Product_Dispatch_Items,
        sp_Delete_Dispatch_Product,
        sp_Get_Product_Quantity_Warehouse,
        sp_Reject_Product_Dispatch,
        sp_Get_Product_To_Dispatch_By_Dispatch_Id,
         #endregion

        #region Product Inward
        sp_Dispatched_Product_Listing,
        sp_Accept_Product_Dispatch,

        #endregion

        #region Inventory

        sp_Get_Inventories,

        #endregion

        #region Sales Report

        sp_Get_Sales_Details,

        #endregion

        #region Barcode

        sp_Get_Barcodes,

        sp_Insert_Barcode,

        sp_Get_Max_Product_SKU_Barcode_Id,

        sp_Get_Barcode_Data_Print_Details_By_SKU_Code,

        sp_Update_Barcode,

        #endregion

    }
}
