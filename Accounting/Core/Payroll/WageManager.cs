using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class WageManager : EntityManager<Wage>
    {
        public WageManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Wage _CreateDbEntity()
        {
            return new Wage(true, this);
        }
        protected override Wage _CreateEntity()
        {
            return new Wage(false, this);
        }
        #endregion

        protected override void LoadFromReader(Wage _obj, DbDataReader reader)
        {
            _obj.FixedHourlyRate = GetDouble(reader, "FixedHourlyRate");
            _obj.IsDummy = GetString(reader, "IsDummy");
            _obj.IsHourly = GetString(reader, "IsHourly", "IsHouly");
            _obj.OverideAccountID = GetInt32(reader, "OverideAccountID");
            _obj.RegularRateMultiplier = GetDouble(reader, "RegularRateMultiplier");
            _obj.UseFixedRate = GetString(reader, "UseFixedRate");
            _obj.WageID = GetInt32(reader, "WageID");
            _obj.WagesName = GetString(reader, "WagesName");
         
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Wage _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["FixedHourlyRate"] = DbMgr.CreateDoubleFieldEntry(_obj.FixedHourlyRate); //GetDouble(reader, "");
            fields["IsDummy"] = DbMgr.CreateStringFieldEntry(_obj.IsDummy); //GetString(reader, "");
            fields["IsHourly"] = DbMgr.CreateStringFieldEntry(_obj.IsHourly); //GetString(reader, "");
            fields["OverideAccountID"] = DbMgr.CreateIntFieldEntry(_obj.OverideAccountID); //GetInt32(reader, "");
            fields["RegularRateMultiplier"] = DbMgr.CreateDoubleFieldEntry(_obj.RegularRateMultiplier); //GetDouble(reader, "");
            fields["UseFixedRate"] = DbMgr.CreateStringFieldEntry(_obj.UseFixedRate); //GetString(reader, "");
            fields["WageID"] = DbMgr.CreateAutoIntFieldEntry(_obj.WageID); //GetInt32(reader, "");
            fields["WagesName"] = DbMgr.CreateStringFieldEntry(_obj.WagesName); //GetString(reader, "");

            return fields;
        }

        protected override object GetDbProperty(Wage _obj, string property_name)
        {
            if (property_name.Equals("OverideAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.OverideAccountID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("Wages");
        }

        private DbSelectStatement GetQuery_SelectByWageID(int WageID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("Wages")
                .Criteria
                    .IsEqual("Wages", "WageID", WageID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByWageID(int WageID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("Wages")
                .Criteria
                    .IsEqual("Wages", "WageID", WageID);

            return clause;
        }

        public bool Exists(int? WageID)
        {
            if (WageID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByWageID(WageID.Value)) != 0;
        }

        public override bool Exists(Wage _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.WageID);
        }

        protected override Wage _FindByIntId(int? WageID)
        {
            if (WageID == null) return null;
            Wage _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByWageID(WageID.Value));
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

        protected override IList<Wage>_FindAllCollection()
        {
            List<Wage> _grp = new List<Wage>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Wage _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
