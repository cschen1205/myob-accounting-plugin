using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Cards
{
    public class ContactLog : Entity
    {
        internal ContactLog(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

        #region RecontactDate
        private DateTime? mRecontactDate;
        public DateTime? RecontactDate
        {
            get { return mRecontactDate; }
            set { mRecontactDate = value; NotifyPropertyChanged("RecontactDate");  }
        }
        #endregion
        

        #region ElapsedTime
        private string mElapsedTime="";
        public string ElapsedTime
        {
            get { return mElapsedTime; }
            set { mElapsedTime = value; NotifyPropertyChanged("ElapsedTime"); 
            }
        }
        #endregion

        #region LogDate
        private DateTime? mLogDate;
        public DateTime? LogDate
        {
            get { return mLogDate; }
            set { mLogDate = value; NotifyPropertyChanged("LogDate"); }
        }
        #endregion

        #region Date
        private DateTime? mDate;
        public DateTime? Date
        {
            get { return mDate; }
            set { mDate = value; NotifyPropertyChanged("Date");  }
        }
        #endregion

        

        #region ContactLogID
        private int? mContactLogID;
        public int? ContactLogID
        {
            get { return mContactLogID; }
            set { mContactLogID = value; NotifyPropertyChanged("ContactLogID");  }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ContactLogID", ContactLogID);
            }
        }

        #region Contact
        private string mContact = "";
        public string Contact
        {
            get { return mContact; }
            set { mContact = value; NotifyPropertyChanged("Contact");  }
        }
        #endregion;

        #region Card
        private int? mCardRecordID;
        public int? CardRecordID
        {
            get
            {
                if (mCard != null)
                {
                    return mCard.CardRecordID;
                }
                return mCardRecordID;
            }
            set
            {
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
        }
        private Card mCard = null;
        public Card Card
        {
            get
            {
                if (mCard == null)
                {
                    mCard = (Card)BuildProperty(this, "Card");
                }
                return mCard;
            }
            set
            {
                mCard = value;
                NotifyPropertyChanged("Card");
            }
        }
        #endregion

        #region Notes
        private string mNotes = "";
        public string Notes
        {
            get { return mNotes; }
            set { mNotes = value; NotifyPropertyChanged("Notes");  }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return Notes;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ContactLog)
            {
                ContactLog _obj = obj as ContactLog;
                if (_obj.FromDb && FromDb)
                {
                    return _obj.ContactLogID == ContactLogID;
                }
                return _obj.Contact.Equals(Contact)
                    && _obj.CardRecordID == CardRecordID
                    && _obj.Notes.Equals(Notes)
                    && _obj.ElapsedTime.Equals(ElapsedTime);
            }
            return false;
        }
        #endregion


    }
}
