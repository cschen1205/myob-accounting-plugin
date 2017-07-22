using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    using System.Linq;
    using System.ComponentModel;
    public abstract class RecurringItemPurchaseLineManager : RecurringEntityManager<RecurringItemPurchaseLine>
    {
        public RecurringItemPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringItemPurchaseLine _CreateDbEntity()
        {
            return new RecurringItemPurchaseLine(true, this);
        }

        protected override RecurringItemPurchaseLine _CreateEntity()
        {
            return new RecurringItemPurchaseLine(false, this);
        }
        #endregion
        
        public override Dictionary<string, DbFieldEntry> GetFields(RecurringItemPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);

            fields["RecurringItemPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringItemPurchaseLineID);
            fields["RecurringPurchaseLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringPurchaseLineID);
            fields["LineNumber"]= DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"]= DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["ItemID"]= DbMgr.CreateIntFieldEntry(_obj.ItemID);
            fields["Description"]= DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["Quantity"]= DbMgr.CreateDoubleFieldEntry(_obj.Quantity);
            fields["TaxExclusiveUnitPrice"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveUnitPrice);
            fields["TaxInclusiveUnitPrice"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveUnitPrice);
            fields["TaxExclusiveTotal"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveTotal);
            fields["TaxInclusiveTotal"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveTotal);
            fields["Discount"]= DbMgr.CreateDoubleFieldEntry(_obj.Discount);
            fields["JobID"]= DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"]= DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"]= DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["LocationID"]=  DbMgr.CreateIntFieldEntry(_obj.LocationID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringItemPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringItemPurchaseLineID(int RecurringItemPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringItemPurchaseLines")
                .Criteria
                    .IsEqual("RecurringItemPurchaseLines", "RecurringItemPurchaseLineID", RecurringItemPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringItemPurchaseLineID(int RecurringItemPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("RecurringItemPurchaseLines")
                .Criteria
                    .IsEqual("RecurringItemPurchaseLines", "RecurringItemPurchaseLineID", RecurringItemPurchaseLineID);

            return clause;
        }

        private bool Exists(int? RecurringItemPurchaseLineID)
        {
            if (RecurringItemPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringItemPurchaseLineID(RecurringItemPurchaseLineID.Value)) != 0;
        }

        public override bool Exists(RecurringItemPurchaseLine _obj)
        {
            return Exists(_obj.RecurringItemPurchaseLineID);
        }

        protected override RecurringItemPurchaseLine _FindByIntId(int? RecurringItemPurchaseLineID)
        {
            if (Exists(RecurringItemPurchaseLineID))
            {
                RecurringItemPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringItemPurchaseLineID(RecurringItemPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringItemPurchaseLine _obj, DbDataReader _reader)
        {
            LoadRecurringEntityFromReader(_obj, _reader);

            _obj.RecurringItemPurchaseLineID =GetInt32(_reader, ("RecurringItemPurchaseLineID"));
            _obj.RecurringPurchaseID = GetInt32(_reader, "RecurringPurchaseID");
            _obj.RecurringPurchaseLineID = GetInt32(_reader, "RecurringPurchaseLineID");
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.ItemID =GetInt32(_reader, ("ItemID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.Quantity = GetDouble(_reader, ("Quantity"));
            _obj.TaxExclusiveUnitPrice = GetDouble(_reader, ("TaxExclusiveUnitPrice"));
            _obj.TaxInclusiveUnitPrice = GetDouble(_reader, ("TaxInclusiveUnitPrice"));
            _obj.TaxExclusiveTotal = GetDouble(_reader, ("TaxExclusiveTotal"));
            _obj.TaxInclusiveTotal = GetDouble(_reader, ("TaxInclusiveTotal"));
            _obj.Discount = GetDouble(_reader, ("Discount"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.LocationID =GetInt32(_reader, ("LocationID"));
        }

        protected override object GetDbProperty(RecurringItemPurchaseLine _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_obj != null) return returned_obj;

            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("RecurringPurchase"))
            {
                return RepositoryMgr.RecurringPurchaseMgr.FindById(_obj.RecurringPurchaseID);
            }

            return null;
        }

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<RecurringItemPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (RecurringItemPurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringItemPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringItemPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringPurchaseID == PurchaseID
                             select ipl;
                return new BindingList<RecurringItemPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<RecurringItemPurchaseLine> _FindCollectionByPurchaseID(int? RecurringPurchaseID)
        {
            BindingList<RecurringItemPurchaseLine> _grp = new BindingList<RecurringItemPurchaseLine>();
            if (RecurringPurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringItemPurchaseLines")
                .Criteria
                    .IsEqual("RecurringItemPurchaseLines", "RecurringPurchaseID", RecurringPurchaseID.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringItemPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override IList<RecurringItemPurchaseLine>_FindAllCollection()
        {
            List<RecurringItemPurchaseLine> _grp = new List<RecurringItemPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringItemPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

       
    }
}
