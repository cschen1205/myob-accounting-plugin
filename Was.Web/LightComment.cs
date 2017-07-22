using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Was.Web
{
    [DataContract()]
    public class LightComment
    {
        [DataMember()]
        public string CommentID { get; set; }

        [DataMember()]
        public string Description { get; set; }
    }
}
