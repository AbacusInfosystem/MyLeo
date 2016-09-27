using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Category
{
	public class SubCategoryInfo
	{
		public SubCategoryInfo()
		{

		}

		public int Sub_Category_Id
		{
			get;
			set;
		}
		public int Category_Id
		{
			get;
			set;
		}

		public string Sub_Category
		{
			get;
			set;
		}

        public string Sub_Category_Code
        {
            get;
            set;
        }

		public string Category
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

        public bool IsActive { get; set; }

    }
}
