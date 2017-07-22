using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Accounting.Core.Enumeration;
using Accounting.Bll;
using Accounting.Bll.Accounts;

namespace DacII.WinForms.Analysis
{
    using DacII.Presenters;
    
    public partial class FrmPLFilter : BaseView
    {
        private Dictionary<int, Button> mButtons = new Dictionary<int, Button>();
        private Dictionary<int, RadioButton> mRdos = new Dictionary<int, RadioButton>();

        public FrmPLFilter(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();
            mButtons[1] = btn01;
            mButtons[2] = btn02;
            mButtons[3] = btn03;
            mButtons[4] = btn04;
            mButtons[5] = btn05;
            mButtons[6] = btn06;
            mButtons[7] = btn07;
            mButtons[8] = btn08;
            mButtons[9] = btn09;
            mButtons[10] = btn10;
            mButtons[11] = btn11;
            mButtons[12] = btn12;

            mRdos[1] = rdo01;
            mRdos[2] = rdo02;
            mRdos[3] = rdo03;
            mRdos[4] = rdo04;
            mRdos[5] = rdo05;
        }

        private PLCriteria mPLCriteria=PLCriteria.ThisYearActualsOnly;
        public PLCriteria PLCriteria
        {
            get
            {
                return mPLCriteria;
            }
            set
            {

                mPLCriteria = value;
                mRdos[PLUtil.GetPLCriteriaIndex(mPLCriteria)].Checked=true;
            }
        }

        private int mPeriod=12;
        public int Period
        {
            get
            {
                return mPeriod;
            }
            set
            {
                mButtons[mPeriod].BackColor = Color.White;
                mPeriod = value;
                mButtons[mPeriod].BackColor = Color.CadetBlue;
            }
        }

        private void FrmFilter_Load(object sender, EventArgs e)
        {
            Accountant accountant = mApplicationController.mAccountant;
            int? lastMonthInFinancialYear = accountant.DataFileInformationMgr.Company.LastMonthInFinancialYear;

            for (int i = 1; i != 13; ++i)
            {
                int month = i - lastMonthInFinancialYear.Value;
                if (month < 1)
                {
                    month += 12;
                }
                mButtons[i].Text = Month.Int2ShortString(month);
            }

            mButtons[Period].BackColor = System.Drawing.Color.CadetBlue;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            Period = 1;
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            Period = 2;
        }

        private void btn03_Click(object sender, EventArgs e)
        {
            Period = 3;
        }

        private void btn04_Click(object sender, EventArgs e)
        {
            Period = 4;
        }

        private void btn05_Click(object sender, EventArgs e)
        {
            Period = 6;
        }

        private void btn06_Click(object sender, EventArgs e)
        {
            Period = 6;
        }

        private void btn07_Click(object sender, EventArgs e)
        {
            Period = 7;
        }

        private void btn08_Click(object sender, EventArgs e)
        {
            Period = 8;
        }

        private void btn09_Click(object sender, EventArgs e)
        {
            Period = 9;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            Period = 10;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            Period = 11;
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            Period = 12;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 6; ++i)
            {
                if (mRdos[i].Checked)
                {
                    PLCriteria = PLUtil.GetPLCriteria(i);
                    break;
                }
            }
        }
    }
}
