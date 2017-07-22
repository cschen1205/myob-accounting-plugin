using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Terms
{
    public abstract class TermsOfPaymentManager : EntityManager<TermsOfPayment>
    {
        public TermsOfPaymentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TermsOfPayment _CreateDbEntity()
        {
            return new TermsOfPayment(true, this);
        }

        protected override TermsOfPayment _CreateEntity()
        {
            return new TermsOfPayment(false, this);
        }
        #endregion


        public override Dictionary<string, DbFieldEntry> GetFields(TermsOfPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["TermsOfPaymentID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.TermsOfPaymentID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectByTermsOfPaymentID(string TermsOfPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TermsOfPayment")
                .Criteria
                    .IsEqual("TermsOfPayment", "TermsOfPaymentID", TermsOfPaymentID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTermsOfPaymentID(string TermsOfPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("TermsOfPayment")
                .Criteria
                    .IsEqual("TermsOfPayment", "TermsOfPaymentID", TermsOfPaymentID);

            return clause;
        }

        public bool Exists(string TermsOfPaymentID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByTermsOfPaymentID(TermsOfPaymentID)) != 0;
        }

        public override bool Exists(TermsOfPayment _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByTermsOfPaymentID(_obj.TermsOfPaymentID)) != 0;
        }

        protected override void LoadFromReader(TermsOfPayment _obj, DbDataReader _reader)
        {
            _obj.TermsOfPaymentID =GetString(_reader, ("TermsOfPaymentID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        protected override IList<TermsOfPayment>_FindAllCollection()
        {
            List<TermsOfPayment> _grp = new List<TermsOfPayment>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TermsOfPayment");
            
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TermsOfPayment _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override TermsOfPayment _FindByTextId(string TermsOfPaymentID)
        {
            if (Exists(TermsOfPaymentID))
            {
                TermsOfPayment _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTermsOfPaymentID(TermsOfPaymentID));
                return _obj;
            }
            else
            {
                return null;
            }
        }
    }
}
