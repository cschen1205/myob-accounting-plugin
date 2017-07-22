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

namespace Accounting.Report.Accounts.PLStatements
{
    public class PLStatementAccrual
    {
        private BOCompany mCompanyModel;
        private Accountant mAccountant;
        public PLStatementAccrual(Accountant acc)
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

        public List<PLStatementLine> Lines
        {
            get
            {
                List<PLStatementLine> lines = new List<PLStatementLine>();

                TreeNode<Account> PLStatement = mAccountant.AccountMgr.PLStatement;
                TreeNode<Account> node_income = null;
                TreeNode<Account> node_cos = null;
                TreeNode<Account> node_expenses = null;
                TreeNode<Account> node_other_income = null;
                TreeNode<Account> node_other_expenses = null;
                foreach (TreeNode<Account> child_node in PLStatement.Children)
                {
                    string accountName = child_node.DataSource.AccountName;
                    if (accountName.Equals("Income"))
                    {
                        node_income = child_node;
                    }
                    else if (accountName.Equals("Cost Of Sales"))
                    {
                        node_cos = child_node;
                    }
                    else if (accountName.Equals("Expenses"))
                    {
                        node_expenses = child_node;
                    }
                    else if (accountName.Equals("Other Income"))
                    {
                        node_other_income = child_node;
                    }
                    else if (accountName.Equals("Other Expenses"))
                    {
                        node_other_expenses = child_node;
                    }
                }

                AddLine(lines, node_income);
                lines.Add(new PLStatementLine());
                AddLine(lines, node_cos);
                lines.Add(new PLStatementLine());
                //PopulateTreeGridView(tgvPLStatement, node_income, year, period, budgets);
                //PopulateTreeGridView(tgvPLStatement, node_cos, year, period, budgets);

                /*
                double gross_profit = 0, gross_profit2 = 0;
                if (node_income != null && node_cos != null)
                {
                    double income = node_income.Entity.GetAccountBalance(year, period, budgets);
                    double cos = node_cos.Entity.GetAccountBalance(year, period, budgets);
                    gross_profit = income - cos;
                    string gross_profit_formatted = PLStatement.Entity.Currency.Format(gross_profit);

                    income = node_income.Entity.GetAmountByPeriod(year, period, budgets);
                    cos = node_cos.Entity.GetAmountByPeriod(year, period, budgets);
                    gross_profit2 = income - cos;
                    string gross_profit_formatted2 = PLStatement.Entity.Currency.Format(gross_profit2);

                    PopulateTreeGridView(tgvPLStatement, "Gross Profit", gross_profit_formatted, gross_profit_formatted2);
                }*/

                AddLine(lines, node_expenses);
                lines.Add(new PLStatementLine());
                //PopulateTreeGridView(tgvPLStatement, node_expenses, year, period, budgets);

                /*
                double operating_profit = 0, operating_profit2 = 0;
                if (node_expenses != null)
                {
                    double expenses = node_expenses.Entity.GetAccountBalance(year, period, budgets);
                    operating_profit = gross_profit - expenses;
                    string operating_profit_formatted = PLStatement.Entity.Currency.Format(operating_profit);

                    expenses = node_expenses.Entity.GetAmountByPeriod(year, period, budgets);
                    operating_profit2 = gross_profit2 - expenses;
                    string operating_profit_formatted2 = PLStatement.Entity.Currency.Format(operating_profit2);

                    PopulateTreeGridView(tgvPLStatement, "Operating Profit", operating_profit_formatted, operating_profit_formatted2);
                }*/


                AddLine(lines, node_other_income);
                lines.Add(new PLStatementLine());
                AddLine(lines, node_other_expenses);
                lines.Add(new PLStatementLine());
                //PopulateTreeGridView(tgvPLStatement, node_other_income, year, period, budgets);
                //PopulateTreeGridView(tgvPLStatement, node_other_expenses, year, period, budgets);

           
                PLStatementLine line = new PLStatementLine();
                line.Type = PLStatementLine.LineType.Footer;
                line.Account = PLStatement.DataSource;
                lines.Add(line);
                return lines;
            }
        }

        private void AddLine(List<PLStatementLine> lines, TreeNode<Account> node)
        {
            PLStatementLine line = null;
            if (node.DataSource.IsHeader)
            {
                line = new PLStatementLine();
                line.Type = PLStatementLine.LineType.Header;
                line.Account = node.DataSource;
                lines.Add(line);
            }
            else
            {
                line = new PLStatementLine();
                line.Account = node.DataSource;
                lines.Add(line);
            }

            foreach (TreeNode<Account> child_node in node.Children)
            {
                AddLine(lines, child_node);
            }

            if (node.DataSource.IsHeader)
            {
                line = new PLStatementLine();
                line.Type = PLStatementLine.LineType.Footer;
                line.Account = node.DataSource;
                lines.Add(line);
            }
        }
    }
}
