using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class AuthenticationTokenFilter : ValueFilter
    {
        public AuthenticationTokenFilter()
        {
            Type = FilterType.AuthenticationToken;
            Label = "authentication_token";
        }
    }
}
