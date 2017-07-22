using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SupplierDiscountLineManager : EntityManager<SupplierDiscountLine>
    {
        public SupplierDiscountLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SupplierDiscountLine _CreateDbEntity()
        {
            return new SupplierDiscountLine(true, this);
        }
        protected override SupplierDiscountLine _CreateEntity()
        {
            return new SupplierDiscountLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(SupplierDiscountLine _obj, DbDataReader reader)
        {
            _obj.AmountApplied = GetDouble(reader, "AmountApplied");
            _obj.SupplierDiscountID = GetInt32(reader, "SupplierDiscountID");
            _obj.SupplierDiscountLineID = GetInt32(reader, "SupplierDiscountLineID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.PurchaseID = GetInt32(reader, "PurchaseID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SupplierDiscountLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AmountApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountApplied);
            fields["SupplierDiscountID"] = DbMgr.CreateIntFieldEntry(_obj.SupplierDiscountID);
            fields["SupplierDiscountLineID"] = DbMgr.CreateIntFieldEntry(_obj.SupplierDiscountLineID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID);

            return fields;
        }

        protected override object GetDbProperty(SupplierDiscountLine _obj, string property_name)
        {
            if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            else if (property_name.Equals("SupplierDiscount"))
            {
                return RepositoryMgr.SupplierDiscountMgr.FindById(_obj.SupplierDiscountID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("SupplierDiscountLines");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySupplierDiscountLineID(int SupplierDiscountLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierDiscountLines")
                .Criteria
                    .IsEqual("SupplierDiscountLines", "SupplierDiscountLineID", SupplierDiscountLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierDiscountLineID(int SupplierDiscountLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SupplierDiscountLines")
                .Criteria
                    .IsEqual("SupplierDiscountLines", "SupplierDiscountLineID", SupplierDiscountLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAllBySupplierDiscountID(int SupplierDiscountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierDiscountLines")
                .Criteria
                    .IsEqual("SupplierDiscountLines", "SupplierDiscountID", SupplierDiscountID);
            return clause;
        }


        public bool Exists(int? SupplierDiscountLineID)
        {
            if (SupplierDiscountLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierDiscountLineID(SupplierDiscountLineID.Value)) != 0;
        }

        public override bool Exists(SupplierDiscountLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SupplierDiscountLineID);
        }

        protected override SupplierDiscountLine _FindByIntId(int? SupplierDiscountLineID)
        {
            if (SupplierDiscountLineID == null) return null;

            SupplierDiscountLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySupplierDiscountLineID(SupplierDiscountLineID.Value));
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

        protected override IList<SupplierDiscountLine>_FindAllCollection()
        {
            List<SupplierDiscountLine> _grp = new List<SupplierDiscountLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierDiscountLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }

        public List<SupplierDiscountLine> List(int? SupplierDiscountID)
        {
            List<SupplierDiscountLine> _grp = new List<SupplierDiscountLine>();

            if (SupplierDiscountID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAllBySupplierDiscountID(SupplierDiscountID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierDiscountLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }
    }
}
