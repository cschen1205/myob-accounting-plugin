using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public class JournalType : Entity
    {
        #region -(Constructor)
        internal JournalType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

      

        #region Description
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set 
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }
        #endregion

        #region JournalTypeID
        private string mJournalTypeID;
        public string JournalTypeID
        {
            get { return mJournalTypeID; }
            set 
            {
                mJournalTypeID = value;
                NotifyPropertyChanged("JournalTypeID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("JournalTypeID", JournalTypeID);
            }
        }
    }
}
