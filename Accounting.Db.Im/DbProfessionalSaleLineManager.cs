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
    public sealed class DbProfessionalSaleLineManager : ProfessionalSaleLineManager
    {
        public DbProfessionalSaleLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //ProfessionalSaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ProfessionalSaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LineDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["SaleLineID"] = "SaleLines(SaleLineID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
             * */

            TableCommands["ProfessionalSaleLines"] = DbMgr.CreateTableCommand("ProfessionalSaleLines", fields, "ProfessionalSaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ProfessionalSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("ProfessionalSaleLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ProfessionalSaleLine _obj)
        {
            return DbMgr.CreateUpdateClause("ProfessionalSaleLines", GetFields(_obj), "ProfessionalSaleLineID", _obj.ProfessionalSaleLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(ProfessionalSaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("ProfessionalSaleLines").Criteria.IsEqual("ProfessionalSaleLines", "ProfessionalSaleLineID", _obj.ProfessionalSaleLineID);
            
            return clause;
        }

        

        protected override OpResult _Store(ProfessionalSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ProfessionalSaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ProfessionalSaleLineID == null)
            {
                _obj.ProfessionalSaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(ProfessionalSaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ProfessionalSaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "ProfessionalSaleLine object cannot be deleted as it does not exist");
        }

    }
}
