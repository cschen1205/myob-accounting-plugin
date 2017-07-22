using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SwissArmyKnife.Util
{
    public sealed class Logger
    {
        private static Logger mInstance = null;
        private static Object mLocker = new Object();
        private StreamWriter mLog = null;

        private Logger()
        {
            mLog = File.CreateText("log.txt");
        }

        public static Logger Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLocker)
                    {
                        mInstance = new Logger();
                    }
                }
                return mInstance;
            }
        }

        public void Log2File(string message)
        {
            mLog.WriteLine(message);
            mLog.Flush();
        }

        public void Close()
        {
            mLog.Close();
        }

        public static void Log(string message)
        {
            Instance.Log2File(message);
        }

    }
}
