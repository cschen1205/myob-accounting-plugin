using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightShippingMethod
    {
        [DataMember()]
        public string ShippingMethodID { get; set; }

        [DataMember()]
        public string Description { get; set; }
    }
}
