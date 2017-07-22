using System;
using System.Windows.Forms;


namespace DacII.WinForms.Cards
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using Accounting.Core.Cards;
    using Accounting.Bll;
    using Accounting.Bll.Cards;

    public partial class FrmCardsRegister : BaseView
    {
        private BOListCard mModel=null;
        private BOViewModel mViewModel;

        public FrmCardsRegister(ApplicationPresenter ap,  BOListCard model)
            : base(ap)
        {
            InitializeComponent();
            mModel = model;
            mViewModel = new BOViewModel(model);

            BindViews();
            RegisterEventHandlers();

            ConfigureDataGridView(dgvAll);
            ConfigureDataGridView(dgvSuppliers);
            ConfigureDataGridView(dgvEmployees);
            ConfigureDataGridView(dgvCustomers);
        }

        public BOListCard Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            DataGridViewColumn c = null;

            if (dgv == dgvEmployees)
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "CardIdentification";
                c.HeaderText = "Card ID";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "FirstName";
                c.HeaderText = "First Name";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "LastName";
                c.HeaderText = "Last Name";
                dgv.Columns.Add(c);

                c = new DataGridViewCheckBoxColumn();
                c.DataPropertyName = "Inactive";
                c.HeaderText = "Inactive";
                dgv.Columns.Add(c);
            }
            else
            {
                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "CardIdentification";
                c.HeaderText = "Card ID";
                dgv.Columns.Add(c);

                c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = "Name";
                c.HeaderText = "Name";
                dgv.Columns.Add(c);

                c = new DataGridViewCheckBoxColumn();
                c.DataPropertyName = "Inactive";
                c.HeaderText = "Inactive";
                dgv.Columns.Add(c);
            }

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(dgv);
        }

        protected override void BindViews()
        {
            dgvAll.DataSource = mModel.AllCards;
            dgvCustomers.DataSource = mModel.Customers;
            dgvSuppliers.DataSource = mModel.Suppliers;
            dgvEmployees.DataSource = mModel.Employees;

            mViewModel.BindView(BOListCard.ALL_CARDS_INFORMATION, lblCountAll);
            mViewModel.BindView(BOListCard.CUSTOMERS_INFORMATION, lblCountCustomers);
            mViewModel.BindView(BOListCard.SUPPLIERS_INFORMATION, lblCountSuppliers);
            mViewModel.BindView(BOListCard.EMPLOYEES_INFORMATION, lblCountEmployees);
        }

        private void CreateCustomer(object sender, EventArgs args)
        {
            mApplicationController.CreateCustomer();
        }

        private void CreateEmployee(object sender, EventArgs args)
        {
            mApplicationController.CreateEmployee();
        }

        private void CreateSupplier(object sender, EventArgs args)
        {
            mApplicationController.CreateSupplier();
        }

        private void OpenFrom_AllCards(object sender, EventArgs args)
        {
            if (dgvAll.SelectedRows.Count == 0) return;
            mApplicationController.OpenCard(dgvAll.SelectedRows[0].DataBoundItem as Card);
        }

        private void OpenFrom_Suppliers(object sender, EventArgs args)
        {
            if (dgvSuppliers.SelectedRows.Count == 0) return;
            mApplicationController.OpenCard(dgvSuppliers.SelectedRows[0].DataBoundItem as Card);
        }

        private void OpenFrom_Customers(object sender, EventArgs args)
        {
            if (dgvCustomers.SelectedRows.Count == 0) return;
            mApplicationController.OpenCard(dgvCustomers.SelectedRows[0].DataBoundItem as Card);
        }

        private void OpenFrom_Employees(object sender, EventArgs args)
        {
            if (dgvEmployees.SelectedRows.Count == 0) return;
            mApplicationController.OpenCard(dgvEmployees.SelectedRows[0].DataBoundItem as Card);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        protected override void _UpdateView()
        {
            //base._UpdateView();
            SetupTabs();
        }

        private void SetupTabs()
        {
            if (mModel.ActiveCardType == Accounting.Core.Cards.CardType.TypeID.Customer)
            {
                if (tc.TabPages.Contains(tpAll))
                {
                    tc.TabPages.Remove(tpAll);
                }
                if (tc.TabPages.Contains(tpSuppliers))
                {
                    tc.TabPages.Remove(tpSuppliers);
                }
                if (tc.TabPages.Contains(tpEmployees))
                {
                    tc.TabPages.Remove(tpEmployees);
                }
                if (!tc.TabPages.Contains(tpCustomers))
                {
                    tc.TabPages.Add(tpCustomers);
                }
                this.Text = "Customers";
            }
            else if (mModel.ActiveCardType == Accounting.Core.Cards.CardType.TypeID.Supplier)
            {
                if (tc.TabPages.Contains(tpAll))
                {
                    tc.TabPages.Remove(tpAll);
                }
                if (!tc.TabPages.Contains(tpSuppliers))
                {
                    tc.TabPages.Add(tpSuppliers);
                }
                if (tc.TabPages.Contains(tpEmployees))
                {
                    tc.TabPages.Remove(tpEmployees);
                }
                if (tc.TabPages.Contains(tpCustomers))
                {
                    tc.TabPages.Remove(tpCustomers);
                }
                this.Text = "Suppliers";
            }
            else if (mModel.ActiveCardType == Accounting.Core.Cards.CardType.TypeID.Employee)
            {
                if (tc.TabPages.Contains(tpAll))
                {
                    tc.TabPages.Remove(tpAll);
                }
                if (tc.TabPages.Contains(tpSuppliers))
                {
                    tc.TabPages.Remove(tpSuppliers);
                }
                if (!tc.TabPages.Contains(tpEmployees))
                {
                    tc.TabPages.Add(tpEmployees);
                }
                if (tc.TabPages.Contains(tpCustomers))
                {
                    tc.TabPages.Remove(tpCustomers);
                }
                this.Text = "Employees";
            }
            else
            {
                if (!tc.TabPages.Contains(tpAll))
                {
                    tc.TabPages.Add(tpAll);
                }
                if (!tc.TabPages.Contains(tpSuppliers))
                {
                    tc.TabPages.Add(tpSuppliers);
                }
                if (!tc.TabPages.Contains(tpEmployees))
                {
                    tc.TabPages.Add(tpEmployees);
                }
                if (!tc.TabPages.Contains(tpCustomers))
                {
                    tc.TabPages.Add(tpCustomers);
                }

                this.Text = "Cards";
            }
        }

        protected override void LoadView()
        {
            SetupTabs();
            mViewModel.UpdateView();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowCardListSummaryRpt();
        }
    }
}