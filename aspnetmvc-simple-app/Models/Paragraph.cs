using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetmvc_simple_app.Models
{
	public class Paragraph
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}