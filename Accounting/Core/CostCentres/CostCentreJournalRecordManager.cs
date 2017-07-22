using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.CostCentres
{
    public abstract class CostCentreJournalRecordManager : EntityManager<CostCentreJournalRecord>
    {
        public CostCentreJournalRecordManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CostCentreJournalRecord _CreateDbEntity()
        {
            return new CostCentreJournalRecord(true, this);
        }
        protected override CostCentreJournalRecord _CreateEntity()
        {
            return new CostCentreJournalRecord(false, this);
        }
        #endregion

        protected override void LoadFromReader(CostCentreJournalRecord _obj, DbDataReader reader)
        {
           
            _obj.CostCentreJournalRecordID = GetInt32(reader, "CostCentreJournalRecordID");
            _obj.TransactionNumber = GetString(reader, "TransactionNumber");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.TaxExclusiveAmount = GetDouble(reader, "TaxExclusiveAmount");
            _obj.JournalRecordID = GetInt32(reader, "JournalRecordID");
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CostCentreJournalRecord _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CostCentreJournalRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreJournalRecordID); //GetInt32(reader, "CostCentreJournalRecordID");
            fields["TransactionNumber"] = DbMgr.CreateStringFieldEntry(_obj.TransactionNumber); //GetString(reader, "TransactionNumber");
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); //GetDateTime(reader, "TransactionDate");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); //fields[""]=DbMgr.CreateIntFieldEntry(_obj.TransactionDate;
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); //GetString(reader, "IsThirteenthPeriod");
            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID); //GetInt32(reader, "CostCentreID");
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID); //GetInt32(reader, "AccountID");
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount); //GetDouble(reader, "TaxExclusiveAmount");
            fields["JournalRecordID"] = DbMgr.CreateIntFieldEntry(_obj.JournalRecordID); //GetInt32(reader, "JournalRecordID");
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID); //GetString(reader, "JournalTypeID");

            return fields;
        }

        protected override object GetDbProperty(CostCentreJournalRecord _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("CostCentre"))
            {
                return RepositoryMgr.CostCentreMgr.FindById(_obj.CostCentreID);
            }
            else if (property_name.Equals("JournalRecord"))
            {
                return RepositoryMgr.JournalRecordMgr.FindById(_obj.JournalRecordID);
            }
            else if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("CostCentreJournalRecords");
        }

        private DbSelectStatement GetQuery_SelectByCostCentreJournalRecordID(int CostCentreJournalRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("CostCentreJournalRecords")
                .Criteria
                    .IsEqual("CostCentreJournalRecords", "CostCentreJournalRecordID", CostCentreJournalRecordID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCostCentreJournalRecordID(int CostCentreJournalRecordID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("CostCentreJournalRecords")
                .Criteria
                    .IsEqual("CostCentreJournalRecords", "CostCentreJournalRecordID", CostCentreJournalRecordID);

            return clause;
        }

        public bool Exists(int? CostCentreJournalRecordID)
        {
            if (CostCentreJournalRecordID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCostCentreJournalRecordID(CostCentreJournalRecordID.Value)) != 0;
        }

        public override bool Exists(CostCentreJournalRecord _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CostCentreJournalRecordID);
        }

        protected override CostCentreJournalRecord _FindByIntId(int? CostCentreJournalRecordID)
        {
            if (CostCentreJournalRecordID == null) return null;

            CostCentreJournalRecord _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCostCentreJournalRecordID(CostCentreJournalRecordID.Value));
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

        protected override IList<CostCentreJournalRecord>_FindAllCollection()
        {
            List<CostCentreJournalRecord> _grp = new List<CostCentreJournalRecord>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CostCentreJournalRecord _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
