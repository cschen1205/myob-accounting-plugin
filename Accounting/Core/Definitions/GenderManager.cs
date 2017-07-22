using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class GenderManager : EntityManager<Gender>
    {
        public GenderManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override Gender _CreateDbEntity()
        {
            return new Gender(true, this);
        }

        protected override Gender _CreateEntity()
        {
            return new Gender(false, this);
        }

        protected override void LoadFromReader(Gender _obj, DbDataReader reader)
        {
            _obj.GenderID = GetString(reader, "GenderID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Gender _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["GenderID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.GenderID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        public override bool Exists(Gender _obj)
        {
            if (_obj == null) return false;
            return ExistsByGenderID(_obj.GenderID);
        }

        public bool ExistsByGenderID(string GenderID)
        {
            if (GenderID == null) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Gender")
                .Criteria
                    .IsEqual("Gender", "GenderID", GenderID);
            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public bool ExistsByDescription(string Description)
        {
            if (string.IsNullOrEmpty(Description)) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Gender")
                .Criteria
                    .IsEqual("Gender", "Description", Description);
            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public virtual DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Gender", "GenderID")
                .SelectColumn("Gender", "Description")
                .From("Gender");

            DataTable table = new DataTable();
            table.Columns.Add("GenderID");
            table.Columns.Add("Description");

            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["GenderID"] = GetString(_reader, "GenderID");
                row["Description"] = GetString(_reader, "Description");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

        protected override IList<Gender>_FindAllCollection()
        {
            List<Gender> _grp = new List<Gender>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Gender");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Gender _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override Gender _FindByTextId(string GenderID)
        {
            Gender _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Gender")
                .Criteria
                    .IsEqual("Gender", "GenderID", GenderID);

            DbCommand _cmd = CreateDbCommand(clause);
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

        public Gender FindByDescription(string Description)
        {
            Gender _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Gender")
                .Criteria
                    .IsEqual("Gender", "Description", Description);

            DbCommand _cmd = CreateDbCommand(clause);
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
    }
}
