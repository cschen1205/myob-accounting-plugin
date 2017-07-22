using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class TerminationMethodManager : EntityManager<TerminationMethod>
    {
        public TerminationMethodManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TerminationMethod _CreateDbEntity()
        {
            return new TerminationMethod(true, this);
        }
        protected override TerminationMethod _CreateEntity()
        {
            return new TerminationMethod(false, this);
        }
        #endregion

        protected override void LoadFromReader(TerminationMethod _obj, DbDataReader reader)
        {
            _obj.TerminationMethodID = GetString(reader, "TerminationMethodID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(TerminationMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["TerminationMethodID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.TerminationMethodID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("TerminationMethod");
        }

        private DbSelectStatement GetQuery_SelectByTerminationMethodID(string TerminationMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("TerminationMethod")
                .Criteria
                    .IsEqual("TerminationMethod", "TerminationMethodID", TerminationMethodID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTerminationMethodID(string TerminationMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("TerminationMethod")
                .Criteria
                    .IsEqual("TerminationMethod", "TerminationMethodID", TerminationMethodID);

            return clause;
        }

        public bool Exists(string TerminationMethodID)
        {
            if (TerminationMethodID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTerminationMethodID(TerminationMethodID)) != 0;
        }

        public override bool Exists(TerminationMethod _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.TerminationMethodID);
        }

        protected override TerminationMethod _FindByTextId(string TerminationMethodID)
        {
            TerminationMethod _obj = null;
            if (TerminationMethodID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByTerminationMethodID(TerminationMethodID));
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

        protected override IList<TerminationMethod>_FindAllCollection()
        {
            List<TerminationMethod> _grp = new List<TerminationMethod>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                TerminationMethod _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
