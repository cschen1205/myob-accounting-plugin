using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using Accounting.Core;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbPersonalCardManager : PersonalCardManager
    {
        public DbPersonalCardManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        private DbInsertStatement GetQuery_InsertQuery(PersonalCard _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("PersonalCards", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PersonalCard _obj)
        {
            return DbMgr.CreateUpdateClause("PersonalCards", GetFields(_obj), "PersonalCardID", _obj.PersonalCardID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(PersonalCard _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("PersonalCards").Criteria.IsEqual("PersonalCards", "PersonalCardID", _obj.PersonalCardID);
            
            return clause;
        }

       

        protected override OpResult _Store(PersonalCard _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PersonalCard object cannot be created as it is null");
            }

            RepositoryMgr.CardMgr.Store(_obj);
            _obj.PersonalCardID = _obj.CardRecordID;

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.PersonalCardID == null)
            {
                _obj.PersonalCardID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(PersonalCard _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PersonalCard object cannot be deleted as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));

                RepositoryMgr.CardMgr.Delete(_obj);

                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "PersonalCard object cannot be deleted as it does not exist") ;
        }
    }
}
