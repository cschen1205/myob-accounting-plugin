using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightCustomer
    {
        [DataMember()]
        public string CustomerID { get; set; }

        [DataMember()]
        public string Name { get; set; }
    }
}
