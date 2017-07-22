using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class FrequencyManager : EntityManager<Frequency>
    {
        public FrequencyManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Frequency _CreateDbEntity()
        {
            return new Frequency(true, this);
        }
        protected override Frequency _CreateEntity()
        {
            return new Frequency(false, this);
        }
        #endregion

        protected override void LoadFromReader(Frequency _obj, DbDataReader reader)
        {
            _obj.FrequencyID = GetString(reader, "FrequencyID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Frequency _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["FrequencyID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.FrequencyID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("Frequencies");
        }

        private DbSelectStatement GetQuery_SelectByFrequencyID(string FrequencyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("Frequencies")
                .Criteria
                    .IsEqual("Frequencies", "FrequencyID", FrequencyID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByFrequencyID(string FrequencyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("Frequencies")
                .Criteria
                    .IsEqual("Frequencies", "FrequencyID", FrequencyID);

            return clause;
        }

        public bool Exists(string FrequencyID)
        {
            if (FrequencyID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByFrequencyID(FrequencyID)) != 0;
        }

        public override bool Exists(Frequency _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.FrequencyID);
        }

        protected override Frequency _FindByTextId(string FrequencyID)
        {
            Frequency _obj = null;
            if (FrequencyID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByFrequencyID(FrequencyID));
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

        protected override IList<Frequency>_FindAllCollection()
        {
            List<Frequency> _grp = new List<Frequency>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Frequency _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
