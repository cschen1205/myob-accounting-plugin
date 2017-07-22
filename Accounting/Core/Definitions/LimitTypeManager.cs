using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class LimitTypeManager : EntityManager<LimitType>
    {
        public LimitTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override LimitType _CreateDbEntity()
        {
            return new LimitType(true, this);
        }
        protected override LimitType _CreateEntity()
        {
            return new LimitType(false, this);
        }

        #endregion

        protected override void LoadFromReader(LimitType _obj, DbDataReader reader)
        {
            _obj.LimitTypeID = GetString(reader, "LimitTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(LimitType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["LimitTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.LimitTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("LimitTypes");
        }

        private DbSelectStatement GetQuery_SelectCountByLimitTypeID(string LimitTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("LimitTypes")
                .Criteria
                    .IsEqual("LimitTypes", "LimitTypeID", LimitTypeID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByLimitTypeID(string LimitTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("LimitTypes")
                .Criteria
                    .IsEqual("LimitTypes", "LimitTypeID", LimitTypeID);
            return clause;
        }

        public bool Exists(string LimitTypeID)
        {
            if (LimitTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByLimitTypeID(LimitTypeID)) != 0;
        }

        public override bool Exists(LimitType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.LimitTypeID);
        }

        protected override LimitType _FindByTextId(string LimitTypeID)
        {
            LimitType _obj = null;
            if (LimitTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByLimitTypeID(LimitTypeID));
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

        protected override IList<LimitType>_FindAllCollection()
        {
            List<LimitType> _grp = new List<LimitType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                LimitType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
