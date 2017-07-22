using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public class ReportingMethodManager : EntityManager<ReportingMethod>
    {
        public ReportingMethodManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ReportingMethod _CreateDbEntity()
        {
            return new ReportingMethod(true, this);
        }
        protected override ReportingMethod _CreateEntity()
        {
            return new ReportingMethod(false, this);
        }
        #endregion

        protected override void LoadFromReader(ReportingMethod _obj, DbDataReader reader)
        {
            _obj.ReportingMethodID = GetString(reader, "ReportingMethodID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ReportingMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ReportingMethodID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.ReportingMethodID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ReportingMethod");
        }

        private DbSelectStatement GetQuery_SelectByReportingMethodID(string ReportingMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll()
                .From("ReportingMethod")
                .Criteria
                    .IsEqual("ReportingMethod", "ReportingMethodID", ReportingMethodID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByReportingMethodID(string ReportingMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectCount()
                .From("ReportingMethod")
                .Criteria
                    .IsEqual("ReportingMethod", "ReportingMethodID", ReportingMethodID);

            return clause;
        }

        public bool Exists(string ReportingMethodID)
        {
            if (ReportingMethodID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByReportingMethodID(ReportingMethodID)) != 0;
        }

        public override bool Exists(ReportingMethod _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ReportingMethodID);
        }

        protected override ReportingMethod _FindByTextId(string ReportingMethodID)
        {
            ReportingMethod _obj = null;
            if (ReportingMethodID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByReportingMethodID(ReportingMethodID));

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

        protected override IList<ReportingMethod>_FindAllCollection()
        {
            List<ReportingMethod> _grp = new List<ReportingMethod>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ReportingMethod _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);

            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
