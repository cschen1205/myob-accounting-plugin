using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Reports.Card.Cards
{
    using DacII.Presenters;
    using Accounting.Report.Card.Cards;
    using DacII.DacHandlers;

    public partial class FrmCardListSummary : BaseView
    {
        private List<ComboBox> mCboFields = new List<ComboBox>();
        private List<CheckBox> mChkFields = new List<CheckBox>();

        public FrmCardListSummary(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            Array types = Enum.GetValues(typeof(CardListSummaryRpt.CardType));
            cboCardType.DataSource = types;

            mCboFields.Add(cboType);
            mCboFields.Add(cboCardID);
            mCboFields.Add(cboPhone);
            mCboFields.Add(cboName);
            mCboFields.Add(cboStatus);
            mCboFields.Add(cboCurrentBalance);

            mChkFields.Add(chkType);
            mChkFields.Add(chkStatus);
            mChkFields.Add(chkCardID);
            mChkFields.Add(chkPhone);
            mChkFields.Add(chkName);
            mChkFields.Add(chkStatus);
            mChkFields.Add(chkCurrentBalance);

            List<string> cboValues = new List<string>();

            for (int ci = 0; ci < mCboFields.Count; ++ci)
            {
                for (int i = 0; i < mCboFields.Count; ++i)
                {
                    mCboFields[ci].Items.Add(string.Format("{0:d2}", i+1));
                }
            }

            mCboFieldHandler = new EventHandler(FrmCardListSummary_SelectedIndexChanged);

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
                RegisterEventHandler(mChkFields[ci], DacEventHandler.EventTypes.CheckedChanged, new EventHandler(FrmCardListSummary_CheckedChanged));
            }
        }

        private CardListSummaryRpt BuildReport()
        {
            CardListSummaryRpt rpt = new CardListSummaryRpt(mApplicationController.mAccountant);

            rpt.DisplayName = chkName.Checked;
            rpt.DisplayPhone = chkPhone.Checked;
            rpt.DisplayType = chkType.Checked;
            rpt.DisplayCurrentBalance = chkCurrentBalance.Checked;
            rpt.DisplayCardID = chkCardID.Checked;
            rpt.DisplayStatus= chkStatus.Checked;
            
            rpt.FieldOrder[CardListSummaryRpt.FieldName.Name] = int.Parse(cboName.Text);
            rpt.FieldOrder[CardListSummaryRpt.FieldName.Phone] = int.Parse(cboPhone.Text);
            rpt.FieldOrder[CardListSummaryRpt.FieldName.Type] = int.Parse(cboType.Text);
            rpt.FieldOrder[CardListSummaryRpt.FieldName.CurrentBalance] = int.Parse(cboCurrentBalance.Text);
            rpt.FieldOrder[CardListSummaryRpt.FieldName.CardID] = int.Parse(cboCardID.Text);
            rpt.FieldOrder[CardListSummaryRpt.FieldName.Status] = int.Parse(cboStatus.Text);


            rpt.IncludeCompanyAddress = chkIncludeCompanyAddress.Checked;
            rpt.IncludeCompanyName = chkIncludeCompanyName.Checked;
            rpt.IncludeReportDateAndTime = chkIncludeReportDateAndTime.Checked;

            rpt.IncludeInactiveCards = chkIncludeInactiveCards.Checked;
            rpt.Type = (CardListSummaryRpt.CardType)cboCardType.SelectedItem;
            return rpt;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            CardListSummaryRpt rpt = BuildReport();

            string filename = string.Format("{0}\\Reports\\CardListSummary.htm", Application.StartupPath);
            rpt.WriteHtmlReport(filename);

            RptViewer.Navigate(filename);
        }

        private void btnGenerateAndEmail_Click(object sender, EventArgs e)
        {
            CardListSummaryRpt rpt = BuildReport();
            string filename = string.Format("{0}\\Emails\\CardListSummary[{1}].xls", Application.StartupPath, DateTime.Now.ToString("yyyyMMdd_HHmm"));
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

                CardListSummaryRpt rpt = BuildReport();
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

        void FrmCardListSummary_CheckedChanged(object sender, EventArgs e)
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
        void FrmCardListSummary_SelectedIndexChanged(object sender, EventArgs e)
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
