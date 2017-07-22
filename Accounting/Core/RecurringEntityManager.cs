using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core
{
    public abstract class RecurringEntityManager<T>: EntityManager<T>
        where T : Entity
    {
        public RecurringEntityManager(DbManager mgr)
            : base(mgr)
        {
        }

        private RecurringEntityStrategy mRecurringEntityStrategy=null;
        public RecurringEntityStrategy RecurringEntityStrategy
        {
            get
            {
                if (mRecurringEntityStrategy == null)
                {
                    mRecurringEntityStrategy = CreateRecurringEntityStrategy();
                }
                return mRecurringEntityStrategy;
            }
            set
            {
                mRecurringEntityStrategy = value;
            }
        }
        protected virtual RecurringEntityStrategy CreateRecurringEntityStrategy()
        {
            return new RecurringEntityStrategy(DbMgr);
        }

        public Dictionary<string, DbFieldEntry> GetRecurringEntityFields(RecurringEntity _obj)
        {
            return RecurringEntityStrategy.GetFields(_obj);
        }

        protected void LoadRecurringEntityFromReader(RecurringEntity _obj, DbDataReader _reader)
        {
            RecurringEntityStrategy.LoadFromReader(_obj, _reader);
        }
        
        protected object GetRecurringEntityDbProperty(RecurringEntity _obj, string property_name)
        {
            return RecurringEntityStrategy.GetDbProperty(_obj, property_name);
        }
    }
}
