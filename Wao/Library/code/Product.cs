using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoWebApp.Library.code
{
    public class Product
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public Double UnitPrice { get; set; }
        public String Category { get; set; }
        public String Manufacturer { get; set; }
        public Int32 Stock { get; set; }

    }
}
