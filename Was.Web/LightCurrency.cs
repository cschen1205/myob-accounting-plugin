using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightCurrency
    {
        [DataMember()]
        public string CurrencyID { get; set; }

        [DataMember()]
        public string Description { get; set; }
    }
}
