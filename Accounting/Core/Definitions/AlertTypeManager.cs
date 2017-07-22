using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class AlertTypeManager : EntityManager<AlertType>
    {
        public AlertTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override AlertType _CreateDbEntity()
        {
            return new AlertType(true, this);
        }
        protected override AlertType _CreateEntity()
        {
            return new AlertType(false, this);
        }
        #endregion

        protected override void LoadFromReader(AlertType _obj, DbDataReader reader)
        {
            _obj.AlertTypeID = GetString(reader, "AlertTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AlertType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AlertTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.AlertTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("AlertTypes");
        }

        private DbSelectStatement GetQuery_SelectByAlertTypeID(string AlertTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("AlertTypes")
                .Criteria
                    .IsEqual("AlertTypes", "AlertTypeID", AlertTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByAlertTypeID(string AlertTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("AlertTypes")
                .Criteria
                    .IsEqual("AlertTypes", "AlertTypeID", AlertTypeID);

            return clause;
        }

        public bool Exists(string AlertTypeID)
        {
            if (AlertTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAlertTypeID(AlertTypeID)) != 0;
        }

        public override bool Exists(AlertType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.AlertTypeID);
        }

        protected override AlertType _FindByTextId(string AlertTypeID)
        {
            AlertType _obj = null;
            if (AlertTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByAlertTypeID(AlertTypeID));
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

        protected override IList<AlertType>_FindAllCollection()
        {
            List<AlertType> _grp = new List<AlertType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                AlertType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
