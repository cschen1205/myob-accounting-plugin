using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class EmployerExpenseTypeManager : EntityManager<EmployerExpenseType>
    {
        public EmployerExpenseTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override EmployerExpenseType _CreateDbEntity()
        {
            return new EmployerExpenseType(true, this);
        }
        protected override EmployerExpenseType _CreateEntity()
        {
            return new EmployerExpenseType(false, this);
        }
        #endregion

        protected override void LoadFromReader(EmployerExpenseType _obj, DbDataReader reader)
        {
            _obj.EmployerExpenseTypeID = GetString(reader, "EmployerExpenseTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(EmployerExpenseType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["EmployerExpenseTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.EmployerExpenseTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("EmployerExpenseTypes");
        }

        private DbSelectStatement GetQuery_SelectByEmployerExpenseTypeID(string EmployerExpenseTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("EmployerExpenseTypes")
                .Criteria
                    .IsEqual("EmployerExpenseTypes", "EmployerExpenseTypeID", EmployerExpenseTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByEmployerExpenseTypeID(string EmployerExpenseTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("EmployerExpenseTypes")
                .Criteria
                    .IsEqual("EmployerExpenseTypes", "EmployerExpenseTypeID", EmployerExpenseTypeID);

            return clause;
        }

        public bool Exists(string EmployerExpenseTypeID)
        {
            if (EmployerExpenseTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByEmployerExpenseTypeID(EmployerExpenseTypeID)) != 0;
        }

        public override bool Exists(EmployerExpenseType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.EmployerExpenseTypeID);
        }

        protected override EmployerExpenseType _FindByTextId(string EmployerExpenseTypeID)
        {
            EmployerExpenseType _obj = null;
            if (EmployerExpenseTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByEmployerExpenseTypeID(EmployerExpenseTypeID));
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

        protected override IList<EmployerExpenseType>_FindAllCollection()
        {
            List<EmployerExpenseType> _grp = new List<EmployerExpenseType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                EmployerExpenseType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
