using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class Config : Entity
    {
        internal Config(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mConfigID;
        public int? ConfigID
        {
            get { return mConfigID; }
            set
            {
                mConfigID = value;
                NotifyPropertyChanged("ConfigID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ConfigID", ConfigID);
            }
        }

        private string mConfigName = "";
        public string ConfigName
        {
            get { return mConfigName; }
            set
            {
                mConfigName = value;
                NotifyPropertyChanged("ConfigName");
            }
        }

        private string mConfigValue = "";
        public string ConfigValue
        {
            get { return mConfigValue; }
            set
            {
                mConfigValue = value;
                NotifyPropertyChanged("ConfigValue");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Config)
            {
                Config _obj = obj as Config;
                return _obj.ConfigName.Equals(ConfigName);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
