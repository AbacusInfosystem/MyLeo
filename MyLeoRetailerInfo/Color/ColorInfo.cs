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

	}
}
