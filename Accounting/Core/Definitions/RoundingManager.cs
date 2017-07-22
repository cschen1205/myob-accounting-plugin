using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class RoundingManager : EntityManager<Rounding>
    {
        public RoundingManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Rounding _CreateDbEntity()
        {
            return new Rounding(true, this);
        }
        protected override Rounding _CreateEntity()
        {
            return new Rounding(false, this);
        }
        #endregion

        protected override void LoadFromReader(Rounding _obj, DbDataReader reader)
        {
            _obj.RoundingID = GetString(reader, "RoundingID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Rounding _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["RoundingID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.RoundingID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("Rounding");
        }

        private DbSelectStatement GetQuery_SelectByRoundingID(string RoundingID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("Rounding")
                .Criteria
                    .IsEqual("Rounding", "RoundingID", RoundingID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRoundingID(string RoundingID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("Rounding")
                .Criteria
                    .IsEqual("Rounding", "RoundingID", RoundingID);

            return clause;
        }

        public bool Exists(string RoundingID)
        {
            if (RoundingID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRoundingID(RoundingID)) != 0;
        }

        public override bool Exists(Rounding _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.RoundingID);
        }

        protected override Rounding _FindByTextId(string RoundingID)
        {
            Rounding _obj = null;
            if (RoundingID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRoundingID(RoundingID));
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

        protected override IList<Rounding>_FindAllCollection()
        {
            List<Rounding> _grp = new List<Rounding>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Rounding _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
