using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class CalculationMethodManager : EntityManager<CalculationMethod>
    {
        public CalculationMethodManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CalculationMethod _CreateDbEntity()
        {
            return new CalculationMethod(true, this);
        }
        protected override CalculationMethod _CreateEntity()
        {
            return new CalculationMethod(false, this);
        }
        #endregion

        protected override void LoadFromReader(CalculationMethod _obj, DbDataReader reader)
        {
            _obj.CalculationMethodID = GetString(reader, "CalculationMethodID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CalculationMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CalculationMethodID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.CalculationMethodID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("CalculationMethod");
        }

        private DbSelectStatement GetQuery_SelectByCalculationMethodID(string CalculationMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("CalculationMethod")
                .Criteria
                    .IsEqual("CalculationMethod", "CalculationMethodID", CalculationMethodID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCalculationMethodID(string CalculationMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("CalculationMethod")
                .Criteria
                    .IsEqual("CalculationMethod", "CalculationMethodID", CalculationMethodID);

            return clause;
        }

        public bool Exists(string CalculationMethodID)
        {
            if (CalculationMethodID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCalculationMethodID(CalculationMethodID)) != 0;
        }

        public override bool Exists(CalculationMethod _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CalculationMethodID);
        }

        protected override CalculationMethod _FindByTextId(string CalculationMethodID)
        {
            CalculationMethod _obj = null;
            if (CalculationMethodID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCalculationMethodID(CalculationMethodID));
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

        protected override IList<CalculationMethod>_FindAllCollection()
        {
            List<CalculationMethod> _grp = new List<CalculationMethod>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CalculationMethod _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
