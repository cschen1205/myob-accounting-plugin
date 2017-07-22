using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Db.Elements;

    public class DbItemAddOnManager : ItemAddOnManager 
    {
        public DbItemAddOnManager(DbManager mgr)
            : base(mgr)
        {
        }

        private DbInsertStatement GetQuery_InsertQuery(ItemAddOn _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ItemAddOn", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ItemAddOn _obj)
        {
            return DbMgr.CreateUpdateClause("ItemAddOn", GetFields(_obj), "ItemAddOnID", _obj.ItemAddOnID);
        }

       

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ItemAddOnID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ItemNumber"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["Color"] = DbManager.FIELDTYPE.VARCHAR_15;
            fields["Brand"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["ItemSizeID"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["BatchNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["SerialNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["GenderID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ExpiryDate"] = DbManager.FIELDTYPE.DATETIME;

            TableCommands["ItemAddOn"] = DbMgr.CreateTableCommand("ItemAddOn", fields, "ItemAddOnID", foreignKeys);
        }

        protected override OpResult _Delete(ItemAddOn _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("ItemAddOn").Criteria
                   .IsEqual("ItemAddOn", "ItemAddOnID", _obj.ItemAddOnID);

                DbMgr.ExecuteNonQuery(clause);

                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "ItemAddOn object does not exists");
        }

        protected override OpResult _Store(ItemAddOn _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemAddOn object cannot be created as it is null"); ;
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ItemAddOnID == null)
            {
                _obj.ItemAddOnID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
