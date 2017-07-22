using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DacII.WinForms.Purchases.PurchaseLines
{
    using DacII.Presenters;
    using DacII.ViewModels;

    using System.Data.Odbc;
    using Accounting.Core.Inventory;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Jobs;
    using Accounting.Bll;
    using Accounting.Bll.Purchases;
    using Accounting.Bll.Purchases.PurchaseLines;

    public partial class FrmItemPurchaseLine : BaseView
    {
        private BOItemPurchaseLine mModel = null;
        private BOViewModel mViewModel;

        public FrmItemPurchaseLine(ApplicationPresenter ap, BOItemPurchaseLine model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);

            BindViews();
            RegisterEventHandlers();
        }

        public BOItemPurchaseLine Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = value;
            }
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

        protected override void BindViews()
        {
            base.BindViews();

            cboItem.DataSource = mApplicationController.FindAllBoughtItems();
            cboTax.DataSource = mApplicationController.FindAllTaxCodes();
            cboJob.DataSource = mApplicationController.FindAllJobs();
            cboLocation.DataSource = mApplicationController.FindAllLocations();

            mViewModel.BindView(BOItemPurchaseLine.ITEM, lblItem, cboItem);
            mViewModel.BindView(BOItemPurchaseLine.RECEIVED, lblReceived, txtReceived);
            mViewModel.BindView(BOItemPurchaseLine.TAXCODE, lblTax, cboTax);
            mViewModel.BindView(BOItemPurchaseLine.JOB, lblJob, cboJob);
            mViewModel.BindView(BOItemPurchaseLine.LOCATION, lblLocation, cboLocation);
            mViewModel.BindView(BOItemPurchaseLine.PRICE, lblPrice, txtPrice);
            mViewModel.BindView(BOItemPurchaseLine.QUANTITY, lblQuantity, txtQuantity);
            mViewModel.BindView(BOItemPurchaseLine.DISCOUNT, lblDiscount, txtDiscount);
            mViewModel.BindView(BOItemPurchaseLine.PERSIST_OBJECT, btnOK);

            
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

        protected override void  LoadView()
        {
 	         base.LoadView();
             mViewModel.UpdateView();
        }
    }
}