using MyLeoRetailerInfo.PurchaseOrder;
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
    public class PurchaseOrderRepo
    {
        SQL_Repo sqlHelper = null;

        public PurchaseOrderRepo()
		{
			sqlHelper = new SQL_Repo();
		}


        public List<SqlParameter> Set_Values_In_Purchase_Order(PurchaseOrderInfo PurchaseOrder)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PurchaseOrder.Purchase_Order_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Created_Date", PurchaseOrder.Created_Date));

                sqlParam.Add(new SqlParameter("@Created_By", PurchaseOrder.Created_By));
            }

            sqlParam.Add(new SqlParameter("@Purchase_Order_No", PurchaseOrder.Purchase_Order_No));

            //sqlParam.Add(new SqlParameter("@Purchase_Order_Date", PurchaseOrder.Purchase_Order_Date));

            sqlParam.Add(new SqlParameter("@Branch_Id", PurchaseOrder.Branch_Id));

            sqlParam.Add(new SqlParameter("@Vendor_Id", PurchaseOrder.Vendor_Id));

            sqlParam.Add(new SqlParameter("@Agent_Id", PurchaseOrder.Agent_Id));

            sqlParam.Add(new SqlParameter("@Shipping_Address", PurchaseOrder.Shipping_Address));

            sqlParam.Add(new SqlParameter("@Transporter_Id", PurchaseOrder.Transporter_Id));

            //sqlParam.Add(new SqlParameter("@Start_Supply_Date", PurchaseOrder.Start_Supply_Date));

            //sqlParam.Add(new SqlParameter("@Stop_Supply_Date", PurchaseOrder.Stop_Supply_Date));

            sqlParam.Add(new SqlParameter("@Total_Quantity", PurchaseOrder.Total_Quantity));

            sqlParam.Add(new SqlParameter("@Net_Amount", PurchaseOrder.Net_Amount));

            if (PurchaseOrder.Purchase_Order_Date == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Date", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Date", PurchaseOrder.Purchase_Order_Date));
            }

            if (PurchaseOrder.Start_Supply_Date == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Start_Supply_Date", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Start_Supply_Date", PurchaseOrder.Start_Supply_Date));
            }

            if (PurchaseOrder.Stop_Supply_Date == DateTime.MinValue)
            {
                sqlParam.Add(new SqlParameter("@Stop_Supply_Date", null));
            }
            else
            {
                sqlParam.Add(new SqlParameter("@Stop_Supply_Date", PurchaseOrder.Stop_Supply_Date));
            }
                        

            sqlParam.Add(new SqlParameter("@Updated_Date", PurchaseOrder.Updated_Date));

            sqlParam.Add(new SqlParameter("@Updated_By", PurchaseOrder.Updated_By));

            return sqlParam;
        }

        public List<SqlParameter> Set_Values_In_Purchase_Order_Item(PurchaseOrderInfo PurchaseOrder)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (PurchaseOrder.Purchase_Order_Item_Id != 0)
            {
                sqlParam.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.Purchase_Order_Item_Id));
            }
            
            sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

            sqlParam.Add(new SqlParameter("@Article_No", PurchaseOrder.Article_No));

            sqlParam.Add(new SqlParameter("@Colour_Id", PurchaseOrder.Colour_Id));

            sqlParam.Add(new SqlParameter("@Brand_Id", PurchaseOrder.Brand_Id));

            sqlParam.Add(new SqlParameter("@Category_Id", PurchaseOrder.Category_Id));

            sqlParam.Add(new SqlParameter("@Sub_Category_Id", PurchaseOrder.Sub_Category_Id));

            sqlParam.Add(new SqlParameter("@Size_Group_Id", PurchaseOrder.Size_Group_Id));

            sqlParam.Add(new SqlParameter("@Start_Size", PurchaseOrder.Start_Size));

            sqlParam.Add(new SqlParameter("@End_Size", PurchaseOrder.End_Size));

            sqlParam.Add(new SqlParameter("@Center_Size", PurchaseOrder.Center_Size));

            sqlParam.Add(new SqlParameter("@Purchase_Price", PurchaseOrder.Purchase_Price));

            sqlParam.Add(new SqlParameter("@Size_Difference", PurchaseOrder.Size_Difference));

            sqlParam.Add(new SqlParameter("@Total_Amount", PurchaseOrder.Total_Amount));

            
            return sqlParam;
        }
        
        private PurchaseOrderInfo Get_Purchase_Order_Values(DataRow dr)
        {
            PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();

            PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

            PurchaseOrder.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

            //PurchaseOrder.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);

            PurchaseOrder.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

            PurchaseOrder.Vendor_Id = Convert.ToInt32(dr["Vendor_Id"]);

            PurchaseOrder.Agent_Id = Convert.ToInt32(dr["Agent_Id"]);

            PurchaseOrder.Shipping_Address = Convert.ToString(dr["Shipping_Address"]);

            PurchaseOrder.Transporter_Id = Convert.ToInt32(dr["Transporter_Id"]);

            //PurchaseOrder.Start_Supply_Date = Convert.ToDateTime(dr["Start_Supply_Date"]);

            //PurchaseOrder.Stop_Supply_Date = Convert.ToDateTime(dr["Stop_Supply_Date"]);

            PurchaseOrder.Total_Quantity = Convert.ToInt32(dr["Total_Quantity"]);

            PurchaseOrder.Net_Amount = Convert.ToDecimal(dr["Net_Amount"]);

            if (dr.IsNull("Purchase_Order_Date"))
            {
                PurchaseOrder.Purchase_Order_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseOrder.Purchase_Order_Date = Convert.ToDateTime(dr["Purchase_Order_Date"]);
            }

            if (dr.IsNull("Start_Supply_Date"))
            {
                PurchaseOrder.Start_Supply_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseOrder.Start_Supply_Date = Convert.ToDateTime(dr["Start_Supply_Date"]);
            }

            if (dr.IsNull("Stop_Supply_Date"))
            {
                PurchaseOrder.Stop_Supply_Date = DateTime.MinValue;
            }
            else
            {
                PurchaseOrder.Stop_Supply_Date = Convert.ToDateTime(dr["Stop_Supply_Date"]);
            }
          
            PurchaseOrder.Created_Date = Convert.ToDateTime(dr["Created_Date"]);

            PurchaseOrder.Created_By = Convert.ToInt32(dr["Created_By"]);

            PurchaseOrder.Updated_Date = Convert.ToDateTime(dr["Updated_Date"]);

            PurchaseOrder.Updated_By = Convert.ToInt32(dr["Updated_By"]);



            PurchaseOrder.Purchase_Order_Item_Id = Convert.ToInt32(dr["Purchase_Order_Item_Id"]);

            PurchaseOrder.Article_No = Convert.ToString(dr["Article_No"]);

            PurchaseOrder.Colour_Id = Convert.ToInt32(dr["Colour_Id"]);

            PurchaseOrder.Brand_Id = Convert.ToInt32(dr["Brand_Id"]);

            PurchaseOrder.Category_Id = Convert.ToInt32(dr["Category_Id"]);

            PurchaseOrder.Sub_Category_Id = Convert.ToInt32(dr["Sub_Category_Id"]);

            PurchaseOrder.Size_Group_Id = Convert.ToInt32(dr["Size_Group_Id"]);

            PurchaseOrder.Start_Size = Convert.ToString(dr["Start_Size"]);

            PurchaseOrder.End_Size = Convert.ToString(dr["End_Size"]);

            PurchaseOrder.Center_Size = Convert.ToString(dr["Center_Size"]);

            PurchaseOrder.Purchase_Price = Convert.ToDecimal(dr["Purchase_Price"]);

            PurchaseOrder.Size_Difference = Convert.ToDecimal(dr["Size_Difference"]);

            PurchaseOrder.Total_Amount = Convert.ToDecimal(dr["Total_Amount"]);

            return PurchaseOrder;
        }

        
		public int Insert_Purchase_Order(PurchaseOrderInfo PurchaseOrder)
		{
            PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(Set_Values_In_Purchase_Order(PurchaseOrder), Storeprocedures.sp_Insert_Purchase_Order.ToString(), CommandType.StoredProcedure));

            foreach (var item in PurchaseOrder.PurchaseOrders)
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();

                if (PurchaseOrder.Purchase_Order_Item_Id != 0)
                {
                    sqlParam.Add(new SqlParameter("@Purchase_Order_Item_Id", item.Purchase_Order_Item_Id));
                }

                sqlParam.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));

                sqlParam.Add(new SqlParameter("@Article_No", item.Article_No));

                sqlParam.Add(new SqlParameter("@Colour_Id", item.Colour_Id));

                sqlParam.Add(new SqlParameter("@Brand_Id", item.Brand_Id));

                sqlParam.Add(new SqlParameter("@Category_Id", item.Category_Id));

                sqlParam.Add(new SqlParameter("@Sub_Category_Id", item.Sub_Category_Id));

                sqlParam.Add(new SqlParameter("@Size_Group_Id", item.Size_Group_Id));

                sqlParam.Add(new SqlParameter("@Start_Size", item.Start_Size));

                sqlParam.Add(new SqlParameter("@End_Size", item.End_Size));

                sqlParam.Add(new SqlParameter("@Center_Size", item.Center_Size));

                sqlParam.Add(new SqlParameter("@Purchase_Price", PurchaseOrder.Purchase_Price));

                sqlParam.Add(new SqlParameter("@Size_Difference", item.Size_Difference));

                sqlParam.Add(new SqlParameter("@Total_Amount", PurchaseOrder.Total_Amount));

                PurchaseOrder.Purchase_Order_Item_Id = Convert.ToInt32(sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.sp_Insert_Purchase_Order_Item.ToString(), CommandType.StoredProcedure));

            }
                       


            int i=0;

            foreach (var item in PurchaseOrder.Sizes)
            {
                i++;
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@Purchase_Order_Item_Id", PurchaseOrder.Purchase_Order_Item_Id));
                sqlParams.Add(new SqlParameter("@Purchase_Order_Id", PurchaseOrder.Purchase_Order_Id));
                if(i==1)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id1));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity1));
                }
                else if(i==2)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id2));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity2));
                }
                else if(i==3)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id3));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity3));
                }
                else if(i==4)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id4));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity4));
                }
                else if(i==5)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id5));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity5));
                }
                else if(i==6)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id6));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity6));
                }
                else if(i==7)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id7));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity7));
                }
                else if(i==8)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id8));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity8));
                }
                else if(i==9)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id9));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity9));
                }
                else if(i==10)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id10));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity10));
                }
                else if(i==11)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id11));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity11));
                }
                else if(i==12)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id12));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity12));
                }
                else if(i==13)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id13));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity13));
                }
                else if(i==14)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id14));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity14));
                }
                else if(i==15)
                {
                    sqlParams.Add(new SqlParameter("@Size_Id", item.Size_Id15));
                    sqlParams.Add(new SqlParameter("@Quantity", item.Quantity15));
                }

                sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.sp_Insert_Purchase_Order_Item_Sizes.ToString(), CommandType.StoredProcedure);
            }


            return PurchaseOrder.Purchase_Order_Id;
		}

        public void Update_Purchase_Order(PurchaseOrderInfo PurchaseOrder)
		{
            sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Order(PurchaseOrder), Storeprocedures.sp_Update_Purchase_Order.ToString(), CommandType.StoredProcedure);

            sqlHelper.ExecuteNonQuery(Set_Values_In_Purchase_Order_Item(PurchaseOrder), Storeprocedures.sp_Update_Purchase_Order_Item.ToString(), CommandType.StoredProcedure);
		}


        public DataTable Get_Purchase_Orders(QueryInfo query_Details)
		{
			return sqlHelper.Get_Table_With_Where(query_Details);
		}

        public PurchaseOrderInfo Get_Purchase_Order_By_Id(int Purchase_Order_Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Purchase_Order_Id", Purchase_Order_Id));

            PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();
            DataTable dt = sqlHelper.ExecuteDataTable(parameters, Storeprocedures.sp_Get_Purchase_Order_By_Id.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                PurchaseOrder = Get_Purchase_Order_Values(dr);
            }
            return PurchaseOrder;
        }

        public List<PurchaseOrderInfo> Get_Purchase_Orders()
        {
            List<PurchaseOrderInfo> PurchaseOrders = new List<PurchaseOrderInfo>();
            DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Purchase_Orders.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in dt.Rows)
            {
                PurchaseOrderInfo PurchaseOrder = new PurchaseOrderInfo();

                PurchaseOrder.Purchase_Order_Id = Convert.ToInt32(dr["Purchase_Order_Id"]);

                PurchaseOrder.Purchase_Order_No = Convert.ToString(dr["Purchase_Order_No"]);

                PurchaseOrders.Add(PurchaseOrder);
            }
            return PurchaseOrders;
        }
	}
}
