using System.Collections.Generic;
using System.Text;


namespace Accounting.Report.Sales
{
    using Accounting.Core.Sales;
    using Accounting.Bll.Company;
    using Accounting.Util;
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Bll;

    public class SalePrintPresenter
    {
        private Sale mSale;
        private BOCompany mCompanyInfo;
        private Accountant mAccountant;

        
        public Status SaleStatus
        {
            get
            {
                return mSale.InvoiceStatus;
            }
        }

        public SalePrintPresenter(Accountant acc, Sale sale)
        {
            mSale = sale;
            mAccountant = acc;
            mCompanyInfo = acc.CompanyInfo;
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
                return string.Format("file:///{0}", AppEnv.GetFullPath("Images/barcode_sale.png"));
                //return "file:///C:/logo.JPG";
            }
        }
        

        public string InvoiceNumber
        {
            get
            {
                return mSale.InvoiceNumber;
            }
        }

        public string PaymentTerms
        {
            get
            {
                return mSale.Terms.TermsOfPayment.Description;
            }
        }

        public string OrderDescription
        {
            get
            {
                return mSale.Memo;
            }
        }

        public string InvoiceDate
        {
            get
            {
                if (mSale.InvoiceDate.HasValue)
                {
                    return mSale.InvoiceDate.Value.ToShortDateString();
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CustomerName
        {
            get
            {
                return mSale.Customer.Name;
            }
        }

        public string CustomerContactPerson
        {
            get
            {
                if (mSale.Customer.Address1 != null)
                {
                    return mSale.Customer.Address1.ContactName;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CustomerEmail
        {
            get
            {
                if (mSale.Customer.Address1 != null)
                {
                    return mSale.Customer.Address1.Email;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CustomerFax
        {
            get
            {
                if (mSale.Customer.Address1 != null)
                {
                    return mSale.Customer.Address1.Fax;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CustomerAddress
        {
            get
            {
                Address address = mSale.Customer.Address1;
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

        public string CustomerPostCode
        {
            get
            {
                Address address = mSale.Customer.Address1;
                if (address != null)
                {
                    return address.Postcode;
                }
                return "";
            }
        }

        public string CustomerPhone1
        {
            get
            {
                if (mSale.Customer.Address1 != null)
                {
                    return mSale.Customer.Address1.Phone1;
                }
                else
                {
                    return "NA";
                }
            }
        }

        public string CustomerPhone2
        {
            get
            {
                if (mSale.Customer.Address1 != null)
                {
                    return mSale.Customer.Address1.Phone2;
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
                if (mSale.ShipToAddress == "")
                {
                    return mCompanyInfo.Address;
                }
                return mSale.ShipToAddress;
            }
        }

        public string Currency
        {
            get
            {
                return mSale.Customer.Currency.CurrencyCode;
            }
        }

        public string DeliveryDate
        {
            get
            {
                if (mSale.PromisedDate.HasValue)
                {
                    return mSale.PromisedDate.Value.ToShortDateString();
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
                string locale = mCompanyInfo.City;
                if (mCompanyInfo.City != mCompanyInfo.Province && mCompanyInfo.Province != "")
                {
                    locale = string.Format("{0}, {1}", mCompanyInfo.City, mCompanyInfo.Province);
                    if (mCompanyInfo.City != mCompanyInfo.Country)
                    {
                        locale = string.Format("{0}, {1}, {0}", mCompanyInfo.City, mCompanyInfo.Province, mCompanyInfo.Country);
                    }
                }
                else if (mCompanyInfo.City != mCompanyInfo.Country)
                {
                    locale = string.Format("{0}, {1}", mCompanyInfo.City, mCompanyInfo.Country);
                }
                return string.Format("{0}\n{1} {2}", mCompanyInfo.Address, locale, mCompanyInfo.PostCode);
            }
        }

        public string OrderTotalPaid
        {
            get
            {
                double total = mSale.TotalLines + mSale.TotalTax;
                return string.Format("{0:C}", total);
            }
        }
        public string OrderTotalTax
        {
            get
            {
                return string.Format("{0:C}", mSale.TotalTax);
            }
        }
        public string OrderSubtotal
        {
            get
            {
                return string.Format("{0:C}", mSale.TotalLines);
            }
        }

        public IList<SaleLine> SaleLines
        {
            get
            {
                return mSale.SaleLines;
            }
        }
    }
}
