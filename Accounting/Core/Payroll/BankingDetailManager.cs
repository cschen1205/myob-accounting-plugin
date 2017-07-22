using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class BankingDetailManager : EntityManager<BankingDetail>
    {
        public BankingDetailManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BankingDetail _CreateDbEntity()
        {
            return new BankingDetail(true, this);
        }
        protected override BankingDetail _CreateEntity()
        {
            return new BankingDetail(false, this);
        }
        #endregion

        protected override void LoadFromReader(BankingDetail _obj, DbDataReader reader)
        {
            _obj.Bank1CalculatedAmount = GetDouble(reader, "Bank1CalculatedAmount");
            _obj.Bank1Value = GetDouble(reader, "Bank1Value");
            _obj.Bank1ValueTypeID = GetString(reader, "Bank1ValueTypeID");
            _obj.BankAccountName1 = GetString(reader, "BankAccountName1");
            _obj.BankAccountNumber1 = GetString(reader, "BankAccountNumber1");
            _obj.BSBCode1 = GetString(reader, "BSBCode1");

            _obj.Bank2CalculatedAmount = GetDouble(reader, "Bank2CalculatedAmount");
            _obj.Bank2Value = GetDouble(reader, "Bank2Value");
            _obj.Bank2ValueTypeID = GetString(reader, "Bank2ValueTypeID");
            _obj.BankAccountName2 = GetString(reader, "BankAccountName2");
            _obj.BankAccountNumber2 = GetString(reader, "BankAccountNumber2");
            _obj.BSBCode2 = GetString(reader, "BSBCode2");

            _obj.Bank3CalculatedAmount = GetDouble(reader, "Bank3CalculatedAmount");
            _obj.Bank3Value = GetDouble(reader, "Bank3Value");
            _obj.Bank3ValueTypeID = GetString(reader, "Bank3ValueTypeID");
            _obj.BankAccountName3 = GetString(reader, "BankAccountName3");
            _obj.BankAccountNumber3 = GetString(reader, "BankAccountNumber3");
            _obj.BSBCode3 = GetString(reader, "BSBCode3");

            _obj.BankingDetailID = GetInt32(reader, "BankingDetailsID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.WritePaychequeID = GetInt32(reader, "WritePaychequeID");
            _obj.JournalRecordID = GetInt32(reader, "JournalRecordID");
            _obj.NumberBankAccounts = GetInt32(reader, "NumberBankAccounts");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(BankingDetail _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["Bank1CalculatedAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank1CalculatedAmount); //GetDouble(reader, "Bank1CalculatedAmount");
            fields["Bank1Value"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank1Value); //GetDouble(reader, "Bank1Value");
            fields["Bank1ValueTypeID"] = DbMgr.CreateStringFieldEntry(_obj.Bank1ValueTypeID); //GetString(reader, "Bank1ValueTypeID");
            fields["BankAccountName1"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName1); //GetString(reader, "BankAccountName1");
            fields["BankAccountNumber1"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber1); //GetString(reader, "BankAccountNumber1");
            fields["BSBCode1"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode1); //GetString(reader, "BSBCode1");

            fields["Bank2CalculatedAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank2CalculatedAmount); //GetDouble(reader, "Bank2CalculatedAmount");
            fields["Bank2Value"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank2Value); //GetDouble(reader, "Bank2Value");
            fields["Bank2ValueTypeID"] = DbMgr.CreateStringFieldEntry(_obj.Bank2ValueTypeID); //GetString(reader, "Bank2ValueTypeID");
            fields["BankAccountName2"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName2); //GetString(reader, "BankAccountName2");
            fields["BankAccountNumber2"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber2); //GetString(reader, "BankAccountNumber2");
            fields["BSBCode2"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode2); //GetString(reader, "BSBCode2");

            fields["Bank3CalculatedAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank3CalculatedAmount); //GetDouble(reader, "Bank3CalculatedAmount");
            fields["Bank3Value"] = DbMgr.CreateDoubleFieldEntry(_obj.Bank3Value); //GetDouble(reader, "Bank3Value");
            fields["Bank3ValueTypeID"] = DbMgr.CreateStringFieldEntry(_obj.Bank3ValueTypeID); //GetString(reader, "Bank3ValueTypeID");
            fields["BankAccountName3"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName3); //GetString(reader, "BankAccountName3");
            fields["BankAccountNumber3"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber3); //GetString(reader, "BankAccountNumber3");
            fields["BSBCode3"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode3); //GetString(reader, "BSBCode3");

            fields["BankingDetailsID"] = DbMgr.CreateAutoIntFieldEntry(_obj.BankingDetailID); //GetInt32(reader, "BankingDetailID");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
            fields["WritePaychequeID"] = DbMgr.CreateIntFieldEntry(_obj.WritePaychequeID); //GetInt32(reader, "WritePaychequeID");
            fields["JournalRecordID"] = DbMgr.CreateIntFieldEntry(_obj.JournalRecordID); //GetInt32(reader, "JournalRecordID");
            fields["NumberBankAccounts"] = DbMgr.CreateIntFieldEntry(_obj.NumberBankAccounts); //GetInt32(reader, "NumberBankAccounts");

            return fields;
        }

        protected override object GetDbProperty(BankingDetail _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("JournalRecord"))
            {
                return RepositoryMgr.JournalRecordMgr.FindById(_obj.JournalRecordID);
            }
            else if (property_name.Equals("WritePaycheque"))
            {
                return RepositoryMgr.WritePaychequeMgr.FindById(_obj.WritePaychequeID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("BankingDetails");
        }

        private DbSelectStatement GetQuery_SelectByBankingDetailID(int BankingDetailID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("BankingDetails")
                .Criteria
                    .IsEqual("BankingDetails", "BankingDetailsID", BankingDetailID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBankingDetailID(int BankingDetailID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("BankingDetails")
                .Criteria
                    .IsEqual("BankingDetails", "BankingDetailsID", BankingDetailID);

            return clause;
        }

        public bool Exists(int? BankingDetailID)
        {
            if (BankingDetailID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByBankingDetailID(BankingDetailID.Value)) != 0;
        }

        public override bool Exists(BankingDetail _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.BankingDetailID);
        }

        protected override BankingDetail _FindByIntId(int? BankingDetailID)
        {
            if (BankingDetailID == null) return null;

            BankingDetail _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByBankingDetailID(BankingDetailID.Value));
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

        protected override IList<BankingDetail>_FindAllCollection()
        {
            List<BankingDetail> _grp = new List<BankingDetail>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                BankingDetail _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
