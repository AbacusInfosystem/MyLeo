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

    }
}
