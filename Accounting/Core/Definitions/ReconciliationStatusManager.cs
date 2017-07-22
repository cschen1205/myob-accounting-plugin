using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class ReconciliationStatusManager : EntityManager<ReconciliationStatus>
    {
        public ReconciliationStatusManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ReconciliationStatus _CreateEntity()
        {
            return new ReconciliationStatus(false, this);
        }
        protected override ReconciliationStatus _CreateDbEntity()
        {
            return new ReconciliationStatus(true, this);
        }
        #endregion

        protected override void LoadFromReader(ReconciliationStatus _obj, DbDataReader reader)
        {
            _obj.ReconciliationStatusID = GetString(reader, "ReconciliationStatusID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ReconciliationStatus _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ReconciliationStatusID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.ReconciliationStatusID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ReconciliationStatus");
        }

        private DbSelectStatement GetQuery_SelectByReconciliationStatusID(string ReconciliationStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ReconciliationStatus")
                .Criteria
                    .IsEqual("ReconciliationStatus", "ReconciliationStatusID", ReconciliationStatusID);
            return clause;
        }
        

        private DbSelectStatement GetQuery_SelectCountByReconciliationStatusID(string ReconciliationStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ReconciliationStatus")
                .Criteria
                    .IsEqual("ReconciliationStatus", "ReconciliationStatusID", ReconciliationStatusID);
            return clause;
        }

        public bool Exists(string ReconciliationStatusID)
        {
            if (ReconciliationStatusID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByReconciliationStatusID(ReconciliationStatusID)) != 0;
        }

        public override bool Exists(ReconciliationStatus _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ReconciliationStatusID);
        }

        protected override ReconciliationStatus _FindByTextId(string ReconciliationStatusID)
        {
            ReconciliationStatus _obj = null;
            if (ReconciliationStatusID == null) return _obj;
            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByReconciliationStatusID(ReconciliationStatusID));
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override IList<ReconciliationStatus>_FindAllCollection()
        {
            List<ReconciliationStatus> _grp = new List<ReconciliationStatus>();
            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ReconciliationStatus _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
