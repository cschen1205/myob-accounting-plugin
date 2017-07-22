using System;
using System.Collections.Generic;

namespace DacII.WinForms.Journals
{
    using DacII.Presenters;
    using Accounting.Core.JournalRecords;
    using AdvancedDataGridView;
    using Accounting.Bll;
    using Accounting.Bll.Journals;


    public partial class FrmTransactionJournals : BaseView
    {
        private BOListTransactionJournal mModel;

        public FrmTransactionJournals(ApplicationPresenter ap, BOListTransactionJournal model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            DateTime end_date = DateTime.Now;
            DateTime start_date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = end_date;
            dtpStartDate.Value = start_date;

            RefreshData();
        }

        private void ExpandTreeGridView(TreeGridNode tgnode)
        {
            tgnode.Expand();
            foreach (TreeGridNode tgchild_node in tgnode.Nodes)
            {
                ExpandTreeGridView(tgchild_node);
            }
        }

        private void RefreshData()
        {
            tgvGeneral.Nodes.Clear();

            List<JournalSet> jsets = mModel.ListJournalSet(dtpStartDate.Value, dtpEndDate.Value);
            foreach (JournalSet jset in jsets)
            {
                PopulateTreeGridView(tgvAll, jset);
                string type=jset.JournalTypeID;
                if (type == "GJ")
                {
                    PopulateTreeGridView(tgvGeneral, jset);
                }
                else if (type == "PO")
                {
                    PopulateTreeGridView(tgvPurchases, jset);
                }
                else if (type == "SI")
                {
                    PopulateTreeGridView(tgvSales, jset);
                }
                else if (type == "TM" || type=="SP" || type=="MS")
                {
                    PopulateTreeGridView(tgvDisbursements, jset);
                }
                else if (type == "IT" || type == "IA")
                {
                    PopulateTreeGridView(tgvInventory, jset);
                }
                else if (type == "CP" ||  type=="MR")
                {
                    PopulateTreeGridView(tgvReceipts, jset);
                }
            }
        }

        private void PopulateTreeGridView(TreeGridView tgv, JournalSet jset)
        {
            TreeGridNode tgnode = tgv.Nodes.Add(string.Format("{0} {1}", jset.JournalTypeID, jset.TransactionDate.Value.ToShortDateString()), jset);
            foreach (JournalRecord jrecord in jset.JournalRecords)
            {
                tgnode.Nodes.Add(jset.TransactionNumber, jrecord.Account, jrecord.DebitDescription, jrecord.CreditDescription, jrecord.Job);
            }
            ExpandTreeGridView(tgnode);
        }

        private void btnGenReload_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}