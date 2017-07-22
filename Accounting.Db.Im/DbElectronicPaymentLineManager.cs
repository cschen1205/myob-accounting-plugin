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
    public class DbElectronicPaymentLineManager : ElectronicPaymentLineManager
    {
        public DbElectronicPaymentLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ElectronicPaymentLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ElectronicPaymentLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ElectronicPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SourceID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["AmountPaid"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;

            TableCommands["ElectronicPaymentLines"] = DbMgr.CreateTableCommand("ElectronicPaymentLines", fields, "ElectronicPaymentLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ElectronicPaymentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ElectronicPaymentLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ElectronicPaymentLine _obj)
        {
            return DbMgr.CreateUpdateClause("ElectronicPaymentLines", GetFields(_obj), "ElectronicPaymentLineID", _obj.ElectronicPaymentLineID);
        }

        protected override OpResult _Store(ElectronicPaymentLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ElectronicPaymentLine object cannot be created as it is null");
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
