using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public bool Status { get; set; }
        public bool IsReaded { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
