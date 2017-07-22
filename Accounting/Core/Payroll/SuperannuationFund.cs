using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Payroll
{
    public class SuperannuationFund : Entity
    {
        internal SuperannuationFund(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSuperannuationFundID;
        public int? SuperannuationFundID
        {
            get { return mSuperannuationFundID; }
            set
            {
                mSuperannuationFundID = value;
                NotifyPropertyChanged("SuperannuationFundID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SuperannuationFundID", SuperannuationFundID);
            }
        }

        private string mSuperannuationFundName = "";
        public string SuperannuationFundName
        {
            get { return mSuperannuationFundName; }
            set
            {
                mSuperannuationFundName = value;
                NotifyPropertyChanged("SuperannuationFundName");
            }
        }

        private string mEmployerMembershipNumber = "";
        public string EmployerMembershipNumber
        {
            get { return mEmployerMembershipNumber; }
            set
            {
                mEmployerMembershipNumber = value;
                NotifyPropertyChanged("EmployerMembershipNumber");
            }
        }

        private string mIsPaid = "N";
        public string IsPaid
        {
            get { return mIsPaid; }
            set
            {
                mIsPaid = value;
                NotifyPropertyChanged("IsPaid");
            }
        }

        private string mSuperannuationFundToPay = "";
        public string SuperannuationFundToPay
        {
            get { return mSuperannuationFundToPay; }
            set
            {
                mSuperannuationFundToPay = value;
                NotifyPropertyChanged("SuperannuationFundToPay");
            }
        }

        private string mSuperannuationFundNumber = "";
        public string SuperannuationFundNumber
        {
            get { return mSuperannuationFundNumber; }
            set
            {
                mSuperannuationFundNumber = value;
                NotifyPropertyChanged("SuperannuationFundNumber");
            }
        }

        public override string ToString()
        {
            return SuperannuationFundName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is SuperannuationFund)
            {
                SuperannuationFund _obj = obj as SuperannuationFund;
                return _obj.SuperannuationFundName == SuperannuationFundName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
