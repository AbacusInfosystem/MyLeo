using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerRepo.Common
{
    public static class CommonMethods
    {
        public static List<DataRow> GetRows(DataTable dt, ref Pagination_Info pager)
        {
            List<DataRow> drList = new List<DataRow>();

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (pager.IsPagingRequired)
                {
                    drList = drList.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
                }

                pager.TotalRecords = count;

                int pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;

                //pager.TotalPages = pages;
            }

            return drList;
        }


        public static void SendMail(SendEmailInfo sendEmail)
        {
            MailMessage mail = new MailMessage();

            SmtpClient SmtpServer = new SmtpClient();

            foreach (string str in sendEmail.AttachmentPath)
            {
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(str);
                mail.Attachments.Add(attachment);
            }

            if (!string.IsNullOrEmpty(sendEmail.To_Email_Id))
            {
                if (sendEmail.To_Email_Id.Contains(','))
                {
                    foreach (var item in sendEmail.To_Email_Id.Split(','))
                    {
                        mail.To.Add(item);
                    }
                }
                else
                {
                    mail.To.Add(sendEmail.To_Email_Id);
                }
            }

            if (!string.IsNullOrEmpty(sendEmail.CC_Email_Id))
            {
                if (sendEmail.CC_Email_Id.Contains(','))
                {
                    foreach (var item in sendEmail.CC_Email_Id.Split(','))
                    {
                        mail.CC.Add(item);
                    }
                }
                else
                {
                    mail.CC.Add(sendEmail.CC_Email_Id);
                }
            }

            mail.Subject = sendEmail.Subject;

            mail.Body = sendEmail.Body;

            mail.IsBodyHtml = true;

            SmtpServer.Send(mail);
        }



    }
}
