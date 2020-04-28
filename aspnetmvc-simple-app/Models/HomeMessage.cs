using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace aspnetmvc_simple_app.Models
{
	public class HomeMessage
        {
                [JsonProperty("id")]
                public int Id { get; set; }
                [JsonProperty("title")]
                public string Title { get; set; }
                [JsonProperty("text")]
                public string Text { get; set; }
                [JsonProperty("imagesrc")]
                public string ImageSrc { get; set; }
                [JsonProperty("link")]
                public string Link { get; set; }
        }
}