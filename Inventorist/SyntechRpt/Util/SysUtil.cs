using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Accounting.Util;


namespace SyntechRpt.Util
{
        public class WinFormUtil : ILogger
        {
            private StreamWriter mLogWriter=null;
            private WinFormUtil()
            {
                mLogWriter = File.CreateText(System.Windows.Forms.Application.StartupPath + "\\dac.log.txt");
            }

            public void Log(string message)
            {
        
                mLogWriter.WriteLine(message);
                mLogWriter.Flush();

                //Alert(message);
            }

            public void LogWithExit(string message)
            {
                if (WinFormUtil.Confirm(string.Format("{0}\r\n{1}", "Would you like to exit?", message), "Log: Would you like to exit?") == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

            public static bool isRowSelected(DataGridView dgv)
            {
                return !(dgv.SelectedRows == null || dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0].Cells==null || dgv.SelectedRows[0].Cells.Count == 0 || dgv.SelectedRows[0].Cells[0].Value==null);
            }

            public static void Alert(string message)
            {
                
                MessageBox.Show(message);
            }

            public static DialogResult Confirm(string message, string title)
            {
                return MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            }

            public static bool DataGridView_GetSelectedID(DataGridView dgv, out int ID)
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    ID = 0;
                    return false;
                }
                ID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
                return true;
            }

            private static WinFormUtil mInstance = null;
            private static object mLocker = new object();
            public static WinFormUtil Instance
            {
                get
                {
                    if (mInstance == null)
                    {
                        mInstance = new WinFormUtil();
                    }
                    return mInstance;
                }
            }
        }
}
