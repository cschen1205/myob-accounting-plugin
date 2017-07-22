using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Accounts
{
    public abstract class LinkedAccountManager : EntityManager<LinkedAccount>
    {
        public LinkedAccountManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override LinkedAccount _CreateEntity()
        {
            return new LinkedAccount(false, this);
        }

        protected override LinkedAccount _CreateDbEntity()
        {
            return new LinkedAccount(true, this);
        }

        public override bool Exists(LinkedAccount _obj)
        {
            if (_obj.LinkedAccountID == null) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount().From("LinkedAccounts").Criteria
                .IsEqual("LinkedAccounts", "LinkedAccountID", _obj.LinkedAccountID);
            return ExecuteScalarInt(clause) != 0;
        }

        public LinkedAccount.LinkAccountType GetLinkedAccountType(Account acc)
        {
            IList<LinkedAccount> acc_grp =FindAllCollection();
            if (acc_grp.Count == 0) return LinkedAccount.LinkAccountType.Unlinked;

            LinkedAccount.LinkAccountType type;
            acc_grp[0].Contains(acc, out type);
            return type;
        }

        protected override IList<LinkedAccount>_FindAllCollection()
        {
            List<LinkedAccount> _grp = new List<LinkedAccount>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            string query=clause.SelectAll().From("LinkedAccounts").ToString();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                LinkedAccount la = CreateDbEntity();
                LoadFromReader(la, _reader);
                _grp.Add(la);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(LinkedAccount _obj, DbDataReader reader)
        {
            _obj.LinkedAccountID = GetInt32(reader, "LinkedAccountID");
            _obj.ChangeControl = GetString(reader, "ChangeControl");
            _obj.CurrencyGainLossID = GetInt32(reader, "CurrencyGainLossID");
            _obj.CurrentEarningsID = GetInt32(reader, "CurrentEarningsID");
            _obj.ElectronicPaymentsID = GetInt32(reader, "ElectronicPaymentsID");
            _obj.EmployerExpenseID = GetInt32(reader, "EmployerExpenseID");
            _obj.HistoricalBalancingID = GetInt32(reader, "HistoricalBalancingID");
            _obj.PayablesAccountID = GetInt32(reader, "PayablesAccountID");
            _obj.PayablesChequeID = GetInt32(reader, "PayablesChequeID");
            _obj.PayablesDepositsID = GetInt32(reader, "PayablesDepositsID");
            _obj.PayablesDiscountsID = GetInt32(reader, "PayablesDiscountsID");
            _obj.PayablesFreightID = GetInt32(reader, "PayablesFreightID");
            _obj.PayablesInventoryID = GetInt32(reader, "PayablesInventoryID");
            _obj.PayablesLateFeesID = GetInt32(reader, "PayablesLateFeesID");
            _obj.PayrollCashID = GetInt32(reader, "PayrollCashID");
            _obj.PayrollChequeID = GetInt32(reader, "PayrollChequeID");
            _obj.ReceivablesAccountID = GetInt32(reader, "ReceivablesAccountID");
            _obj.ReceivablesDepositsID = GetInt32(reader, "ReceivablesDepositsID");
            _obj.ReceivablesDiscountsID = GetInt32(reader, "ReceivablesDiscountsID");
            _obj.ReceivablesFreightID = GetInt32(reader, "ReceivablesFreightID");
            _obj.ReceivablesLateFeesID = GetInt32(reader, "ReceivablesLateFeesID");
            _obj.RetainedEarningsID = GetInt32(reader, "RetainedEarningsID");
            _obj.UndepositedFundsID = GetInt32(reader, "UndepositedFundsID");
            _obj.WagesExpenseID = GetInt32(reader, "WagesExpenseID");
            _obj.WithholdingPayableID = GetInt32(reader, "WithholdingPayableID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(LinkedAccount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["LinkedAccountID"] = DbMgr.CreateAutoIntFieldEntry(_obj.LinkedAccountID);
            fields["ChangeControl"] = DbMgr.CreateStringFieldEntry(_obj.ChangeControl);
            fields["CurrencyGainLossID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyGainLossID);
            fields["CurrentEarningsID"] = DbMgr.CreateIntFieldEntry(_obj.CurrentEarningsID);
            fields["ElectronicPaymentsID"] = DbMgr.CreateIntFieldEntry(_obj.ElectronicPaymentsID);
            fields["EmployerExpenseID"] = DbMgr.CreateIntFieldEntry(_obj.EmployerExpenseID);
            fields["HistoricalBalancingID"] = DbMgr.CreateIntFieldEntry(_obj.HistoricalBalancingID);
            fields["PayablesAccountID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesAccountID);
            fields["PayablesChequeID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesChequeID);
            fields["PayablesDepositsID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesDepositsID);
            fields["PayablesDiscountsID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesDiscountsID);
            fields["PayablesFreightID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesFreightID);
            fields["PayablesInventoryID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesInventoryID);
            fields["PayablesLateFeesID"] = DbMgr.CreateIntFieldEntry(_obj.PayablesLateFeesID);
            fields["PayrollCashID"] = DbMgr.CreateIntFieldEntry(_obj.PayrollCashID);
            fields["PayrollChequeID"] = DbMgr.CreateIntFieldEntry(_obj.PayrollChequeID);
            fields["ReceivablesAccountID"] = DbMgr.CreateIntFieldEntry(_obj.ReceivablesAccountID);
            fields["ReceivablesDepositsID"] = DbMgr.CreateIntFieldEntry(_obj.ReceivablesDepositsID);
            fields["ReceivablesDiscountsID"] = DbMgr.CreateIntFieldEntry(_obj.ReceivablesDiscountsID);
            fields["ReceivablesFreightID"] = DbMgr.CreateIntFieldEntry(_obj.ReceivablesFreightID);
            fields["ReceivablesLateFeesID"] = DbMgr.CreateIntFieldEntry(_obj.ReceivablesLateFeesID);
            fields["RetainedEarningsID"] = DbMgr.CreateIntFieldEntry(_obj.RetainedEarningsID);
            fields["UndepositedFundsID"] = DbMgr.CreateIntFieldEntry(_obj.UndepositedFundsID);
            fields["WagesExpenseID"] = DbMgr.CreateIntFieldEntry(_obj.WagesExpenseID);
            fields["WithholdingPayableID"] = DbMgr.CreateIntFieldEntry(_obj.WithholdingPayableID);
            return fields;
        }
    }
}
