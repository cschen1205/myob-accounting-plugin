using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Bll.Company
{
    using Accounting.Core;
    using Accounting.Core.Misc;

    public class BOCompany : BusinessObject
    {
        DataFileInformation mDataProxy;
        DataFileInformation mDataSource;

        public BOCompany(Accountant acc, DataFileInformation data, BOContext context)
            : base(acc, context)
        {
            mObjectID = BOType.BOCompany;
            mDataProxy = data.Clone() as DataFileInformation;
            mDataSource = data;
        }

        public DataFileInformation DataSource
        {
            get
            {
                return mDataProxy;
            }
        }

        public string DefaultCompanyLogoPath
        {
            get
            {
                //Console.WriteLine(string.Format("file:///{0}", AppEnv.GetFullPath("Images/company_logo.png")));
                return mAccountant.GetFullPath("Images/company_logo.png");
                //return "file:///C:/logo.JPG";
            }
        }

        public string DefaultCompanyLogoDirectory
        {
            get
            {
                //Console.WriteLine(string.Format("file:///{0}", AppEnv.GetFullPath("Images/company_logo.png")));
                return mAccountant.GetFullPath("Images");
                //return "file:///C:/logo.JPG";
            }
        }

        #region RegistrationNumber
        //private string mRegistrationNumber;
        public string RegistrationNumber
        {
            get { return mDataProxy.CompanyRegistrationNumber; }
            set { mDataProxy.CompanyRegistrationNumber = value; }
        }
        #endregion

        #region ID
        //private int mID;
        public int? ID
        {
            get { return mDataProxy.ID; }
            set { mDataProxy.ID = value; }
        }
        #endregion

        #region CompanyName
        //private string mCompanyName;
        public string CompanyName
        {
            get { return mDataProxy.CompanyName; }
            set { mDataProxy.CompanyName=value; }
        }
        #endregion

        #region Address
        //private string mAddress;
        public string Address
        {
            get { return mDataProxy.Address; }
            set { mDataProxy.Address=value; }
        }
        #endregion

        #region CompanyInfo.City
        //private string mCity;
        public string City
        {
            get { return mDataProxy.City; }
            set { mDataProxy.City=value; }
        }
        #endregion

        #region CompanyInfo.Province
        //private string mProvince;
        public string Province
        {
            get { return mDataProxy.Province; }
            set { mDataProxy.Province=value; }
        }
        #endregion

        #region PostCode
        //private string mPostCode;
        public string PostCode
        {
            get { return mDataProxy.PostCode; }
            set { mDataProxy.PostCode=value; }
        }
        #endregion

        #region Country
        //private string mCountry;
        public string Country
        {
            get { return mDataProxy.DataFileCountry; }
            set { mDataProxy.DataFileCountry=value; }
        }
        #endregion

        #region Phone1
        //private string mPhone1;
        public string Phone1
        {
            get { return mDataProxy.Phone1; }
            set { mDataProxy.Phone1=value; }
        }
        #endregion

        #region Phone2
        //private string mPhone2;
        public string Phone2
        {
            get { return mDataProxy.Phone2; }
            set { mDataProxy.Phone2=value; }
        }
        #endregion

        #region Fax
        //private string mFax;
        public string Fax
        {
            get { return mDataProxy.FaxNumber; }
            set { mDataProxy.FaxNumber=value; }
        }
        #endregion

        #region CurrentFinancialYear
        public int? CurrentFinancialYear
        {
            get { return mDataProxy.CurrentFinancialYear; }
            set { mDataProxy.CurrentFinancialYear = value; }
        }
        #endregion

        #region LastMonthInFinancialYear
        public int? LastMonthInFinancialYear
        {
            get { return mDataProxy.LastMonthInFinancialYear; }
            set
            {
                mDataProxy.LastMonthInFinancialYear = value;
            }
        }
        #endregion

        #region Email
        //private string mEmail;
        public string Email
        {
            get { return mDataProxy.Email; }
            set { mDataProxy.Email=value; }
        }
        #endregion

        #region WebSite
        //private string mWebSite;
        public string WebSite
        {
            get { return mDataProxy.WebSite; }
            set { mDataProxy.WebSite = value; }
        }
        #endregion

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.DataFileInformationMgr.Store(mDataSource);
        }
    }
}
