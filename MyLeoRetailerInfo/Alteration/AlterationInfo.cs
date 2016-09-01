using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Alteration
{
   public class AlterationInfo
    {
        public AlterationInfo()
        {

        }

        public int Alteration_ID { get; set; }

        public int Sales_Invoice_ID { get; set; }

        public string Product_Name { get; set; }

        public DateTime Alteration_Date { get; set; }

        public DateTime Delivery_Date { get; set; }

        public string Customer_Mobile_No { get; set; }

        public int Job_Assigned_To { get; set; }

        public string Additional_Info { get; set; }

        public DateTime Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_Date { get; set; }

        public int Updated_By { get; set; }

       // public string Branch_Name { get; set; }

    }
}
