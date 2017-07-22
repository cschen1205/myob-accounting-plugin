using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class DepositStatusManager : EntityManager<DepositStatus>
    {
        public DepositStatusManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override DepositStatus _CreateDbEntity()
        {
            return new DepositStatus(true, this);
        }
        protected override DepositStatus _CreateEntity()
        {
            return new DepositStatus(false, this);
        }
        #endregion

        protected override DepositStatus _FindByTextId(string DepositStatusID)
        {
            DepositStatus _obj = null;
            if (DepositStatusID == null) return _obj;
            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByDepositStatusID(DepositStatusID));
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


        protected override void LoadFromReader(DepositStatus _obj, DbDataReader reader)
        {
            _obj.DepositStatusID = GetString(reader, "DepositStatusID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(DepositStatus _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["DepositStatusID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.DepositStatusID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        public override bool Exists(DepositStatus _obj)
        {
            if(_obj==null) return false;
            return Exists(_obj.DepositStatusID);
        }

        public bool Exists(string DepositStatusID)
        {
            if (DepositStatusID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByDepositStatusID(DepositStatusID)) != 0;
        }

        private DbSelectStatement GetQuery_SelectCountByDepositStatusID(string DepositStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("DepositStatus")
                .Criteria
                    .IsEqual("DepositStatus", "DepositStatusID", DepositStatusID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByDepositStatusID(string DepositStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("DepositStatus")
                .Criteria
                    .IsEqual("DepositStatus", "DepositStatusID", DepositStatusID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll().From("DepositStatus");

            return clause;
        }

        protected override IList<DepositStatus>_FindAllCollection()
        {
            List<DepositStatus> _grp = new List<DepositStatus>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DepositStatus _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
