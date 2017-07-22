using System.Collections.Generic;
using System.Text;


namespace Accounting.Report.Purchases
{
    using Accounting.Bll;
    using Accounting.Bll.Company;
    using Accounting.Core.Purchases;
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Util;

    public class PurchasePrintPresenter
    {
        private Purchase mPurchase;
        private BOCompany mCompanyInfo;
        private Accountant mAccountant;

        public PurchasePrintPresenter(Accountant acc, Purchase _obj)
        {
            mPurchase = _obj;
            mAccountant=acc;
            mCompanyInfo = mAccountant.CompanyInfo;
        }

        public Status PurchaseStatus
        {
            get
            {
                return mPurchase.PurchaseStatus;
            }
        }

        public string CompanyLogo
        {
            get
            {
                //Console.WriteLine(string.Format("file:///{0}", AppEnv.GetFullPath("Images/company_logo.png")));
                return string.Format("file:///{0}", AppEnv.GetFullPath("Images/company_logo.png"));
                //return "file:///C:/logo.JPG";
            }
        }

        public string Barcode
        {
            get
            {
                //Console.WriteLine(string.Format("file:///{0}", AppEnv.GetFullPath("Images/barcode_sale.png")));
                return string.Format("file:///{0}", AppEnv.GetFullPath("Images/barcode_purchase.png"));
                //return "file:///C:/logo.JPG";
            }
        }

        public string OrderNumber
        {
            get
            {
                return mPurchase.PurchaseNumber;
            }
        }

        public string PaymentTerms
        {
            get
            {
                return mPurchase.Terms.TermsOfPayment.Description;
            }
        }

        public string OrderDescription
        {
            get
            {
                return mPurchase.Memo;
            }
        }

        public string OrderDate
        {
            get
            {
                if (mPurchase.PurchaseDate.HasValue)
                {
                    return mPurchase.PurchaseDate.Value.ToShortDateString();
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string SupplierName
        {
            get
            {
                return mPurchase.Supplier.Name;
            }
        }

        public string SupplierContactPerson
        {
            get
            {
                if (mPurchase.Supplier.Address1 != null)
                {
                    return mPurchase.Supplier.Address1.ContactName;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string SupplierEmail
        {
            get
            {
                if (mPurchase.Supplier.Address1 != null)
                {
                    return mPurchase.Supplier.Address1.Email;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string SupplierFax
        {
            get
            {
                if (mPurchase.Supplier.Address1 != null)
                {
                    return mPurchase.Supplier.Address1.Fax;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string SupplierAddress
        {
            get
            {
                Address address=mPurchase.Supplier.Address1;
                if (address != null)
                {
                    StringBuilder sb = new StringBuilder();
                    if (address.StreetLine1 != "")
                    {
                        sb.AppendFormat("{0}\n", address.StreetLine1);
                    }
                    if (address.StreetLine2 != "")
                    {
                        sb.AppendFormat("{0}\n", address.StreetLine2);
                    }
                    if (address.StreetLine3 != "")
                    {
                        sb.AppendFormat("{0}\n", address.StreetLine3);
                    }
                    if (address.StreetLine4 != "")
                    {
                        sb.Append(address.StreetLine4);
                    }
                    return sb.ToString();
                }
                return "";
            }
        }

        public string SupplierPostCode
        {
            get
            {
                Address address = mPurchase.Supplier.Address1;
                if (address != null)
                {
                    return address.Postcode;
                }
                return "";
            }
        }

        public string SupplierPhone1
        {
            get
            {
                if (mPurchase.Supplier.Address1 != null)
                {
                    return mPurchase.Supplier.Address1.Phone1;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string SupplierPhone2
        {
            get
            {
                if (mPurchase.Supplier.Address1 != null)
                {
                    return mPurchase.Supplier.Address1.Phone2;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CompanyName
        {
            get
            {
                return mCompanyInfo.CompanyName;
            }
        }

        public string CompanyPhone1
        {
            get
            {
                return mCompanyInfo.Phone1;
            }
        }

        public string CompanyPhone2
        {
            get
            {
                return mCompanyInfo.Phone2;
            }
        }


        public string CompanyFax
        {
            get
            {
                return mCompanyInfo.Fax;
            }
        }

        public string CompanyEmail
        {
            get
            {
                return mCompanyInfo.Email;
            }
        }

        public string ShipToAddress
        {
            get
            {
                if (mPurchase.ShipToAddress == "")
                {
                    return mCompanyInfo.Address;
                }
                return mPurchase.ShipToAddress;
            }
        }

        public string Currency
        {
            get
            {
                return mPurchase.Supplier.Currency.CurrencyCode;
            }
        }

        public string DeliveryDate
        {
            get
            {
                if (mPurchase.PromisedDate.HasValue)
                {
                    return mPurchase.PromisedDate.Value.ToShortDateString();
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CompanyAddress
        {
            get
            {
                string locale=mCompanyInfo.City;
                if(mCompanyInfo.City != mCompanyInfo.Province && mCompanyInfo.Province != "")
                {
                    locale=string.Format("{0}, {1}", mCompanyInfo.City, mCompanyInfo.Province);
                    if(mCompanyInfo.City != mCompanyInfo.Country)
                    {
                         locale=string.Format("{0}, {1}, {0}", mCompanyInfo.City, mCompanyInfo.Province, mCompanyInfo.Country);
                    }
                }
                else if(mCompanyInfo.City != mCompanyInfo.Country)
                {
                    locale=string.Format("{0}, {1}", mCompanyInfo.City, mCompanyInfo.Country);
                }
                return string.Format("{0}\n{1} {2}", mCompanyInfo.Address, locale, mCompanyInfo.PostCode);
            }
        }

        public string OrderTotalPaid
        {
            get
            {
                double total = mPurchase.TotalLines + mPurchase.TotalTax;
                return string.Format("{0:C}", total); 
            }
        }
        public string OrderTotalTax
        {
            get
            {
                return string.Format("{0:C}", mPurchase.TotalTax); 
            }
        }
        public string OrderSubtotal
        {
            get
            {
                return string.Format("{0:C}", mPurchase.TotalLines); 
            }
        }

        public IList<PurchaseLine> PurchaseLines
        {
            get
            {
                return mPurchase.PurchaseLines;
            }
        }
    }
}
