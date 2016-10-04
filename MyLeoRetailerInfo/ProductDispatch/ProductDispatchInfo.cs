using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.ProductDispatch
{
  public class ProductDispatchInfo
    {

      public ProductDispatchInfo()
      {
          grid_Dispatch_List = new List<ProductDispatchInfo>();

          Is_View = 0;

          Dispatch_Id = 0;
      }

      public List<ProductDispatchInfo> grid_Dispatch_List {get;set;}

      public int Branch_Id { get; set; }

      public string Branch_Name { get; set;}

      public int Request_Id { get; set; }

      public int Dispatch_Id { get; set; }

      public int Dispatch_Item_Id { get; set; }

      public DateTime Request_Date { get; set; }

      public string Status { get; set; }

      public int Quantity { get; set; }

      public int Balance_Quantitya { get; set; }

      public string SKU { get; set; }

      public DateTime Created_Date { get; set; }

      public int Created_By { get; set; }

      public DateTime Updated_Date { get; set; }

      public int Updated_By { get; set; }

      public DateTime Dispatch_Date { get; set; }

      public int Is_View { get; set; }
  }

  public class Filter
  {
      public string Branch_Name { get; set; }

      public DateTime From_Request_Date { get; set; }

      public DateTime To_Request_Date { get; set; }

      public string Status { get; set; }

  }

}
