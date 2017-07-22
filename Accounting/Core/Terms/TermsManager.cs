using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Terms
{
    public abstract class TermsManager : EntityManager<Terms>
    {
        public TermsManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Terms _CreateDbEntity()
        {
            return new Terms(true, this);
        }

        protected override Terms _CreateEntity()
        {
            return new Terms(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Terms _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["TermsID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TermsID);
            fields["TermsOfPaymentID"] = DbMgr.CreateStringFieldEntry(_obj.TermsOfPaymentID);
            fields["BalanceDueDays"] = DbMgr.CreateIntFieldEntry(_obj.BalanceDueDays);
            fields["DiscountDate"] = DbMgr.CreateStringFieldEntry(_obj.DiscountDate);
            fields["EarlyPaymentDiscountPercent"] = DbMgr.CreateDoubleFieldEntry(_obj.EarlyPaymentDiscountPercent);
            fields["DiscountDays"] = DbMgr.CreateIntFieldEntry(_obj.DiscountDays);
            fields["BalanceDueDate"] = DbMgr.CreateStringFieldEntry(_obj.BalanceDueDate);
            fields["LatePaymentChargePercent"] = DbMgr.CreateDoubleFieldEntry(_obj.LatePaymentChargePercent);
            fields["ImportPaymentIsDue"] = DbMgr.CreateIntFieldEntry(_obj.ImportPaymentIsDue);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Terms");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTermsID(int TermsID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Terms")
                .Criteria
                    .IsEqual("Terms", "TermsID", TermsID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTermsID(int TermsID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Terms")
                .Criteria
                    .IsEqual("Terms", "TermsID", TermsID);

            return clause;
        }

        public bool Exists(int? TermsID)
        {
            if (TermsID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTermsID(TermsID.Value)) != 0;
        }

        public override bool Exists(Terms _obj)
        {
            return Exists(_obj.TermsID);
        }

        protected override void LoadFromReader(Terms _obj, DbDataReader _reader)
        {
            _obj.TermsID =GetInt32(_reader, ("TermsID"));
            _obj.TermsOfPaymentID =GetString(_reader, ("TermsOfPaymentID"));
            try
            {
                _obj.BalanceDueDays = GetInt16(_reader, ("BalanceDueDays"));
            }
            catch
            {
                _obj.BalanceDueDays =GetInt32(_reader, ("BalanceDueDays"));
            }
            _obj.EarlyPaymentDiscountPercent = GetDouble(_reader, ("EarlyPaymentDiscountPercent"));
            try
            {
                _obj.DiscountDays = GetInt16(_reader, ("DiscountDays"));
            }catch{
                _obj.DiscountDays =GetInt32(_reader, ("DiscountDays"));
            }
            _obj.DiscountDate =GetString(_reader, ("DiscountDate"));
            _obj.BalanceDueDate =GetString(_reader, ("BalanceDueDate"));
            _obj.LatePaymentChargePercent = GetDouble(_reader, ("LatePaymentChargePercent"));
            _obj.ImportPaymentIsDue =GetInt32(_reader, ("ImportPaymentIsDue"));
        }

        protected override object GetDbProperty(Terms _obj, string property_name)
        {
            if (property_name.Equals("TermsOfPayment"))
            {
                return RepositoryMgr.TermsOfPaymentMgr.FindById(_obj.TermsOfPaymentID);
            }
            return null;
        }

        protected override IList<Terms>_FindAllCollection()
        {
            List<Terms> terms = new List<Terms>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Terms _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                terms.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return terms;
        }

        protected override Terms _FindByIntId(int? TermsID)
        {
            if (Exists(TermsID))
            {
                Terms _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTermsID(TermsID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Terms", "TermsID", "ID")
                .SelectColumn("Terms", "DiscountDays", "DiscountDays")
                .SelectColumn("Terms", "BalanceDueDays", "BalanceDueDays")
                .SelectColumn("TermsOfPayment", "Description", "Description")
                .From("Terms")
                .From("TermsOfPayment");
            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Discount Days");
            table.Columns.Add("Balance Due Days");
            table.Columns.Add("Description");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Discount Days"] = GetInt32(_reader, "DiscountDays");
                row["Balance Due Days"] = GetInt32(_reader, "BalanceDueDays");
                row["Description"] = GetString(_reader, "Description");
                table.Rows.Add(row);
            }

            _reader.Close();
            _cmd.Dispose();

            return table;
        }
    }
}
