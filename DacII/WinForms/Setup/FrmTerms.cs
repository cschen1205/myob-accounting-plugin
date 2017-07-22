using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.WinForms.Setup
{
    using DacII.Presenters;
    public partial class FrmTerms : BaseView
    {
        public FrmTerms(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();
        }

        protected override void BindViews()
        {
            base.BindViews();

            
        }
    }
}
