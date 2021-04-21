using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestClassLibrary;

namespace ForgetPasswordAPIFlow.Models
{
    public class ForgetPasswordFlowModel
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string Userid { get; set; }
        public string CompanyId { get; set; }
        public string Password { get; set; }
    }
}