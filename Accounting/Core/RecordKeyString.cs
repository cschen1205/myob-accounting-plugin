using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
    public class RecordKeyString
    {
        string mName;
        string mValue;
        public RecordKeyString(string name, string val)
        {
            mName = name;
            mValue = val;
        }

        public bool Match(string val)
        {
            if (val == null) return false;
            return mValue == val;
        }

        public string Value
        {
            get { return mValue; }
        }

    }
}
