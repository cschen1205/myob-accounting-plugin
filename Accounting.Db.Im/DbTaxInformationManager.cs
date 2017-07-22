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
    public class DbTaxInformationManager : TaxInformationManager
    {
        public DbTaxInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //TaxInformation()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxInformationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["TransactionID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxPercentageRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxableAmountAUS"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxableAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountAUS"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxAmountAUS"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxAmountIsChanged"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ReportTaxAsID"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
            foreignKeys["TransactionID"] = "GeneralJournals(TransactionID)";     
             * */

            TableCommands["TaxInformation"] = DbMgr.CreateTableCommand("TaxInformation", fields, "TaxInformationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(TaxInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TaxInformation", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TaxInformation _obj)
        {
            return DbMgr.CreateUpdateClause("TaxInformation", GetFields(_obj), "TaxInformationID", _obj.TaxInformationID);
        }

        protected override OpResult _Store(TaxInformation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TaxInformation object cannot be created as it is null");
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
