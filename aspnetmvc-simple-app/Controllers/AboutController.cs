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
    public class AboutController : BaseController
    {
                // GET: About
                public ActionResult Index()
                {
                        AboutModel model = new AboutModel();
                        using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/pages/about.md"), Encoding.UTF8, true))
                        {
                                model.MdText = sr.ReadToEnd();
                                model.MdHtml = base.StripHtml(base.MarkdownToHtml(model.MdText));
                        }
                        return View(model);
                }

                public ActionResult WhoAre()
                {
                        WhoAreModel model = new WhoAreModel();
                        using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/people.json"), Encoding.UTF8, true))
                        {
                                model.JsonString = sr.ReadToEnd();
                                model.People = JsonConvert.DeserializeObject<List<Person>>(model.JsonString);
                        }
                        using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/pages/whoare.md"), Encoding.UTF8, true))
                        {
                                model.MdText = sr.ReadToEnd();
                                model.MdHtml = base.StripHtml(base.MarkdownToHtml(model.MdText));
                        }
                        return View(model);
                }

                public ActionResult WhereAre()
                {
                        WhereAreModel model = new WhereAreModel();
                        using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/places.json"), Encoding.UTF8, true))
                        {
                                model.JsonString = sr.ReadToEnd();
                                model.Places = JsonConvert.DeserializeObject<List<Place>>(model.JsonString);
                        }
                        using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/data/pages/whereare.md"), Encoding.UTF8, true))
                        {
                                model.MdText = sr.ReadToEnd();
                                model.MdHtml = base.StripHtml(base.MarkdownToHtml(model.MdText));
                        }
                        return View(model);
                }
        }
}