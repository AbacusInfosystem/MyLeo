using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
    public class SendEmailInfo
    {
        public int ID { get; set; }

        public string To_Email_Id { get; set; }

        public string CC_Email_Id { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<string> AttachmentPath { get; set; }

    }
}
