 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.ProductWarehouse
{
  public class ProductWarehouseInfo
    {
      public ProductWarehouseInfo()
      { 
      
      }

     public int Product_Warehouse_Id { get; set;}

     public string Product_SKU { get; set; }

     public int Product_Invoice_Id { get; set; }

     public int Product_Quantity { get; set; }

      #region createdBy, UpdateBy

      public DateTime Created_Date { get; set; }

      public int Created_By { get; set; }

      public DateTime Updated_Date { get; set; }

      public int Updated_By { get; set; }

      #endregion

    }
}
