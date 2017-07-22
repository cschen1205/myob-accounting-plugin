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
    public sealed class DbServiceSaleLineManager : ServiceSaleLineManager
    {
        public DbServiceSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ServiceSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ServiceSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["SaleLineID"]="SaleLines(SaleLineID)";
            foreignKeys["SaleID"]="Sales(SaleID)";
            foreignKeys["LineTypeID"]="LineType(LineTypeID)";
            foreignKeys["AccountID"]="Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
             * */


            TableCommands["ServiceSaleLines"] = DbMgr.CreateTableCommand("ServiceSaleLines", fields, "ServiceSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ServiceSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("ServiceSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ServiceSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("ServiceSaleLines", GetFields(_obj), "ServiceSaleLineID", _obj.ServiceSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(ServiceSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("ServiceSaleLines").Criteria.IsEqual("ServiceSaleLines", "ServiceSaleLineID", _obj.ServiceSaleLineID);
            
            return clause;
        }

        
        protected override OpResult _Store(ServiceSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ServiceSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.ServiceSaleLineID == null)
            {
                _obj.ServiceSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(ServiceSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ServiceSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "ServiceSaleLine object cannot be deleted as it does not exist"); ;
        }

    }
}
