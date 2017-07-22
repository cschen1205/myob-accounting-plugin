using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Analysis
{
    public class BOCashFlow : BusinessObject
    {
        public BOCashFlow(Accountant _acc, BOContext context)
            : base(_acc, context)
        {
            mObjectID = BOType.BOAnalysisCashFlow;
        }
    }
}
