using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    using System.Linq;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class MiscPurchaseLineManager : EntityManager<MiscPurchaseLine>
    {
        public MiscPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override MiscPurchaseLine _CreateDbEntity()
        {
            return new MiscPurchaseLine(true, this);
        }

        protected override MiscPurchaseLine _CreateEntity()
        {
            return new MiscPurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(MiscPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["MiscPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MiscPurchaseLineID);
            fields["PurchaseLineID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseLineID);
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);

            return fields;
        }

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<MiscPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (MiscPurchaseLine line in lines)
            {
                Delete(line);
            }
        }
       
        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MiscPurchaseLines");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByMiscPurchaseLineID(int MiscPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MiscPurchaseLines")
                .Criteria
                    .IsEqual("MiscPurchaseLines", "MiscPurchaseLineID", MiscPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByMiscPurchaseLineID(int MiscPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("MiscPurchaseLines")
                .Criteria
                    .IsEqual("MiscPurchaseLines", "MiscPurchaseLineID", MiscPurchaseLineID);

            return clause;
        }

        private bool Exists(int? MiscPurchaseLineID)
        {
            if (MiscPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMiscPurchaseLineID(MiscPurchaseLineID.Value)) != 0;
        }

        public override bool Exists(MiscPurchaseLine _obj)
        {
            if (_obj.MiscPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMiscPurchaseLineID(_obj.MiscPurchaseLineID.Value)) != 0;
        }

        protected override MiscPurchaseLine _FindByIntId(int? MiscPurchaseLineID)
        {
            if (Exists(MiscPurchaseLineID))
            {
                MiscPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByMiscPurchaseLineID(MiscPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public IList<MiscPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<MiscPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.PurchaseID == PurchaseID
                             select ipl;
                return new BindingList<MiscPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<MiscPurchaseLine> _FindCollectionByPurchaseID(int? PurchaseID)
        {
            BindingList<MiscPurchaseLine> _grp = new BindingList<MiscPurchaseLine>();
            if (PurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MiscPurchaseLines")
                .Criteria
                    .IsEqual("MiscPurchaseLines", "PurchaseID", PurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MiscPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(MiscPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.MiscPurchaseLineID =GetInt32(_reader, ("MiscPurchaseLineID"));
            _obj.PurchaseLineID =GetInt32(_reader, ("PurchaseLineID"));
            _obj.PurchaseID =GetInt32(_reader, ("PurchaseID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
        }

        protected override object GetDbProperty(MiscPurchaseLine _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }

            return null;
        }

        protected override IList<MiscPurchaseLine>_FindAllCollection()
        {
            List<MiscPurchaseLine> _grp = new List<MiscPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MiscPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
