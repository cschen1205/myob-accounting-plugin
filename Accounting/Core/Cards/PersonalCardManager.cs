using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Cards
{
    public abstract class PersonalCardManager : EntityManager<PersonalCard>
    {
        public PersonalCardManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PersonalCard _CreateDbEntity()
        {
            PersonalCard _obj = new PersonalCard(true, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.PersonalCard);

            return _obj;
        }
        protected override PersonalCard _CreateEntity()
        {
            PersonalCard _obj = new PersonalCard(false, this);
            _obj.CardTypeID = CardType.GetCardTypeID(CardType.TypeID.PersonalCard);
            _obj.IsIndividual = "Y";

            return _obj;
        }
        #endregion

        protected override void LoadFromReader(PersonalCard _obj, DbDataReader reader)
        {
            _obj.CardIdentification = GetString(reader, "CardIdentification");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.ChangeControl = GetString(reader, "ChangeControl");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.FirstName = GetString(reader, "FirstName");
            _obj.IsInactive = GetString(reader, "IsInactive");
            _obj.IsIndividual = GetString(reader, "IsIndividual");
            _obj.LastName = GetString(reader, "LastName");
            _obj.Name = GetString(reader, "Name");
            _obj.Notes = GetString(reader, "Notes");
            _obj.PaymentDeliveryID = GetString(reader, "PaymentDeliveryID");
            _obj.PersonalCardID = GetInt32(reader, "PersonalCardID");
            _obj.Picture = GetString(reader, "Picture");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PersonalCard _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["PersonalCardID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PersonalCardID);
            fields["CardIdentification"] = DbMgr.CreateStringFieldEntry(_obj.CardIdentification);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["FirstName"] = DbMgr.CreateStringFieldEntry(_obj.FirstName);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["IsIndividual"] = DbMgr.CreateStringFieldEntry(_obj.IsIndividual);
            fields["LastName"] = DbMgr.CreateStringFieldEntry(_obj.LastName);
            fields["Name"] = DbMgr.CreateStringFieldEntry(_obj.Name);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes);
            fields["Picture"] = DbMgr.CreateStringFieldEntry(_obj.Picture);
            return fields;
        }

        protected override object GetDbProperty(PersonalCard _obj, string property_name)
        {
            if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "PaymentDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.PaymentDeliveryID);
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

        public override bool Exists(PersonalCard _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PersonalCardID);
        }

        public bool Exists(int? PersonalCardID)
        {
            if (PersonalCardID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPersonalCardID(PersonalCardID.Value)) != 0;
        }

        private DbSelectStatement GetQuery_SelectCountByPersonalCardID(int PersonalCardID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("PersonalCards")
                .Criteria
                    .IsEqual("PersonalCards", "PersonalCardID", PersonalCardID);
            return clause;
        }

         private DbSelectStatement GetQuery_SelectByPersonalCardID(int PersonalCardID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PersonalCards")
                .Criteria
                    .IsEqual("PersonalCards", "PersonalCardID", PersonalCardID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PersonalCards");

            return clause;
        }

        protected override IList<PersonalCard>_FindAllCollection()
        {
            List<PersonalCard> _grp = new List<PersonalCard>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                PersonalCard _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override PersonalCard _FindByIntId(int? PersonalCardID)
        {
            PersonalCard _obj = null;
            if (PersonalCardID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPersonalCardID(PersonalCardID.Value));
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
