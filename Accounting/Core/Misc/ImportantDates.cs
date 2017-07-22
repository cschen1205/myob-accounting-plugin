using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class ImportantDates : Entity
    {
        internal ImportantDates(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mImportantDatesID;
        public int? ImportantDatesID
        {
            get { return mImportantDatesID; }
            set
            {
                mImportantDatesID = value;
                NotifyPropertyChanged("ImportantDatesID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ImportantDatesID", ImportantDatesID);
            }
        }

        private int? mCalendarYear;
        public int? CalendarYear
        {
            get { return mCalendarYear; }
            set
            {
                mCalendarYear = value;
                NotifyPropertyChanged("CalendarYear");
            }
        }

        private string mJanuaryDetails = "";
        public string JanuaryDetails
        {
            get { return mJanuaryDetails; }
            set
            {
                mJanuaryDetails = value;
                NotifyPropertyChanged("JanuaryDetails");
            }
        }

        private string mFebruaryDetails = "";
        public string FebruaryDetails
        {
            get { return mFebruaryDetails; }
            set
            {
                mFebruaryDetails = value;
                NotifyPropertyChanged("FebruaryDetails");
            }
        }

        private string mMarchDetails = "";
        public string MarchDetails
        {
            get { return mMarchDetails; }
            set
            {
                mMarchDetails = value;
                NotifyPropertyChanged("MarchDetails");
            }
        }

        private string mAprilDetails = "";
        public string AprilDetails
        {
            get { return mAprilDetails; }
            set
            {
                mAprilDetails = value;
                NotifyPropertyChanged("AprilDetails");
            }
        }

        private string mMayDetails = "";
        public string MayDetails
        {
            get { return mMayDetails; }
            set
            {
                mMayDetails = value;
                NotifyPropertyChanged("MayDetails");
            }
        }

        private string mJuneDetails = "";
        public string JuneDetails
        {
            get { return mJuneDetails; }
            set
            {
                mJuneDetails = value;
                NotifyPropertyChanged("JuneDetails");
            }
        }

        private string mJulyDetails = "";
        public string JulyDetails
        {
            get { return mJulyDetails; }
            set
            {
                mJulyDetails = value;
                NotifyPropertyChanged("JulyDetails");
            }
        }

        private string mAugustDetails = "";
        public string AugustDetails
        {
            get { return mAugustDetails; }
            set
            {
                mAugustDetails = value;
                NotifyPropertyChanged("AugustDetails");
            }
        }

        private string mSeptemberDetails = "";
        public string SeptemberDetails
        {
            get { return mSeptemberDetails; }
            set
            {
                mSeptemberDetails = value;
                NotifyPropertyChanged("SeptemberDetails");
            }
        }

        private string mOctoberDetails = "";
        public string OctoberDetails
        {
            get { return mOctoberDetails; }
            set
            {
                mOctoberDetails = value;
                NotifyPropertyChanged("OctoberDetails");
            }
        }

        private string mNovemberDetails = "";
        public string NovemberDetails
        {
            get { return mNovemberDetails; }
            set
            {
                mNovemberDetails = value;
                NotifyPropertyChanged("NovemberDetails");
            }
        }

        private string mDecemberDetails = "";
        public string DecemberDetails
        {
            get { return mDecemberDetails; }
            set
            {
                mDecemberDetails = value;
                NotifyPropertyChanged("DecemberDetails");
            }
        }
    }
}
