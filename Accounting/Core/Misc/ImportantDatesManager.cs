using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public abstract class ImportantDatesManager : EntityManager<ImportantDates>
    {
        public ImportantDatesManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ImportantDates _CreateDbEntity()
        {
            return new ImportantDates(true, this);
        }
        protected override ImportantDates _CreateEntity()
        {
            return new ImportantDates(false, this);
        }
        #endregion

        protected override void LoadFromReader(ImportantDates _obj, DbDataReader reader)
        {
            _obj.ImportantDatesID = GetInt32(reader, "ImportantDatesID");
            _obj.CalendarYear = GetInt32(reader, "CalendarYear");
            _obj.JanuaryDetails = GetString(reader, "JanuaryDetails");
            _obj.FebruaryDetails = GetString(reader, "FebruaryDetails");
            _obj.MarchDetails = GetString(reader, "MarchDetails");
            _obj.AprilDetails = GetString(reader, "AprilDetails");
            _obj.MayDetails = GetString(reader, "MayDetails");
            _obj.JuneDetails = GetString(reader, "JuneDetails");
            _obj.JulyDetails = GetString(reader, "JulyDetails");
            _obj.AugustDetails = GetString(reader, "AugustDetails");
            _obj.SeptemberDetails = GetString(reader, "SeptemberDetails");
            _obj.OctoberDetails = GetString(reader, "OctoberDetails");
            _obj.NovemberDetails = GetString(reader, "NovemberDetails");
            _obj.DecemberDetails = GetString(reader, "DecemberDetails");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ImportantDates _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ImportantDatesID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ImportantDatesID); //GetInt32(reader, "");
            fields["CalendarYear"] = DbMgr.CreateIntFieldEntry(_obj.CalendarYear); //GetInt32(reader, "");
            fields["JanuaryDetails"] = DbMgr.CreateStringFieldEntry(_obj.JanuaryDetails); //GetString(reader, "");
            fields["FebruaryDetails"] = DbMgr.CreateStringFieldEntry(_obj.FebruaryDetails); //GetString(reader, "");
            fields["MarchDetails"] = DbMgr.CreateStringFieldEntry(_obj.MarchDetails); //GetString(reader, "");
            fields["AprilDetails"] = DbMgr.CreateStringFieldEntry(_obj.AprilDetails); //GetString(reader, "");
            fields["MayDetails"] = DbMgr.CreateStringFieldEntry(_obj.MayDetails); //GetString(reader, "");
            fields["JuneDetails"] = DbMgr.CreateStringFieldEntry(_obj.JuneDetails); //GetString(reader, "");
            fields["JulyDetails"] = DbMgr.CreateStringFieldEntry(_obj.JulyDetails); //GetString(reader, "");
            fields["AugustDetails"] = DbMgr.CreateStringFieldEntry(_obj.AugustDetails); //GetString(reader, "");
            fields["SeptemberDetails"] = DbMgr.CreateStringFieldEntry(_obj.SeptemberDetails); //GetString(reader, "");
            fields["OctoberDetails"] = DbMgr.CreateStringFieldEntry(_obj.OctoberDetails); //GetString(reader, "");
            fields["NovemberDetails"] = DbMgr.CreateStringFieldEntry(_obj.NovemberDetails); //GetString(reader, "");
            fields["DecemberDetails"] = DbMgr.CreateStringFieldEntry(_obj.DecemberDetails); //GetString(reader, "");

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ImportantDates");
        }

        private DbSelectStatement GetQuery_SelectByImportantDatesID(int ImportantDatesID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ImportantDates")
                .Criteria
                    .IsEqual("ImportantDates", "ImportantDatesID", ImportantDatesID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByImportantDatesID(int ImportantDatesID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ImportantDates")
                .Criteria
                    .IsEqual("ImportantDates", "ImportantDatesID", ImportantDatesID);

            return clause;
        }

        public bool Exists(int? ImportantDatesID)
        {
            if (ImportantDatesID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByImportantDatesID(ImportantDatesID.Value)) != 0;
        }

        public override bool Exists(ImportantDates _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ImportantDatesID);
        }

        protected override ImportantDates _FindByIntId(int? ImportantDatesID)
        {
            ImportantDates _obj = null;
            if (ImportantDatesID == null) return null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByImportantDatesID(ImportantDatesID.Value));
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

        protected override IList<ImportantDates>_FindAllCollection()
        {
            List<ImportantDates> _grp = new List<ImportantDates>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ImportantDates _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
