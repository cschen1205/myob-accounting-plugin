using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbRecurringTimeBillingPurchaseLineManager : RecurringTimeBillingPurchaseLineManager
    {
        public DbRecurringTimeBillingPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringTimeBillingPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringTimeBillingPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringTimeBillingPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringTimeBillingPurchaseLines", GetFields(_obj), "RecurringTimeBillingPurchaseLineID", _obj.RecurringTimeBillingPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringTimeBillingPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringTimeBillingPurchaseLines").Criteria.IsEqual("RecurringTimeBillingPurchaseLines", "RecurringTimeBillingPurchaseLineID", _obj.RecurringTimeBillingPurchaseLineID);
            
            return clause;
        }

       

        protected override OpResult _Store(RecurringTimeBillingPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringTimeBillingPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringTimeBillingPurchaseLineID == null)
            {
                _obj.RecurringTimeBillingPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringTimeBillingPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringTimeBillingPurchaseLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringTimeBillingPurchaseLine object cannot be deleted as it does not exist");
        }

    }
}
