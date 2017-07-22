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
    public sealed class DbSaleLineManager : SaleLineManager
    {
        public DbSaleLineManager(DbManager mgr)
            : base(mgr)
        {


        }
            

        protected override void CreateTableCommands() //SaleLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SaleLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxBasisAmountIsInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["LineTypeID"] = "LineType(LineTypeID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";
            */

            TableCommands["SaleLines"] = DbMgr.CreateTableCommand("SaleLines", fields, "SaleLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause
                .InsertColumns(fields)
                .Into("SaleLines");

            return clause;
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SaleLine _obj)
        {
            DbUpdateStatement clause = DbMgr.CreateUpdateClause();
            clause
                .UpdateColumns(GetFields(_obj))
                .From("SaleLines")
                .Criteria
                    .IsEqual("SaleLines", "SaleLineID", _obj.SaleLineID);
            return clause;
        }

        private DbDeleteStatement GetQuery_DeleteQuery(SaleLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause
                .DeleteFrom("SaleLines")
                .Criteria
                    .IsEqual("SaleLines", "SaleLineID", _obj.SaleLineID);
            return clause;
        }

       

        protected override OpResult _Store(SaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SaleLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SaleLineID == null)
            {
                _obj.SaleLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(SaleLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SaleLine object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "SaleLine object cannot be deleted as it does not exist"); ;
        }
    }
}
