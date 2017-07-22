using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Accounts
{
    public abstract class CashFlowClassificationManager : EntityManager<CashFlowClassification>
    {
        public CashFlowClassificationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CashFlowClassification _CreateDbEntity()
        {
            return new CashFlowClassification(true, this);
        }

        protected override CashFlowClassification _CreateEntity()
        {
            return new CashFlowClassification(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(CashFlowClassification _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CashFlowClassID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.CashFlowClassID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CashFlowClassifications");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCashFlowClassID(string CashFlowClassID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CashFlowClassifications")
                .Criteria.IsEqual("CashFlowClassifications", "CashFlowClassID", CashFlowClassID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByCashFlowClassID(string CashFlowClassID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CashFlowClassifications")
                .Criteria.IsEqual("CashFlowClassifications", "CashFlowClassID", CashFlowClassID);

            return clause;
        }

        public override bool Exists(CashFlowClassification _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCashFlowClassID(_obj.CashFlowClassID)) != 0;
        }

        protected override CashFlowClassification _FindByTextId(string CashFlowClassID)
        {
            if (Exists(CashFlowClassID))
            {
                CashFlowClassification _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCashFlowClassID(CashFlowClassID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<CashFlowClassification>_FindAllCollection()
        {
            List<CashFlowClassification> _grp = new List<CashFlowClassification>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CashFlowClassification _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(CashFlowClassification _obj, DbDataReader _reader)
        {
            _obj.CashFlowClassID =GetString(_reader, ("CashFlowClassID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        public bool Exists(string CashFlowClassID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCashFlowClassID(CashFlowClassID)) != 0;
        }
    }
}
