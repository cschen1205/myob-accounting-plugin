using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Cards;
using Accounting.Core.TaxCodes;
using Accounting.Core.Definitions;
using Accounting.Core.Currencies;
using Accounting.Core;

namespace Accounting.Bll.Cards
{
    using System.ComponentModel;
    public class BOListCard : BOList<BOCard>
    {
        public static string ALL_CARDS_INFORMATION="AllCardsInformation";
        public static string CUSTOMERS_INFORMATION = "CustomersInformation";
        public static string SUPPLIERS_INFORMATION = "SuppliersInformation";
        public static string EMPLOYEES_INFORMATION = "EmployeesInformation";

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(ALL_CARDS_INFORMATION,
                ALL_CARDS_INFORMATION,
                delegate() { return string.Format("# found: {0}", mAllCards.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(CUSTOMERS_INFORMATION,
                CUSTOMERS_INFORMATION,
                delegate() { return string.Format("# found: {0}", mCustomers.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(EMPLOYEES_INFORMATION,
                EMPLOYEES_INFORMATION,
                delegate() { return string.Format("# found: {0}", mEmployees.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(SUPPLIERS_INFORMATION,
                SUPPLIERS_INFORMATION,
                delegate() { return string.Format("# found: {0}", mSuppliers.Count); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });
        }

        private CardType.TypeID mActiveCardType=CardType.TypeID.None;
        public CardType.TypeID ActiveCardType
        {
            get { return mActiveCardType; }
            set { mActiveCardType = value; }
        }

        private BindingList<Card> mAllCards = new BindingList<Card>();
        private BindingList<Supplier> mSuppliers = new BindingList<Supplier>();
        private BindingList<Customer> mCustomers = new BindingList<Customer>();
        private BindingList<Employee> mEmployees = new BindingList<Employee>();

        public IList<Card> AllCards { get { return mAllCards; } }
        public IList<Supplier> Suppliers { get { return mSuppliers; } }
        public IList<Customer> Customers { get { return mCustomers; } }
        public IList<Employee> Employees { get { return mEmployees; } }

        public BOListCard(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListCard;

            UpdateContent();

            mAccountant.SupplierMgr.PropertyChanged += new PropertyChangedEventHandler(SupplierMgr_PropertyChanged);
            mAccountant.EmployeeMgr.PropertyChanged += new PropertyChangedEventHandler(EmployeeMgr_PropertyChanged);
            mAccountant.CustomerMgr.PropertyChanged += new PropertyChangedEventHandler(CustomerMgr_PropertyChanged);
        }

        protected override void UpdateContent()
        {
            Console.WriteLine("{0} : UpdateContent", ObjectID);
            mSuppliers.Clear();
            mEmployees.Clear();
            mCustomers.Clear();
            mAllCards.Clear();

            IList<Supplier> suppliers = FindSuppliers();
            foreach (Supplier supplier in suppliers)
            {
                mSuppliers.Add(supplier);
                mAllCards.Add(supplier);
            }

            IList<Employee> employees = FindEmployees();
            foreach (Employee employee in employees)
            {
                mEmployees.Add(employee);
                mAllCards.Add(employee);
            }            

            IList<Customer> customers = FindCustomers();
            foreach (Customer customer in customers)
            {
                mCustomers.Add(customer);
                mAllCards.Add(customer);
            }
        }

        private void CustomerMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        private void EmployeeMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        private void SupplierMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        //private IList<Card> FindAllCards()
        //{
        //    BindingList<Card> cards = new BindingList<Card>();
        //    IList<Employee> employees = FindEmployees();
        //    foreach (Employee employee in employees)
        //    {
        //        cards.Add(employee);
        //    }
        //    IList<Supplier> suppliers = FindSuppliers();
        //    foreach (Supplier supplier in suppliers)
        //    {
        //        cards.Add(supplier);
        //    }
        //    IList<Customer> customers = FindCustomers();
        //    foreach (Customer customer in customers)
        //    {
        //        cards.Add(customer);
        //    }
        //    return cards;
        //}

        private IList<Employee> FindEmployees()
        {
            return mAccountant.EmployeeMgr.FindAllCollection();
        }

        private IList<Supplier> FindSuppliers()
        {
            return mAccountant.SupplierMgr.FindAllCollection();
        }

        private IList<Customer> FindCustomers()
        {
            return mAccountant.CustomerMgr.FindAllCollection();
        }

        public override bool CanDelete
        {
            get
            {
                return mAccountant.CardMgr.DbMgr.AllowDelete;
            }
        }

    }
}
