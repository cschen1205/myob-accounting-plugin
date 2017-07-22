using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Core.Cards;

namespace Accounting.Db.Im
{
    public class DbContactLogManager : ContactLogManager
    {
        public DbContactLogManager(DbManager mgr)
            : base(mgr)
        {

        }


        protected override void CreateTableCommands() //ContactLog()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ContactLogID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Contact"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["LogDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["Notes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ElapsedTime"] = DbManager.FIELDTYPE.VARCHAR_6;
            fields["RecontactDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_10;

            /*
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            //foreignKeys["CardRecordID"] = "Customers(CardRecordID)";
            //foreignKeys["CardRecordID"] = "Employees(CardRecordID)";
            //foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
            //foreignKeys["CardRecordID"] = "Suppliers(CardRecordID)";
             * */


            TableCommands["ContactLog"] = DbMgr.CreateTableCommand("ContactLog", fields, "ContactLogID", foreignKeys);


        }
    }
}
