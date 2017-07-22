using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Enumeration
{
    public class Month
    {
        public enum LongEnum
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public enum ShortEnum
        {
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            Jun = 6,
            Jul = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12
        }

        public static Month.LongEnum String2LongEnum(string month_string)
        {
            return (Month.LongEnum)Enum.Parse(typeof(Month.LongEnum), month_string, true);
        }

        public static string Int2LongString(int month)
        {
            LongEnum enumMonth=(LongEnum)month;
            return enumMonth.ToString();
        }

        public static string Int2ShortString(int month)
        {
            ShortEnum enumMonth = (ShortEnum)month;
            return enumMonth.ToString();
        }

        private int mValue;
        public Month(int month)
        {
            mValue = month;
        }

        public string LongDescription
        {
            get
            {
                return Int2LongString(mValue);
            }
        }
        public string ShortDescription
        {
            get
            {
                return Int2ShortString(mValue);
            }
        }
    }
}
