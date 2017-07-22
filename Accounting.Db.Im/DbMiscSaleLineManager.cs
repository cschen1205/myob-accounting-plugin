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
    public class DbMiscSaleLineManager : MiscSaleLineManager
    {
        public DbMiscSaleLineManager(DbManager mgr)
            : base(mgr)
        {
          
        }


        protected override void CreateTableCommands() //MiscSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["MiscSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveAmoun"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
             * */

            TableCommands["MiscSaleLines"] = DbMgr.CreateTableCommand("MiscSaleLines", fields, "MiscSaleLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(MiscSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("MiscSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MiscSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("MiscSaleLines", GetFields(_obj), "MiscSaleLineID", _obj.MiscSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(MiscSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("MiscSaleLines").Criteria.IsEqual("MiscSaleLines", "MiscSaleLineID", _obj.MiscSaleLineID);
            
            return clause;
        }

        protected override OpResult _Store(MiscSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MiscSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.MiscSaleLineID == null)
            {
                _obj.MiscSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(MiscSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MiscSaleLine object cannot be deleted as it is null");
            }
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "MiscSaleLine object cannot be deleted as it does not exist");
        }
    }
}
