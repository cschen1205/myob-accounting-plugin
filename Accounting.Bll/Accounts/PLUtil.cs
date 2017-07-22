using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core;
using Accounting.Core.Enumeration;

namespace Accounting.Bll.Accounts
{
    public enum PLCriteria
    {
        ThisYearActualsOnly=1,
        LastYearActualsOnly=2,
        BudgetsOnly=3,
        ActualsVsBudgets=4,
        ThisYearVsLastYear=5
    }

    public class PLUtil
    {
        public static PLCriteria GetPLCriteria(int index)
        {
            return (PLCriteria)index;
        }
        public static int GetPLCriteriaIndex(PLCriteria criteria)
        {
            return (int)criteria;
        }
        public static void Period2MonthYear(Accountant acc, int period, ref int year, out int month)
        {
            int? lastMonthInFinancialYear = acc.DataFileInformationMgr.Company.LastMonthInFinancialYear;
            month = period - lastMonthInFinancialYear.Value;
            if (month < 1)
            {
                month += 12;
                year -= 1;
            }
        }
        public static string Month2String(int month)
        {
            return Month.Int2ShortString(month);
        }
    }
}
