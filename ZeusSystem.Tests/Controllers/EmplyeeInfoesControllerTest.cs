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
        List<EmplyeeInfo> emplyeeInfos;
        Mock<IMockEmployees> mock;

        [TestInitialize]
        public void TestIntialize()
        {
            emplyeeInfos = new List<EmplyeeInfo>
            {
                new EmplyeeInfo { EmployeeID = 1, EmployeeName = "Test", EmployeeAddress = "Test", EmployeePhoneNumber = "98989898", EmployeeEmailID = "test@test.com", EmployeeDoB = Convert.ToDateTime("11/09/1999") },
                new EmplyeeInfo { EmployeeID = 1, EmployeeName = "Test", EmployeeAddress = "Test", EmployeePhoneNumber = "98989898", EmployeeEmailID = "test@test.com", EmployeeDoB = Convert.ToDateTime("11/09/1999") },
                new EmplyeeInfo { EmployeeID = 1, EmployeeName = "Test", EmployeeAddress = "Test", EmployeePhoneNumber = "98989898", EmployeeEmailID = "test@test.com", EmployeeDoB = Convert.ToDateTime("11/09/1999") }
            };
            mock = new Mock<IMockEmployees>();
            mock.Setup(e => e.EmplyeeInfos).Returns(emplyeeInfos.AsQueryable());
            controller = new EmplyeeInfoesController(mock.Object);
        }


        [TestMethod]
        public void IndexViewLoads()
        {
            

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}
