using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ForgetPasswordFlow1.Models
{
    public class EmailParameters
    {
     
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}