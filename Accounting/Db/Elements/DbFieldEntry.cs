using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Db;

namespace Accounting.Db.Elements
{
    public class DbFieldEntry : DbElement
    {
        protected string mValue;

        public virtual object DataSource
        {
            get { return mValue; }
        }

        public enum EntryType
        {
            Type_int,
            Type_auto_int,
            Type_double,
            Type_string,
            Type_DateTime
        };

        protected bool mSkipOnUpdate = false;
        public bool SkipOnUpdate
        {
            get
            {
                return mSkipOnUpdate;
            }
            set
            {
                mSkipOnUpdate = true;
            }
        }

        

        protected EntryType mType;
        public EntryType Type
        {
            get { return mType; }
            set { mType = value; }
        }

        public string Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public override string ToString()
        {
            return mValue;
        }
    }
}
