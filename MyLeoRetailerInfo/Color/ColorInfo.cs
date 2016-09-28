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
            ProductMRP_N_WSR = new List<ProductMRPInfo>();
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
        //Commented by vinod mane on 27/09/2016
        //public bool Is_Active 
        //{
        //    get;
        //    set;
        //}
        //End

        //Added by Vinod Mane on 27/09/2016
        public int IsActive
        {
            get;
            set;
        }
        public bool Is_Active
        {
            get;
            set;
        }
        //End
        
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

        public List<ProductMRPInfo> ProductMRP_N_WSR { get; set; }

	}
}
