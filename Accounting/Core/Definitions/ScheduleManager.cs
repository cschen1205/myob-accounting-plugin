using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class ScheduleManager : EntityManager<Schedule>
    {
        public ScheduleManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Schedule _CreateDbEntity()
        {
            return new Schedule(true, this);
        }
        protected override Schedule _CreateEntity()
        {
            return new Schedule(false, this);
        }
        #endregion

        protected override void LoadFromReader(Schedule _obj, DbDataReader reader)
        {
            _obj.ScheduleID = GetString(reader, "ScheduleID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Schedule _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ScheduleID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.ScheduleID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("Schedule");
        }

        private DbSelectStatement GetQuery_SelectByScheduleID(string ScheduleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("Schedule")
                .Criteria
                    .IsEqual("Schedule", "ScheduleID", ScheduleID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByScheduleID(string ScheduleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("Schedule")
                .Criteria
                    .IsEqual("Schedule", "ScheduleID", ScheduleID);

            return clause;
        }

        public bool Exists(string ScheduleID)
        {
            if (ScheduleID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByScheduleID(ScheduleID)) != 0;
        }

        public override bool Exists(Schedule _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ScheduleID);
        }

        protected override Schedule _FindByTextId(string ScheduleID)
        {
            Schedule _obj = null;
            if (ScheduleID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByScheduleID(ScheduleID));
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

        protected override IList<Schedule>_FindAllCollection()
        {
            List<Schedule> _grp = new List<Schedule>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Schedule _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
