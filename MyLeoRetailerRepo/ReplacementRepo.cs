using MyLeoRetailerInfo.PurchaseInvoice;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerInfo.Replacement;
using MyLeoRetailerInfo;


namespace MyLeoRetailerRepo
{
   public class ReplacementRepo
    {

          SQL_Repo sqlHelper = null;

          public ReplacementRepo()
		{
			sqlHelper = new SQL_Repo();
		}

          public List<PurchaseInvoiceInfo> Get_Purchase_Invoice()
          {
              List<PurchaseInvoiceInfo> purchase = new List<PurchaseInvoiceInfo>();

              DataTable dt = sqlHelper.ExecuteDataTable(null, Storeprocedures.sp_Get_Purchase_Invoice.ToString(), CommandType.StoredProcedure);

              foreach (DataRow dr in dt.Rows)
              {
                  purchase.Add(Get_Purchase_Invoice_Value(dr));
              
              }


              return purchase;
          }

          public PurchaseInvoiceInfo Get_Purchase_Invoice_Value(DataRow dr)
          {
              PurchaseInvoiceInfo purchase = new PurchaseInvoiceInfo();

              purchase.Purchase_Invoice_Id = Convert.ToInt32(dr["Purchase_Invoice_Id"]);
              purchase.Purchase_Invoice_No = Convert.ToString(dr["Purchase_Invoice_No"]);

              return purchase;
          }


          public void Insert(ReplacementInfo replacement, List<ReplacementInfo> list_Replacement)
          {
              List<SqlParameter>sqlparam= new List<SqlParameter>();

                  sqlparam.Add(new SqlParameter("vendor_Id", replacement.Vendor_Id));
                  sqlparam.Add(new SqlParameter("replacement_No", replacement.Replacement_No));
                  sqlparam.Add(new SqlParameter("purchase_Invoice_Id", replacement.Purchase_Invoice_Id));
                  sqlparam.Add(new SqlParameter("replacement_Date", replacement.Replacement_Date));
                  sqlparam.Add(new SqlParameter("persone_Name", replacement.Persone_Name));
                  sqlparam.Add(new SqlParameter("transpoter_Name", replacement.Transpoter_Name));
                  sqlparam.Add(new SqlParameter("lr_No", replacement.Lr_No));
                  sqlparam.Add(new SqlParameter("payment_Due_Date", replacement.Payment_Due_Date));

                  sqlparam.Add(new SqlParameter("@Created_By", replacement.Created_By));
                  sqlparam.Add(new SqlParameter("@Created_Date", replacement.Created_Date));
                  sqlparam.Add(new SqlParameter("@Updated_By", replacement.Updated_By));
                  sqlparam.Add(new SqlParameter("@Updated_Date", replacement.Updated_Date));


             int Replacement_Id=Convert.ToInt32(sqlHelper.ExecuteScalerObj(sqlparam, Storeprocedures.sp_Insert_Replacement.ToString(), CommandType.StoredProcedure));

                  foreach (var item in list_Replacement)
                  {
                      item.Replacement_Id = Replacement_Id;

                      sqlparam = new List<SqlParameter>();

                      sqlparam.Add(new SqlParameter("replacement_Id", item.Replacement_Id)); //SELECT SCOPE_IDENTITY()
                      sqlparam.Add(new SqlParameter("purchase_Order_Id", item.Purchase_Order_Id));
                      sqlparam.Add(new SqlParameter("sku_Code", item.SKU_Code));
                      sqlparam.Add(new SqlParameter("size_Group_Id", item.Size_Group_Id));
                      sqlparam.Add(new SqlParameter("size_Id", item.Size_Id));
                      sqlparam.Add(new SqlParameter("quantity", item.Quantity));
                      sqlparam.Add(new SqlParameter("amount", item.Amount));

                      sqlparam.Add(new SqlParameter("@Created_By", replacement.Created_By));
                      sqlparam.Add(new SqlParameter("@Created_Date", replacement.Created_Date));
                      sqlparam.Add(new SqlParameter("@Updated_By", replacement.Updated_By));
                      sqlparam.Add(new SqlParameter("@Updated_Date", replacement.Updated_Date));


                  sqlHelper.ExecuteNonQuery(sqlparam, Storeprocedures.sp_Insert_Replacement_Item.ToString(), CommandType.StoredProcedure);
              
              }

          }

          public DataTable Get_Replacement(QueryInfo query_Details)
          {
              return sqlHelper.Get_Table_With_Where(query_Details);
          }
    }
}
