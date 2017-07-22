using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public class WritePaychequeLineManager : EntityManager<WritePaychequeLine>
    {
        public WritePaychequeLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override WritePaychequeLine _CreateDbEntity()
        {
            return new WritePaychequeLine(true, this);
        }
        protected override WritePaychequeLine _CreateEntity()
        {
            return new WritePaychequeLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(WritePaychequeLine _obj, DbDataReader reader)
        {
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.Amount = GetDouble(reader, "Amount");
            _obj.CategoryID = GetInt32(reader, "CategoryID");
            _obj.CategoryTypeID = GetString(reader, "CategoryTypeID");
            _obj.HasActivitySlip = GetString(reader, "HasActivitySlip");
            _obj.Hours = GetDouble(reader, "Hours");
            _obj.IsMultipleJob = GetString(reader, "IsMultipleJob");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
            _obj.WritePaychequeID = GetInt32(reader, "WritePaychequeID");
            _obj.WritePaychequeLineID = GetInt32(reader, "WritePaychequeLineID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(WritePaychequeLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID); //GetInt32(reader, "AccountID");
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount); //GetDouble(reader, "Amount");
            fields["CategoryID"] = DbMgr.CreateIntFieldEntry(_obj.CategoryID); //GetInt32(reader, "CategoryID");
            fields["CategoryTypeID"] = DbMgr.CreateStringFieldEntry(_obj.CategoryTypeID); //GetString(reader, "CategoryTypeID");
            fields["HasActivitySlip"] = DbMgr.CreateStringFieldEntry(_obj.HasActivitySlip); //GetString(reader, "HasActivitySlip");
            fields["Hours"] = DbMgr.CreateDoubleFieldEntry(_obj.Hours); //GetDouble(reader, "Hours");
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob); //GetString(reader, "IsMultipleJob");
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID); //GetInt32(reader, "JobID");
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); //GetInt32(reader, "LineNumber");
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID); //GetString(reader, "PaymentStatusID");
            fields["WritePaychequeID"] = DbMgr.CreateIntFieldEntry(_obj.WritePaychequeID); //GetInt32(reader, "WritePaychequeID");
            fields["WritePaychequeLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.WritePaychequeLineID); //GetInt32(reader, "WritePaychequeLineID");

            return fields;
        }

        protected override object GetDbProperty(WritePaychequeLine _obj, string property_name)
        {
            if (property_name.Equals("WritePaycheque"))
            {
                return RepositoryMgr.WritePaychequeMgr.FindById(_obj.WritePaychequeID);
            }
            else if (property_name.Equals("CategoryType"))
            {
                return RepositoryMgr.CategoryTypeMgr.FindById(_obj.CategoryTypeID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("PaymentStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.PaymentStatusID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("WritePaychequeLines");
        }

        private DbSelectStatement GetQuery_SelectByWritePaychequeLineID(int WritePaychequeLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("WritePaychequeLines")
                .Criteria
                    .IsEqual("WritePaychequeLines", "WritePaychequeLineID", WritePaychequeLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByWritePaychequeLineID(int WritePaychequeLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("WritePaychequeLines")
                .Criteria
                    .IsEqual("WritePaychequeLines", "WritePaychequeLineID", WritePaychequeLineID);

            return clause;
        }

        public bool Exists(int? WritePaychequeLineID)
        {
            if (WritePaychequeLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByWritePaychequeLineID(WritePaychequeLineID.Value)) != 0;
        }

        public override bool Exists(WritePaychequeLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.WritePaychequeLineID);
        }

        protected override WritePaychequeLine _FindByIntId(int? WritePaychequeLineID)
        {
            if (WritePaychequeLineID == null) return null;
            WritePaychequeLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByWritePaychequeLineID(WritePaychequeLineID.Value));
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

        protected override IList<WritePaychequeLine> _FindAllCollection()
        {
            List<WritePaychequeLine> _grp = new List<WritePaychequeLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                WritePaychequeLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
