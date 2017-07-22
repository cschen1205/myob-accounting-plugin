using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using Accounting.Core;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbCardManager : CardManager
    {
        public DbCardManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CardIdentification"] = DbManager.FIELDTYPE.VARCHAR_16;
            fields["Name"] = DbManager.FIELDTYPE.VARCHAR_52;
            fields["LastName"] = DbManager.FIELDTYPE.VARCHAR_52;
            fields["FirstName"] = DbManager.FIELDTYPE.VARCHAR_20;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["IsIndividual"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IdentifierID"] = DbManager.FIELDTYPE.VARCHAR_26;
            fields["CustomList1ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList2ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomList3ID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CustomField1"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField2"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CustomField3"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["CardTypeID"] = "CardTypes(CardTypeID)";
            foreignKeys["CurrencyID"]="Currency(CurrencyID)";
            foreignKeys["IdentifierID"]="Identifiers(IdentifierID)";
            foreignKeys["CustomList1ID"]="CustomLists(CustomList1ID)";
            foreignKeys["CustomList2ID"]="CustomLists(CustomList2ID)";
            foreignKeys["CustomList3ID"] = "CustomLists(CustomList3ID)";
            foreignKeys["PaymentDeliveryID"]="InvoiceDelivery(PaymentDeliveryID)";
             * */

            TableCommands["Cards"] = DbMgr.CreateTableCommand("Cards", fields, "CardRecordID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Card _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Cards", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Card _obj)
        {
            return DbMgr.CreateUpdateClause("Cards", GetFields(_obj), "CardRecordID", _obj.CardRecordID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(Card _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Cards").Criteria.IsEqual("Cards", "CardRecordID", _obj.CardRecordID);
            
            return clause;
        }

        protected override OpResult _Store(Card _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Card object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                if (RepositoryMgr.State == RepositoryManager.MgrState.Normal)
                {
                    RepositoryMgr.AddressMgr.Store(_obj.Address1);
                    RepositoryMgr.AddressMgr.Store(_obj.Address2);
                    RepositoryMgr.AddressMgr.Store(_obj.Address3);
                    RepositoryMgr.AddressMgr.Store(_obj.Address4);
                    RepositoryMgr.AddressMgr.Store(_obj.Address5);
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CardRecordID == null)
            {
                _obj.CardRecordID = DbMgr.GetLastInsertID();
            }

            if (RepositoryMgr.State == RepositoryManager.MgrState.Normal)
            {
                RepositoryMgr.AddressMgr.Store(_obj.Address1);
                RepositoryMgr.AddressMgr.Store(_obj.Address2);
                RepositoryMgr.AddressMgr.Store(_obj.Address3);
                RepositoryMgr.AddressMgr.Store(_obj.Address4);
                RepositoryMgr.AddressMgr.Store(_obj.Address5);
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        

        protected override OpResult _Delete(Card _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Card object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                RepositoryMgr.AddressMgr.Delete(_obj.Address1);
                RepositoryMgr.AddressMgr.Delete(_obj.Address2);
                RepositoryMgr.AddressMgr.Delete(_obj.Address3);
                RepositoryMgr.AddressMgr.Delete(_obj.Address4);
                RepositoryMgr.AddressMgr.Delete(_obj.Address5);

                CardType.TypeID type = CardType.GetTypeID(_obj.CardTypeID);
                if (type == CardType.TypeID.Customer)
                {
                    RepositoryMgr.CustomerMgr.Delete((Customer)_obj);
                }
                else if (type == CardType.TypeID.Employee)
                {
                    RepositoryMgr.EmployeeMgr.Delete((Employee)_obj);
                }
                else if (type == CardType.TypeID.Supplier)
                {
                    RepositoryMgr.SupplierMgr.Delete((Supplier)_obj);
                }
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            else
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Card object cannot be deleted as it does not exist");
            }
        }
    }
}
