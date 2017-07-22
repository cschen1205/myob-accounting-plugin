using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Accounting.Bll;
using Accounting.Bll.Im;
using Accounting.Db.OleDb;
using Accounting.Db;


namespace Wao
{
    public sealed class AccLoader : IAccountantFactory
    {
        private static AccLoader mInstance = null;
        private static object mLocker = new object();
        private string mApplicationDirPath = "";

        public static AccLoader Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLocker)
                    {
                        mInstance = new AccLoader();
                    }
                }
                return mInstance;
            }
        }

        private Dictionary<string, string> mDataSources = new Dictionary<string, string>();
        private string mDefaultDataSource = "";
        private bool mAlwayCheckDataSourceOnStart = true;

        public bool AlwaysCheckDataSourceOnStart
        {
            get { return mAlwayCheckDataSourceOnStart; }
            set { mAlwayCheckDataSourceOnStart = value; }
        }

        public Accountant CreateAccountant(params object[] options)
        {
            //create OleDbAccountant object
            Accountant _obj = new ImAccountant("IAccountant(OleDb");
            _obj.ApplicationDirPath = mApplicationDirPath;

            DbManager primary_factory = new OleDbManager(_obj, "PrimaryFactory");
            primary_factory.Database = string.Format("{0}\\config.mdb", mApplicationDirPath);
            primary_factory.DbPassword = "lkj3972897_89&";
            _obj.AddMgrFactory(primary_factory);

            _obj.ConfigMgrFactory = primary_factory;
            _obj.ConfigMgr.Prefix = "OleDb";

            _obj.DefaultMgrFactory.Database = string.Format("{0}\\inventorist.mdb", mApplicationDirPath);
            _obj.DefaultMgrFactory.DbPassword = "lkj3972897_89&";

            return _obj;
        }

       

        public void Load()
        {
            //Accounting.Util.AppEnv.Instance.AddLogger(Dac.Util.WinFormUtil.Instance);

            string accountant_type=mDataSources[mDefaultDataSource];
            AccountantPool.Instance.CreateCurrentAccountant(accountant_type);
        }

        public string DefaultDataSource
        {
            get { return mDefaultDataSource; }
            set { mDefaultDataSource = value; }
        }

        public void Unload()
        {
            AccountantPool.Instance.Release();
        }

        public void SaveConfig()
        {
            XmlDocument doc = new XmlDocument();

             doc.Load(string.Format("{0}\\config.xml", mApplicationDirPath));

             XmlElement root = doc.DocumentElement;
             foreach (XmlElement level1 in root.ChildNodes)
             {
                 if (level1.Name.Equals("data_source_dlg"))
                 {
                     foreach (XmlElement level2 in level1.ChildNodes)
                     {
                         if (level2.Name.Equals("data_source"))
                         {
                             string data_source = level2.Attributes["name"].Value.ToString();
                             level2.Attributes["accountant"].Value = mDataSources[data_source];
                         }
                     }
                     level1.Attributes["default_source"].Value = mDefaultDataSource;
                     string always_check = "false";
                     if (mAlwayCheckDataSourceOnStart)
                     {
                         always_check = "true";    
                     }
                      level1.Attributes["always_check"].Value=always_check;
                 }
             }

             doc.Save(string.Format("{0}\\config.xml", mApplicationDirPath));
        }

        public void Init(string path)
        {
            mApplicationDirPath = path;

            XmlDocument doc = new XmlDocument();
            doc.Load(string.Format("{0}\\config.xml", mApplicationDirPath));

            XmlElement root = doc.DocumentElement;
            foreach (XmlElement level1 in root.ChildNodes)
            {
                if (level1.Name.Equals("data_source_dlg"))
                {
                    foreach (XmlElement level2 in level1.ChildNodes)
                    {
                        if (level2.Name.Equals("data_source"))
                        {
                            string data_source = level2.Attributes["name"].Value.ToString();
                            string accountant = level2.Attributes["accountant"].Value.ToString();
                            mDataSources[data_source] = accountant;
                        }
                    }
                    mDefaultDataSource = level1.Attributes["default_source"].Value.ToString();
                    string always_check = level1.Attributes["always_check"].Value.ToString().ToLower();
                    if (always_check.Equals("true"))
                    {
                        mAlwayCheckDataSourceOnStart = true;
                    }
                    else
                    {
                        mAlwayCheckDataSourceOnStart = false;
                    }
                }
            }
        }

        private AccLoader()
        {
            AccountantPool.Instance.Factory = this;
        }
    }
}
