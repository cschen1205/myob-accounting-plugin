using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class PayBasisManager : EntityManager<PayBasis>
    {
        public PayBasisManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PayBasis _CreateDbEntity()
        {
            return new PayBasis(true, this);
        }
        protected override PayBasis _CreateEntity()
        {
            return new PayBasis(false, this);
        }
        #endregion

        protected override void LoadFromReader(PayBasis _obj, DbDataReader reader)
        {
            _obj.PayBasisID = GetString(reader, "PayBasisID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PayBasis _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["PayBasisID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.PayBasisID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("PayBasis");
        }

        private DbSelectStatement GetQuery_SelectByPayBasisID(string PayBasisID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("PayBasis")
                .Criteria
                    .IsEqual("PayBasis", "PayBasisID", PayBasisID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPayBasisID(string PayBasisID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("PayBasis")
                .Criteria
                    .IsEqual("PayBasis", "PayBasisID", PayBasisID);

            return clause;
        }

        public bool Exists(string PayBasisID)
        {
            if (PayBasisID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPayBasisID(PayBasisID)) != 0;
        }

        public override bool Exists(PayBasis _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PayBasisID);
        }

        protected override PayBasis _FindByTextId(string PayBasisID)
        {
            PayBasis _obj = null;
            if (PayBasisID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPayBasisID(PayBasisID));
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

        protected override IList<PayBasis>_FindAllCollection()
        {
            List<PayBasis> _grp = new List<PayBasis>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PayBasis _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
