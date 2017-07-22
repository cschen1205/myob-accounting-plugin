using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Accounting.Bll;
using Accounting.Db.Myob;
using Accounting.Db;
using Accounting.Db.OleDb;

namespace DacII
{
    public sealed class AccLoader 
    {
        private static AccLoader mInstance = null;
        private static object mLocker = new object();
        private string mApplicationDirPath = "";
        private Accountant mAccountant = null;

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

        public Accountant Load()
        {
            Accounting.Util.AppEnv.Instance.AddLogger(DacII.Util.WinFormUtil.Instance);

            mAccountant = new Accountant("MyobAccountant");
            mAccountant.ApplicationDirPath = mApplicationDirPath;

            DbManager default_factory = new MyobDbManager(mAccountant, "DefaultFactory");
            mAccountant.DefaultMgrFactory = default_factory;

            DbManager primary_factory = new OleDbManager(mAccountant, "PrimaryFactory");
            primary_factory.Database = string.Format("{0}\\config.mdb", mApplicationDirPath);
            primary_factory.DbPassword = "lkj3972897_89&";
            mAccountant.AddMgrFactory(primary_factory);

            mAccountant.ConfigMgrFactory = primary_factory;
            mAccountant.MiscNumberMgrFactory = primary_factory;

            mAccountant.ConfigMgr.Prefix = "Myob";

            DbManager secondary_factory = new OleDbManager(mAccountant, "SecondaryFactory");
            secondary_factory.Database = string.Format("{0}\\inventorist.mdb", mApplicationDirPath);
            secondary_factory.DbPassword = "lkj3972897_89&";
            mAccountant.AddMgrFactory(secondary_factory);

            mAccountant.AuthItemMgrFactory = secondary_factory;
            mAccountant.AuthRoleMgrFactory = secondary_factory;
            mAccountant.AuthUserMgrFactory = secondary_factory;
            mAccountant.ItemAddOnMgrFactory = secondary_factory;
            mAccountant.ItemSizeMgrFactory = secondary_factory;
            mAccountant.GenderMgrFactory = secondary_factory;

            mAccountant.DataFieldMgrFactory = secondary_factory;
            mAccountant.ItemDataFieldEntryMgrFactory = secondary_factory;

            mAccountant.ItemDataFieldEntryMgr.UseMemoryStore = false;

            return mAccountant;
        }

       

        public void Unload()
        {
            mAccountant.Release();
        }

        public void Init(string path)
        {
            mApplicationDirPath = path;           
        }

        private AccLoader()
        {
            
        }

        
    }
}
