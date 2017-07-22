using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class RecurringPurchaseLineManager : RecurringEntityManager<RecurringPurchaseLine>
    {
        public RecurringPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringPurchaseLine _CreateDbEntity()
        {
            return new RecurringPurchaseLine(true, this);
        }

        protected override RecurringPurchaseLine _CreateEntity()
        {
            return new RecurringPurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringPurchaseLineID);
            fields["RecurringPurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringPurchaseID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringPurchaseLineID(int RecurringPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringPurchaseLines")
                .Criteria
                    .IsEqual("RecurringPurchaseLines", "RecurringPurchaseLineID", RecurringPurchaseLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringPurchaseLineID(int RecurringPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringPurchaseLines")
                .Criteria
                    .IsEqual("RecurringPurchaseLines", "RecurringPurchaseLineID", RecurringPurchaseLineID);
            return clause;
        }

        private bool Exists(int? RecurringPurchaseLineID)
        {
            if (RecurringPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringPurchaseLineID(RecurringPurchaseLineID.Value)) != 0;
        }

        public override bool Exists(RecurringPurchaseLine _obj)
        {
            return Exists(_obj.RecurringPurchaseLineID);
        }

        protected override RecurringPurchaseLine _FindByIntId(int? RecurringPurchaseLineID)
        {
            if (Exists(RecurringPurchaseLineID))
            {
                RecurringPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringPurchaseLineID(RecurringPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.RecurringPurchaseLineID =GetInt32(_reader, ("RecurringPurchaseLineID"));
            _obj.RecurringPurchaseID =GetInt32(_reader, ("RecurringPurchaseID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
        }

        protected override object GetDbProperty(RecurringPurchaseLine _obj, string property_name)
        {
            if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if(property_name.Equals("RecurringPurchase"))
            {
                return RepositoryMgr.RecurringPurchaseMgr.FindById(_obj.RecurringPurchaseID);
            }
            return null;
        }

        protected override IList<RecurringPurchaseLine>_FindAllCollection()
        {
            List<RecurringPurchaseLine> _grp = new List<RecurringPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
