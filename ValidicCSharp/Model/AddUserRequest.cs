using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class AddUserRequest : IValidic
    {
        public UserRequest user { get; set; }
        public string access_token { get; set; }
        
    }

    public class UserRequest
    {
        public string uid { get; set; }
        public Profile profile { get; set; }
    }
}
