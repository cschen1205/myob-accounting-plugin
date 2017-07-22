using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Cards
{
    public abstract class AddressManager : EntityManager<Address>
    {
        public AddressManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Address _CreateDbEntity()
        {
            return new Address(true, this);
        }

        protected override Address _CreateEntity()
        {
            return new Address(false, this);
        }
        #endregion 

        public override Dictionary<string, DbFieldEntry> GetFields(Address _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AddressID"] = DbMgr.CreateAutoIntFieldEntry(_obj.AddressID);
            fields["StreetLine1"] = DbMgr.CreateStringFieldEntry(_obj.StreetLine1);
            fields["StreetLine2"] = DbMgr.CreateStringFieldEntry(_obj.StreetLine2);
            fields["StreetLine3"] = DbMgr.CreateStringFieldEntry(_obj.StreetLine3);
            fields["StreetLine4"] = DbMgr.CreateStringFieldEntry(_obj.StreetLine4);
            fields["Street"] = DbMgr.CreateStringFieldEntry(_obj.Street);
            fields["City"] = DbMgr.CreateStringFieldEntry(_obj.City);
            fields["Country"] = DbMgr.CreateStringFieldEntry(_obj.Country);
            fields["Phone1"] = DbMgr.CreateStringFieldEntry(_obj.Phone1);
            fields["Phone2"] = DbMgr.CreateStringFieldEntry(_obj.Phone2);
            fields["Phone3"] = DbMgr.CreateStringFieldEntry(_obj.Phone3);
            fields["Email"] = DbMgr.CreateStringFieldEntry(_obj.Email);
            fields["Fax"] = DbMgr.CreateStringFieldEntry(_obj.Fax);
            fields["ContactName"] = DbMgr.CreateStringFieldEntry(_obj.ContactName);
            fields["WWW"] = DbMgr.CreateStringFieldEntry(_obj.Website);
            fields["Location"] = DbMgr.CreateIntFieldEntry(_obj.Location);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Postcode"] = DbMgr.CreateStringFieldEntry(_obj.Postcode);
            fields["State"] = DbMgr.CreateStringFieldEntry(_obj.State);
            fields["Solutation"] = DbMgr.CreateStringFieldEntry(_obj.Solutation);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Address");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByAddressID(int CardRecordID, int Location)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Address")
                .Criteria
                    .IsEqual("Address", "CardRecordID", CardRecordID)
                    .IsEqual("Address", "Location", Location);
       
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByAddressID(int CardRecordID, int Location)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Address")
                .Criteria
                    .IsEqual("Address", "CardRecordID", CardRecordID)
                    .IsEqual("Address", "Location", Location);

            return clause;
        }

        public override bool Exists(Address _obj)
        {
            if (_obj == null)
            {
                return false;
            }
            if (!_obj.IsValid)
            {
                return false;
            }
            return ExecuteScalarInt(GetQuery_SelectCountByAddressID(_obj.CardRecordID.Value, _obj.Location.Value)) != 0;
        }

        protected override void LoadFromReader(Address _obj, DbDataReader _reader)
        {
            _obj.StreetLine1 =GetString(_reader, ("StreetLine1"));
            _obj.StreetLine2 =GetString(_reader, ("StreetLine2"));
            _obj.StreetLine3 =GetString(_reader, ("StreetLine3"));
            _obj.StreetLine4 =GetString(_reader, ("StreetLine4"));
            _obj.Street =GetString(_reader, ("Street"));
            _obj.City =GetString(_reader, ("City"));
            _obj.Country =GetString(_reader, ("Country"));
            _obj.Phone1 =GetString(_reader, ("Phone1"));
            _obj.Phone2 =GetString(_reader, ("Phone2"));
            _obj.Phone3 =GetString(_reader, ("Phone3"));
            _obj.Email =GetString(_reader, ("Email"));
            _obj.Fax =GetString(_reader, ("Fax"));
            _obj.ContactName =GetString(_reader, ("ContactName"));
            _obj.Website =GetString(_reader, ("WWW"));
            _obj.Location =GetInt32(_reader, ("Location"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.AddressID = GetInt32(_reader, ("AddressID"));
            _obj.State = GetString(_reader, "State");
            _obj.Solutation = GetString(_reader, "Solutation");

            _obj.Postcode =GetString(_reader, ("Postcode"));
        }

        protected override IList<Address>_FindAllCollection()
        {
            List<Address> adrs = new List<Address>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader =  _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Address _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                if (_obj.IsValid)
                {
                    adrs.Add(_obj);
                }
            }

            _reader.Close();
            _cmd.Dispose();

            return adrs;
        }

        public Address FindByCardId(int? CardRecordID, int? Location)
        {
            
            return _FindByCardId(CardRecordID, Location);
        }

        protected virtual Address _FindByCardId(int? CardRecordID, int? Location)
        {
            if (CardRecordID == null || Location == null) return null;
            Address _obj = null;

            DbSelectStatement clause = GetQuery_SelectByAddressID(CardRecordID.Value, Location.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            if (_obj != null && _obj.IsValid)
            {
                return _obj;
            }

            return null;
        }

        public List<Address> FindCollectionByCardId(int? CardRecordID)
        {
            List<Address> _grp = new List<Address>();

            if (CardRecordID == null) return _grp;

            Address _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Address")
                .Criteria
                    .IsEqual("Address", "CardRecordID", CardRecordID);


            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                if (_obj.IsValid)
                {
                    _grp.Add(_obj);
                }
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
