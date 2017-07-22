using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data.Common;

namespace Accounting.Core.Misc
{
    public abstract class PaymentMethodManager : EntityManager<PaymentMethod>
    {
        public PaymentMethodManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override PaymentMethod _CreateDbEntity()
        {
            return new PaymentMethod(true, this);
        }

        protected override PaymentMethod _CreateEntity()
        {
            return new PaymentMethod(false, this);
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PaymentMethods");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByPaymentMethodID(int PaymentMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PaymentMethods")
                .Criteria
                    .IsEqual("PaymentMethods", "PaymentMethodID", PaymentMethodID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPaymentMethodID(int PaymentMethodID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("PaymentMethods")
                .Criteria
                    .IsEqual("PaymentMethods", "PaymentMethodID", PaymentMethodID);

            return clause;
        }

        private bool Exists(int? PaymentMethodID)
        {
            if (PaymentMethodID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPaymentMethodID(PaymentMethodID.Value)) != 0;
        }

        public override bool Exists(PaymentMethod _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByPaymentMethodID(_obj.PaymentMethodID.Value)) != 0;
        }

        protected override IList<PaymentMethod>_FindAllCollection()
        {
            List<PaymentMethod> methods = new List<PaymentMethod>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                PaymentMethod _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                methods.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return methods;
        }


        protected override PaymentMethod _FindByIntId(int? PaymentMethodID)
        {
            if (Exists(PaymentMethodID))
            {
                PaymentMethod _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByPaymentMethodID(PaymentMethodID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(PaymentMethod _obj, DbDataReader reader)
        {
            _obj.PaymentMethodID = GetInt32(reader, ("PaymentMethodID"));
            _obj.Description = GetString(reader, ("PaymentMethod"));
            _obj.MethodType = GetString(reader, ("MethodType"));
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PaymentMethod _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["PaymentMethodID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PaymentMethodID);
            fields["PaymentMethod"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["MethodType"] = DbMgr.CreateStringFieldEntry(_obj.MethodType);
            return fields;
        }

    }
}
