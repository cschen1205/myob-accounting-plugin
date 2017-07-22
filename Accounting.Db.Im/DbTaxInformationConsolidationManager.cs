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
    public class DbTaxInformationConsolidationManager : TaxInformationConsolidationManager
    {
        public DbTaxInformationConsolidationManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //TaxInformationConsolidations()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxInformationConsolidationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ConsolidationTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ElementTaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["TransactionID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ElementTaxableAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ElementTaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ElementTaxAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ElementTaxableAmountAUS"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ElementTaxBasisAmountAUS"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ElementTaxAmountAUS"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ConsolidationTaxCodeID"] = "TaxCodes(ConsolidationTaxCodeID)";
            foreignKeys["ElementTaxCodeID"] = "TaxCodes(ElementTaxCodeID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
            foreignKeys["TransactionID"] = "GeneralJournals(TransactionID)";           
             * */

            TableCommands["TaxInformationConsolidations"] = DbMgr.CreateTableCommand("TaxInformationConsolidations", fields, "TaxInformationConsolidationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(TaxInformationConsolidation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TaxInformationConsolidations", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TaxInformationConsolidation _obj)
        {
            return DbMgr.CreateUpdateClause("TaxInformationConsolidations", GetFields(_obj), "TaxInformationConsolidationID", _obj.TaxInformationConsolidationID);
        }

        protected override OpResult _Store(TaxInformationConsolidation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TaxInformationConsolidation object cannot be created as it is null");
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
