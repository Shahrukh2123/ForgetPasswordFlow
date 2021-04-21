using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using ForgetPasswordFlow1.Models;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ForgetPasswordFlow.Controllers
{
    public class ForgetPasswordController : Controller
    {
        // GET: ForgetPassword
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            ViewBag.Message = "Forget Password ,Flow";
            return View();
        }
     
        [HttpGet]
        public ActionResult ResetPassword()
        {
            string code;
            code = Request.QueryString["code"];
            string encodedcode = Request.QueryString["text"];
            string token = TempData["token"].ToString();
            string token1 = encodedcode;
            ForgetPasswordViewModel model = new ForgetPasswordViewModel();
            //model.EmailConfirmationToken = code;
            model.token = token;
            if (token != null)
            {
                return View(model);
            }
            else
            {
                return View("Error");

            }
            
            //model.ReceivedCode = encodedcode;
                       
         


        }


        //POST RESET PASSWORD ACTION METHOD WITH CONFIRMATION LINK
        [HttpPost]
        public ActionResult ResetPassword(ForgetPasswordViewModel models)
        {
            //string decodedstrings = DecodeStrings.Decode(models.ReceivedCode);
            //string[] strlist = decodedstrings.Split('%');
            //string decodedcompanyid = strlist[0];
            //string decodeduserid = strlist[1];
            string password = string.Empty;
            string token = string.Empty;
            password = models.password;
            token = models.token;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://fsmx-qa.azurewebsites.net");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ForgetPasswordViewModel resource = new ForgetPasswordViewModel()
                {
                    token = token,
                    password = password
                };
                string json = JsonConvert.SerializeObject(resource);
                Console.WriteLine(json);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response1 = httpClient.PostAsync("rest/c/profile/password", content);
                response1.Wait();
                var result1 = response1.Result;


                if (result1.IsSuccessStatusCode)
                {

                }
            }
            return View();

        }

        public ActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string Email)
        {
            IEnumerable<ForgetPasswordViewModel> details = null;

            if (ModelState.IsValid)
            {


                using (var client = new HttpClient())
                {
                    string type = "email";
                    client.BaseAddress = new Uri("http://fsmx-qa.azurewebsites.net/rest/c/customer/duplicate/user/email/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("id"+Email);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        using (var client2 = new HttpClient())
                        {
                            client2.BaseAddress = new Uri("http://fsmx-qa.azurewebsites.net//rest/c/customer/profile/");
                            string sampletoken = "03E42414-BE22-48CA-90F0-EEC952081DE8";
                            //var responsetask1 = client2.GetAsync(string.Format("{0}", sampletoken));
                            var responsetask = client.GetAsync(string.Format("{0}",sampletoken));
                            responsetask.Wait();
                            var result1 = responsetask.Result;
                            if (result1.IsSuccessStatusCode)
                            {
                                //var readTask1 = result1.Content.ReadAsAsync<IList<ForgetPasswordViewModel>>();
                               
                                string readtask1 = result1.Content.ReadAsStringAsync().Result;
                                //readtask1.Wait();

                                // details= readtask1.Result;
                            }
                          
                        }



                        string userid = "demo1";
                        string companyid = "em12723";

                        string datetime = DateTime.UtcNow.ToString();

                        string text = String.Concat(userid, "%", companyid, "%", datetime);
                        string plaintext = "fgfghehry63646126262677351dgg";
                        string token = "BLSHDGFGER2433564GDGG4664";
                        var lnkHref = Url.Action("ResetPassword", "ForgetPassword", new { text = plaintext, code = token, }, "http");
                        string To = "sk0450230@gmail.com";
                        string subject = "test1";

                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.html")))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("{ConfirmationLink}", lnkHref);
                        body = body.Replace("{UserName}", Email);


                        using (var client1 = new HttpClient())
                        {
                            client1.BaseAddress = new Uri("http://fsmx-qa.azurewebsites.net");
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                              EmailParameters account = new EmailParameters
                            {
                                
                                To = To,
                                Subject = subject,
                                Body = body


                            };
                            try
                            {
                                string json = JsonConvert.SerializeObject(account);
                                Console.WriteLine(json);
                                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                                var response1 = client.PutAsync("/rest/c/customer/reset/email", content);
                                response1.Wait();
                                var result1 = response1.Result;



                                if (result1.IsSuccessStatusCode)
                                {

                                    ViewBag.Message = "Confirmation Mail Has been Sent to your Registered Mail Id";
                                }
                                else
                                {
                                    return RedirectToAction("Error");
                                }
                            }
                            catch(Exception ex)
                            {

                            }

                        }
                     
                    }
                }
            }
            return View("ForgetPassword");
        }
    }
}

