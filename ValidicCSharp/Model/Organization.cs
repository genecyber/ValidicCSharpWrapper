using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Organization : Me
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("users")]
        public int Users { get; set; }

        [JsonProperty("users_provisioned")]
        public int UsersProvisioned { get; set; }

        [JsonProperty("activities")]
        public int? Activities { get; set; }

        [JsonProperty("connections")]
        public int? Connections { get; set; }

        [JsonProperty("organizations")]
        public List<Organization> ChildOrganizations { get; set; }
    }
}