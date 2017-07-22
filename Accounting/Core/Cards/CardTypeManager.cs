using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Cards
{
    public abstract class CardTypeManager : EntityManager<CardType>
    {
        public CardTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CardType _CreateDbEntity()
        {
            return new CardType(true, this);
        }

        protected override CardType _CreateEntity()
        {
            return new CardType(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(CardType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CardTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.CardTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectDistinct()
                .SelectColumn("CardTypes", "CardTypeID")
                .From("CardTypes");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCardTypeID(string CardTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CardTypes")
                .Criteria.IsEqual("CardTypes", "CardTypeID", CardTypeID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCardTypeID(string CardTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CardTypes")
                .Criteria.IsEqual("CardTypes", "CardTypeID", CardTypeID);
            return clause;
        }

        public bool Exists(string CardTypeID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByCardTypeID(CardTypeID)) != 0;
        }

        public override bool Exists(CardType _obj)
        {
            return Exists(_obj.CardTypeID);
        }

        protected override void LoadFromReader(CardType _obj, DbDataReader _reader)
        {
            _obj.CardTypeID=GetString(_reader, ("CardTypeID"));
            //_obj.Description =GetString(_reader, ("Description"));
        }

        protected override IList<CardType>_FindAllCollection()
        {
            List<CardType> cards = new List<CardType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CardType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                cards.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return cards;
        }

        protected override CardType _FindByTextId(string CardTypeID)
        {
            if (Exists(CardTypeID))
            {
                CardType _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCardTypeID(CardTypeID));
                return _obj;
            }
            else
            {
                return null;
            }
        }
    }
}
