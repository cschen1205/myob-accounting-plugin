using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class PaymentTypeManager : EntityManager<PaymentType>
    {
        public PaymentTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PaymentType _CreateDbEntity()
        {
            return new PaymentType(true, this);
        }
        protected override PaymentType _CreateEntity()
        {
            return new PaymentType(false, this);
        }
        #endregion

        protected override void LoadFromReader(PaymentType _obj, DbDataReader reader)
        {
            _obj.PaymentTypeID = GetString(reader, "PaymentTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PaymentType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["PaymentTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.PaymentTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("PaymentTypes");
        }

        private DbSelectStatement GetQuery_SelectByPaymentTypeID(string PaymentTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("PaymentTypes")
                .Criteria
                    .IsEqual("PaymentTypes", "PaymentTypeID", PaymentTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPaymentTypeID(string PaymentTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("PaymentTypes")
                .Criteria
                    .IsEqual("PaymentTypes", "PaymentTypeID", PaymentTypeID);

            return clause;
        }

        public bool Exists(string PaymentTypeID)
        {
            if (PaymentTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPaymentTypeID(PaymentTypeID)) != 0;
        }

        public override bool Exists(PaymentType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PaymentTypeID);
        }

        protected override PaymentType _FindByTextId(string PaymentTypeID)
        {
            PaymentType _obj = null;
            if (PaymentTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPaymentTypeID(PaymentTypeID));
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override IList<PaymentType>_FindAllCollection()
        {
            List<PaymentType> _grp = new List<PaymentType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PaymentType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
