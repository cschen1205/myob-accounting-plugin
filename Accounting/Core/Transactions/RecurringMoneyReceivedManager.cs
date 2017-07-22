using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class RecurringMoneyReceivedManager : RecurringEntityManager<RecurringMoneyReceived>
    {
        public RecurringMoneyReceivedManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringMoneyReceived _CreateDbEntity()
        {
            return new RecurringMoneyReceived(true, this);
        }
        protected override RecurringMoneyReceived _CreateEntity()
        {
            return new RecurringMoneyReceived(false, this);
        }
        #endregion

        protected override void LoadFromReader(RecurringMoneyReceived _obj, DbDataReader reader)
        {
            LoadRecurringEntityFromReader(_obj, reader);

            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TotalAmountReceived = GetDouble(reader, "TotalAmountReceived");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.Memo = GetString(reader, "Memo");
            _obj.RecurringMoneyReceivedID = GetInt32(reader, "RecurringMoneyReceivedID");
            _obj.MethodOfPaymentID = GetInt32(reader, "MethodOfPaymentID", "PaymentMethodID");
            _obj.PaymentCardNumber = GetString(reader, "PaymentCardNumber");
            _obj.PaymentExpirationDate = GetString(reader, "PaymentExpirationDate");
            _obj.PaymentNameOnCard = GetString(reader, "PaymentNameOnCard");
            _obj.PaymentNotes = GetString(reader, "PaymentNotes");
            _obj.RecipientAccountID = GetInt32(reader, "RecipientAccountID");
            
        }

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringMoneyReceived _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);

            fields["RecurringMoneyReceivedID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringMoneyReceivedID);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["MethodOfPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.MethodOfPaymentID);
            fields["PaymentCardNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentCardNumber);
            fields["PaymentExpirationDate"] = DbMgr.CreateStringFieldEntry(_obj.PaymentExpirationDate);
            fields["PaymentNameOnCard"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNameOnCard);
            fields["PaymentNotes"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNotes);
            fields["RecipientAccountID"] = DbMgr.CreateIntFieldEntry(_obj.RecipientAccountID); 

            return fields;
        }

        protected override object GetDbProperty(RecurringMoneyReceived _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_obj != null) return returned_obj;

            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("RecipientAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.RecipientAccountID);
            }
            else if (property_name.Equals("MethodOfPayment"))
            {
                return RepositoryMgr.PaymentMethodMgr.FindById(_obj.MethodOfPaymentID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll().From("RecurringMoneyReceived");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringMoneyReceivedID(int RecurringMoneyReceivedID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("RecurringMoneyReceived")
                .Criteria
                    .IsEqual("RecurringMoneyReceived", "RecurringMoneyReceivedID", RecurringMoneyReceivedID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringMoneyReceivedID(int RecurringMoneyReceivedID)
        {
            DbSelectStatement clause=DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("RecurringMoneyReceived")
                .Criteria
                    .IsEqual("RecurringMoneyReceived", "RecurringMoneyReceivedID", RecurringMoneyReceivedID);
            return clause;
        }

        public bool Exists(int? RecurringMoneyReceivedID)
        {
            if(RecurringMoneyReceivedID==null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringMoneyReceivedID(RecurringMoneyReceivedID.Value)) != 0;
        }

        public override bool  Exists(RecurringMoneyReceived _obj)
        {
 	         if(_obj==null) return false;
            return Exists(_obj.RecurringMoneyReceivedID);
        }

        protected override IList<RecurringMoneyReceived>_FindAllCollection()
        {
            List<RecurringMoneyReceived> _grp = new List<RecurringMoneyReceived>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringMoneyReceived _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringMoneyReceived _FindByIntId(int? RecurringMoneyReceivedID)
        {
            if (RecurringMoneyReceivedID == null) return null;

            RecurringMoneyReceived _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByRecurringMoneyReceivedID(RecurringMoneyReceivedID.Value));
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
