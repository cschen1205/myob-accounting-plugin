using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Bll.Journals
{
    public class BOTransferMoney : BusinessObject
    {
        public BOTransferMoney(Accountant accountant, BOContext context)
            : base(accountant, context)
        {
            mObjectID = BOType.BOTransferMoney;
        }

       
    }
}
