using MyLeoRetailerInfo.ProductDispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyLeoRetailerRepo.Utility;
using System.Data.SqlClient;
using MyLeoRetailerInfo.Common;

namespace MyLeoRetailerRepo
{
    public class ProductDispatchRepo
    {
        SQL_Repo sqlHelper = null;

        public ProductDispatchRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public DataTable Get_Product_To_Dispatch(Filter filter)
        {

            DataTable dt = new DataTable();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@branch_Name", filter.Branch_Name));

            sqlParam.Add(new SqlParameter("@from_Request_Date", filter.From_Request_Date == DateTime.MinValue ? null : filter.From_Request_Date.ToString("yyyy-MM-dd")));

            sqlParam.Add(new SqlParameter("@to_Request_Date", filter.To_Request_Date == DateTime.MinValue ? null : filter.To_Request_Date.ToString("yyyy-MM-dd ")));

            sqlParam.Add(new SqlParameter("@status", filter.Status));

            dt = sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.sp_Get_Product_To_Dispatch.ToString(), CommandType.StoredProcedure);

            return dt;
        }

        public ProductDispatchInfo Get_Product_To_Dispatch_By_Id(int request_Id, string SKU)
        {
            ProductDispatchInfo product = new ProductDispatchInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@request_Id", request_Id));

            sqlparam.Add(new SqlParameter("@SKU", SKU));

            DataSet ds = sqlHelper.ExecuteDataSet(sqlparam, Storeprocedures.sp_Get_Product_To_Dispatch_By_Id.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                product.Request_Id = Convert.ToInt32(dr["Purchase_Order_Request_Id"]);

                product.SKU = Convert.ToString(dr["SKU_Code"]);

                product.Balance_Quantitya = Convert.ToInt32(dr["Balance_Quantity"]);

                product.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

                product.Quantity = Convert.ToInt32(dr["Quantity"]);

            }

            ProductDispatchInfo dispatch_Products;

            List<ProductDispatchInfo> list_dispatch_Products = new List<ProductDispatchInfo>();

            foreach (DataRow dr in ds.Tables[1].Rows) //for binding grid in index page
            {
                dispatch_Products = new ProductDispatchInfo();

                dispatch_Products.Dispatch_Id = Convert.ToInt32(dr["Dispatch_Id"]);

                dispatch_Products.Dispatch_Item_Id = Convert.ToInt32(dr["Dispatch_Item_Id"]);

                dispatch_Products.Quantity = Convert.ToInt32(dr["Dispatch_Quantity"]);

                dispatch_Products.Dispatch_Date = Convert.ToDateTime(dr["Dispatch_Date"]);

                list_dispatch_Products.Add(dispatch_Products);

                product.Dispatch_Id = dispatch_Products.Dispatch_Id;
            }

            product.grid_Dispatch_List = list_dispatch_Products;

            return product;
        }

        public void Insert(ProductDispatchInfo dispatch, List<ProductDispatchInfo> list_Dispatch)
        {

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@dispatch_Id", dispatch.Dispatch_Id));

            sqlparam.Add(new SqlParameter("@branch_Id", dispatch.Branch_Id));

            sqlparam.Add(new SqlParameter("@request_Id", dispatch.Request_Id)); //use to update Purchase_order_request_consolidation table and insert in Product_Dispatch table

            sqlparam.Add(new SqlParameter("@sku_Code", dispatch.SKU)); //use to update Purchase_order_request_consolidation table

            sqlparam.Add(new SqlParameter("@balance_Quantity", dispatch.Balance_Quantitya)); //use to update Purchase_order_request_consolidation table

            sqlparam.Add(new SqlParameter("@quantity", dispatch.Quantity)); //use to update Purchase_order_request_consolidation table

            sqlparam.Add(new SqlParameter("@created_By", dispatch.Created_By));

            sqlparam.Add(new SqlParameter("@created_Date", dispatch.Created_Date));

            sqlparam.Add(new SqlParameter("@updated_Date", dispatch.Updated_Date));

            sqlparam.Add(new SqlParameter("@updated_By", dispatch.Updated_By));

            string Dispatch_Id = "";

            Dispatch_Id = Convert.ToString(sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Insert_Product_Dispatch.ToString(), CommandType.StoredProcedure));

            if (!string.IsNullOrEmpty(Dispatch_Id))
            {
                dispatch.Dispatch_Id = Convert.ToInt32(Dispatch_Id);
            }


            foreach (var item in list_Dispatch)
            {
                sqlparam = new List<SqlParameter>();

                sqlparam.Add(new SqlParameter("@dispatch_Id", dispatch.Dispatch_Id));

                sqlparam.Add(new SqlParameter("@dispatch_Date", item.Dispatch_Date));

                sqlparam.Add(new SqlParameter("@sku_Code", dispatch.SKU));

                sqlparam.Add(new SqlParameter("@quantity", item.Quantity));

                sqlparam.Add(new SqlParameter("@created_By", dispatch.Created_By));

                sqlparam.Add(new SqlParameter("@created_Date", dispatch.Created_Date));

                sqlparam.Add(new SqlParameter("@updated_Date", dispatch.Updated_Date));

                sqlparam.Add(new SqlParameter("@updated_By", dispatch.Updated_By));

                sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Insert_Product_Dispatch_Items.ToString(), CommandType.StoredProcedure);
            }

        }

        public void Delete_Dispatch_Product(ProductDispatchInfo dispatch)
        {
            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Dispatch_Item_Id", dispatch.Dispatch_Item_Id));

            sqlparam.Add(new SqlParameter("@balance_Quantity", dispatch.Balance_Quantitya));

            sqlparam.Add(new SqlParameter("@request_Id", dispatch.Request_Id)); //use to update Purchase_order_request_consolidation table 

            sqlparam.Add(new SqlParameter("@sku_Code", dispatch.SKU));

            sqlparam.Add(new SqlParameter("@quantity", dispatch.Quantity));

            sqlHelper.ExecuteNonQuery(sqlparam, Storeprocedures.sp_Delete_Dispatch_Product.ToString(), CommandType.StoredProcedure);
        }

        public List<ProductDispatchInfo> Dispatched_Product_Listing(string branch_Ids)
        {
            List<ProductDispatchInfo> product_List = new List<ProductDispatchInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@branch_Ids", branch_Ids));

            DataTable dt = sqlHelper.ExecuteDataTable(sqlparam, Storeprocedures.sp_Dispatched_Product_Listing.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in dt.Rows)
            {
                ProductDispatchInfo product = new ProductDispatchInfo();

                product.Dispatch_Id = Convert.ToInt32(dr["Dispatch_Id"]);

                product.Request_Id = Convert.ToInt32(dr["Request_Id"]); // purchase_Order_Request_Id

                product.Dispatch_Date = Convert.ToDateTime(dr["Dispatch_Date"]);

                product.SKU = Convert.ToString(dr["SKU"]);

                product.Quantity = Convert.ToInt32(dr["Dispatch_Quantity"]);

                product.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

                product_List.Add(product);

            }
            return product_List;
        }

    }
}
