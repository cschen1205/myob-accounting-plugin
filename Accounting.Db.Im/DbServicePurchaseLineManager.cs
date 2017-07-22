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
    public class DbServicePurchaseLineManager : ServicePurchaseLineManager
    {
        public DbServicePurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ServicePurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ServicePurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["PurchaseLineID"] = "PurchaseLines(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
             * */

            TableCommands["ServicePurchaseLines"] = DbMgr.CreateTableCommand("ServicePurchaseLines", fields, "ServicePurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ServicePurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            
            return DbMgr.CreateInsertClause("ServicePurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ServicePurchaseLine _obj)
        {
            DbUpdateStatement clause = DbMgr.CreateUpdateClause();
            clause
                .UpdateColumns(GetFields(_obj))
                .From("ServicePurchaseLines")
                .Criteria
                    .IsEqual("ServicePurchaseLines", "ServicePurchaseLineID", _obj.ServicePurchaseLineID);
            return clause;
        }

        private DbDeleteStatement GetQuery_DeleteQuery(ServicePurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause
                .DeleteFrom("ServicePurchaseLines")
                .Criteria
                    .IsEqual("ServicePurchaseLines", "ServicePurchaseLineID", _obj.ServicePurchaseLineID);
            return clause;
        }

        

        protected override OpResult _Store(ServicePurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ServicePurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ServicePurchaseLineID == null)
            {
                _obj.ServicePurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(ServicePurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ServicePurchaseLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "ServicePurchaseLine object cannot be deleted as it does not exist");
        }
    }
}
