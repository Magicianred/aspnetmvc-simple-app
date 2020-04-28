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
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace aspnetmvc_simple_app.Test.Controllers
{
        [TestFixture]
        public class AboutControllerTest
        {

                // SUT : System Under Test
                private AboutController _sut;
                private string _executableLocation;

                [SetUp]
                public void Setup()
                {
                        _sut = new AboutController();
                        _executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                [TearDown]
                public void Teardown()
                {
                        _sut = null;
                }

                [Test]
                public void Should_AboutController_Return_IndexPage()
                {
                        // *************** ARRANGE
                        var sut = _sut;

                        // set path to test files in Resources folder
                        string mdPath = Path.Combine(_executableLocation, "Resources\\data\\pages\\about.md");

                        // create mock of HttpServerUtilityBase
                        var serverMock = Substitute.For<HttpServerUtilityBase>();

                        // set up paths to files
                        serverMock.MapPath("~/Content/data/pages/about.md").Returns(mdPath);

                        // create mock of HttpServerUtilityBase
                        var httpContextMock = Substitute.For<HttpContextBase>();

                        httpContextMock.Server.Returns(serverMock);

                        RouteData routeData = new RouteData();
                        sut.ControllerContext = new ControllerContext(httpContextMock, routeData, sut);


                        // *************** ACT
                        var actionResult = sut.Index();
                        //actionResult.ExecuteResult(sut.ControllerContext);

                        var viewResult = actionResult as ViewResult;
                        //viewResult.ExecuteResult(sut.ControllerContext);

                        var model = viewResult.Model as AboutModel;


                        // *************** ASSERT

                        Assert.That(String.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Index");

                        Assert.That(model, Is.Not.Null);

                        Assert.That(model.MdText.Contains("# About Page"));

                        // TODO : Check HTML for find H1, UL > LI.homemessage, etc
                }


                [Test]
                public void Should_AboutController_Return_WhoArePage()
                {
                        // *************** ARRANGE
                        var sut = _sut;

                        // set path to test files in Resources folder
                        string jsonPath = Path.Combine(_executableLocation, "Resources\\data\\people.json");
                        string mdPath = Path.Combine(_executableLocation, "Resources\\data\\pages\\whoare.md");

                        // create mock of HttpServerUtilityBase
                        var serverMock = Substitute.For<HttpServerUtilityBase>();

                        // set up paths to files
                        serverMock.MapPath("~/Content/data/people.json").Returns(jsonPath);
                        serverMock.MapPath("~/Content/data/pages/whoare.md").Returns(mdPath);

                        // create mock of HttpServerUtilityBase
                        var httpContextMock = Substitute.For<HttpContextBase>();

                        httpContextMock.Server.Returns(serverMock);

                        RouteData routeData = new RouteData();
                        sut.ControllerContext = new ControllerContext(httpContextMock, routeData, sut);


                        // *************** ACT
                        var actionResult = sut.WhoAre();

                        var viewResult = actionResult as ViewResult;

                        var model = viewResult.Model as WhoAreModel;


                        // *************** ASSERT

                        Assert.That(String.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "WhoAre");

                        Assert.That(model, Is.Not.Null);

                        Assert.That(model.MdText.Contains("### Who Are page"));

                        // TODO : Check HTML for find H1, UL > LI.homemessage, etc
                }


                [Test]
                public void Should_AboutController_Return_WhereArePage()
                {
                        // *************** ARRANGE
                        var sut = _sut;

                        // set path to test files in Resources folder
                        string jsonPath = Path.Combine(_executableLocation, "Resources\\data\\places.json");
                        string mdPath = Path.Combine(_executableLocation, "Resources\\data\\pages\\whereare.md");

                        // create mock of HttpServerUtilityBase
                        var serverMock = Substitute.For<HttpServerUtilityBase>();

                        // set up paths to files
                        serverMock.MapPath("~/Content/data/places.json").Returns(jsonPath);
                        serverMock.MapPath("~/Content/data/pages/whereare.md").Returns(mdPath);

                        // create mock of HttpServerUtilityBase
                        var httpContextMock = Substitute.For<HttpContextBase>();

                        httpContextMock.Server.Returns(serverMock);

                        RouteData routeData = new RouteData();
                        sut.ControllerContext = new ControllerContext(httpContextMock, routeData, sut);


                        // *************** ACT
                        var actionResult = sut.WhereAre();

                        var viewResult = actionResult as ViewResult;

                        var model = viewResult.Model as WhereAreModel;


                        // *************** ASSERT

                        Assert.That(String.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "WhereAre");

                        Assert.That(model, Is.Not.Null);

                        Assert.That(model.MdText.Contains("### Where Are page"));

                        // TODO : Check HTML for find H1, UL > LI.homemessage, etc
                }
        }
}
