using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;


namespace SyntechRpt.WinForms
{
    public partial class FrmDocProps : Form
    {
        public FrmDocProps()
        {
            InitializeComponent();
        }

        private void FrmDocProp_Load(object sender, EventArgs e)
        {
            Office.DocumentProperties props=Globals.ThisWorkbook.BuiltinDocumentProperties as Office.DocumentProperties;
            txtCompany.Text = props["Company"].Value as string;
            txtAuthor.Text = props["Author"].Value as string;
            txtComments.Text = props["Comments"].Value as string;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Office.DocumentProperties props = Globals.ThisWorkbook.BuiltinDocumentProperties as Office.DocumentProperties;
            props["Company"].Value = txtCompany.Text;
            props["Author"].Value = txtAuthor.Text;
            props["Comments"].Value = txtComments.Text;
        }
    }
}
