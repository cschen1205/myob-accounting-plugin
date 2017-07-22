using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Activities
{
    public abstract class BillingRateUsedManager : EntityManager<BillingRateUsed>        
    {
        public BillingRateUsedManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BillingRateUsed _CreateDbEntity()
        {
            return new BillingRateUsed(true, this);
        }

        protected override BillingRateUsed _CreateEntity()
        {
            return new BillingRateUsed(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(BillingRateUsed _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["BillingRateUsedID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.BillingRateUsedID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("BillingRateUsed");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByBillingRateUsedID(string BillingRateUsedID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("BillingRateUsed")
                .Criteria.IsEqual("BillingRateUsed", "BillingRateUsedID", BillingRateUsedID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBillingRateUsedID(string BillingRateUsedID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("BillingRateUsed")
                .Criteria.IsEqual("BillingRateUsed", "BillingRateUsedID", BillingRateUsedID);

            return clause;
        }

        private bool Exists(string BillingRateUsedID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByBillingRateUsedID(BillingRateUsedID)) != 0;
        }

        public override bool Exists(BillingRateUsed _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByBillingRateUsedID(_obj.BillingRateUsedID)) != 0;
        }

        protected override void LoadFromReader(BillingRateUsed _obj, DbDataReader reader)
        {
            _obj.BillingRateUsedID =GetString(reader, ("BillingRateUsedID"));
            _obj.Description =GetString(reader, ("Description"));
        }

        protected override BillingRateUsed _FindByTextId(string BillingRateUsedID)
        {
            if (Exists(BillingRateUsedID))
            {
                BillingRateUsed _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByBillingRateUsedID(BillingRateUsedID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<BillingRateUsed>_FindAllCollection()
        {
            List<BillingRateUsed> objs = new List<BillingRateUsed>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                BillingRateUsed _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
