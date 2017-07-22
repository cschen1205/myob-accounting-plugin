using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class EmploymentBasisManager : EntityManager<EmploymentBasis>
    {
        public EmploymentBasisManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override EmploymentBasis _CreateDbEntity()
        {
            return new EmploymentBasis(true, this);
        }
        protected override EmploymentBasis _CreateEntity()
        {
            return new EmploymentBasis(false, this);
        }
        #endregion

        protected override void LoadFromReader(EmploymentBasis _obj, DbDataReader reader)
        {
            _obj.EmploymentBasisID = GetString(reader, "EmploymentBasisID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(EmploymentBasis _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["EmploymentBasisID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.EmploymentBasisID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("EmploymentBasis");
        }

        private DbSelectStatement GetQuery_SelectByEmploymentBasisID(string EmploymentBasisID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("EmploymentBasis")
                .Criteria
                    .IsEqual("EmploymentBasis", "EmploymentBasisID", EmploymentBasisID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByEmploymentBasisID(string EmploymentBasisID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("EmploymentBasis")
                .Criteria
                    .IsEqual("EmploymentBasis", "EmploymentBasisID", EmploymentBasisID);

            return clause;
        }

        public bool Exists(string EmploymentBasisID)
        {
            if (EmploymentBasisID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByEmploymentBasisID(EmploymentBasisID)) != 0;
        }

        public override bool Exists(EmploymentBasis _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.EmploymentBasisID);
        }

        protected override EmploymentBasis _FindByTextId(string EmploymentBasisID)
        {
            EmploymentBasis _obj = null;
            if (EmploymentBasisID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByEmploymentBasisID(EmploymentBasisID));
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

        protected override IList<EmploymentBasis>_FindAllCollection()
        {
            List<EmploymentBasis> _grp = new List<EmploymentBasis>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                EmploymentBasis _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
