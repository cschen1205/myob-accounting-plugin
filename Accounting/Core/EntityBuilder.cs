using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;

namespace Accounting.Core
{
    public abstract class EntityBuilder 
    {
        public EntityBuilder(DbManager mgr)
        {
            mDbManager = mgr;
            mRepositoryMgr = mgr.RepositoryMgr;
        }
        private DbManager mDbManager = null;
        public abstract object BuildProperty(object _obj, string property_name);
        public DbManager DbMgr
        {
            get { return mDbManager; }
        }
        private RepositoryManager mRepositoryMgr=null;
        public RepositoryManager RepositoryMgr
        {
            get { return mRepositoryMgr; }
        }


        public abstract Entity Create();
        public abstract Entity GetDbEntity(Entity _rhs);
    }
}
