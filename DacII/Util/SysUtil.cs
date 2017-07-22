using System.Windows.Forms;
using Accounting.Util;


namespace DacII.Util
{
        public class WinFormUtil : ILogger
        {
            //private StreamWriter mLogWriter=null;
            private WinFormUtil()
            {
                //try
                //{
                //    mLogWriter = File.CreateText(System.Windows.Forms.Application.StartupPath + "\\dac.log.txt");
                //}
                //catch (System.IO.IOException)
                //{
                    
                //}
            }

            public void Log(string message)
            {
                //if (mLogWriter != null)
                //{
                //    mLogWriter.WriteLine(message);
                //    mLogWriter.Flush();
                //}
            }

            public void LogWithExit(string message)
            {
                if (MessageBox.Show(string.Format("{0}\r\n{1}", "Would you like to exit?", message), "Log: Would you like to exit?") == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

 


            //public static bool DataGridView_GetSelectedID(DataGridView dgv, out int ID)
            //{
            //    if (dgv.SelectedRows.Count == 0)
            //    {
            //        ID = 0;
            //        return false;
            //    }
            //    ID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            //    return true;
            //}

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
