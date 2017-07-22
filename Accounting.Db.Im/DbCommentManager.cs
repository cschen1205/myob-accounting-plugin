using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbCommentManager : CommentManager
    {
        public DbCommentManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //Comments()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CommentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["Comment"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*         
             * */

            TableCommands["Comments"] = DbMgr.CreateTableCommand("Comments", fields, "CommentID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Comment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("Comments", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Comment _obj)
        {
            return DbMgr.CreateUpdateClause("Comments", GetFields(_obj), "CommentID", _obj.CommentID);
        }

        protected override OpResult _Store(Comment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Comment object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CommentID == null)
            {
                _obj.CommentID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
