using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class NumberingTypeManager : EntityManager<NumberingType>
    {
        public NumberingTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override NumberingType _CreateDbEntity()
        {
            return new NumberingType(true, this);
        }
        protected override NumberingType _CreateEntity()
        {
            return new NumberingType(false, this);
        }
        #endregion

        protected override void LoadFromReader(NumberingType _obj, DbDataReader reader)
        {
            _obj.NumberingTypeID = GetString(reader, "NumberingTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(NumberingType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["NumberingTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.NumberingTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("NumberingTypes");
        }

        private DbSelectStatement GetQuery_SelectByNumberingTypeID(string NumberingTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("NumberingTypes")
                .Criteria
                    .IsEqual("NumberingTypes", "NumberingTypeID", NumberingTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByNumberingTypeID(string NumberingTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("NumberingTypes")
                .Criteria
                    .IsEqual("NumberingTypes", "NumberingTypeID", NumberingTypeID);

            return clause;
        }

        public bool Exists(string NumberingTypeID)
        {
            if (NumberingTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByNumberingTypeID(NumberingTypeID)) != 0;
        }

        public override bool Exists(NumberingType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.NumberingTypeID);
        }

        protected override NumberingType _FindByTextId(string NumberingTypeID)
        {
            NumberingType _obj = null;
            if (NumberingTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByNumberingTypeID(NumberingTypeID));
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

        protected override IList<NumberingType>_FindAllCollection()
        {
            List<NumberingType> _grp = new List<NumberingType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                NumberingType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
