using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class BuildComponentManager : EntityManager<BuildComponent>
    {
        public BuildComponentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BuildComponent _CreateDbEntity()
        {
            return new BuildComponent(true, this);
        }
        protected override BuildComponent _CreateEntity()
        {
            return new BuildComponent(false, this);
        }
        #endregion

        protected override void LoadFromReader(BuildComponent _obj, DbDataReader reader)
        {
            _obj.BuildComponentID = GetInt32(reader, "BuildComponentID");
            _obj.BuiltItemID = GetInt32(reader, "BuiltItemID");
            _obj.SequenceNumber = GetInt32(reader, "SequenceNumber");
            _obj.ComponentID = GetInt32(reader, "ComponentID");
            _obj.QuantityNeeded = GetDouble(reader, "QuantityNeeded");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(BuildComponent _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["BuildComponentID"] = DbMgr.CreateIntFieldEntry(_obj.BuildComponentID); //GetInt32(reader, "");
            fields["BuiltItemID"] = DbMgr.CreateIntFieldEntry(_obj.BuiltItemID); //GetInt32(reader, "");
            fields["SequenceNumber"] = DbMgr.CreateIntFieldEntry(_obj.SequenceNumber); //GetInt32(reader, "");
            fields["ComponentID"] = DbMgr.CreateIntFieldEntry(_obj.ComponentID); //GetInt32(reader, "");
            fields["QuantityNeeded"] = DbMgr.CreateDoubleFieldEntry(_obj.QuantityNeeded); //GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(BuildComponent _obj, string property_name)
        {
            if (property_name.Equals("BuiltItem"))
            {
                return RepositoryMgr.BuiltItemMgr.FindById(_obj.BuiltItemID);
            }
            else if (property_name.Equals("Component"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ComponentID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("BuildComponents");
        }

        private DbSelectStatement GetQuery_SelectByBuildComponentID(int BuildComponentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("BuildComponents")
                .Criteria
                    .IsEqual("BuildComponents", "BuildComponentID", BuildComponentID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBuildComponentID(int BuildComponentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("BuildComponents")
                .Criteria
                    .IsEqual("BuildComponents", "BuildComponentID", BuildComponentID);

            return clause;
        }

        public bool Exists(int? BuildComponentID)
        {
            if (BuildComponentID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByBuildComponentID(BuildComponentID.Value)) != 0;
        }

        public override bool Exists(BuildComponent _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.BuildComponentID);
        }

        protected override BuildComponent _FindByIntId(int? BuildComponentID)
        {
            if (BuildComponentID == null) return null;
            BuildComponent _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByBuildComponentID(BuildComponentID.Value));
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

        protected override IList<BuildComponent>_FindAllCollection()
        {
            List<BuildComponent> _grp = new List<BuildComponent>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                BuildComponent _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
