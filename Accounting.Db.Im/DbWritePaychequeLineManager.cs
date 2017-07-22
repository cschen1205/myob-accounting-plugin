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
    public class DbWritePaychequeLineManager : WritePaychequeLineManager
    {
        public DbWritePaychequeLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //WritePaychequeLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["WritePaychequeLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["WritePaychequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["Hours"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["HasActivitySlip"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;


            TableCommands["WritePaychequeLines"] = DbMgr.CreateTableCommand("WritePaychequeLines", fields, "WritePaychequeLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(WritePaychequeLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("WritePaychequeLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(WritePaychequeLine _obj)
        {
            return DbMgr.CreateUpdateClause("WritePaychequeLines", GetFields(_obj), "WritePaychequeLineID", _obj.WritePaychequeLineID);
        }

        protected override OpResult _Store(WritePaychequeLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "WritePaychequeLine object cannot be created as it is null");
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
