using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
	public partial class AlertMessageBoxDlg: Form
	{
        public AlertMessageBoxDlg()
		{
			InitializeComponent();
		}

        public String Content
        {
            get
            {
                return lblContent.Text;
            }
            set
            {
                lblContent.Text = value;
            }
        }
	}
}
