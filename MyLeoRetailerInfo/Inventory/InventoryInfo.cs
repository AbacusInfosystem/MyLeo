using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Inventory
{
    public class InventoryInfo
    {
        public InventoryInfo()
		{

		}

        public int Inventory_Id
		{
			get;
			set;
		}
        public string Product_SKU
		{
			get;
			set;
		}
        public int Branch_Id
		{
			get;
			set;
		}

        public int Product_Dispatch_Id
        {
            get;
            set;
        }

        public int Product_Quantity
        {
            get;
            set;
        }
               
        
		public DateTime Created_Date
		{
			get;
			set;
		}
		public int Created_By
		{
			get;
			set;
		}
		public DateTime Updated_Date
		{
			get;
			set;
		}
		public int Updated_By
		{
			get;
			set;
		}

	}

    public class Filter_Inventory
    {
        public string Inventory_Id
        {
            get;
            set;
        }
    }
}
