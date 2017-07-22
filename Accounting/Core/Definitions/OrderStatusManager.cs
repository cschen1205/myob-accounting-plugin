using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class OrderStatusManager : EntityManager<OrderStatus>
    {
        public OrderStatusManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override OrderStatus _CreateDbEntity()
        {
            return new OrderStatus(true, this);
        }

        protected override OrderStatus _CreateEntity()
        {
            return new OrderStatus(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(OrderStatus _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["OrderStatusID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.OrderStatusID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("OrderStatus");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByOrderStatusID(string OrderStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("OrderStatus")
                .Criteria
                    .IsEqual("OrderStatus", "OrderStatusID", OrderStatusID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByOrderStatusID(string OrderStatusID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("OrderStatus")
                .Criteria
                    .IsEqual("OrderStatus", "OrderStatusID", OrderStatusID);
            return clause;
        }

        private bool Exists(string OrderStatusID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByOrderStatusID(OrderStatusID)) != 0;
        }

        public override bool Exists(OrderStatus _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByOrderStatusID(_obj.OrderStatusID)) != 0;
        }

        protected override void LoadFromReader(OrderStatus _obj, DbDataReader reader)
        {
            _obj.OrderStatusID =GetString(reader, ("OrderStatusID"));
            _obj.Description =GetString(reader, ("Description"));
        }

        protected override OrderStatus _FindByTextId(string OrderStatusID)
        {
            if (Exists(OrderStatusID))
            {
                OrderStatus _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByOrderStatusID(OrderStatusID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<OrderStatus>_FindAllCollection()
        {
            List<OrderStatus> objs = new List<OrderStatus>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                OrderStatus _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
