using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class EmploymentStatusManager : EntityManager<EmploymentStatus>
    {
        public EmploymentStatusManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override EmploymentStatus _CreateDbEntity()
        {
            return new EmploymentStatus(true, this);
        }
        protected override EmploymentStatus _CreateEntity()
        {
            return new EmploymentStatus(false, this);
        }
        #endregion

        protected override void LoadFromReader(EmploymentStatus _obj, DbDataReader reader)
        {
            _obj.EmploymentStatusID = GetString(reader, "EmploymentStatusID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(EmploymentStatus _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["EmploymentStatusID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.EmploymentStatusID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("EmploymentStatus");
        }

        private DbSelectStatement GetQuery_SelectByEmploymentStatusID(string EmploymentStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("EmploymentStatus")
                .Criteria
                    .IsEqual("EmploymentStatus", "EmploymentStatusID", EmploymentStatusID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByEmploymentStatusID(string EmploymentStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("EmploymentStatus")
                .Criteria
                    .IsEqual("EmploymentStatus", "EmploymentStatusID", EmploymentStatusID);

            return clause;
        }

        public bool Exists(string EmploymentStatusID)
        {
            if (EmploymentStatusID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByEmploymentStatusID(EmploymentStatusID)) != 0;
        }

        public override bool Exists(EmploymentStatus _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.EmploymentStatusID);
        }

        protected override EmploymentStatus _FindByTextId(string EmploymentStatusID)
        {
            EmploymentStatus _obj = null;
            if (EmploymentStatusID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByEmploymentStatusID(EmploymentStatusID));
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

        protected override IList<EmploymentStatus>_FindAllCollection()
        {
            List<EmploymentStatus> _grp = new List<EmploymentStatus>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                EmploymentStatus _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
