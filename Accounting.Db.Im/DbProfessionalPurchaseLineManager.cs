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
    public sealed class DbProfessionalPurchaseLineManager : ProfessionalPurchaseLineManager
    {
        public DbProfessionalPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ProfessionalPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ProfessionalPurchaseLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
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
            fields["LineDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["PurchaseLineID"] = "PurchaseLines(PurchaseLineID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";            
             * */

            TableCommands["ProfessionalPurchaseLines"] = DbMgr.CreateTableCommand("ProfessionalPurchaseLines", fields, "ProfessionalPurchaseLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(ProfessionalPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("ProfessionalPurchaseLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ProfessionalPurchaseLine _obj)
        {
            return DbMgr.CreateUpdateClause("ProfessionalPurchaseLines", GetFields(_obj), "ProfessionalPurchaseLineID", _obj.ProfessionalPurchaseLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(ProfessionalPurchaseLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("ProfessionalPurchaseLines").Criteria.IsEqual("ProfessionalPurchaseLines", "ProfessionalPurchaseLineID", _obj.ProfessionalPurchaseLineID);
            
            return clause;
        }


        protected override OpResult _Store(ProfessionalPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ProfessionalPurchaseLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ProfessionalPurchaseLineID == null)
            {
                _obj.ProfessionalPurchaseLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(ProfessionalPurchaseLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ProfessionalPurchaseLine, object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj);
        }
    }
}
