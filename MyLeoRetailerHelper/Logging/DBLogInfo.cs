using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerHelper.Logging
{
    [Serializable]
    public class DBLogInfo
    {
        public int UserId { get; set; }

        public string Exception { get; set; }

        public string IPAddress { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
