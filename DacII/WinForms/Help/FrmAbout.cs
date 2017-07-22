using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Help
{
    using DacII.Presenters;
    using Accounting.Bll;

    public partial class FrmAbout : BaseView
    {
        public FrmAbout(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            Accountant acc = mApplicationController.mAccountant;
            txtDetail.LoadFile(acc.GetFullPath("About.rtf"));
        }
    }
}