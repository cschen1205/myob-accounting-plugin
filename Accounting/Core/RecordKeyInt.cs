using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
    public class RecordKeyInt
    {
        string mName;
        int? mValue;
        public RecordKeyInt(string name, int? val)
        {
            mName = name;
            mValue = val;
        }

        public bool Match(int? val)
        {
            if (val == null) return false;
            return mValue == val;
        }

        public int? Value
        {
            get { return mValue; }
        }
    }
}
