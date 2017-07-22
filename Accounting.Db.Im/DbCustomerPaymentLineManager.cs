using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbCustomerPaymentLineManager : CustomerPaymentLineManager
    {
        public DbCustomerPaymentLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //CustomerPaymentLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerPaymentLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomerPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountApplied"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsDepositPayment"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["CustomerPaymentID"] = "CustomerPayments(CustomerPaymentID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
             * */

            TableCommands["CustomerPaymentLines"] = DbMgr.CreateTableCommand("CustomerPaymentLines", fields, "CustomerPaymentLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CustomerPaymentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CustomerPaymentLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomerPaymentLine _obj)
        {
            return DbMgr.CreateUpdateClause("CustomerPaymentLines", GetFields(_obj), "CustomerPaymentLineID", _obj.CustomerPaymentLineID);
        }

       

        protected override OpResult _Store(CustomerPaymentLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CustomerPaymentLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CustomerPaymentLineID == null)
            {
                _obj.CustomerPaymentLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
