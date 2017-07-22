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
    public sealed class DbSupplierPaymentLineManager : SupplierPaymentLineManager
    {
        public DbSupplierPaymentLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //SupplierPaymentLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierPaymentLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SupplierPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountApplied"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsDepositPayment"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["SupplierPaymentID"] = "SupplierPayments(SupplierPaymentID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            TableCommands["SupplierPaymentLines"] = DbMgr.CreateTableCommand("SupplierPaymentLines", fields, "SupplierPaymentLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SupplierPaymentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SupplierPaymentLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SupplierPaymentLine _obj)
        {
            return DbMgr.CreateUpdateClause("SupplierPaymentLines", GetFields(_obj), "SupplierPaymentLineID", _obj.SupplierPaymentLineID);
        }

       

        protected override OpResult _Store(SupplierPaymentLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SupplierPaymentLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SupplierPaymentLineID == null)
            {
                _obj.SupplierPaymentLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
