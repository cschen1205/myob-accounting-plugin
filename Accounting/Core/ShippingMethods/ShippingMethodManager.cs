using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.ShippingMethods
{
    public abstract class ShippingMethodManager : EntityManager<ShippingMethod>
    {
        public ShippingMethodManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region ShippingMethod factory methods
        protected override ShippingMethod _CreateDbEntity()
        {
            return new ShippingMethod(true, this);
        }

        protected override ShippingMethod _CreateEntity()
        {
            return new ShippingMethod(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(ShippingMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ShippingMethodID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ShippingMethodID);
            fields["ShippingMethod"] = DbMgr.CreateStringFieldEntry(_obj.Method);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ShippingMethods");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByShippingMethodID(int ShippingMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ShippingMethods")
                .Criteria
                    .IsEqual("ShippingMethods", "ShippingMethodID", ShippingMethodID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByShippingMethodID(int ShippingMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ShippingMethods")
                .Criteria
                    .IsEqual("ShippingMethods", "ShippingMethodID", ShippingMethodID);

            return clause;
        }

        private bool Exists(int? ShipppingMethodID)
        {
            if (ShipppingMethodID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByShippingMethodID(ShipppingMethodID.Value)) != 0;
        }

        public override bool Exists(ShippingMethod _obj)
        {
            return Exists(_obj.ShippingMethodID);
        }

        protected override void LoadFromReader(ShippingMethod _obj, DbDataReader reader)
        {
            _obj.ShippingMethodID =GetInt32(reader, ("ShippingMethodID"));
            _obj.Method =GetString(reader, ("ShippingMethod"));
        }

        protected override ShippingMethod _FindByIntId(int? ShippingMethodID)
        {
            if (Exists(ShippingMethodID))
            {
                ShippingMethod _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByShippingMethodID(ShippingMethodID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<ShippingMethod>_FindAllCollection()
        {
            List<ShippingMethod> _purchases = new List<ShippingMethod>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ShippingMethod _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _purchases.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _purchases;
        }
    }
}
