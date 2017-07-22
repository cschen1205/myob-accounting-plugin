using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Accounting.Util
{
    public sealed class AppEnv
    {
        private static AppEnv mInstance = null;
        private static Object mLocker = new Object();
        private StreamWriter mLog = null;
        private List<ILogger> mLoggers = new List<ILogger>();
        private static string mApplicationPath;

        private AppEnv()
        {
            
        }

        public static string GetFullPath(string filename)
        {
            if (mApplicationPath == null)
            {
                return filename;
            }
            else
            {
                return mApplicationPath + Path.DirectorySeparatorChar + filename;
            }
        }

        public static string ApplicationPath
        {
            get { return mApplicationPath; }
            set { mApplicationPath = value; }
        }

        public void AddLogger(ILogger logger)
        {
            mLoggers.Add(logger);
        }

        public void RemoveLogger(ILogger logger)
        {
            mLoggers.Remove(logger);
        }

        public static void RemoveDuplicates(List<string> items)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            foreach (string item in items)
            {
                map[item] = item;
            }
            items.Clear();
            foreach (string item in map.Keys)
            {
                items.Add(item);
            }
        }

        public static AppEnv Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLocker)
                    {
                        mInstance = new AppEnv();
                    }
                }
                return mInstance;
            }
        }

        public void Log(string message)
        {
            foreach (ILogger logger in mLoggers)
            {
                logger.Log(message);
            }

            
            //FileLog.WriteLine(message);
            //FileLog.Flush();
        }

        public StreamWriter FileLog
        {
            get
            {
                if (mLog == null)
                {
                    mLog = File.CreateText(GetFullPath("log.txt"));
                }
                return mLog;
            }
        }

        public void LogWithExit(string message)
        {
            //FileLog.WriteLine(message);
            //FileLog.Flush();
            foreach (ILogger logger in mLoggers)
            {
                logger.LogWithExit(message);
            }
            
        }

        public void Close()
        {
            //FileLog.Close();
        }

    }
}
