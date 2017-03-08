using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class AccessTokenFilter: ValueFilter
    {
        public AccessTokenFilter()
        {
            Type = FilterType.AccessToken;
            Label = "access_token";
        }
    }

}
