using System;
using System.Collections.Generic;
using System.Text;

namespace System.Windows.Forms
{
	public class CustomizedMessageBox
	{
        public static DialogResult Show(string title, string message)
        {
            AlertMessageBoxDlg frm = new AlertMessageBoxDlg();
            frm.Text = title;
            frm.Content = message;
            return frm.ShowDialog();
        }

        public static DialogResult Show(string message)
        {
            AlertMessageBoxDlg frm = new AlertMessageBoxDlg();
            frm.Text = "Information";
            frm.Content = message;
            return frm.ShowDialog();
        }

        public static DialogResult Confirm(string title, string message)
        {
            ConfirmMessageBoxDlg frm = new ConfirmMessageBoxDlg();
            frm.Text = title;
            frm.Content = message;
            return frm.ShowDialog();
        }
	}
}
