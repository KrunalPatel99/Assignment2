using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//new referances
using System.Web.Mvc;
using ZeusSystem.Controllers;
using Moq;
using ZeusSystem.Models;
using System.Linq;
using System.Collections.Generic;

namespace ZeusSystem.Tests.Controllers
{
    
    [TestClass]
    public class EmplyeeInfoesControllerTest
    {
        //moq data
        EmplyeeInfoesController controller;
        List<EmplyeeInfo> Employees;

        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange
            EmplyeeInfoesController controller = new EmplyeeInfoesController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
