using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core;
using Accounting.Core.Enumeration;
using Accounting.Core.Data;
using Accounting.Core.Accounts;
using Accounting.Bll;
using Accounting.Bll.Company;


namespace Accounting.Report.Accounts.BalanceSheets
{
    public class BalanceSheetStd
    {
        private BOCompany mCompanyModel;
        private Accountant mAccountant;
        public BalanceSheetStd(Accountant acc)
        {
            mAccountant = acc;
            mCompanyModel = mAccountant.CompanyInfo;
        }

        public string CompanyName
        {
            get { return mCompanyModel.CompanyName; }
        }

        public string CompanyAddress
        {
            get
            {
                return mCompanyModel.Address;
            }
        }

        public string AsOf
        {
            get
            {
                int? FinancialYear = mCompanyModel.CurrentFinancialYear;
                int? LastMonth=mCompanyModel.LastMonthInFinancialYear;
                string month = Month.Int2LongString(LastMonth.Value);
                return string.Format("As of {0} {1}", month, FinancialYear.Value);
            }
        }

        public string CreateTime
        {
            get
            {
                DateTime create_time=DateTime.Now;
                return string.Format("{0}/{1}/{2}\r\n{3}", 
                    create_time.Day,
                    create_time.Month,
                    create_time.Year, 
                    create_time.ToLongTimeString());
            }
        }

        public List<BalanceSheetLine> Lines
        {
            get
            {
                List<BalanceSheetLine> lines = new List<BalanceSheetLine>();
                TreeNode<Account> balanceSheet = mAccountant.AccountMgr.BalanceSheet;
                foreach (TreeNode<Account> child_node in balanceSheet.Children)
                {
                    AddLine(lines, child_node);
                    lines.Add(new BalanceSheetLine());
                }

                /*
                BalanceSheetLine line = new BalanceSheetLine();
                line.Type = BalanceSheetLine.LineType.Footer;
                line.Account = balanceSheet.Entity;
                lines.Add(line);*/
                return lines;
            }
        }

        private void AddLine(List<BalanceSheetLine> lines, TreeNode<Account> node)
        {
            BalanceSheetLine line = null;
            if (node.DataSource.IsHeader)
            {
                line = new BalanceSheetLine();
                line.Type = BalanceSheetLine.LineType.Header;
                line.Account = node.DataSource;
                lines.Add(line);
            }
            else
            {
                line = new BalanceSheetLine();
                line.Account = node.DataSource;
                lines.Add(line);
            }

            foreach (TreeNode<Account> child_node in node.Children)
            {
                AddLine(lines, child_node);
            }

            if (node.DataSource.IsHeader)
            {
                line = new BalanceSheetLine();
                line.Type = BalanceSheetLine.LineType.Footer;
                line.Account = node.DataSource;
                lines.Add(line);
            }
        }
    }
}
