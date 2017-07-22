using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Reports.Inventory.Items
{
    using DacII.Presenters;
    using Accounting.Report.Inventory.Items;
    using DacII.DacHandlers;

    public partial class FrmItemsListSummary : BaseView
    {
        private List<ComboBox> mCboFields = new List<ComboBox>();
        private List<CheckBox> mChkFields = new List<CheckBox>();

        public FrmItemsListSummary(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            string[] search_fields = new string[] { "ItemNumber", "ItemName", "ItemDescription" };
            cboSearchFieldName.DataSource = search_fields;

            mCboFields.Add(cboAverageCost);
            mCboFields.Add(cboBatchNumber);
            mCboFields.Add(cboBrand);
            mCboFields.Add(cboColor);
            mCboFields.Add(cboSupplier);
            mCboFields.Add(cboExpiryDate);
            mCboFields.Add(cboGender);
            mCboFields.Add(cboPriceStatus);
            mCboFields.Add(cboItemName);
            mCboFields.Add(cboItemNumber);
            mCboFields.Add(cboTotalValue);
            mCboFields.Add(cboStatus);
            mCboFields.Add(cboSerialNumber);
            mCboFields.Add(cboSize);
            mCboFields.Add(cboUnitsOnHand);
            mCboFields.Add(cboCurrentPrice);
            mCboFields.Add(cboItemDescription);

            mChkFields.Add(chkAverageCost);
            mChkFields.Add(chkBatchNumber);
            mChkFields.Add(chkBrand);
            mChkFields.Add(chkColor);
            mChkFields.Add(chkSupplier);
            mChkFields.Add(chkExpiryDate);
            mChkFields.Add(chkGender);
            mChkFields.Add(chkPriceStatus);
            mChkFields.Add(chkItemName);
            mChkFields.Add(chkItemNumber);
            mChkFields.Add(chkTotalValue);
            mChkFields.Add(chkStatus);
            mChkFields.Add(chkSerialNumber);
            mChkFields.Add(chkSize);
            mChkFields.Add(chkUnitsOnHand);
            mChkFields.Add(chkCurrentPrice);
            mChkFields.Add(chkItemDescription);

            List<string> cboValues = new List<string>();

            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                for (int i = 0; i < mCboFields.Count; ++i)
                {
                    mCboFields[ci].Items.Add(string.Format("{0:d2}", i+1));
                }
            }

            mCboFieldHandler = new EventHandler(FrmItemsListSummary_SelectedIndexChanged);

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                mCboFields[ci].Text = string.Format("{0:d2}", ci + 1);
                mCboFields[ci].Tag = string.Format("{0:d2}", ci + 1);
                mCboFields[ci].SelectedIndexChanged += mCboFieldHandler;
            }
            base.LoadView();
        }

        protected override void RegisterEventHandlers()
        {
            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                RegisterEventHandler(mChkFields[ci], DacEventHandler.EventTypes.CheckedChanged, new EventHandler(FrmItemsListSummary_CheckedChanged));
            }
        }

        private ItemsListSummaryRpt BuildReport()
        {
            ItemsListSummaryRpt rpt = new ItemsListSummaryRpt(mApplicationController.mAccountant);

            rpt.DisplayItemNumber = chkItemNumber.Checked;
            rpt.DisplayItemName = chkItemName.Checked;
            rpt.DisplayBatchNumber = chkBatchNumber.Checked;
            rpt.DisplaySerialNumber = chkSerialNumber.Checked;
            rpt.DisplayExpiryDate = chkExpiryDate.Checked;
            rpt.DisplayBrand = chkBrand.Checked;
            rpt.DisplayColor = chkColor.Checked;
            rpt.DisplayGender = chkGender.Checked;
            rpt.DisplaySize = chkSize.Checked;
            rpt.DisplaySupplier = chkSupplier.Checked;
            rpt.DisplayStatus= chkStatus.Checked;
            rpt.DisplayPriceStatus = chkPriceStatus.Checked;
            rpt.DisplayTotalValue = chkTotalValue.Checked;
            rpt.DisplayUnitsOnHand = chkUnitsOnHand.Checked;
            rpt.DisplayAverageCost = chkAverageCost.Checked;
            rpt.DisplayItemDescription = chkItemDescription.Checked;
            rpt.DisplayCurrentPrice = chkCurrentPrice.Checked;

            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.ItemNumber] = int.Parse(cboItemNumber.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.ItemName] = int.Parse(cboItemName.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.BatchNumber] = int.Parse(cboBatchNumber.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.SerialNumber] = int.Parse(cboSerialNumber.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.ExpiryDate] = int.Parse(cboExpiryDate.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.Brand] = int.Parse(cboBrand.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.Color] = int.Parse(cboColor.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.Gender] = int.Parse(cboGender.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.Size] = int.Parse(cboSize.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.Supplier] = int.Parse(cboSupplier.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.CurrentPrice] = int.Parse(cboCurrentPrice.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.PriceStatus] = int.Parse(cboPriceStatus.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.ItemDescription] = int.Parse(cboItemDescription.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.UnitsOnHand] = int.Parse(cboUnitsOnHand.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.AverageCost] = int.Parse(cboAverageCost.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.TotalValue] = int.Parse(cboTotalValue.Text);
            rpt.FieldOrder[ItemsListSummaryRpt.FieldName.Status] = int.Parse(cboStatus.Text);

            rpt.ItemIsSold = chkItemIsSold.Checked;
            rpt.ItemIsBought = chkItemIsBought.Checked;
            rpt.ItemIsInventoried = chkItemIsInventoried.Checked;
            rpt.ItemKeywords = txtSearchFieldValue.Text;
            rpt.ItemFieldName = cboSearchFieldName.Text;

            rpt.IncludeCompanyAddress = chkIncludeCompanyAddress.Checked;
            rpt.IncludeCompanyName = chkIncludeCompanyName.Checked;
            rpt.IncludeReportDateAndTime = chkIncludeReportDateAndTime.Checked;

            return rpt;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ItemsListSummaryRpt rpt = BuildReport();

            string filename = string.Format("{0}\\Reports\\ItemsListSummary.htm", Application.StartupPath);
            rpt.WriteHtmlReport(filename);

            RptViewer.Navigate(filename);
        }

        private void btnGenerateAndEmail_Click(object sender, EventArgs e)
        {
            ItemsListSummaryRpt rpt = BuildReport();
            string filename = string.Format("{0}\\Emails\\ItemsListSummary[{1}].xls", Application.StartupPath, DateTime.Now.ToString("yyyyMMdd_HHmm"));
            rpt.WriteExcelReport(filename);

            mApplicationController.Email(null, null, filename);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Excel Files (*.xls)|*.xls|HTML Files (*.htm)|*.htm|Text Files (*.txt)|*.txt|PDF Files (*.pdf)|*.pdf|Rich Text Files (*.rtf)|*.rtf";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                string filename = dlgSave.FileName;
                string ext = System.IO.Path.GetExtension(filename.ToLower());

                ItemsListSummaryRpt rpt = BuildReport();
                if (ext.Equals(".xls"))
                {
                    rpt.WriteExcelReport(filename);
                }
                else if (ext.Equals(".htm"))
                {
                    rpt.WriteHtmlReport(filename);
                }
                else if (ext.Equals(".txt"))
                {
                    rpt.WriteDelimitedTextReport(filename);
                }
                else if (ext.Equals(".pdf"))
                {
                    bool landscape = false;
                    if (MessageBox.Show("Do you want to save the PDF in Landscape view?", "PDF Landscape View", MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        landscape = true;
                    }
                   
                    rpt.WritePdfReport(filename, landscape);
                }
                else if (ext.Equals(".rtf"))
                {
                    rpt.WriteRtfReport(filename);
                }

                if (MessageBox.Show("Do you want to open the file", "File Saved", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filename);
                }
            }
        }

        void FrmItemsListSummary_CheckedChanged(object sender, EventArgs e)
        {
            for (int ci = 0; ci < mChkFields.Count; ++ci)
            {
                if (sender == mChkFields[ci])
                {
                    CheckBox chk = mChkFields[ci];
                    mCboFields[ci].Enabled = chk.Checked;
                    break;
                }
            }
        }

        private EventHandler mCboFieldHandler;
        void FrmItemsListSummary_SelectedIndexChanged(object sender, EventArgs e)
        {
            string previous_value = "";
            string current_value = "";
            ComboBox cbo = null;
            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                if (sender == mCboFields[ci])
                {
                    cbo = mCboFields[ci];
                    break;
                }
            }

           
            previous_value = (string)cbo.Tag;
            current_value = cbo.Text;
            cbo.Tag = current_value;
            //MessageBox.Show(previous_value);

            ComboBox cbo2 = null;
            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                if (mCboFields[ci].Text.Equals(current_value) && mCboFields[ci] != cbo)
                {
                    cbo2=mCboFields[ci];
                    break;
                }
            }

            cbo2.SelectedIndexChanged -= mCboFieldHandler;
            cbo2.Text = previous_value;
            cbo2.Tag = previous_value;
            cbo2.SelectedIndexChanged += mCboFieldHandler;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
