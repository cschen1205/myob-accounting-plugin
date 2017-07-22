using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class InventoryTransferManager : EntityManager<InventoryTransfer>
    {
        public InventoryTransferManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override InventoryTransfer _CreateDbEntity()
        {
            return new InventoryTransfer(true, this);
        }
        protected override InventoryTransfer _CreateEntity()
        {
            return new InventoryTransfer(false, this);
        }
        #endregion

        protected override void LoadFromReader(InventoryTransfer _obj, DbDataReader reader)
        {
            _obj.CostCentreID = GetInt32(reader, "CostCentreID");
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.InventoryJournalNumber = GetString(reader, "InventoryJournalNumber");
            _obj.InventoryTransferID = GetInt32(reader, "InventoryTransferID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(InventoryTransfer _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CostCentreID"] = DbMgr.CreateIntFieldEntry(_obj.CostCentreID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["InventoryJournalNumber"] = DbMgr.CreateStringFieldEntry(_obj.InventoryJournalNumber);
            fields["InventoryTransferID"] = DbMgr.CreateAutoIntFieldEntry(_obj.InventoryTransferID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); 

            return fields;
        }

        protected override object GetDbProperty(InventoryTransfer _obj, string property_name)
        {
            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("InventoryTransfers");
        }

        private DbSelectStatement GetQuery_SelectByInventoryTransferID(int InventoryTransferID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("InventoryTransfers")
                .Criteria
                    .IsEqual("InventoryTransfers", "InventoryTransferID", InventoryTransferID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInventoryTransferID(int InventoryTransferID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("InventoryTransfers")
                .Criteria
                    .IsEqual("InventoryTransfers", "InventoryTransferID", InventoryTransferID);

            return clause;
        }

        public bool Exists(int? InventoryTransferID)
        {
            if (InventoryTransferID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByInventoryTransferID(InventoryTransferID.Value)) != 0;
        }

        public override bool Exists(InventoryTransfer _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.InventoryTransferID);
        }

        protected override InventoryTransfer _FindByIntId(int? InventoryTransferID)
        {
            InventoryTransfer _obj = null;
            if (InventoryTransferID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByInventoryTransferID(InventoryTransferID.Value));
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

        protected override IList<InventoryTransfer>_FindAllCollection()
        {
            List<InventoryTransfer> _grp = new List<InventoryTransfer>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                InventoryTransfer _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
