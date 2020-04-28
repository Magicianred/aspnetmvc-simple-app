using aspnetmvc_simple_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetmvc_simple_app.PresentationModels
{
	public class WhoAreModel
        {
                public List<Person> People;
                public string MdHtml;
                public string MdText;
                public string JsonString;
        }
}