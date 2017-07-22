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
    public class DbReferralSourceManager : ReferralSourceManager
    {
        public DbReferralSourceManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ReferralSources()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ReferralSourceID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ReferralSource"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*         
             * */

            TableCommands["ReferralSources"] = DbMgr.CreateTableCommand("ReferralSources", fields, "ReferralSourceID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ReferralSource _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("ReferralSources", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ReferralSource _obj)
        {
            return DbMgr.CreateUpdateClause("ReferralSources", GetFields(_obj), "ReferralSourceID", _obj.ReferralSourceID);
        }

        

        protected override OpResult _Store(ReferralSource _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ReferralSource object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.ReferralSourceID == null)
            {
                _obj.ReferralSourceID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
