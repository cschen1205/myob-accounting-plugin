using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Db;
using Accounting.Util;

namespace Accounting.Core
{
    using System.Reflection;
    using System.ComponentModel;
    using Accounting.Db.Elements;

    public abstract class Entity : INotifyPropertyChanged, IRecord
    {
        private bool mFromDb=true;
        private EntityBuilder mEntityBuilder = null;

        public static readonly string MESSAGE_CREATED = "MsgEntityCreated";
        public static readonly string MESSAGE_UPDATED = "MsgEntityUpdated";
        public static readonly string MESSAGE_DELETED = "MsgEntityDeleted";

        public bool FromDb
        {
            get { return mFromDb; }
            set { mFromDb = value; }
        }

        public virtual RecordKeyInt IntId
        {
            get { return null; }
        }

        public Entity Discover()
        {
            return mEntityBuilder.GetDbEntity(this);
        }

        public virtual RecordKeyString TextId
        {
            get { return null; }
        }

        public bool Match(int? id)
        {
            if (IntId == null)
            {
                throw new Exception("Match(int? id): IntId == null");
            }
            return IntId.Match(id);
        }

        public bool Match(string id)
        {
            if (TextId == null)
            {
                throw new Exception("Match(string id): TextId == null");
            }
            return TextId.Match(id);
        }

        public EntityBuilder EntityBuilder
        {
            get { return mEntityBuilder; }
            set { mEntityBuilder = value; }
        }

        public object Clone()
        {
            Entity _cloned = EntityBuilder.Create();
            _cloned.AssignFrom(this);
            return _cloned;
        }

        public RepositoryManager RepositoryMgr
        {
            get { return mEntityBuilder.RepositoryMgr; }
        }

        public bool AllowUpdate
        {
            get
            {
                if (DbMgr == null) return true;
                return DbMgr.AllowUpdate;
            }
        }

        public bool AllowDelete
        {
            get
            {
                if (DbMgr == null) return true;
                return DbMgr.AllowDelete;
            }
        }

        public bool AllowCreate
        {
            get
            {
                if (DbMgr == null) return true;
                return DbMgr.AllowCreate;
            }
        }

        public DbManager DbMgr
        {
            get
            {
                if (mEntityBuilder == null)
                {
                    return null;
                }
                else
                {
                    return mEntityBuilder.DbMgr;
                }
            }
        }

        public Entity(bool _fromDb, EntityBuilder eb)
        {
            mEntityBuilder = eb;
            mFromDb = _fromDb;
        }

       
        public virtual void AssignFrom(Entity rhs)
        {
            //FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            //foreach (FieldInfo fi in fields)
            //{
            //    Console.WriteLine("Assign From: {0}", fi.Name);
            //    fi.SetValue(this, fi.GetValue(rhs));
            //}

             
            Type type = rhs.GetType();
            while (type != null)
            {
                UpdateForType(type, rhs, this);
                type = type.BaseType;
            }
        }

        private static void UpdateForType(Type type, Entity source, Entity destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }

        protected object BuildProperty(Entity _obj, string property_name)
        {
            if (mEntityBuilder == null)
            {
                return null;
            }
            return mEntityBuilder.BuildProperty(_obj, property_name);
        }

        public void Log(string message)
        {
            AppEnv.Instance.Log(message);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
