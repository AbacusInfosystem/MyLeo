using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Brand
{
    public class BrandInfo
    {
        public BrandInfo()
		{

		}

        public int Brand_Id { get; set; }

        public string Brand_Name { get; set; }

        public int IsActive { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

	}
}
