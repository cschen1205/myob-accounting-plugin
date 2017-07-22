using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Cards
{
    public abstract class CardActivityManager : EntityManager<CardActivity>
    {
        public CardActivityManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CardActivity _CreateDbEntity()
        {
            return new CardActivity(true, this);
        }
        protected override CardActivity _CreateEntity()
        {
            return new CardActivity(false, this);
        }
        #endregion

        protected override void LoadFromReader(CardActivity _obj, DbDataReader reader)
        {
            _obj.CardActivityID = GetInt32(reader, "CardActivityID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.DollarsSold = GetDouble(reader, "DollarsSold");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CardActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CardActivityID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CardActivityID);
            fields["DollarsSold"] = DbMgr.CreateDoubleFieldEntry(_obj.DollarsSold);
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear);
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period);

            return fields;
        }

        protected override object GetDbProperty(CardActivity _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectCountByCardActivityID(int CardActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CardActivities")
                .Criteria
                    .IsEqual("CardActivities", "CardActivityID", CardActivityID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCardActivityID(int CardActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CardActivities")
                .Criteria
                    .IsEqual("CardActivities", "CardActivityID", CardActivityID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CardActivities");
            return clause;
        }

        public bool Exists(int? CardActivityID)
        {
            if(CardActivityID==null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCardActivityID(CardActivityID.Value)) != 0;
        }

        public override bool Exists(CardActivity _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CardActivityID);
        }

        protected override IList<CardActivity>_FindAllCollection()
        {
            List<CardActivity> _grp = new List<CardActivity>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CardActivity _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override CardActivity _FindByIntId(int? CardActivityID)
        {
            CardActivity _obj = null;
            if (CardActivityID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCardActivityID(CardActivityID.Value));
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
