using System;
using UnitTestClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForgetPasswordFlow.Controllers;

namespace ForgetPasswordFlowTest
{
    [TestClass]
    public class ForgetPasswordUnitTest
    {
        [TestMethod]
        public void validate()
        {
            bool expected = true;
            string testemail = "sh0450230@gmail.com";
            bool actualvalue = BLClass.validateEmail(testemail);
            Assert.AreEqual(expected, actualvalue);
        }
        [TestMethod]
        public void SendEmail()
        {
            bool expectedstatus = true;
            //arrange
            string email = "sk0450230@gmail.com";
            string subject = "Customer Portal,Reset Your Password";
            string body = "<b>Please find the Password Reset Link below. </b><br/>" ;
            //act
            bool actualstatus = BLClass.SendEmail(email, subject, body);

            //act 



            //assert

            Assert.AreEqual(expectedstatus, actualstatus);
        }
        
    }
}
