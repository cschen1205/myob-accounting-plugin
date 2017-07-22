using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Core.Cards
{
    using System.Linq;
    using System.Data;
    using System.Data.Common;
    using System.ComponentModel;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class CardManager : EntityManager<Card>
    {
        public CardManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Card _CreateDbEntity()
        {
            return new Card(true, this);
        }

        protected override Card _CreateEntity()
        {
            return new Card(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Card _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CardRecordID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CardRecordID);
            fields["Name"] = DbMgr.CreateStringFieldEntry(_obj.Name);
            fields["CardIdentification"] = DbMgr.CreateStringFieldEntry(_obj.CardIdentification);
            fields["PaymentDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentDeliveryID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["CardTypeID"] = DbMgr.CreateStringFieldEntry(_obj.CardTypeID);
            fields["IsIndividual"] = DbMgr.CreateStringFieldEntry(_obj.IsIndividual);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectDistinct()
                .SelectAll()
                .From("Cards");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCardRecordID(int CardRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Cards")
                .Criteria.IsEqual("Cards", "CardRecordID", CardRecordID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecordID(int CardRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Cards")
                .Criteria.IsEqual("Cards", "CardRecordID", CardRecordID);

            return clause;
        }

        public bool Exists(int? CardRecordID)
        {
            if (CardRecordID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecordID(CardRecordID.Value)) != 0;
        }

        public override bool Exists(Card _obj)
        {
            return Exists(_obj.CardRecordID);
        }

        protected override void LoadFromReader(Card _obj, DbDataReader _reader)
        {
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.Name =GetString(_reader, ("Name"));
            _obj.CardIdentification =GetString(_reader, ("CardIdentification"));
            _obj.PaymentDeliveryID =GetString(_reader, ("PaymentDeliveryID"));
            _obj.IsInactive =GetString(_reader, ("IsInactive"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.CardTypeID =GetString(_reader, ("CardTypeID"));
            _obj.IsIndividual = GetString(_reader, ("IsIndividual"));
        }

        protected override object GetDbProperty(Card _obj, string property_name)
        {
            if (property_name == "PaymentDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
            }
            else if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "Address1")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 1);
            }
            else if (property_name == "Address2")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 2);
            }
            else if (property_name == "Address3")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 3);
            }
            else if (property_name == "Address4")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 4);
            }
            else if (property_name == "Address5")
            {
                return RepositoryMgr.AddressMgr.FindByCardId(_obj.CardRecordID, 5);
            }
            else if (property_name == "CardType")
            {
                return RepositoryMgr.CardTypeMgr.FindById(_obj.CardTypeID);
            }

            return null;
        }

       
        protected override IList<Card>_FindAllCollection()
        {
            BindingList<Card> cards = new BindingList<Card>();
            IList<Customer> customers = RepositoryMgr.CustomerMgr.FindAllCollection();
            foreach (Customer c in customers)
            {
                cards.Add(c);
            }
            IList<Supplier> suppliers = RepositoryMgr.SupplierMgr.FindAllCollection();
            foreach(Supplier s in suppliers)
            {
                cards.Add(s);
            }
            IList<Employee> employees = RepositoryMgr.EmployeeMgr.FindAllCollection();
            foreach (Employee e in employees)
            {
                cards.Add(e);
            }

            return cards;
        }

        public Card FindByCardId(int? CardRecordID, bool cast)
        {
            return _FindByCardId(CardRecordID, cast);
        }

        protected virtual Card _FindByCardId(int? CardRecordID, bool cast)
        {
            if (Exists(CardRecordID))
            {
                Card _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCardRecordID(CardRecordID.Value));

                if (cast)
                {
                    CardType.TypeID type = CardType.GetTypeID(_obj.CardTypeID);
                    if (type == CardType.TypeID.Customer)
                    {
                        Card specialized_card = RepositoryMgr.CustomerMgr.FindById(_obj.CardRecordID);
                        return specialized_card;
                    }
                    else if (type == CardType.TypeID.Employee)
                    {
                        Card specialized_card = RepositoryMgr.EmployeeMgr.FindById(_obj.CardRecordID);
                        return specialized_card;
                    }
                    else if (type == CardType.TypeID.Supplier)
                    {
                        Card specialized_card = RepositoryMgr.SupplierMgr.FindById(_obj.CardRecordID);
                        return specialized_card;
                    }
                }
                return _obj;
            }
            else
            {
                return null;
            }
        }
    }
}
