
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShoppingDotnet.common
{
    public class MailInfor
    {
        private string src;
        private string dest;
        private string subject;
        private string body;

        public MailInfor(string src, string dest, string subject, string body)
        {
            this.src = src;
            this.dest = dest;
            this.subject = subject;
            this.body = body;
        }
        public MailInfor()
        {

        }
        public string Src { get => src; set => src = value; }
        public string Dest { get => dest; set => dest = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Body { get => body; set => body = value; }
    }
}
