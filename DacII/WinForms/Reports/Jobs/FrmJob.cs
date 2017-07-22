using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting.Core.Jobs;

namespace DacII.WinForms.Report.Jobs
{
    public partial class FrmJob : Form
    {
        private Job mJob;
        public FrmJob(Job _obj)
        {
            mJob = _obj;
            InitializeComponent();
        }
    }
}