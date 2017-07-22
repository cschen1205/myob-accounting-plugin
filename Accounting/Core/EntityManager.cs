using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core
{
    using System.ComponentModel;
    using System.Data.Common;
    using System.Linq;

    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Util;

    public abstract class EntityManager<T> : EntityBuilder, IRepository, INotifyPropertyChanged
        where T : Entity
    {
        private Dictionary<string, DbTableCommand> mTableCommands = new Dictionary<string, DbTableCommand>();

        public EntityManager(DbManager mgr)
            : base(mgr)
        {
            RepositoryMgr.RegisterRepository(this);

            CreateTableCommands();
            CreateTable();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        protected Dictionary<string, DbTableCommand> TableCommands
        {
            get { return mTableCommands; }
        }

        public T CreateEntity()
        {
            return _CreateEntity();
        }

        protected T CreateDbEntity()
        {
            return _CreateDbEntity();
        }

        public override Entity Create()
        {
            return CreateEntity();
        }

        protected abstract T _CreateEntity();
        protected abstract T _CreateDbEntity();

        public override object BuildProperty(object _obj, string property_name)
        {
            return GetDbProperty((T)_obj, property_name);
        }

        protected virtual void CreateTableCommands()
        {
            
        }

        public void CreateTable()
        {
            foreach(DbTableCommand tc in mTableCommands.Values)
            {
                tc.CreateTable();
            }
        }

        public void RecreateTable()
        {
            foreach(DbTableCommand tc in mTableCommands.Values)
            {
                tc.RecreateTable();
            }
        }

        public abstract Dictionary<string, DbFieldEntry> GetFields(T _obj);

        protected virtual object GetDbProperty(T _obj, string property_name)
        {
            throw new NotImplementedException();
        }

        protected string GetString(DbDataReader reader, params string[] columnNames)
        {
            return DbMgr.GetString(reader, columnNames);
        }

        protected Nullable<DateTime> GetDateTime(DbDataReader reader, params string[] columnNames)
        {
            return DbMgr.GetDateTime(reader, columnNames);
        }

        public DbCriteria CreateCriteria()
        {
            return DbMgr.CreateCriteria();
        }

        public void Log(string message)
        {
            AppEnv.Instance.Log(message);
        }

        protected int? GetInt32(DbDataReader reader, params string[] columnNames)
        {
            return DbMgr.GetInt32(reader, columnNames);
        }

        protected int? GetInt16(DbDataReader reader, params string[] columnNames)
        {
            return DbMgr.GetInt16(reader, columnNames);
        }

        protected double GetDouble(DbDataReader reader, params string[] columnNames)
        {
            return DbMgr.GetDouble(reader, columnNames);
        }

        protected DbCommand CreateDbCommand(DbSelectStatement _query)
        {
            return DbMgr.CreateDbCommand(_query);
        }

        protected DbCommand CreateDbCommand(DbUpdateStatement clause)
        {
            return DbMgr.CreateDbCommand(clause);
        }

        protected DbCommand CreateDbCommand(DbDeleteStatement clause)
        {
            return DbMgr.CreateDbCommand(clause);
        }

        protected DbCommand CreateDbCommand(DbInsertStatement clause)
        {
            return DbMgr.CreateDbCommand(clause);
        }

        protected DbDataAdapter CreateDbDataAdapter(DbSelectStatement clause)
        {
            return DbMgr.CreateDbDataAdapter(clause);
        }

        protected void LoadFromDb(T _obj, DbSelectStatement _query)
        {
            DbCommand _cmd = CreateDbCommand(_query);
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();
        }

        private object ExecuteScalar(DbSelectStatement clause)
        {
            return DbMgr.ExecuteScalar(clause);
        }

        public int ExecuteNonQuery(DbUpdateStatement clause)
        {
            return DbMgr.ExecuteNonQuery(clause);
        }

        public int ExecuteNonQuery(DbDeleteStatement clause)
        {
            return DbMgr.ExecuteNonQuery(clause);
        }

        public int ExecuteNonQuery(DbInsertStatement clause)
        {
            return DbMgr.ExecuteNonQuery(clause);
        }

        public int ExecuteScalarInt(DbSelectStatement clause)
        {
            return DbMgr.ExecuteScalarInt(clause);
        }

        protected abstract void LoadFromReader(T _obj, DbDataReader reader);

        public OpResult Store(T _obj)
        {
            OpResult result = _Store(_obj);

            if (result.Status==OpResult.ResultStatus.Created || result.Status==OpResult.ResultStatus.CreatedWithException)
            {
                if (UseMemoryStore)
                {
                    T db_copy=GetDbEntity(_obj);
                    if (db_copy != null)
                    {
                        DataStore.Add(_obj);
                    }
                    else
                    {
                        UpdateDataStore();    
                    }
                }
                NotifyPropertyChanged(Entity.MESSAGE_CREATED);
            }

            return result;
        }

        public T GetDbEntity(T _obj)
        {
            return _GetDbEntity(_obj);
        }

        public override Entity GetDbEntity(Entity _rhs)
        {
            
            return GetDbEntity(_rhs as T);
        }

        protected virtual T _GetDbEntity(T _obj)
        {
            T result = null;
            RecordKeyInt intId = _obj.IntId;
            if (intId != null)
            {
                result = FindById(intId.Value);
            }
            if (result == null)
            {
                RecordKeyString textId = _obj.TextId;
                if (textId != null)
                {
                    result = FindById(textId.Value);
                }
            }

            return result;
        }

        public void InvalidateDataStore()
        {
            mDataStore = null;
        }

        private void UpdateDataStore()
        {
            if (UseMemoryStore)
            {
                BindingList<T> store = DataStore;
                store.Clear();
                GC.Collect();

                IList<T> new_store = _FindAllCollection();
                foreach (T _obj in new_store)
                {
                    store.Add(_obj);
                }
            }
            NotifyPropertyChanged(Entity.MESSAGE_CREATED);
        }

        public OpResult Delete(T _obj)
        {
            OpResult result = _Delete(_obj);
            if (result.Status == OpResult.ResultStatus.ExistsAndDeleted)
            {
                if (UseMemoryStore)
                {
                    DataStore.Remove(_obj);
                }
                NotifyPropertyChanged(Entity.MESSAGE_DELETED);
            }
            return result;
        }

        protected BindingList<T> mDataStore = null;
        private static object mLocker = new object();
        private bool mUseMemoryStore = true;
        public bool UseMemoryStore
        {
            get { return mUseMemoryStore; }
            set { mUseMemoryStore = value; }
        }

        protected BindingList<T> DataStore
        {
            get
            {
                if (mDataStore == null)
                {
                    lock (mLocker)
                    {
                        mDataStore = new BindingList<T>(_FindAllCollection());
                    }
                }
                return mDataStore;
            }
        }

        public IList<T>FindAllCollection()
        {
            if (mUseMemoryStore)
            {
                return DataStore;
            }
            return _FindAllCollection();
        }

     

        public T FindById(string id)
        {
            T obj = null;
            if (mUseMemoryStore)
            {
                BindingList<T> ds=DataStore;
                var result = from o in ds
                             where o.Match(id)
                             select o;
                if (result.Count() != 0)
                {

                    obj = result.First();
                }
            }
            if (obj == null)
            {
                obj = _FindByTextId(id);
            }
            return obj;
        }

        public T FindById(int? id)
        {
            T obj = null;
            if (mUseMemoryStore)
            {
                BindingList<T> ds = DataStore;
                var result = from o in ds
                             where o.Match(id)
                             select o;
                if (result.Count() != 0)
                {
                    obj = result.First();
                }
            }
            if (obj == null)
            {
                obj = _FindByIntId(id);
            }
            return obj;
        }

        protected virtual T _FindByTextId(string id)
        {
            return null;
        }

        protected virtual T _FindByIntId(int? id)
        {
            return null;
        }

        protected abstract IList<T> _FindAllCollection();

        protected virtual OpResult _Store(T _obj)
        {
            throw new NotImplementedException();
        }

        protected virtual OpResult _Delete(T _obj)
        {
            throw new NotImplementedException();
        }

        public virtual bool Exists(T _obj)
        {
            throw new NotImplementedException();
        }


    }
}
