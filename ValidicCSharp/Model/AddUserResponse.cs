using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidicCSharp.Model
{
    public class AddUserResponse
    {
        public int code { get; set; }
        public string message { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public string _id { get; set; }
        public string uid { get; set; }
        public string access_token { get; set; }
        public Profile profile { get; set; }
    }

   
}
