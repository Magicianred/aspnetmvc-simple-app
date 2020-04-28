using aspnetmvc_simple_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetmvc_simple_app.PresentationModels
{
	public class IndexModel
        {
                public List<HomeMessage> HomeMessages;
                public string MdHtml;
                public string MdText;
                public string JsonString;
        }
}