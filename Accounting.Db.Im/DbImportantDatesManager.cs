using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbImportantDatesManager : ImportantDatesManager
    {
        public DbImportantDatesManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ImportantDates()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ImportantDatesID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CalendarYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["JanuaryDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["FebruaryDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["MarchDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AprilDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["MayDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["JuneDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["JulyDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AugustDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["SeptemberDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["OctoberDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["NovemberDetails"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["DecemberDetails"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["ImportantDates"] = DbMgr.CreateTableCommand("ImportantDates", fields, "ImportantDatesID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ImportantDates _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ImportantDates", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ImportantDates _obj)
        {
            return DbMgr.CreateUpdateClause("ImportantDates", GetFields(_obj), "ImportantDatesID", _obj.ImportantDatesID);
        }

        protected override OpResult _Store(ImportantDates _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ImportantDates object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ImportantDatesID == null)
            {
                _obj.ImportantDatesID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
