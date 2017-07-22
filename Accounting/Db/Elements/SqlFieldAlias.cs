using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Elements
{
    public class SqlFieldAlias
    {
        private Dictionary<string, string> mFormats = new Dictionary<string, string>();
        public string this[string fieldname]
        {
            get
            {
                if (mFormats.ContainsKey(fieldname))
                {
                    return mFormats[fieldname];
                }
                else
                {
                    return fieldname;
                }
            }
            set
            {
                mFormats[fieldname] = value;
            }
        }
    }
}
