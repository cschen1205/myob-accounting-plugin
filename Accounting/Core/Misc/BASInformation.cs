using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class BASInformation : Entity
    {
        internal BASInformation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mBASInformationID;
        public int? BASInformationID
        {
            get { return mBASInformationID; }
            set
            {
                mBASInformationID = value;
                NotifyPropertyChanged("BASInformationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
               return new RecordKeyInt("BASInformationID", BASInformationID);
            }
        }

        #region GSTFrequency
        private Definitions.Frequency mGSTFrequency = null;
        public Definitions.Frequency GSTFrequency
        {
            get
            {
                if (mGSTFrequency == null) mGSTFrequency = (Definitions.Frequency)BuildProperty(this, "GSTFrequency");
                return mGSTFrequency;
            }
            set
            {
                mGSTFrequency = value;
                NotifyPropertyChanged("GSTFrequency");
            }
        }
        private string mGSTFrequencyID;
        public string GSTFrequencyID
        {
            get
            {
                if (mGSTFrequency != null) return mGSTFrequency.FrequencyID;
                return mGSTFrequencyID;
            }
            set
            {
                mGSTFrequencyID = value;
                NotifyPropertyChanged("GSTFrequencyID");
            }
        }
        #endregion

        #region GSTBasis
        private Definitions.AccountingBasis mGSTBasis = null;
        public Definitions.AccountingBasis GSTBasis
        {
            get
            {
                if (mGSTBasis == null) mGSTBasis = (Definitions.AccountingBasis)BuildProperty(this, "GSTBasis");
                return mGSTBasis;
            }
            set
            {
                mGSTBasis = value;
                NotifyPropertyChanged("GSTBasis");
            }
        }
        private string mGSTBasisID;
        public string GSTBasisID
        {
            get
            {
                if (mGSTBasis != null) return mGSTBasis.AccountingBasisID;
                return mGSTBasisID;
            }
            set
            {
                mGSTBasisID = value;
                NotifyPropertyChanged("GSTBasisID");
            }
        }
        #endregion


        private string mGSTOption = "";
        public string GSTOption
        {
            get { return mGSTOption; }
            set
            {
                mGSTOption = value;
                NotifyPropertyChanged("GSTOption");
            }
        }

        private int? mGSTInstalmentAmount;
        public int? GSTInstalmentAmount
        {
            get { return mGSTInstalmentAmount; }
            set
            {
                mGSTInstalmentAmount = value;
                NotifyPropertyChanged("GSTInstalmentAmount");
            }
        }

        #region CalculationMethod
        private Definitions.CalculationMethod mCalculationMethod = null;
        public Definitions.CalculationMethod CalculationMethod
        {
            get
            {
                if (mCalculationMethod == null) mCalculationMethod = (Definitions.CalculationMethod)BuildProperty(this, "CalculationMethod");
                return mCalculationMethod;
            }
            set
            {
                mCalculationMethod = value;
                NotifyPropertyChanged("CalculationMethod");
            }
        }
        private string mCalculationMethodID;
        public string CalculationMethodID
        {
            get
            {
                if (mCalculationMethod != null) return mCalculationMethod.CalculationMethodID;
                return mCalculationMethodID;
            }
            set
            {
                mCalculationMethodID = value;
                NotifyPropertyChanged("CalculationMethodID");
            }
        }
        #endregion

        private string mClaimFuelTaxCredits = "";
        public string ClaimFuelTaxCredits
        {
            get { return mClaimFuelTaxCredits; }
            set
            {
                mClaimFuelTaxCredits = value;
                NotifyPropertyChanged("ClaimFuelTaxCredits");
            }
        }

        private string mUseSimplifiedAccounting = "N";
        public string UseSimplifiedAccounting
        {
            get { return mUseSimplifiedAccounting; }
            set
            {
                mUseSimplifiedAccounting = value;
                NotifyPropertyChanged("UseSimplifiedAccounting");
            }
        }

        private double mGSTFreeSales;
        public double GSTFreeSales
        {
            get { return mGSTFreeSales; }
            set
            {
                mGSTFreeSales = value;
                NotifyPropertyChanged("GSTFreeSales");
            }
        }

        private double mGSTFreePurchases;
        public double GSTFreePurchases
        {
            get { return mGSTFreePurchases; }
            set
            {
                mGSTFreePurchases = value;
                NotifyPropertyChanged("GSTFreePurchases");
            }
        }

        #region InstalmentFrequency
        private Definitions.Frequency mInstalmentFrequency = null;
        public Definitions.Frequency InstalmentFrequency
        {
            get
            {
                if (mInstalmentFrequency == null) mInstalmentFrequency = (Definitions.Frequency)BuildProperty(this, "InstalmentFrequency");
                return mInstalmentFrequency;
            }
            set
            {
                mInstalmentFrequency = value;
                NotifyPropertyChanged("InstalmentFrequency");
            }
        }
        private string mInstalmentFrequencyID;
        public string InstalmentFrequencyID
        {
            get
            {
                if (mInstalmentFrequency != null) return mInstalmentFrequency.FrequencyID;
                return mInstalmentFrequencyID;
            }
            set
            {
                mInstalmentFrequencyID = value;
                NotifyPropertyChanged("InstalmentFrequencyID");
            }
        }
        #endregion

        #region InstalmentBasis
        private Definitions.AccountingBasis mInstalmentBasis = null;
        public Definitions.AccountingBasis InstalmentBasis
        {
            get
            {
                if (mInstalmentBasis == null) mInstalmentBasis = (Definitions.AccountingBasis)BuildProperty(this, "InstalmentBasis");
                return mInstalmentBasis;
            }
            set
            {
                mInstalmentBasis = value;
                NotifyPropertyChanged("InstalmentBasis");
            }
        }
        private string mInstalmentBasisID;
        public string InstalmentBasisID
        {
            get
            {
                if (mInstalmentBasis != null) return mInstalmentBasis.AccountingBasisID;
                return mInstalmentBasisID;
            }
            set
            {
                mInstalmentBasisID = value;
                NotifyPropertyChanged("InstalmentBasisID");
            }
        }
        #endregion

        private string mInstalmentOption = "";
        public string InstalmentOption
        {
            get { return mInstalmentOption; }
            set
            {
                mInstalmentOption = value;
                NotifyPropertyChanged("InstalmentOption");
            }
        }

        private int? mPAYGInstalmentAmount;
        public int? PAYGInstalmentAmount
        {
            get { return mPAYGInstalmentAmount; }
            set
            {
                mPAYGInstalmentAmount = value;
                NotifyPropertyChanged("PAYGInstalmentAmount");
            }
        }

        private double mPAYGInstalmentRate;
        public double PAYGInstalmentRate
        {
            get { return mPAYGInstalmentRate; }
            set
            {
                mPAYGInstalmentRate = value;
                NotifyPropertyChanged("PAYGInstalmentRate");
            }
        }

        #region WithholdingFrequency
        private Definitions.Frequency mWithholdingFrequency = null;
        public Definitions.Frequency WithholdingFrequency
        {
            get
            {
                if (mWithholdingFrequency == null) mWithholdingFrequency = (Definitions.Frequency)BuildProperty(this, "WithholdingFrequency");
                return mWithholdingFrequency;
            }
            set
            {
                mWithholdingFrequency = value;
                NotifyPropertyChanged("WithholdingFrequency");
            }
        }
        private string mWithholdingFrequencyID="";
        public string WithholdingFrequencyID
        {
            get
            {
                if (mWithholdingFrequency != null) return mWithholdingFrequency.FrequencyID;
                return mWithholdingFrequencyID;
            }
            set
            {
                mWithholdingFrequencyID = value;
                NotifyPropertyChanged("WithholdingFrequencyID");
            }
        }
        #endregion

        private string mHaveFBTObligations = "";
        public string HaveFBTObligations
        {
            get { return mHaveFBTObligations; }
            set
            {
                mHaveFBTObligations = value;
                NotifyPropertyChanged("HaveFBTObligations");
            }
        }

        private int? mFBTInstalmentAmount;
        public int? FBTInstalmentAmount
        {
            get { return mFBTInstalmentAmount; }
            set
            {
                mFBTInstalmentAmount = value;
                NotifyPropertyChanged("FBTInstalmentAmount");
            }
        }

        private string mInclude13Period = "N";
        public string Include13Period
        {
            get { return mInclude13Period; }
            set
            {
                mInclude13Period = value;
                NotifyPropertyChanged("Include13Period");
            }
        }

    }
}
