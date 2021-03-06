using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Currencies
{
    public class Currency : Entity
    {
        #region CurrencyID
        private int? mCurrencyID;
        public int? CurrencyID
        {
            set 
            {
                mCurrencyID = value;
                NotifyPropertyChanged("CurrencyID");
            }
            get { return mCurrencyID; }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CurrencyID", CurrencyID);
            }
        }

        #region CurrencyName
        private string mCurrencyName="Singapore Dollars";
        public string CurrencyName
        {
            set
            {
                mCurrencyName = value;
                NotifyPropertyChanged("CurrencyName");
            }
            get { return mCurrencyName; }
        }
        #endregion

        #region CurrencyCode
        private string mCurrencyCode="SGD";
        public string CurrencyCode
        {
            set
            {
                mCurrencyCode = value;
                NotifyPropertyChanged("CurrencyCode");
            }
            get { return mCurrencyCode; }
        }
        #endregion

        #region ExchangeRate
        private double mExchangeRate=1;
        public double ExchangeRate
        {
            set 
            {
                mExchangeRate = value;
                NotifyPropertyChanged("ExchangeRate");
            }
            get { return mExchangeRate; }
        }
        #endregion

        #region CurrencySymbol
        private string mCurrencySymbol="S$";
        public string CurrencySymbol
        {
            set 
            {
                mCurrencySymbol = value;
                NotifyPropertyChanged("CurrencySymbol");
            }
            get { return mCurrencySymbol; }
        }
        #endregion

        #region DigitGroupingSymbol
        private string mDigitGroupingSymbol=",";
        public string DigitGroupingSymbol
        {
            set 
            {
                mDigitGroupingSymbol = value;
                NotifyPropertyChanged("DigitGroupingSymbol");
            }
            get { return mDigitGroupingSymbol; }
        }
        #endregion

        #region SymbolPosition
        private string mSymbolPosition="Before Number";
        public string SymbolPosition
        {
            set 
            { 
                mSymbolPosition = value;
                NotifyPropertyChanged("SymbolPosition");
            }
            get { return mSymbolPosition; }
        }
        #endregion

        #region DecimalPlaces
        private int? mDecimalPlaces=2;
        public int? DecimalPlaces
        {
            set 
            {
                mDecimalPlaces = value;
                NotifyPropertyChanged("DecimalPlaces");
            }
            get { return mDecimalPlaces; }
        }
        #endregion

        #region NumberDigitsInGroup
        private int? mNumberDigitsInGroup=3;
        public int? NumberDigitsInGroup
        {
            set
            {
                mNumberDigitsInGroup = value;
                NotifyPropertyChanged("NumberDigitsInGroup");
            }
            get { return mNumberDigitsInGroup; }
        }
        #endregion

        #region DecimalPlaceSymbol
        private string mDecimalPlaceSymbol=".";
        public string DecimalPlaceSymbol
        {
            set 
            {
                mDecimalPlaceSymbol = value;
                NotifyPropertyChanged("DecimalPlaceSymbol");
            }
            get { return mDecimalPlaceSymbol; }
        }
        #endregion

        #region NegativeFormat
        private string mNegativeFormat="Parenthesis";
        public string NegativeFormat
        {
            set 
            {
                mNegativeFormat = value;
                NotifyPropertyChanged("NegativeFormat");
            }
            get { return mNegativeFormat; }
        }
        #endregion 

        #region UseLeadingZero
        private string mUseLeadingZero="Y";
        public string UseLeadingZero
        {
            set
            {
                mUseLeadingZero = value;
                NotifyPropertyChanged("UseLeadingZero");
            }
            get { return mUseLeadingZero; }
        }
        #endregion

        #region -(Format)
        public string Format(double amount)
        {
            System.Globalization.NumberFormatInfo nfi;
            nfi = new System.Globalization.NumberFormatInfo();

            nfi.CurrencySymbol = mCurrencySymbol;
            nfi.CurrencyDecimalDigits = DecimalPlaces.Value;
            nfi.CurrencyDecimalSeparator = DecimalPlaceSymbol;
            nfi.CurrencyGroupSeparator = DigitGroupingSymbol;
            nfi.CurrencyGroupSizes =new int[] {NumberDigitsInGroup.Value};
            if (SymbolPosition == "Before Number")
            {
                if (NegativeFormat == "Parenthesis")
                {
                    nfi.CurrencyNegativePattern = 0;
                }
                else
                {
                    nfi.CurrencyNegativePattern = 1;
                }
                nfi.CurrencyPositivePattern = 0;
            }
            else
            {
                if (NegativeFormat == "Parenthesis")
                {
                    nfi.CurrencyNegativePattern = 4;
                }
                else
                {
                    nfi.CurrencyNegativePattern = 5;
                }
                nfi.CurrencyPositivePattern = 1;
            }

            return string.Format(nfi, "{0:C}", amount);
        }

        public string FormatPercent(double amount)
        {
            System.Globalization.NumberFormatInfo nfi;
            nfi = new System.Globalization.NumberFormatInfo();

            nfi.CurrencySymbol = "%";
            nfi.CurrencyDecimalDigits = 1;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.CurrencyGroupSeparator = DigitGroupingSymbol;
            nfi.CurrencyGroupSizes = new int[] { NumberDigitsInGroup.Value };

                if (NegativeFormat == "Parenthesis")
                {
                    nfi.CurrencyNegativePattern = 4;
                }
                else
                {
                    nfi.CurrencyNegativePattern = 5;
                }
                nfi.CurrencyPositivePattern = 1;

            return string.Format(nfi, "{0:C}", amount);
        }
        #endregion

        #region -(ConvertFromCurrency)
        public double ConvertFromCurrency(Currency rhs, double amount)
        {
            return amount * rhs.ExchangeRate / mExchangeRate;
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mCurrencyCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is Currency)
            {
                Currency _obj = (Currency)obj;
                if (_obj.FromDb && FromDb)
                {
                    return _obj.CurrencyID == mCurrencyID;
                }
                else
                {
                    return _obj.CurrencyCode.Equals(CurrencyCode);
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region -(Constructor)
        internal Currency(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

   
    }
}
