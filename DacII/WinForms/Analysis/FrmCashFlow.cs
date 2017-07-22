using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Analysis
{
    using DacII.Presenters;
    public partial class FrmCashFlow : BaseView
    {
        public FrmCashFlow(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();
        }
    }
}
