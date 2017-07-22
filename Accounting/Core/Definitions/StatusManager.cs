using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class StatusManager : EntityManager<Status>
    {
        public StatusManager(DbManager mgr)
            : base(mgr)
        {
        }
        #region Status factory methods
        protected override Status _CreateDbEntity()
        {
            return new Status(true, this);
        }

        protected override Status _CreateEntity()
        {
            return new Status(false, this);
        }
        #endregion

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Status");

            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Status _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectByStatusID(string StatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Status")
                .Criteria.IsEqual("Status", "StatusID", StatusID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByStatusID(string StatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("Status")
                .Criteria.IsEqual("Status", "StatusID", StatusID);

            return clause;
        }       

        public bool Exists(string StatusID)
        {
            if (StatusID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByStatusID(StatusID)) != 0;
        }

        public override bool Exists(Status _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByStatusID(_obj.StatusID)) != 0;
        }

        protected override void LoadFromReader(Status _obj, DbDataReader _reader)
        {
            _obj.StatusID =GetString(_reader, ("StatusID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        public Status Status_Order
        {
            get { return FindById("OR"); }
        }

        public Status Status_Quote
        {
            get { return FindById("Q"); }
        }

        public Status Status_Open
        {
            get { return FindById("O"); }
        }

        public Status Status_Closed
        {
            get { return FindById("C"); }
        }

        public Status Status_DebitReturn
        {
            get { return FindById("DR"); }
        }

        public Status Status_CreditReturn
        {
            get { return FindById("CR"); }
        }

        protected override Status _FindByTextId(string StatusID)
        {
            if (Exists(StatusID))
            {
                Status _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByStatusID(StatusID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public Status FindByStatusType(Status.StatusType status)
        {
            return FindById(Status.StatusType2ID(status));
        }

        protected override IList<Status>_FindAllCollection()
        {
            List<Status> _grp = new List<Status>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Status _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public List<Status> List(DbCriteria criteria)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Status")
                .Criteria.And(criteria);

            List<Status> result = new List<Status>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Status _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                result.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return result ;
        }

        public IList<Status> FindSaleStatusCollection()
        {
            return _FindSaleStatusCollection();
        }

        protected virtual IList<Status> _FindSaleStatusCollection()
        {
            DbCriteria criteria = DbMgr.CreateCriteria();
            criteria
                .IsEqual("Status", "StatusID", "O", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "C", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "OR", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "CR", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "Q", DbCriteria.ConcatMode.OR);
            return List(criteria);
        }

        public List<Status> ListPurchaseStatus()
        {
            DbCriteria criteria = DbMgr.CreateCriteria();
            criteria
                .IsEqual("Status", "StatusID", "O", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "C", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "OR", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "DR", DbCriteria.ConcatMode.OR)
                .IsEqual("Status", "StatusID", "Q", DbCriteria.ConcatMode.OR);
            return List(criteria);
        }

        public List<Status> ListOrderStatus()
        {
            List<Status> result = new List<Status>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("OrderStatus");

            
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Status _obj = CreateDbEntity();
                _obj.StatusID =GetString(_reader, ("OrderStatusID"));
                _obj.Description =GetString(_reader, ("Description"));
                result.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return result;
        }
    }
}
