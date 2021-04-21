using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForgetPasswordFlow.Controllers;
using System.Web.Mvc;
namespace ForgetPasswordFlowTest.Controllers
{
   
    [TestClass]
    public class ForgetPasswordControllerTest
    {
        //public ForgetPasswordControllerTest()
        //{
        //    ForgetPasswordController controller = new ForgetPasswordController();

        //}

       

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            ForgetPasswordController controller = new ForgetPasswordController();

            //ACT
            ViewResult result = controller.ForgetPassword() as ViewResult;

            //ASSERT
            Assert.IsNotNull(result);
            
        }
    }
}
