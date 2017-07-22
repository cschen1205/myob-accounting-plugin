using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Accounting.Bll;
using Accounting.Db;
using Accounting.Db.OleDb;
using Accounting.Db.Myob;

namespace SyntechRpt
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

        public Accountant CreateAccountant(params object[] options)
        {
            string accountant_name = (string)options[0];
            Accountant _obj = new Accountant(accountant_name);
            _obj.ApplicationDirPath = mApplicationDirPath;

            DbManager default_factory = new MyobDbManager(_obj, "DefaultFactory");
            _obj.DefaultMgrFactory = default_factory;

            DbManager primary_factory = new OleDbManager(_obj, "PrimaryFactory");
            primary_factory.Database = string.Format("{0}\\config.mdb", mApplicationDirPath);
            primary_factory.DbPassword = "lkj3972897_89&";
            _obj.AddMgrFactory(primary_factory);

            _obj.ConfigMgrFactory = primary_factory;
            _obj.MiscNumberMgrFactory = primary_factory;

            _obj.ConfigMgr.Prefix = "Myob";
           
            DbManager secondary_factory = new OleDbManager(_obj, "SecondaryFactory");
            secondary_factory.Database = string.Format("{0}\\inventorist.mdb", mApplicationDirPath);
            secondary_factory.DbPassword = "lkj3972897_89&";
            _obj.AddMgrFactory(secondary_factory);

            _obj.AuthItemMgrFactory = secondary_factory;
            _obj.AuthRoleMgrFactory = secondary_factory;
            _obj.AuthUserMgrFactory = secondary_factory;
            _obj.ItemSizeMgrFactory = secondary_factory;
            _obj.ItemAddOnMgrFactory = secondary_factory;
            _obj.GenderMgrFactory = secondary_factory;
            

            return _obj;
        }

    


        public void Load()
        {
            Accounting.Util.AppEnv.Instance.AddLogger(SyntechRpt.Util.WinFormUtil.Instance);
            AccountantPool.Instance.CreateCurrentAccountant("MyobAccountant");
        }

        public void Unload()
        {
            AccountantPool.Instance.Release();
        }

        public void Init(string path)
        {
            mApplicationDirPath = path;           
        }

        private AccLoader()
        {
            AccountantPool.Instance.Factory = this;
        }
    }
}
