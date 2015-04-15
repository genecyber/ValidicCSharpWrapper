using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
   [JsonObject("User")]
    public class RefreshToken
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("authentication_token")]
        public string AuthenticationToken { get; set; }
    }
}
