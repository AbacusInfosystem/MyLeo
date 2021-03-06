﻿using MyLeoRetailerInfo.PurchaseReturn;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using System.Transactions;
using MyLeoRetailerRepo.Common;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace MyLeoRetailerRepo
{
    public class PurchaseReturnRepo
    {
         SQL_Repo sqlHelper = null;

         public PurchaseReturnRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        private List<SqlParameter> Set_Values_In_Purchase_Return(PurchaseReturnInfo PurchaseReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (PurchaseReturn.Purchase_Return_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Created_By", PurchaseReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", PurchaseReturn.Created_Date));
            }

            sqlParams.Add(new SqlParameter("@Debit_Note_No", PurchaseReturn.Debit_Note_No));

            sqlParams.Add(new SqlParameter("@GR_No", PurchaseReturn.GR_No));

            sqlParams.Add(new SqlParameter("@Vendor_Id", PurchaseReturn.Vendor_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", PurchaseReturn.Purchase_Invoice_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Return_Date", PurchaseReturn.Purchase_Return_Date));
                       
            sqlParams.Add(new SqlParameter("@Total_Quantity", PurchaseReturn.Total_Quantity));

            sqlParams.Add(new SqlParameter("@Total_Amount", PurchaseReturn.Total_Amount));
            
            sqlParams.Add(new SqlParameter("@Discount_Percentage", PurchaseReturn.Discount_Percentage));

            sqlParams.Add(new SqlParameter("@Discount_Amount", PurchaseReturn.Discount_Amount));

            sqlParams.Add(new SqlParameter("@Gross_Amount", PurchaseReturn.Gross_Amount));

            sqlParams.Add(new SqlParameter("@Tax_Percentage", PurchaseReturn.Tax_Percentage));

            sqlParams.Add(new SqlParameter("@Round_Off_Amount", PurchaseReturn.Round_Off_Amount));

            sqlParams.Add(new SqlParameter("@Net_Amount", PurchaseReturn.Net_Amount));

            sqlParams.Add(new SqlParameter("@Logistics_Person_Name", PurchaseReturn.Logistics_Person_Name));
           
            sqlParams.Add(new SqlParameter("@Transporter_Id", PurchaseReturn.Transporter_Id));

            sqlParams.Add(new SqlParameter("@Lr_No", PurchaseReturn.Lr_No));

            if (PurchaseReturn.Lr_Date != DateTime.MinValue)
            {
                sqlParams.Add(new SqlParameter("@Lr_Date", PurchaseReturn.Lr_Date));
            }
            else
            {
                sqlParams.Add(new SqlParameter("@Lr_Date", DateTime.MinValue));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", PurchaseReturn.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseReturn.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Purchase_Return_Item(PurchaseReturnInfo item)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", item.Purchase_Return_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", item.Purchase_Invoice_Id));

            sqlParams.Add(new SqlParameter("@Purchase_Order_Id", item.Purchase_Order_Id));

            sqlParams.Add(new SqlParameter("@SKU_Code", item.SKU_Code));

            sqlParams.Add(new SqlParameter("@Size_Group_Id", item.Size_Group_Id));

            sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id));

            sqlParams.Add(new SqlParameter("@Quantity", item.Quantity));

            sqlParams.Add(new SqlParameter("@Total_Amount", item.Amount));

            sqlParams.Add(new SqlParameter("@Created_By", item.Created_By));

            sqlParams.Add(new SqlParameter("@Created_Date", item.Created_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", item.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", item.Updated_Date));

            sqlParams.Add(new SqlParameter("@Item_Ids", item.Item_Ids));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Purchase_Credit_Note(PurchaseReturnInfo PurchaseReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));

            sqlParams.Add(new SqlParameter("@Status", PurchaseReturn.Status));

            sqlParams.Add(new SqlParameter("@Credit_Note_No", PurchaseReturn.GR_No));

            sqlParams.Add(new SqlParameter("@Credit_Note_Type", 1));

            sqlParams.Add(new SqlParameter("@Credit_Note_Amount", PurchaseReturn.Net_Amount));

            sqlParams.Add(new SqlParameter("@Created_By", PurchaseReturn.Created_By));

            sqlParams.Add(new SqlParameter("@Created_Date", PurchaseReturn.Created_Date));

            sqlParams.Add(new SqlParameter("@Updated_By", PurchaseReturn.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseReturn.Updated_Date));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_GR_No(PurchaseReturnInfo PurchaseReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));

            sqlParams.Add(new SqlParameter("@GR_No", PurchaseReturn.GR_No));

            sqlParams.Add(new SqlParameter("@Updated_By", PurchaseReturn.Updated_By));

            sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseReturn.Updated_Date));

            return sqlParams;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Items_By_SKU_Values(DataRow dr)
        {
            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            if (!dr.IsNull("Article_No"))
            {
                PurchaseReturn.Article_No = Convert.ToString(dr["Article_No"]);
            }

            if (!dr.IsNull("Brand_Id"))
            {
                PurchaseReturn.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);
            }

            if (!dr.IsNull("Brand_Name"))
            {
                PurchaseReturn.Brand = Convert.ToString(dr["Brand_Name"]);
            }

            if (!dr.IsNull("Colour_Id"))
            {
                PurchaseReturn.Color_Id = Convert.ToInt32(dr["Colour_Id"]);
            }

            if (!dr.IsNull("Colour_Name"))
            {
                PurchaseReturn.Color = Convert.ToString(dr["Colour_Name"]);
            }

            if (!dr.IsNull("Category_Id"))
            {
                PurchaseReturn.Category_Id = Convert.ToInt32(dr["Category_Id"]);
            }

            if (!dr.IsNull("Category"))
            {
                PurchaseReturn.Category = Convert.ToString(dr["Category"]);
            }

            if (!dr.IsNull("Sub_Category_Id"))
            {
                PurchaseReturn.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);
            }

            if (!dr.IsNull("Sub_Category"))
            {
                PurchaseReturn.SubCategory = Convert.ToString(dr["Sub_Category"]);
            }

            if (!dr.IsNull("Size_Group_Id"))
            {
                PurchaseReturn.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);
            }

            if (!dr.IsNull("Size_Group_Name"))
            {
                PurchaseReturn.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);
            }

            if (!dr.IsNull("Size_Id"))
            {
                PurchaseReturn.Size_Id = Convert.ToInt32(dr["Size_Id"]);
            }

            if (!dr.IsNull("Size_Name"))
            {
                PurchaseReturn.Size_Name = Convert.ToString(dr["Size_Name"]);
            }

            if (!dr.IsNull("Purchase_Price"))
            {
                PurchaseReturn.WSR_Price = Convert.ToInt32(dr["Purchase_Price"]);
            }

            return PurchaseReturn;
        }
       
        public PurchaseReturnInfo Get_Purchase_Return_Items_By_SKU_Code(string SKU_Code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));

            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_Items_By_SKU_Code.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                PurchaseReturn = Get_Purchase_Return_Items_By_SKU_Values(dr);
            }

            return PurchaseReturn;
        }

        public PurchaseReturnInfo Get_Purchase_Return_Items_By_Barcode(string Barcode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Barcode", Barcode));

            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Invoice_Items_By_Barcode.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                PurchaseReturn = Get_Purchase_Return_Items_By_SKU_Values(dr);
            }

            return PurchaseReturn;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Values(DataRow dr)
        {
            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            PurchaseReturn.Purchase_Return_Id = Convert.ToInt32(dr["Purchase_Return_Id"]);

            PurchaseReturn.Debit_Note_No = Convert.ToString(dr["Debit_Note_No"]);

            PurchaseReturn.GR_No = Convert.ToString(dr["GR_No"]);

            PurchaseReturn.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

            PurchaseReturn.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseReturn.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseReturn.Total_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            PurchaseReturn.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            PurchaseReturn.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

            PurchaseReturn.Logistics_Person_Name = Convert.ToString(dr["Logistics_Person_Name"]);

            PurchaseReturn.Lr_No = Convert.ToString(dr["Lr_No"]);

            PurchaseReturn.Purchase_Return_Date = Convert.ToDateTime(dr["Purchase_Return_Date"]);
           
            if (!dr.IsNull("Vendor_Name"))
            {
                PurchaseReturn.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            }

            if (!dr.IsNull("Purchase_Invoice_No"))
            {
                PurchaseReturn.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);
            }

            return PurchaseReturn;
        }

        public int Insert_Purchase_Return(PurchaseReturnInfo PurchaseReturn)
        {
            PurchaseReturn.Purchase_Return_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Return(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Return.ToString(), CommandType.StoredProcedure));

            foreach (var item in PurchaseReturn.PurchaseReturns)
            {
                item.Purchase_Return_Id = PurchaseReturn.Purchase_Return_Id;

                item.Purchase_Invoice_Id = PurchaseReturn.Purchase_Invoice_Id;

                sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Return_Item(item), Storeprocedures.sp_Insert_Purchase_Return_Item.ToString(), CommandType.StoredProcedure);
            }

            //sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Credit_Note(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Credit_Note.ToString(), CommandType.StoredProcedure);
            
            return PurchaseReturn.Purchase_Return_Id;

        }

        public void Update_Purchase_Return(PurchaseReturnInfo PurchaseReturn)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlHelper.ExecuteScalerObj(Set_Values_In_GR_No(PurchaseReturn), Storeprocedures.sp_Update_Purchase_Return.ToString(), CommandType.StoredProcedure);

                var date = PurchaseReturn.Updated_Date;

                var id = PurchaseReturn.Updated_By;

                PurchaseReturn = Get_Purchase_Return_By_Purchase_Return_Id(PurchaseReturn.Purchase_Return_Id);

                PurchaseReturn.Created_By = id;

                PurchaseReturn.Created_Date = date;

                PurchaseReturn.Updated_By = id;

                PurchaseReturn.Updated_Date = date;

                sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Credit_Note(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Credit_Note.ToString(), CommandType.StoredProcedure);
               
                scope.Complete();

            }
                        
        }

        public DataTable Get_Purchase_Returns(Filter_Purchase_Return filter)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Debit_Note_No", filter.Debit_Note_No));

            sqlParams.Add(new SqlParameter("@GR_No", filter.GR_No));

            dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Returns.ToString(), CommandType.StoredProcedure);

            return dt;
        }


        public List<PurchaseReturnInfo> Get_Purchase_Return_List(ref Pagination_Info Pager, string Debit_Note_No)
        {
            List<PurchaseReturnInfo> PurchaseReturns = new List<PurchaseReturnInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Debit_Note_No", Debit_Note_No));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Returns.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                PurchaseReturns.Add(Get_Purchase_Return_Values(dr));
            }

            return PurchaseReturns;
        }

        //public DataTable Get_Purchase_Returns(QueryInfo query_Details)
        //{
        //    return sqlHelper.Get_Table_With_Where(query_Details);
        //}

        public PurchaseReturnInfo Get_Vendor_Details_By_Id(int vendor_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_ID", vendor_Id));

            PurchaseReturnInfo Vendor = new PurchaseReturnInfo();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Vendor_Details_By_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    Vendor.Vendor_Id = Convert.ToInt32(dr["Vendor_ID"]);

                    Vendor.Tax_Percentage = Convert.ToDecimal(dr["Vendor_Vat_Rate"]);
                }
            }

            return Vendor;
        }

        public List<PurchaseReturnInfo> Get_Purchase_Return_Items_By_Vendor_And_PO(int vendor_Id, int Purchase_Invoice_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Vendor_Id", vendor_Id));
            sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));

            List<PurchaseReturnInfo> purchaseReturnItems = new List<PurchaseReturnInfo>();

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Return_Items_By_Vendor_And_PI.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    purchaseReturnItems.Add(Get_Purchase_Return_Item_Values(dr));
                }
            }

            return purchaseReturnItems;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Item_Values(DataRow dr)
        {
            PurchaseReturnInfo purchaseReturnItem = new PurchaseReturnInfo();

            if (!dr.IsNull("SKU_Code"))
                purchaseReturnItem.SKU_Code = Convert.ToString(dr["SKU_Code"]);

            if (!dr.IsNull("Quantity"))
                purchaseReturnItem.Quantity = Convert.ToInt32(dr["Quantity"]);

            if (!dr.IsNull("Amount"))
                purchaseReturnItem.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr.IsNull("Vendor_Id"))
                purchaseReturnItem.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            if (!dr.IsNull("Purchase_Invoice_Id"))
                purchaseReturnItem.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

            if (!dr.IsNull("Colour_Id"))
                purchaseReturnItem.Color_Id = Convert.ToInt32(dr["Colour_Id"]);

            if (!dr.IsNull("Colour_Name"))
                purchaseReturnItem.Color = Convert.ToString(dr["Colour_Name"]);

            if (!dr.IsNull("Size_Id"))
                purchaseReturnItem.Size_Id = Convert.ToInt32(dr["Size_Id"]);

            if (!dr.IsNull("Size_Name"))
                purchaseReturnItem.Size_Name = Convert.ToString(dr["Size_Name"]);

            //if (!dr.IsNull("Product_Id"))
            //    purchaseReturnItem.Product_Id = Convert.ToInt32(dr["Product_Id"]);

            if (!dr.IsNull("Article_No"))
                purchaseReturnItem.Article_No = Convert.ToString(dr["Article_No"]);

            if (!dr.IsNull("Category_Id"))
                purchaseReturnItem.Category_Id = Convert.ToInt32(dr["Category_Id"]);

            if (!dr.IsNull("Category"))
                purchaseReturnItem.Category = Convert.ToString(dr["Category"]);

            if (!dr.IsNull("Sub_Category_Id"))
                purchaseReturnItem.SubCategory_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

            if (!dr.IsNull("Sub_Category"))
                purchaseReturnItem.SubCategory = Convert.ToString(dr["Sub_Category"]);

            if (!dr.IsNull("Size_Group_Id"))
                purchaseReturnItem.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

            if (!dr.IsNull("Size_Group_Name"))
                purchaseReturnItem.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);

            if (!dr.IsNull("Purchase_Price"))
                purchaseReturnItem.WSR_Price = Convert.ToDecimal(dr["Purchase_Price"]);

            if (!dr.IsNull("Brand_Id"))
                purchaseReturnItem.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

            if (!dr.IsNull("Brand_Name"))
                purchaseReturnItem.Brand = Convert.ToString(dr["Brand_Name"]);

            if (!dr.IsNull("Item_Ids"))
                purchaseReturnItem.Item_Ids = Convert.ToString(dr["Item_Ids"]);

            return purchaseReturnItem;
        }
                 

        //public bool Get_Quantity_By_SKU_Code(string SKU_Code, int Purchase_Invoice_Id, int Quantity)
        //{
        //    bool check = false;
        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    parameters.Add(new SqlParameter("@SKU_Code", SKU_Code));
        //    parameters.Add(new SqlParameter("@Purchase_Invoice_Id", Purchase_Invoice_Id));
        //    parameters.Add(new SqlParameter("@Quantity", Quantity));

        //    DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Return_Request_Quantity_By_SKU_Code.ToString(), CommandType.StoredProcedure);
            
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        check = Convert.ToBoolean(dt.Rows[0]["Quantity"]);

        //    }
        //    return check;
        //}

        //Added by vinod mane on 30/09/2016

        public PurchaseReturnInfo Get_Purchase_Return_By_Purchase_Return_Id(int Purchase_Return_Id)
        {
            
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", Purchase_Return_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Return_by_Purchase_Return_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseReturn = Get_Purchase_Return_Details_Values(dr);
                }
            }
           
            return PurchaseReturn;
        }

        private PurchaseReturnInfo Get_Purchase_Return_Details_Values(DataRow dr)
        {
            PurchaseReturnInfo PurchaseReturn = new PurchaseReturnInfo();

            PurchaseReturn.Purchase_Return_Id = Convert.ToInt32(dr["Purchase_Return_Id"]);

            PurchaseReturn.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseReturn.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

            PurchaseReturn.Debit_Note_No = Convert.ToString(dr["Debit_Note_No"]);

            PurchaseReturn.GR_No = Convert.ToString(dr["GR_No"]);

            PurchaseReturn.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);
           
            PurchaseReturn.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);
           
            //PurchaseReturn.Purchase_Return_Date = Convert.ToDateTime(dr["Purchase_Return_Date"]);

            if (!dr.IsNull("Purchase_Return_Date"))
            {
                PurchaseReturn.Purchase_Return_Date = Convert.ToDateTime(dr["Purchase_Return_Date"]);
            }

            PurchaseReturn.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseReturn.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

            PurchaseReturn.Discount_Percentage = Convert.ToDecimal(dr["Discount_Percentage"]);

            PurchaseReturn.Discount_Amount = Convert.ToDecimal(dr["Discount_Amount"]);

            PurchaseReturn.Gross_Amount = Convert.ToDecimal(dr["Gross_Amount"]);

            PurchaseReturn.Tax_Percentage = Convert.ToDecimal(dr["Tax_Percentage"]);

            PurchaseReturn.Tax_Percentage = Convert.ToDecimal(dr["Tax_Percentage"]);           

            PurchaseReturn.Round_Off_Amount = Convert.ToDecimal(dr["Round_Off_Amount"]);

            PurchaseReturn.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            PurchaseReturn.Logistics_Person_Name = Convert.ToString(dr["Logistics_Person_Name"]);

            PurchaseReturn.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

           // PurchaseReturn.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);
            PurchaseReturn.Transporter_Name = Convert.ToString(dr["Vendor_Name"]);
            

            PurchaseReturn.Lr_No = Convert.ToString(dr["Lr_No"]);
            PurchaseReturn.Lr_Date = Convert.ToDateTime(dr["Lr_Date"]);   
           
            //if (PurchaseReturn.Lr_Date != DateTime.MinValue)
            //{
            //    sqlParams.Add(new SqlParameter("@Lr_Date", PurchaseReturn.Lr_Date));
            //}
            //else
            //{
            //    sqlParams.Add(new SqlParameter("@Lr_Date", DateTime.MinValue));
            //}
            

            //if (!dr.IsNull("Vendor_Name"))
            //{
            //    PurchaseReturn.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);
            //}

            //if (!dr.IsNull("Purchase_Invoice_No"))
            //{
            //    PurchaseReturn.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);
            //}

            return PurchaseReturn;
        }


        public List<PurchaseReturnInfo> Get_Purchase_Return_Item_By_Id(int Purchase_Return_Id)
        {
            List<PurchaseReturnInfo> PurchaseReturnList = new List<PurchaseReturnInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", Purchase_Return_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.sp_Get_Purchase_Return_Item_by_Purchase_Return_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseReturnInfo list = new PurchaseReturnInfo();

                    if (!dr.IsNull("SKU_Code"))
                        list.SKU_Code = Convert.ToString(dr["SKU_Code"]);
                    if (!dr.IsNull("Article_No"))
                        list.Article_No = Convert.ToString(dr["Article_No"]);
                    if (!dr.IsNull("Colour_Name"))
                        list.Color = Convert.ToString(dr["Colour_Name"]);
                    if (!dr.IsNull("Brand_Name"))
                        list.Brand = Convert.ToString(dr["Brand_Name"]);
                    if (!dr.IsNull("Category"))
                        list.Category = Convert.ToString(dr["Category"]);
                    if (!dr.IsNull("Sub_Category"))
                        list.SubCategory = Convert.ToString(dr["Sub_Category"]);
                    if (!dr.IsNull("Size_Group_Name"))
                        list.Size_Group_Name = Convert.ToString(dr["Size_Group_Name"]);
                    if (!dr.IsNull("Size_Name"))
                        list.Size_Name = Convert.ToString(dr["Size_Name"]);
                    if (!dr.IsNull("Quantity"))
                        list.Quantity = Convert.ToInt32(dr["Quantity"]);
                    if (!dr.IsNull("Purchase_Price"))
                        list.WSR_Price = Convert.ToInt32(dr["Purchase_Price"]);                  
                    if (!dr.IsNull("Total_Amount"))
                        list.Amount = Convert.ToInt32(dr["Total_Amount"]);                    

                    PurchaseReturnList.Add(list);
                }
            }

            return PurchaseReturnList;
        }

        //End


        /* Added by gauravi on 16-11-2016*/

        public PurchaseReturnInfo Get_Purchase_Return_Details_By_Id(int Purchase_Return_Id)
        {
            PurchaseReturnInfo purchaseReturn = new PurchaseReturnInfo();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Return_Id", Purchase_Return_Id));

            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Return_Details_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                purchaseReturn.Purchase_Return_Id = Convert.ToInt32(dr["Purchase_Return_Id"]);

                if (!dr.IsNull("Debit_Note_No"))
                    purchaseReturn.Debit_Note_No = Convert.ToString(dr["Debit_Note_No"]);

                if (!dr.IsNull("GR_No"))
                    purchaseReturn.GR_No = Convert.ToString(dr["GR_No"]);

                if (!dr.IsNull("Purchase_Return_Date"))
                    purchaseReturn.Purchase_Return_Date = Convert.ToDateTime(dr["Purchase_Return_Date"]);

                if (!dr.IsNull("Vendor_Id"))
                    purchaseReturn.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

                if (!dr.IsNull("Purchase_Invoice_Id"))
                    purchaseReturn.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);

                if (!dr.IsNull("Purchase_Invoice_No"))
                    purchaseReturn.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);

                if (!dr.IsNull("Logistics_Person_Name"))
                    purchaseReturn.Logistics_Person_Name = Convert.ToString(dr["Logistics_Person_Name"]);

                if (!dr.IsNull("Lr_No"))
                    purchaseReturn.Lr_No = Convert.ToString(dr["Lr_No"]);
                                
                if (!dr.IsNull("Transporter_Id"))
                    purchaseReturn.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

                if (!dr.IsNull("Transporter_Name"))
                    purchaseReturn.Transporter_Name = Convert.ToString(dr["Transporter_Name"]);

                if (!dr.IsNull("Total_Quantity"))
                    purchaseReturn.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

                if (!dr.IsNull("Net_Amount"))
                    purchaseReturn.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

                if (!dr.IsNull("Vendor_Name"))
                    purchaseReturn.Vendor_Name = Convert.ToString(dr["Vendor_Name"]);

                if (!dr.IsNull("Vendor_Address"))
                    purchaseReturn.Vendor_Address = Convert.ToString(dr["Vendor_Address"]);

                if (!dr.IsNull("Vendor_Email1"))
                    purchaseReturn.Vendor_Email1 = Convert.ToString(dr["Vendor_Email1"]);

                if (!dr.IsNull("Vendor_Phone1"))
                    purchaseReturn.Vendor_Phone1 = Convert.ToString(dr["Vendor_Phone1"]);

                if (!dr.IsNull("Vendor_Phone2"))
                    purchaseReturn.Vendor_Phone2 = Convert.ToString(dr["Vendor_Phone2"]);

                if (!dr.IsNull("Company_Name"))
                    purchaseReturn.Company_Name = Convert.ToString(dr["Company_Name"]);

                if (!dr.IsNull("Company_Address"))
                    purchaseReturn.Company_Address = Convert.ToString(dr["Company_Address"]);

            }

            return purchaseReturn;
        }

        public MemoryStream Create_Purchase_Return_Invoice_PDf(PurchaseReturnInfo PurchaseReturn)
        {
            MemoryStream ms = new MemoryStream();

            StringBuilder htmldiv = new StringBuilder();
            StringBuilder htmltbl = new StringBuilder();
            StringBuilder htmltblItem = new StringBuilder();

            htmldiv.Append("<div style='text-align:center'>");
            htmldiv.Append("<h2>" + PurchaseReturn.Company_Name + "</h2>");
            //htmldiv.Append("<br />");
            htmldiv.Append("<h5>" + PurchaseReturn.Company_Address + "</h5>");
            //htmldiv.Append("<br />");
            //htmldiv.Append("<label>Company Address2</label>");
            htmldiv.Append("<h5> <b>PURCHASE RETURN</b></h5>");
            htmldiv.Append("</div>");

            htmltbl.Append("<table>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<td>");
            htmltbl.Append("<div>");
            htmltbl.Append("<label>" + PurchaseReturn.Vendor_Name + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseReturn.Vendor_Address + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseReturn.Vendor_Phone1 + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseReturn.Vendor_Phone2 + "</label>");
            htmltbl.Append("<br />");
            htmltbl.Append("<label>" + PurchaseReturn.Vendor_Email1 + "</label>");
            htmltbl.Append("</div>");
            htmltbl.Append("</td>");
            htmltbl.Append("<td>");
            htmltbl.Append("<div>");
            htmltbl.Append("<table border='1' style='width:500;'>");
            htmltbl.Append("<thead>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Debit Note No.</th>");
            htmltbl.Append("<td>" + PurchaseReturn.Debit_Note_No + "</td>");
            htmltbl.Append("</tr>");//
            htmltbl.Append("<tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Purchase Invoice No.</th>");
            htmltbl.Append("<td>" + PurchaseReturn.Purchase_Invoice_No + "</td>");
            htmltbl.Append("</tr>");//
            htmltbl.Append("<th>Date</th>");
            htmltbl.Append("<td>" + PurchaseReturn.Purchase_Return_Date.ToShortDateString() + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Logistics Person</th>");
            htmltbl.Append("<td>" + PurchaseReturn.Logistics_Person_Name + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Transport</th>");
            htmltbl.Append("<td>" + PurchaseReturn.Transporter_Name + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("<tr>");
            htmltbl.Append("<th>Lr No.</th>");
            htmltbl.Append("<td>" + PurchaseReturn.Lr_No + "</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("</thead>");
            htmltbl.Append("</table>");
            htmltbl.Append("</div>");
            htmltbl.Append("<br />");
            htmltbl.Append("</td>");
            htmltbl.Append("</tr>");
            htmltbl.Append("</table>");

            htmltblItem.Append("<div>");
            htmltblItem.Append("<table border='1'>");
            htmltblItem.Append("<tr>");
            htmltblItem.Append("<th>SKU No.</th>");
            htmltblItem.Append("<th>Article No.</th>");
            htmltblItem.Append("<th>Color</th><th>Brand</th><th>Category</th><th>Sub Category</th><th>Size Group</th>");
            htmltblItem.Append("<th>Size</th><th>QTY</th><th>WSR</th><th>Total Amount</th>");
            htmltblItem.Append("</tr>");
            if (PurchaseReturn.PurchaseReturns.Count > 0)
            {
                foreach (var item in PurchaseReturn.PurchaseReturns)
                {
                    
                    htmltblItem.Append("<tr>");

                    htmltblItem.Append("<td>" + item.SKU_Code + "</td>");
                    htmltblItem.Append("<td>" + item.Article_No + "</td>");
                    htmltblItem.Append("<td>" + item.Color + "</td>");
                    htmltblItem.Append("<td>" + item.Brand + "</td>");
                    htmltblItem.Append("<td>" + item.Category + "</td>");
                    htmltblItem.Append("<td>" + item.SubCategory + "</td>");
                    htmltblItem.Append("<td>" + item.Size_Group_Name + "</td>");
                    htmltblItem.Append("<td>" + item.Size_Name + "</td>");
                    htmltblItem.Append("<td>" + item.Quantity + "</td>");
                    htmltblItem.Append("<td>" + item.WSR_Price + "</td>");
                    htmltblItem.Append("<td>" + item.Amount + "</td>");

                    htmltblItem.Append("</tr>");
                }
                htmltblItem.Append("<tr></tr>");
            }
            htmltblItem.Append("<tr>");
            htmltblItem.Append("<td colspan='6'>Remark : </td>");
            htmltblItem.Append("<td colspan='2' style='text-align: left;'>Total : </td>");
            htmltblItem.Append("<td>" + PurchaseReturn.Total_Quantity + "</td>");
            htmltblItem.Append("<td colspan='1'></td>");
            htmltblItem.Append("<td>" + PurchaseReturn.PurchaseReturns.Sum(a => a.Amount) + "</td>");
            htmltblItem.Append("</tr>");

            htmltblItem.Append("<tr>");
            htmltblItem.Append("<td colspan='13'>Amount(In words) : " + PurchaseReturn.Total_Amount_In_Word + "</td>");
            htmltblItem.Append("</tr>");
            htmltblItem.Append("</table>");
            htmltblItem.Append("</div>");
            htmltblItem.Append("<br />");

            using (ms = new MemoryStream())
            {
                iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont("Courier", 1.4f, Font.NORMAL);
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();
                iTextSharp.text.Paragraph pCompanyName = new iTextSharp.text.Paragraph("Invoice");
                pCompanyName.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                pCompanyName.Font = font;
                document.Add(pCompanyName);
                document.Add(new iTextSharp.text.Paragraph("\n"));

                iTextSharp.text.Paragraph AddLine = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                document.Add(AddLine);

                document.Add(new iTextSharp.text.Paragraph("\n"));

                foreach (IElement element in iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmldiv.ToString()), null))
                {
                    document.Add(element);
                }

                document.Add(new iTextSharp.text.Paragraph("\n"));

                foreach (IElement element in iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmltbl.ToString()), null))
                {
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                    document.Add(element);
                }

                foreach (IElement element in iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmltblItem.ToString()), null))
                {
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                    document.Add(element);
                }

                document.Close();
                writer.Close();

            }

            return ms;
        }

        public void SendDemoEmail(PurchaseReturnInfo PurchaseReturn, string attachmentPath)
        {

            SendEmailInfo emailData = new SendEmailInfo();

            emailData.ID = PurchaseReturn.Vendor_Id;
            emailData.To_Email_Id = PurchaseReturn.Vendor_Email1;
            emailData.Subject = "Purchase Return Invoice";

            StringBuilder html = new StringBuilder();
            html.Append("<table>");

            html.Append("<tr>");
            html.Append("<td>");
            html.Append("Hi " + PurchaseReturn.Vendor_Name + " ,");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td>");
            html.Append("Purchase Return Invoice attached here");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("</table>");

            emailData.Body = html.ToString();

            emailData.AttachmentPath = new List<string>() { attachmentPath };

            MyLeoRetailerRepo.Common.CommonMethods.SendMail(emailData);
        }


        /* End */

    }
}

