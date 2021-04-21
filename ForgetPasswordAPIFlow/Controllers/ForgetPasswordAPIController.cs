using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using UnitTestClassLibrary;

namespace ForgetPasswordAPIFlow.Controllers
{
    public class ForgetPasswordAPIController : ApiController
    {
        [HttpGet]
        public IEnumerable<tbl_ForgetPassword> GetEmployees()
        {
            UsersEntities db = new UsersEntities();
            return db.tbl_ForgetPassword.ToList();

        }
        public tbl_ForgetPassword Get(int id)
        {
            UsersEntities db = new UsersEntities();
            return db.tbl_ForgetPassword.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet]
        [Route("api/ForgetPasswordAPI/email")]
        public IHttpActionResult ValidateEmail([FromBody]string Email)
        {
            //if (ModelState.IsValid)
            //    return BadRequest("Something went wrong");
            using (var db = new UsersEntities())
            {

                var existinguser = db.tbl_ForgetPassword.Where(x => x.email == Email);

                if (existinguser != null)
                {
                    return Ok();
                }
                return NotFound();
            }
        }
        private static String AGELIX_FROM = "sk0450230@gmail.com";
        private static String AGELIX_BCC = "shaifykhan@gmail.com";
        private static String AGELIX_SMTP = "smtp.gmail.com";
        private static String AGELIX_PWD = "8448665526";
        private static int AGELIX_PORT = 587;
        [HttpGet]
        [Route("api/ForgetPasswordAPI/SendEmail")]
        public IHttpActionResult SendEmail([FromBody]string emailTo, [FromBody]string msgSubject, [FromBody]string msgBody)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailAddress from = new MailAddress(AGELIX_FROM, "Agelix Consulting LLC");
            MailMessage mail = new MailMessage(from.ToString(), emailTo, msgSubject, msgBody);
            //MailMessage mail = new MailMessage(AGELIX_FROM, emailTo, msgSubject, msgBody);
            mail.Bcc.Add(AGELIX_BCC);
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(AGELIX_SMTP);
            client.Port = AGELIX_PORT;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true; // Important: This line of code must be executed before setting the NetworkCredentials object, otherwise the setting will be reset (a bug in .NET)
            NetworkCredential cred = new System.Net.NetworkCredential(AGELIX_FROM, AGELIX_PWD);
            client.Credentials = cred;
            try
            {
                client.Send(mail);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something Went Wrong ,Please Try Again Later");
            }



        }
        [HttpPut]
        [Route("api/ForgetPasswordAPI/reset")]
        public IHttpActionResult ResetPassword([FromBody]tbl_ForgetPassword model)
        {
            if(ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            using (var db = new UsersEntities())
            {
                var result = db.tbl_ForgetPassword.SingleOrDefault(x => x.email == model.email);
                    if(result!=null)
                    {
                    result.Password = model.Password;
                    db.SaveChanges();
           
                    }
                else
                {
                    return NotFound();
                }
            }
            return Ok();

        }

    }
}

