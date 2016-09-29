using MyLeoRetailerInfo.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Color
{
	public class ColorInfo
	{

        public ColorInfo()
		{
            ProductMRPs = new List<ProductMRPInfo>();
            ProductDescription = new List<ProductDescription>();
		}

		public int Colour_Id
		{
			get;
			set;
		}
        public string Colour
		{
			get;
			set;
		}
        
        public string Colour_Code
        {
            get;
            set;
        }

        public string Color_Code
        {
            get;
            set;
        }

        public bool IsActive
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

        public string Description
		{
			get;
			set;
		}

        public string Vendor_Color_Code { get; set; }

        public List<ProductMRPInfo> ProductMRP_N_WSR { get; set; }

        public List<ProductDescription> ProductDescription { get; set; }


        public IEnumerable<object> ProductMRPs { get; set; }
    }
}
