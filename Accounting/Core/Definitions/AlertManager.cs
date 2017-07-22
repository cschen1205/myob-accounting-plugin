using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class AlertManager : EntityManager<Alert>
    {
        public AlertManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Alert _CreateDbEntity()
        {
            return new Alert(true, this);
        }
        protected override Alert _CreateEntity()
        {
            return new Alert(false, this);
        }
        #endregion

        protected override void LoadFromReader(Alert _obj, DbDataReader reader)
        {
            _obj.AlertID = GetString(reader, "AlertID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Alert _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AlertID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.AlertID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("Alerts");
        }

        private DbSelectStatement GetQuery_SelectByAlertID(string AlertID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("Alerts")
                .Criteria
                    .IsEqual("Alerts", "AlertID", AlertID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByAlertID(string AlertID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("Alerts")
                .Criteria
                    .IsEqual("Alerts", "AlertID", AlertID);

            return clause;
        }

        public bool Exists(string AlertID)
        {
            if (AlertID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAlertID(AlertID)) != 0;
        }

        public override bool Exists(Alert _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.AlertID);
        }

        protected override Alert _FindByTextId(string AlertID)
        {
            Alert _obj = null;
            if (AlertID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByAlertID(AlertID));
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

        protected override IList<Alert>_FindAllCollection()
        {
            List<Alert> _grp = new List<Alert>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Alert _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
