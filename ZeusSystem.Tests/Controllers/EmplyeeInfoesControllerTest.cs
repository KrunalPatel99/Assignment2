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
                new EmplyeeInfo { EmployeeID = 1, EmployeeName = "Test", EmployeeAddress = "Test", EmployeePhoneNumber = "98989898", EmployeeEmailID = "test@test.com", EmployeeDoB = DateTime.Parse("2000-12-10 12:00:00 AM") },
                new EmplyeeInfo { EmployeeID = 2, EmployeeName = "Test2", EmployeeAddress = "Test2", EmployeePhoneNumber = "98189898", EmployeeEmailID = "test1@test.com", EmployeeDoB = DateTime.Parse("2000-12-10 12:00:00 AM") },
                new EmplyeeInfo { EmployeeID = 3, EmployeeName = "Test3", EmployeeAddress = "Test3", EmployeePhoneNumber = "98981898", EmployeeEmailID = "test2@test.com", EmployeeDoB = DateTime.Parse("2000-12-10 12:00:00 AM") }
            };
            mock = new Mock<IMockEmployees>();
            mock.Setup(e => e.EmplyeeInfos).Returns(emplyeeInfos.AsQueryable());
            controller = new EmplyeeInfoesController(mock.Object);
        }


        [TestMethod]
        public void IndexViewLoads()
        {

            //ACT
            ViewResult result = controller.Index() as ViewResult;

            //ASSERT
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void EmployeeIndex()
        {
            //ACT
            var result = (List<EmplyeeInfo>)((ViewResult)controller.Index()).Model;

            //ASSERT
            CollectionAssert.AreEqual(emplyeeInfos.OrderBy(c => c.EmployeeName).ToList(), result);
        }

        [TestMethod]
        public void CreateGet()
        {
            //ACT
            ViewResult result = controller.Create() as ViewResult;

            //ASSERT
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreatePost()
        {
            //ACT
            ViewResult result = controller.Create() as ViewResult;

            //ASSERT
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateRedirect()
        {
            EmplyeeInfo e1 = new EmplyeeInfo { EmployeeID = 11, EmployeeName = "Test11", EmployeeAddress = "Test11", EmployeePhoneNumber = "98119898", EmployeeEmailID = "test11@test.com", EmployeeDoB = DateTime.Parse("2000-12-10 12:00:00 AM") };

            //ACT
            RedirectToRouteResult result = controller.Create(e1) as RedirectToRouteResult;

            //ASSERT
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        [TestMethod]
        public void EditPost()
        {
            //ACT
            RedirectToRouteResult result = controller.Edit(emplyeeInfos[0]) as RedirectToRouteResult;

            //ASSERT
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostView()
        {
            //ACT
            RedirectToRouteResult result = controller.Edit(emplyeeInfos[0]) as RedirectToRouteResult;

            //ASSERT
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void InvalidEditPostModel()
        {
            controller.ModelState.AddModelError("Description", "error");

            //ACT
            ViewResult result = controller.Edit(emplyeeInfos[0]) as ViewResult;

            //ASSERT
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InvalidModelViewNameEditPost()
        {
            controller.ModelState.AddModelError("Description", "error");

            //ACT
            ViewResult result = controller.Edit(emplyeeInfos[0]) as ViewResult;

            //ASSERT
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void LoadDetails()
        {
            //Act
            ViewResult result = controller.Details(0001) as ViewResult;

            //Assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DetailsViewNullId()
        {
            //Act

        }
    }
}
