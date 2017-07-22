using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Cards
{
    public class PersonalCard : Card
    {
        internal PersonalCard(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

       

        private int? mPersonalCardID;
        public int? PersonalCardID
        {
            get { return mPersonalCardID; }
            set
            {
                mPersonalCardID = value;
                NotifyPropertyChanged("PersonalCardID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PersonalCardID", PersonalCardID);
            }
        }

        private string mFirstName = "";
        public string FirstName
        {
            get { return mFirstName; }
            set
            {
                mFirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        private string mLastName = "";
        public string LastName
        {
            get { return mLastName; }
            set
            {
                mLastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        private string mChangeControl = "";
        public string ChangeControl
        {
            get { return mChangeControl; }
            set
            {
                mChangeControl = value;
                NotifyPropertyChanged("ChangeControl");
            }
        }

        private string mNotes = "";
        public string Notes
        {
            get { return mNotes; }
            set
            {
                mNotes = value;
                NotifyPropertyChanged("Notes");
            }
        }

        private string mPicture = "";
        public string Picture
        {
            get { return mPicture; }
            set
            {
                mPicture = value;
                NotifyPropertyChanged("Picture");
            }
        }
    }
}
