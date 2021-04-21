using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ForgetPasswordFlow1.Models
{
    public class ForgetPasswordViewModel
    {
        public string password { get; set; }
        public string token { get; set; }
        public string user { get; set; }

        //public string Name { get; set; }
        //public string token { get; set; }
        //public DateTime LastChangedPassword { get; set; }
        //public bool Locked { get; set; }
        //public string Features { get; set; }

        //public string CustomerId { get; set; }

        //public string RoleCode { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }
        //public string Email { get; set; }


        //public string UserId { get; set; }

        //public string CompanyId { get; set; }
        //public string Id { get; set; }




        public string UpdatedBy { get; set; }

       
        public DateTime? UpdatedAt { get; set; }

       
        public string CreatedBy { get; set; }

       
        public DateTime? CreatedAt { get; set; }

        public bool Active { get; set; }

       
        
      
       



    }
}