using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Reports.Sales
{
    using DacII.Presenters;
    using DacII.DacHandlers;

    using Accounting.Bll;
    using Accounting.Report.Customized.Sales;

    public partial class FrmRptSalesItem : BaseView
    {
        private List<ComboBox> mCboFields = new List<ComboBox>();
        private List<CheckBox> mChkFields = new List<CheckBox>();
        public FrmRptSalesItem(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            mCboFields.Add(cboAverageCost);
            mCboFields.Add(cboBatchNumber);
            mCboFields.Add(cboBrand);
            mCboFields.Add(cboColor);
            mCboFields.Add(cboCostOfSales);
            mCboFields.Add(cboExpiryDate);
            mCboFields.Add(cboGender);
            mCboFields.Add(cboGrossProfit);
            mCboFields.Add(cboItemName);
            mCboFields.Add(cboItemNumber);
            mCboFields.Add(cboProfitMargin);
            mCboFields.Add(cboSaleAmount);
            mCboFields.Add(cboSerialNumber);
            mCboFields.Add(cboSize);
            mCboFields.Add(cboUnitsSold);

            mChkFields.Add(chkAverageCost);
            mChkFields.Add(chkBatchNumber);
            mChkFields.Add(chkBrand);
            mChkFields.Add(chkColor);
            mChkFields.Add(chkCostOfSales);
            mChkFields.Add(chkExpiryDate);
            mChkFields.Add(chkGender);
            mChkFields.Add(chkGrossProfit);
            mChkFields.Add(chkItemName);
            mChkFields.Add(chkItemNumber);
            mChkFields.Add(chkProfitMargin);
            mChkFields.Add(chkSaleAmount);
            mChkFields.Add(chkSerialNumber);
            mChkFields.Add(chkSize);
            mChkFields.Add(chkUnitsSold);

            List<string> cboValues = new List<string>();

            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                for (int i = 0; i < mCboFields.Count; ++i)
                {
                    mCboFields[ci].Items.Add(string.Format("{0:d2}", i+1));
                    
                }
            }

            mCboFieldHandler = new EventHandler(FrmRptSalesItem_SelectedIndexChanged);

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
                RegisterEventHandler(mChkFields[ci], DacEventHandler.EventTypes.CheckedChanged, new EventHandler(FrmRptSalesItem_CheckedChanged));
            }
        }

        private ItemRpt BuildReport()
        {
            ItemRpt rpt = new ItemRpt(mApplicationController.mAccountant);

            rpt.YearFrom=int.Parse(txtFromYear.Text);
            rpt.YearTo = int.Parse(txtToYear.Text);

            rpt.DisplayItemNumber = chkItemNumber.Checked;
            rpt.DisplayItemName = chkItemName.Checked;
            rpt.DisplayBatchNumber = chkBatchNumber.Checked;
            rpt.DisplaySerialNumber = chkSerialNumber.Checked;
            rpt.DisplayExpiryDate = chkExpiryDate.Checked;
            rpt.DisplayBrand = chkBrand.Checked;
            rpt.DisplayColor = chkColor.Checked;
            rpt.DisplayGender = chkGender.Checked;
            rpt.DisplaySize = chkSize.Checked;
            rpt.DisplaySaleAmount = chkSaleAmount.Checked;
            rpt.DisplayCostOfSalesAmount = chkCostOfSales.Checked;
            rpt.DisplayGrossProfit = chkGrossProfit.Checked;
            rpt.DisplayProfitMargin = chkProfitMargin.Checked;
            rpt.DisplayUnitsSold = chkUnitsSold.Checked;
            rpt.DisplayAverageCost = chkAverageCost.Checked;

            rpt.FieldOrder[ItemRpt.FieldName.ItemNumber] = int.Parse(cboItemNumber.Text);
            rpt.FieldOrder[ItemRpt.FieldName.ItemName] = int.Parse(cboItemName.Text);
            rpt.FieldOrder[ItemRpt.FieldName.BatchNumber] = int.Parse(cboBatchNumber.Text);
            rpt.FieldOrder[ItemRpt.FieldName.SerialNumber] = int.Parse(cboSerialNumber.Text);
            rpt.FieldOrder[ItemRpt.FieldName.ExpiryDate] = int.Parse(cboExpiryDate.Text);
            rpt.FieldOrder[ItemRpt.FieldName.Brand] = int.Parse(cboBrand.Text);
            rpt.FieldOrder[ItemRpt.FieldName.Color] = int.Parse(cboColor.Text);
            rpt.FieldOrder[ItemRpt.FieldName.Gender] = int.Parse(cboGender.Text);
            rpt.FieldOrder[ItemRpt.FieldName.Size] = int.Parse(cboSize.Text);
            rpt.FieldOrder[ItemRpt.FieldName.SaleAmount] = int.Parse(cboSaleAmount.Text);
            rpt.FieldOrder[ItemRpt.FieldName.CostOfSalesAmount] = int.Parse(cboCostOfSales.Text);
            rpt.FieldOrder[ItemRpt.FieldName.GrossProfit] = int.Parse(cboGrossProfit.Text);
            rpt.FieldOrder[ItemRpt.FieldName.ProfitMargin] = int.Parse(cboProfitMargin.Text);
            rpt.FieldOrder[ItemRpt.FieldName.UnitsSold] = int.Parse(cboUnitsSold.Text);
            rpt.FieldOrder[ItemRpt.FieldName.AverageCost] = int.Parse(cboAverageCost.Text);

            rpt.IncludeCompanyAddress = chkIncludeCompanyAddress.Checked ;
            rpt.IncludeCompanyName = chkIncludeCompanyName.Checked;
            rpt.IncludeReportDateAndTime = chkIncludeReportDateAndTime.Checked;

            return rpt;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ItemRpt rpt = BuildReport();

            string filename = string.Format("{0}\\Reports\\Sales[Item].htm", Application.StartupPath);
            rpt.WriteHtmlReport(filename);

            RptViewer.Navigate(filename);
        }

        private void btnGenerateAndEmail_Click(object sender, EventArgs e)
        {
            ItemRpt rpt = BuildReport();
            string filename = string.Format("{0}\\Emails\\Sales[Item][{1}].xls", Application.StartupPath, DateTime.Now.ToString("yyyyMMdd_HHmm"));
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

                ItemRpt rpt = BuildReport();
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

        void FrmRptSalesItem_CheckedChanged(object sender, EventArgs e)
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
        void FrmRptSalesItem_SelectedIndexChanged(object sender, EventArgs e)
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
