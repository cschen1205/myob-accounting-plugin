using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Bll.Security;
using Accounting.Db;
using Accounting.Db.Db2;

namespace Accounting.Bll.Db2
{
    public class Db2Accountant : Accountant
    {
        public Db2Accountant(string _name)
            : base(_name)
        {
        }
        

        public override DbManager CreateDefaultMgrFactory()
        {
            return new Db2Manager(this, "Default");
        }
    }
}
