using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class EmploymentClassificationManager : EntityManager<EmploymentClassification>
    {
        public EmploymentClassificationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override EmploymentClassification _CreateDbEntity()
        {
            return new EmploymentClassification(true, this);
        }
        protected override EmploymentClassification _CreateEntity()
        {
            return new EmploymentClassification(false, this);
        }
        #endregion

        protected override void LoadFromReader(EmploymentClassification _obj, DbDataReader reader)
        {
            _obj.EmploymentClassificationID = GetInt32(reader, "EmploymentClassificationID");
            _obj.EmploymentClassificationName = GetString(reader, "EmploymentClassificationName");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(EmploymentClassification _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["EmploymentClassificationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.EmploymentClassificationID);
            fields["EmploymentClassificationName"] = DbMgr.CreateStringFieldEntry(_obj.EmploymentClassificationName);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("EmploymentClassifications");
        }

        private DbSelectStatement GetQuery_SelectByEmploymentClassificationID(int? EmploymentClassificationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("EmploymentClassifications")
                .Criteria
                    .IsEqual("EmploymentClassifications", "EmploymentClassificationID", EmploymentClassificationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByEmploymentClassificationID(int? EmploymentClassificationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("EmploymentClassifications")
                .Criteria
                    .IsEqual("EmploymentClassifications", "EmploymentClassificationID", EmploymentClassificationID);

            return clause;
        }

        public bool Exists(int? EmploymentClassificationID)
        {
            if (EmploymentClassificationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByEmploymentClassificationID(EmploymentClassificationID)) != 0;
        }

        public override bool Exists(EmploymentClassification _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.EmploymentClassificationID);
        }

        protected override EmploymentClassification _FindByIntId(int? EmploymentClassificationID)
        {
            EmploymentClassification _obj = null;
            if (EmploymentClassificationID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByEmploymentClassificationID(EmploymentClassificationID));
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

        protected override IList<EmploymentClassification>_FindAllCollection()
        {
            List<EmploymentClassification> _grp = new List<EmploymentClassification>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                EmploymentClassification _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
