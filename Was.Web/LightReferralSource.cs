using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightReferralSource
    {
        [DataMember()]
        public string ReferralSourceID { get; set; }

        [DataMember()]
        public string Description { get; set; }
    }
}
