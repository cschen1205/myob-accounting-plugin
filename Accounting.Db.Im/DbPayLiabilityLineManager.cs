using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Transactions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbPayLiabilityLineManager : PayLiabilityLineManager
    {
        public DbPayLiabilityLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //PayLiabilityLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PayLiabilityLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayLiabilitiesID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SourceLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["SuperannuationFundID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountPaid"] = DbManager.FIELDTYPE.DOUBLE;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;

            TableCommands["PayLiabilityLines"] = DbMgr.CreateTableCommand("PayLiabilityLines", fields, "PayLiabilityLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PayLiabilityLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PayLiabilityLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PayLiabilityLine _obj)
        {
            return DbMgr.CreateUpdateClause("PayLiabilityLines", GetFields(_obj), "PayLiabilityLineID", _obj.PayLiabilityLineID);
        }

        protected override OpResult _Store(PayLiabilityLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PayLiabilityLine object cannot be created as it is null");
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
