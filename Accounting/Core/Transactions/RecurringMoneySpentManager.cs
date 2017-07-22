using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class RecurringMoneySpentManager : RecurringEntityManager<RecurringMoneySpent>
    {
        public RecurringMoneySpentManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringMoneySpent _CreateDbEntity()
        {
            return new RecurringMoneySpent(true, this);
        }
        protected override RecurringMoneySpent _CreateEntity()
        {
            return new RecurringMoneySpent(false, this);
        }
        #endregion

        protected override void LoadFromReader(RecurringMoneySpent _obj, DbDataReader reader)
        {
            LoadRecurringEntityFromReader(_obj, reader);

            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.Memo = GetString(reader, "Memo");
            _obj.Payee = GetString(reader, "Payee");
            _obj.PayeeLine1 = GetString(reader, "PayeeLine1");
            _obj.PayeeLine2 = GetString(reader, "PayeeLine2");
            _obj.PayeeLine3 = GetString(reader, "PayeeLine3");
            _obj.PayeeLine4 = GetString(reader, "PayeeLine4");
            _obj.PaymentDeliveryID = GetString(reader, "PaymentDeliveryID");
            _obj.TotalSpentAmount = GetDouble(reader, "TotalSpentAmount");
            _obj.RecurringMoneySpentID = GetInt32(reader, "RecurringMoneySpentID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringMoneySpent _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);

            fields["RecurringMoneySpentID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringMoneySpentID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["Payee"] = DbMgr.CreateStringFieldEntry(_obj.Payee);
            fields["PayeeLine1"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine1);
            fields["PayeeLine2"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine2);
            fields["PayeeLine3"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine3);
            fields["PayeeLine4"] = DbMgr.CreateStringFieldEntry(_obj.PayeeLine4);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);
            fields["TotalSpentAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalSpentAmount);

            return fields;
        }

        protected override object GetDbProperty(RecurringMoneySpent _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);

            if (returned_obj != null) return returned_obj;

            if (property_name.Equals("IssuingAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IssuingAccountID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("PaymentDelivery"))
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll().From("RecurringMoneySpent");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringMoneySpentID(int RecurringMoneySpentID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("RecurringMoneySpent")
                .Criteria
                    .IsEqual("RecurringMoneySpent", "RecurringMoneySpentID", RecurringMoneySpentID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringMoneySpentID(int RecurringMoneySpentID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("RecurringMoneySpent")
                .Criteria
                    .IsEqual("RecurringMoneySpent", "RecurringMoneySpentID", RecurringMoneySpentID);
            return clause;
        }

        public bool Exists(int? RecurringMoneySpentID)
        {
            if(RecurringMoneySpentID==null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringMoneySpentID(RecurringMoneySpentID.Value)) != 0;
        }

        public override bool  Exists(RecurringMoneySpent _obj)
        {
 	         if(_obj==null) return false;
            return Exists(_obj.RecurringMoneySpentID);
        }

        protected override IList<RecurringMoneySpent>_FindAllCollection()
        {
            List<RecurringMoneySpent> _grp = new List<RecurringMoneySpent>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringMoneySpent _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringMoneySpent _FindByIntId(int? RecurringMoneySpentID)
        {
            if (RecurringMoneySpentID == null) return null;

            RecurringMoneySpent _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRecurringMoneySpentID(RecurringMoneySpentID.Value));
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

    }
}
