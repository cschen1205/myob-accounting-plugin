using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class DataField : Entity
    {
        internal DataField(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    DataField _rhs=rhs as DataField;
        //    DataFieldName = _rhs.DataFieldName;
        //    DataFieldType = _rhs.DataFieldType;
        //}

        public override void AssignFrom(Entity rhs)
        {
            base.AssignFrom(rhs);

            DataField _rhs=rhs as DataField;
            DataFieldID = _rhs.DataFieldID;
        }

        private int? mDataFieldID;
        public int? DataFieldID
        {
            get { return mDataFieldID; }
            set 
            {
                mDataFieldID = value;
                NotifyPropertyChanged("DataFieldID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("DataFieldID", DataFieldID);
            }
        }

        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("DataFieldName", DataFieldName);
            }
        }

        private string mDataFieldType;
        public string DataFieldType
        {
            get { return mDataFieldType; }
            set 
            {
                mDataFieldType = value;
                NotifyPropertyChanged("DataFieldType");
            }
        }

        private string mDataFieldName;
        public string DataFieldName
        {
            get { return mDataFieldName; }
            set 
            {
                mDataFieldName = value;
                NotifyPropertyChanged("DataFieldName");
            }
        }

        

        private bool mIsNullable;
        public bool IsNullable
        {
            get { return mIsNullable; }
            set 
            {
                mIsNullable = value;
                NotifyPropertyChanged("IsNullable");
            }
        }

        public override string ToString()
        {
            return mDataFieldName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is DataField)
            {
                DataField _obj = obj as DataField;
                return _obj.DataFieldName == DataFieldName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }
}
