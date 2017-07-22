using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.JournalRecords;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbJournalSetManager : JournalSetManager
    {
        public DbJournalSetManager(DbManager mgr)
            : base(mgr)
        {


        }
            
        protected override void CreateTableCommands() //JournalSets()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["SetID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["SourceID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["JournalTypeID"] = "JournalTypes";
            foreignKeys["SourceID"] = "GeneralJournals(SourceID)";
            foreignKeys["SourceID"] = "MoneySpent(SourceID)";
            foreignKeys["SourceID"] = "MoneyReceived(SourceID)";
            foreignKeys["SourceID"] = "BankDeposits(SourceID)";
            foreignKeys["SourceID"] = "Sales(SourceID)";
            foreignKeys["SourceID"] = "CustomerPayments(SourceID)";
            foreignKeys["SourceID"] = "CustomerFinanceCharges(SourceID)";
            foreignKeys["SourceID"] = "CustomerDiscounts(SourceID)";
            foreignKeys["SourceID"] = "CustomerDeposits(SourceID)";
            foreignKeys["SourceID"] = "SettledCredits(SourceID)";
            foreignKeys["SourceID"] = "CreditRefunds(SourceID)";
            foreignKeys["SourceID"] = "Purchases(SourceID)";
            foreignKeys["SourceID"] = "SupplierPayments(SourceID)";
            foreignKeys["SourceID"] = "SupplierFinanceCharges(SourceID)";
            foreignKeys["SourceID"] = "SupplierDiscounts(SourceID)";
            foreignKeys["SourceID"] = "SupplierDeposits(SourceID)";
            foreignKeys["SourceID"] = "SettledDebits(SourceID)";
            foreignKeys["SourceID"] = "DebitRefunds(SourceID)";
            foreignKeys["SourceID"] = "InventoryAdjustments(SourceID)";
            foreignKeys["SourceID"] = "InventoryTransfers(SourceID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            TableCommands["JournalSets"] = DbMgr.CreateTableCommand("JournalSets", fields, "SetID", foreignKeys);
        }

        public JournalSource GetJournalSource(JournalSet jset)
        {
            string type=jset.JournalTypeID;
            if (type == "GJ")
            {
                return RepositoryMgr.GeneralJournalMgr.FindById(jset.SourceID);
            }
            else if(type=="PO")
            {
                return RepositoryMgr.PurchaseMgr.FindById(jset.SourceID);
            }
            else if (type == "SI")
            {
                return RepositoryMgr.SaleMgr.FindById(jset.SourceID);
            }
            return null;
        }

        private DbInsertStatement GetQuery_InsertQuery(JournalSet _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("JournalSets", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JournalSet _obj)
        {
            return DbMgr.CreateUpdateClause("JournalSets", GetFields(_obj), "SetID", _obj.SetID);
        }

        protected override OpResult _Store(JournalSet _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JournalSet object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SetID == null)
            {
                _obj.SetID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
