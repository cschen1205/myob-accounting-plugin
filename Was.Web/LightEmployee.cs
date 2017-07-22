using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightEmployee
    {
        [DataMember()]
        public string EmployeeID;

        [DataMember()]
        public string Name;
    }
}
