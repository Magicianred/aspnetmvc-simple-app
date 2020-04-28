using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetmvc_simple_app.Models
{
	public class Place
        {

                [JsonProperty("id")]
                public int Id { get; set; }

                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("address")]
                public string Address { get; set; }

                [JsonProperty("country")]
                public string Country { get; set; }

                [JsonProperty("phone")]
                public string Phone { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }
        }
}