using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.JournalRecords
{
    public abstract class JournalTypeManager : EntityManager<JournalType>
    {
        public JournalTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override JournalType _CreateDbEntity()
        {
            return new JournalType(true, this);
        }

        protected override JournalType _CreateEntity()
        {
            return new JournalType(false, this);
        }
        #endregion

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("JournalTypes");

            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(JournalType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectByJournalTypeID(string JournalTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("JournalTypes")
                .Criteria
                    .IsEqual("JournalTypes", "JournalTypeID", JournalTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByJournalTypeID(string JournalTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("JournalTypes")
                .Criteria
                    .IsEqual("JournalTypes", "JournalTypeID", JournalTypeID);

            return clause;
        }

        private bool Exists(string JournalTypeID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByJournalTypeID(JournalTypeID)) != 0;
        }

        public override bool Exists(JournalType _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByJournalTypeID(_obj.JournalTypeID)) != 0;
        }

        protected override void LoadFromReader(JournalType _obj, DbDataReader reader)
        {
            _obj.JournalTypeID =GetString(reader, ("JournalTypeID"));
            _obj.Description =GetString(reader, ("Description"));
        }

        protected override JournalType _FindByTextId(string JournalTypeID)
        {
            if (Exists(JournalTypeID))
            {
                JournalType _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByJournalTypeID(JournalTypeID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<JournalType>_FindAllCollection()
        {
            List<JournalType> objs = new List<JournalType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                JournalType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
