using aspnetmvc_simple_app.Controllers;
using aspnetmvc_simple_app.PresentationModels;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace aspnetmvc_simple_app.Test.Controllers
{

	[TestFixture]
	public class HomeControllerTest
        {

                // SUT : System Under Test
                private HomeController _sut;
                private string _executableLocation;

                [SetUp]
                public void Setup()
                {
                        _sut = new HomeController();
                        _executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                [TearDown]
                public void Teardown()
                {
                         _sut = null;
                }

                [Test]
                public void Should_HomeController_Return_IndexPage()
                {
                        // *************** ARRANGE
                        var sut = _sut;

                        // set path to test files in Resources folder
                        string jsonPath = Path.Combine(_executableLocation, "Resources\\data\\home_messages.json");
                        string mdPath = Path.Combine(_executableLocation, "Resources\\data\\pages\\home.md");

                        // create mock of HttpServerUtilityBase
                        var serverMock = Substitute.For<HttpServerUtilityBase>();

                        // set up paths to files
                        serverMock.MapPath("~/Content/data/home_messages.json").Returns(jsonPath);
                        serverMock.MapPath("~/Content/data/pages/home.md").Returns(mdPath);

                        // create mock of HttpServerUtilityBase
                        var httpContextMock = Substitute.For<HttpContextBase>();

                        httpContextMock.Server.Returns(serverMock);

                        RouteData routeData = new RouteData();
                        //// data for ExecuteResult
                        //routeData.Values.Add("controller", "Home");
                        //routeData.Values.Add("action", "Index");
                        sut.ControllerContext = new ControllerContext(httpContextMock, routeData, sut);


                        // *************** ACT
                        var actionResult = sut.Index();
                        //actionResult.ExecuteResult(sut.ControllerContext);

                        var viewResult = actionResult as ViewResult;
                        //viewResult.ExecuteResult(sut.ControllerContext);

                        var model = viewResult.Model as IndexModel;


                        // *************** ASSERT

                        Assert.That(String.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Index");

                        Assert.That(model, Is.Not.Null);

                        Assert.That(model.HomeMessages.Count, Is.EqualTo(2));

                        Assert.That(model.HomeMessages.First().Id, Is.EqualTo(1));
                        Assert.That(model.HomeMessages.First().Title, Is.EqualTo("Title 1"));

                        Assert.That(model.MdText.Contains("# Welcome to"));

                        // TODO : Check HTML for find H1, UL > LI.homemessage, etc
                }


                [Test]
                public void Should_HomeController_Return_ContactPage()
                {
                        // *************** ARRANGE
                        var sut = _sut;

                        // set path to test files in Resources folder
                        string mdPath = Path.Combine(_executableLocation, "Resources\\data\\pages\\contact.md");

                        // create mock of HttpServerUtilityBase
                        var serverMock = Substitute.For<HttpServerUtilityBase>();

                        // set up paths to files
                        serverMock.MapPath("~/Content/data/pages/contact.md").Returns(mdPath);

                        // create mock of HttpServerUtilityBase
                        var httpContextMock = Substitute.For<HttpContextBase>();

                        httpContextMock.Server.Returns(serverMock);

                        RouteData routeData = new RouteData();
                        sut.ControllerContext = new ControllerContext(httpContextMock, routeData, sut);


                        // *************** ACT
                        var actionResult = sut.Contact();

                        var viewResult = actionResult as ViewResult;

                        var model = viewResult.Model as ContactModel;


                        // *************** ASSERT

                        Assert.That(String.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Contact");

                        Assert.That(model, Is.Not.Null);

                        Assert.That(model.MdText.Contains("### about the contact page"));

                        // TODO : Check HTML for find H1, UL > LI.homemessage, etc
                }
        }
}
