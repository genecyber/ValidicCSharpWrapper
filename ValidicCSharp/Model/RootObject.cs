using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class RootObject<T>
    {
        public Summary Summary { get; set; }
        public T Object { get; set; }
    }

    
}
