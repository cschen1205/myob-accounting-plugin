using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class DayNameManager : EntityManager<DayName>
    {
        public DayNameManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override DayName _CreateDbEntity()
        {
            return new DayName(true, this);
        }
        protected override DayName _CreateEntity()
        {
            return new DayName(false, this);
        }
        #endregion

        protected override void LoadFromReader(DayName _obj, DbDataReader reader)
        {
            _obj.DayNameID = GetString(reader, "DayNameID", "DayNamesID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(DayName _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["DayNameID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.DayNameID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("DayNames");
        }

        private DbSelectStatement GetQuery_SelectByDayNameID(string DayNameID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("DayNames")
                .Criteria
                    .IsEqual("DayNames", "DayNameID", DayNameID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByDayNameID(string DayNameID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("DayNames")
                .Criteria
                    .IsEqual("DayNames", "DayNameID", DayNameID);

            return clause;
        }

        public bool Exists(string DayNameID)
        {
            if (DayNameID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByDayNameID(DayNameID)) != 0;
        }

        public override bool Exists(DayName _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.DayNameID);
        }

        protected override DayName _FindByTextId(string DayNameID)
        {
            DayName _obj = null;
            if (DayNameID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByDayNameID(DayNameID));
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

        protected override IList<DayName>_FindAllCollection()
        {
            List<DayName> _grp = new List<DayName>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                DayName _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
