using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.CostCentres
{
    public class CostCentre : Entity
    {
        internal CostCentre(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCostCentreID;
        public int? CostCentreID
        {
            get { return mCostCentreID; }
            set
            {
                mCostCentreID = value;
                NotifyPropertyChanged("CostCentreID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CostCentreID", CostCentreID);
            }
        }

        private string mCostCentreName = "";
        public string CostCentreName
        {
            get { return mCostCentreName; }
            set
            {
                mCostCentreName = value;
                NotifyPropertyChanged("CostCentreName");
            }
        }

        private string mCostCentreIdentification = "";
        public string CostCentreIdentification
        {
            get { return mCostCentreIdentification; }
            set
            {
                mCostCentreIdentification = value;
                NotifyPropertyChanged("CostCentreIdentification");
            }
        }

        private string mCostCentreDescription = "";
        public string CostCentreDescription
        {
            get { return mCostCentreDescription; }
            set
            {
                mCostCentreDescription = value;
                NotifyPropertyChanged("CostCentreDescription");
            }
        }

        private string mIsInactive = "N";
        public string IsInactive
        {
            get
            {
                return mIsInactive;
            }
            set
            {
                mIsInactive = value;
                NotifyPropertyChanged("IsInactive");
            }
        }
    }
}
