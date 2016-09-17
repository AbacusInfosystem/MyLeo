using MyLeoRetailerInfo.PurchaseReturn;
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

        private List<SqlParameter> Set_Values_In_Purchase_Credit_Note(PurchaseReturnInfo PurchaseReturn)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));

            sqlParams.Add(new SqlParameter("@Status", 1));

            sqlParams.Add(new SqlParameter("@Credit_Note_No", PurchaseReturn.Credit_Note_No));

            sqlParams.Add(new SqlParameter("@Credit_Note_Type", 1));

            sqlParams.Add(new SqlParameter("@Credit_Note_Amount", PurchaseReturn.Net_Amount));

            sqlParams.Add(new SqlParameter("@Created_By", PurchaseReturn.Created_By));

            sqlParams.Add(new SqlParameter("@Created_Date", PurchaseReturn.Created_Date));

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
               
        public int Insert_Purchase_Return(PurchaseReturnInfo PurchaseReturn)
        {

            PurchaseReturn.Purchase_Return_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Return(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Return.ToString(), CommandType.StoredProcedure));
                       
            foreach (var item in PurchaseReturn.PurchaseReturns)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Purchase_Return_Id", PurchaseReturn.Purchase_Return_Id));

                sqlParams.Add(new SqlParameter("@Purchase_Invoice_Id", PurchaseReturn.Purchase_Invoice_Id));

                sqlParams.Add(new SqlParameter("@Purchase_Order_Id", item.Purchase_Order_Id));

                sqlParams.Add(new SqlParameter("@SKU_Code", item.SKU_Code));

                sqlParams.Add(new SqlParameter("@Size_Group_Id", item.Size_Group_Id));

                sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id));

                sqlParams.Add(new SqlParameter("@Quantity", item.Quantity));

                sqlParams.Add(new SqlParameter("@Total_Amount", item.Amount));
               
                sqlParams.Add(new SqlParameter("@Created_By", PurchaseReturn.Created_By));

                sqlParams.Add(new SqlParameter("@Created_Date", PurchaseReturn.Created_Date));

                sqlParams.Add(new SqlParameter("@Updated_By", PurchaseReturn.Updated_By));

                sqlParams.Add(new SqlParameter("@Updated_Date", PurchaseReturn.Updated_Date));

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Return_Item.ToString(), CommandType.StoredProcedure);
            }

            sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Credit_Note(PurchaseReturn), Storeprocedures.sp_Insert_Purchase_Credit_Note.ToString(), CommandType.StoredProcedure);

            return PurchaseReturn.Purchase_Return_Id;

        }

        public DataTable Get_Purchase_Returns(QueryInfo query_Details)
        {
            return sqlHelper.Get_Table_With_Where(query_Details);
        }
        
    }
}

