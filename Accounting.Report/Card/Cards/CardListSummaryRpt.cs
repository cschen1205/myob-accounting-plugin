using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Accounting.Report.Card.Cards
{
    using Accounting.Core.Misc;
    using Accounting.Core.Cards;
    using Accounting.Bll;
    using System.Data;

    public class CardListSummaryRpt : ReportTemplate
    {

        public enum CardType
        {
            All,
            Supplier,
            Customer,
            Employee
        }

        public CardListSummaryRpt(Accountant acc)
            : base(acc)
        {

        }



        protected override Doddle.Reporting.Report BuildReport()
        {
            Doddle.Reporting.Report report = CreateReport("Card List Summary");
            report.Source = new Doddle.Reporting.DataTableReportSource(BuildTable());

            return report;
        }

        public bool DisplayName { get; set; }
        public bool DisplayPhone { get; set; }
        public bool DisplayType { get; set; }
        public bool DisplayCurrentBalance { get; set; }
        public bool DisplayCardID { get; set; }
        public bool DisplayStatus { get; set; }

        public enum FieldName
        {
            Name,
            Phone,
            Type,
            CurrentBalance,
            CardID,
            Status
        }

        private CardType mCardType = CardType.All;
        public CardType Type
        {
            get { return mCardType; }
            set { mCardType = value; }
        }

        private bool mIncludeInactiveCards = true;
        public bool IncludeInactiveCards
        {
            get { return mIncludeInactiveCards; }
            set { mIncludeInactiveCards = value; }
        }

        public Dictionary<FieldName, int> FieldOrder = new Dictionary<FieldName, int>();

        private IList<Card> GetCards()
        {
            IList<Card> items = new List<Card>();

            if (mCardType == CardType.All)
            {
                IList<Card> cards = mAccountant.CardMgr.FindAllCollection();
                if (!mIncludeInactiveCards)
                {
                    foreach (Card _card in cards)
                    {
                        if (!_card.Inactive)
                        {
                            items.Add(_card);
                        }
                    }
                }
            }
            else if (mCardType == CardType.Customer)
            {
                IList<Customer> customers = mAccountant.CustomerMgr.FindAllCollection();
                if (!mIncludeInactiveCards)
                {
                    foreach (Card _card in customers)
                    {
                        if (!_card.Inactive)
                        {
                            items.Add(_card);
                        }
                    }
                }
            }
            else if (mCardType == CardType.Supplier)
            {
                IList<Supplier> suppliers = mAccountant.SupplierMgr.FindAllCollection();
                if (!mIncludeInactiveCards)
                {
                    foreach (Card _card in suppliers)
                    {
                        if (!_card.Inactive)
                        {
                            items.Add(_card);
                        }
                    }
                }
            }
            else if (mCardType == CardType.Employee)
            {
                IList<Employee> employees = mAccountant.EmployeeMgr.FindAllCollection();
                if (!mIncludeInactiveCards)
                {
                    foreach (Card _card in employees)
                    {
                        if (!_card.Inactive)
                        {
                            items.Add(_card);
                        }
                    }
                }
            }

            return items;
        }

        private DataTable BuildTable()
        {
            IList<Card> items = GetCards();

            DataTable table = new DataTable();

            List<FieldName> names = new List<FieldName>();
            foreach (FieldName fn in FieldOrder.Keys)
            {
                names.Add(fn);
            }
            for (int i = 0; i < names.Count - 1; ++i)
            {
                for (int j = i + 1; j < names.Count; ++j)
                {
                    if (FieldOrder[names[i]] > FieldOrder[names[j]])
                    {
                        FieldName temp = names[i];
                        names[i] = names[j];
                        names[j] = temp;
                    }
                }
            }

            for (int i = 0; i < names.Count; ++i)
            {
                FieldName fn = names[i];
                if (fn == FieldName.Name && DisplayName)
                {
                    table.Columns.Add("Name");
                }
                else if (fn == FieldName.Phone && DisplayPhone)
                {
                    table.Columns.Add("Phone");
                }
                else if (fn == FieldName.Type && DisplayType)
                {
                    table.Columns.Add("Type");
                }
                else if (fn == FieldName.CurrentBalance && DisplayCurrentBalance)
                {
                    table.Columns.Add("Current Balance");
                }
                else if (fn == FieldName.CardID && DisplayCardID)
                {
                    table.Columns.Add("Card ID");
                }
                else if (fn == FieldName.Status && DisplayStatus)
                {
                    table.Columns.Add("Status");
                }
            }

            DataRow row = null;
            foreach (Card item in items)
            {
                row = table.NewRow();

                for (int i = 0; i < names.Count; ++i)
                {
                    FieldName fn = names[i];
                    if (fn == FieldName.Name && DisplayName)
                    {
                        row["Name"] = item.Name;
                    }
                    if (fn == FieldName.Phone && DisplayPhone)
                    {
                        row["Phone"] = item.Address1.Phone1;
                    }
                    if (fn == FieldName.Type && DisplayType)
                    {
                        if (item is Customer)
                        {
                            row["Type"] = "Customer";
                        }
                        else if (item is Supplier)
                        {
                            row["Type"] = "Supplier";
                        }
                        else if (item is Employee)
                        {
                            row["Type"] = "Employee";
                        }
                        else
                        {
                            row["Type"] = "Card";
                        }
                    }
                    if (fn == FieldName.CurrentBalance && DisplayCurrentBalance)
                    {
                        if (item is Customer)
                        {
                            Customer _customer = (item as Customer);
                            row["Current Balance"] = _customer.Currency.Format(_customer.CurrentBalance);
                        }
                        else if (item is Supplier)
                        {
                            Supplier _supplier = (item as Supplier);
                            row["Current Balance"] = _supplier.Currency.Format(_supplier.CurrentBalance);
                        }
                        else if (item is Employee)
                        {
                            Employee _employee = (item as Employee);
                            row["Current Balance"] = _employee.Currency.Format(_employee.Bank1Value);
                        }
                        else
                        {
                            row["Current Balance"] = "NA";
                        }
                    }
                    if (fn == FieldName.CardID && DisplayCardID)
                    {
                        row["Card ID"] = item.CardIdentification;
                    }
                    if (fn == FieldName.Status && DisplayStatus)
                    {
                        if (item.Inactive)
                        {
                            row["Status"] = "Inactive";
                        }
                        else
                        {
                            row["Status"] = "Active";
                        }
                    }
                }
                table.Rows.Add(row);
            }
            
            return table;
        }
    }
}
