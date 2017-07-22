using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.TaxCodes;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbTaxCodeConsolidationManager : TaxCodeConsolidationManager
    {
        public DbTaxCodeConsolidationManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //TaxCodeConsolidations()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxCodeConsolidationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ConsolidatedTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ElementTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["ConsolidatedTaxCodeID"] = "TaxCodes(ConsolidatedTaxCodeID)";
            foreignKeys["ElementTaxCodeID"] = "TaxCodes(ElementTaxCodeID)";        
             * */

            TableCommands["TaxCodeConsolidations"] = DbMgr.CreateTableCommand("TaxCodeConsolidations", fields, "TaxCodeConsolidationID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(TaxCodeConsolidation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TaxCodeConsolidations", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TaxCodeConsolidation _obj)
        {
            return DbMgr.CreateUpdateClause("TaxCodeConsolidations", GetFields(_obj), "TaxCodeConsolidationID", _obj.TaxCodeConsolidationID);
        }

        protected override OpResult _Store(TaxCodeConsolidation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TaxCodeConsolidation object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
