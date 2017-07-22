using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Sales.SaleLines
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using System.Data.Odbc;
    using Accounting.Core.Inventory;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Jobs;
    using Accounting;
    using Accounting.Bll.Sales.SaleLines;

    public partial class FrmItemSaleLine : BaseView
    {
        private BOItemSaleLine mModel = null;
        private BOViewModel mViewModel;

        public FrmItemSaleLine(ApplicationPresenter ap, BOItemSaleLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOItemSaleLine Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
        }

        protected override void BindViews()
        {
            base.BindViews();

            cboItem.DataSource = mApplicationController.FindAllSoldItems();
            cboTax.DataSource = mApplicationController.FindAllTaxCodes();
            cboJob.DataSource = mApplicationController.FindAllJobs();
            cboLocation.DataSource = mApplicationController.FindAllLocations();

            mViewModel.BindView(BOItemSaleLine.ITEM, lblItem, cboItem);
            mViewModel.BindView(BOItemSaleLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOItemSaleLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOItemSaleLine.LOCATION, lblLocation, cboLocation);
            mViewModel.BindView(BOItemSaleLine.PRICE, lblPrice, txtPrice);
            mViewModel.BindView(BOItemSaleLine.QUANTITY, lblQuantity, txtQuantity);
            mViewModel.BindView(BOItemSaleLine.DISCOUNT, lblDiscount, txtDiscount);
            mViewModel.BindView(BOItemSaleLine.PERSIST_OBJECT, btnOK);
        }

        private void OnItemChanged(object sender, EventArgs args)
        {
            if (cboItem.SelectedIndex == -1)
            {
                return;
            }
            Item _obj = (Item)cboItem.SelectedItem;
            cboTax.SelectedItem = _obj.SellTaxCode;
            cboJob.SelectedItem = null;
            cboLocation.SelectedItem = _obj.DefaultSellLocation;
            txtPrice.Text = string.Format("{0}", _obj.BaseSellingPrice);
            txtQuantity.Text = "1";
            txtDiscount.Text = "0";
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                mModel.Update();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        protected override void LoadView()
        {
            base.LoadView();
            mViewModel.UpdateView();
        }
    }
}