using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class PaymentValueTypeManager : EntityManager<PaymentValueType>
    {
        public PaymentValueTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PaymentValueType _CreateDbEntity()
        {
            return new PaymentValueType(true, this);
        }
        protected override PaymentValueType _CreateEntity()
        {
            return new PaymentValueType(false, this);
        }
        #endregion

        protected override void LoadFromReader(PaymentValueType _obj, DbDataReader reader)
        {
            _obj.ValueTypeID = GetString(reader, "ValueTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PaymentValueType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ValueTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.ValueTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ValueTypes");
        }

        private DbSelectStatement GetQuery_SelectByValueTypeID(string ValueTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ValueTypes")
                .Criteria
                    .IsEqual("ValueTypes", "ValueTypeID", ValueTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByValueTypeID(string ValueTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ValueTypes")
                .Criteria
                    .IsEqual("ValueTypes", "ValueTypeID", ValueTypeID);

            return clause;
        }

        public bool Exists(string ValueTypeID)
        {
            if (ValueTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByValueTypeID(ValueTypeID)) != 0;
        }

        public override bool Exists(PaymentValueType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ValueTypeID);
        }

        protected override PaymentValueType _FindByTextId(string ValueTypeID)
        {
            PaymentValueType _obj = null;
            if (ValueTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByValueTypeID(ValueTypeID));
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

        protected override IList<PaymentValueType>_FindAllCollection()
        {
            List<PaymentValueType> _grp = new List<PaymentValueType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PaymentValueType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
