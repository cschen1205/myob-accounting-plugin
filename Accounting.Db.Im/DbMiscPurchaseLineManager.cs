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
    public class DbMiscPurchaseLineManager : MiscPurchaseLineManager
    {
        public DbMiscPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //MiscPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["MiscPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["PurchaseLineID"] = "PurchaseLines(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";            
             * */

            TableCommands["MiscPurchaseLines"] = DbMgr.CreateTableCommand("MiscPurchaseLines", fields, "MiscPurchaseLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(MiscPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("MiscPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MiscPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("MiscPurchaseLines", GetFields(_obj), "MiscPurchaseLineID", _obj.MiscPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(MiscPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("MiscPurchaseLines").Criteria.IsEqual("MiscPurchaseLines", "MiscPurchaseLineID", _obj.MiscPurchaseLineID);
            
            return clause;
        }

        protected override OpResult _Store(MiscPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MiscPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.MiscPurchaseLineID == null)
            {
                _obj.MiscPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(MiscPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MiscPurchaseLine object cannot be deleted as it is null");
            }
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "MiscPurchaseLine object cannot be deleted as it does not exist");
        }

    }
}
