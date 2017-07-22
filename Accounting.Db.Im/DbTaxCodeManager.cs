using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.TaxCodes;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbTaxCodeManager : TaxCodeManager
    {
        protected override void CreateTableCommands() //TaxCodes()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["TaxCode"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["TaxCodeDescription"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["TaxPercentageRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxCodeTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["TaxCollectedAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxPaidAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LinkedCardID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["TaxCodeTypeID"] = "TaxCodeConsolidations(TaxCodeTypeID)";
            foreignKeys["TaxCollectedAccountID"] = "Accounts(TaxCollectedAccountID)";
            foreignKeys["TaxPaidAccountID"] = "Accounts(TaxPaidAccountID)";
            foreignKeys["LinkedCardID"] = "Cards(LinkedCardID)";
        
             * */

            TableCommands["TaxCodes"] = DbMgr.CreateTableCommand("TaxCodes", fields, "TaxCodeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(TaxCode _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TaxCodes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TaxCode _obj)
        {
            return DbMgr.CreateUpdateClause("TaxCodes", GetFields(_obj), "TaxCodeID", _obj.TaxCodeID);
        }

        protected override OpResult _Store(TaxCode _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TaxCode object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.TaxCodeID == null)
            {
                _obj.TaxCodeID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        public DbTaxCodeManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
