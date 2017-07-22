using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll
{
    using System.ComponentModel;
    public abstract class BOList<BO> : BusinessObject
        where BO : BusinessObject
    {
        public BOList(Accountant accountant)
            : base(accountant, BOContext.Record_Update)
        {

        }

        public void Refresh()
        {
            UpdateContent();
        }
    }
}
