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
    public abstract class DataFieldManager : EntityManager<DataField>
    {
        public DataFieldManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override DataField _CreateEntity()
        {
            return new DataField(false, this);
        }

        protected override DataField _CreateDbEntity()
        {
            return new DataField(true, this);
        }

        public override bool Exists(DataField _obj)
        {
            if (_obj == null) return false;
            return ExistsByDataFieldID(_obj.DataFieldID);
        }

        public virtual bool ExistsByDataFieldID(int? DataFieldID)
        {
            if (DataFieldID == null) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("DataFields")
                .Criteria
                    .IsEqual("DataFields", "DataFieldID", DataFieldID);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public virtual bool ExistsByDataFieldName(string DataFieldName)
        {
            if (DataFieldName == null) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("DataFields")
                .Criteria
                    .IsEqual("DataFields", "DataFieldName", DataFieldName);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        protected override void LoadFromReader(DataField _obj, DbDataReader reader)
        {
            _obj.DataFieldID = GetInt32(reader, "DataFieldID");
            _obj.DataFieldType = GetString(reader, "DataFieldType");
            _obj.DataFieldName = GetString(reader, "DataFieldName");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(DataField _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["DataFieldID"] = DbMgr.CreateAutoIntFieldEntry(_obj.DataFieldID);
            fields["DataFieldType"] = DbMgr.CreateStringFieldEntry(_obj.DataFieldType);
            fields["DataFieldName"] = DbMgr.CreateStringFieldEntry(_obj.DataFieldName);

            return fields;
        }

        protected override IList<DataField>_FindAllCollection()
        {
            List<DataField> _grp = new List<DataField>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("DataFields");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                DataField _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override DataField _FindByIntId(int? DataFieldID)
        {
            if (DataFieldID == null) return null;
            DataField _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("DataFields")
                .Criteria
                    .IsEqual("DataFields", "DataFieldID", DataFieldID);

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

        protected override DataField _FindByTextId(string DataFieldName)
        {
            DataField _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("DataFields")
                .Criteria
                    .IsEqual("DataFields", "DataFieldName", DataFieldName);

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
