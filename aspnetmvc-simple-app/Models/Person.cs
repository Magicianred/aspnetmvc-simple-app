using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetmvc_simple_app.Models
{
	public class Person
        {

                [JsonProperty("id")]
                public int Id { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("surname")]
                public string Surname { get; set; }

                [JsonProperty("shortbio")]
                public string ShortBio { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("profilesrc")]
                public string ProfileSrc { get; set; }
        }
}