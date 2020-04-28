using aspnetmvc_simple_app.Models;
using aspnetmvc_simple_app.PresentationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc_simple_app.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			IndexModel model = new IndexModel();
			using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/home_messages.json"), Encoding.UTF8, true))
			{
				model.JsonString = sr.ReadToEnd();
				model.HomeMessages = JsonConvert.DeserializeObject<List<HomeMessage>>(model.JsonString);
			}
			using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/pages/home.md"), Encoding.UTF8, true))
			{
				model.MdText = sr.ReadToEnd();
				model.MdHtml = base.StripHtml(base.MarkdownToHtml(model.MdText));
			}
			return View(model);
		}

		public ActionResult Contact()
		{
			ContactModel model = new ContactModel();
			using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/pages/contact.md"), Encoding.UTF8, true))
			{
				model.MdText = sr.ReadToEnd();
				model.MdHtml = base.StripHtml(base.MarkdownToHtml(model.MdText));
			}
			return View(model);
		}
	}
}