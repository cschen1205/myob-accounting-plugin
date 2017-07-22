using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbAddressManager : AddressManager
    {
        public DbAddressManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //Address()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AddressID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Location"] = DbManager.FIELDTYPE.INTEGER;
            fields["Street"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["StreetLine1"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["StreetLine2"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["StreetLine3"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["StreetLine4"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["City"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["State"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["Postcode"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Country"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["Phone1"] = DbManager.FIELDTYPE.VARCHAR_21;
            fields["Phone2"] = DbManager.FIELDTYPE.VARCHAR_21;
            fields["Phone3"] = DbManager.FIELDTYPE.VARCHAR_21;
            fields["Fax"] = DbManager.FIELDTYPE.VARCHAR_21;
            fields["Email"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Salutation"] = DbManager.FIELDTYPE.VARCHAR_15;
            fields["ContactName"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["WWW"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["State"] = DbManager.FIELDTYPE.VARCHAR_256;
            fields["Solutation"] = DbManager.FIELDTYPE.VARCHAR_15;
            /*
            foreignKeys["CardRecordID"]="Cards(CardRecordID)";
            //foreignKeys["CardRecordID"]="Suppliers(CardRecordID)";
            //foreignKeys["CardRecordID"]="Employees(CardRecordID)";
            //foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
             * */

            TableCommands["Address"] = DbMgr.CreateTableCommand("Address", fields, "AddressID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Address _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("Address", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Address _obj)
        {
            return DbMgr.CreateUpdateClause("Address", GetFields(_obj), "AddressID", _obj.AddressID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(Address _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("Address").Criteria.IsEqual("Address", "AddressID", _obj.AddressID);
            
            return clause;
        }

        protected override OpResult _Store(Address _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Address object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.AddressID == null)
            {
                _obj.AddressID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(Address _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            else
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Address object cannot be deleted as it does not exist");
            }
        }
    }
}
