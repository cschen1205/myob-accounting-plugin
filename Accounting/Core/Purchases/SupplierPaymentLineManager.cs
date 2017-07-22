using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SupplierPaymentLineManager : EntityManager<SupplierPaymentLine>
    {
        public SupplierPaymentLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SupplierPaymentLine _CreateDbEntity()
        {
            return new SupplierPaymentLine(true, this);
        }
        protected override SupplierPaymentLine _CreateEntity()
        {
            return new SupplierPaymentLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(SupplierPaymentLine _obj, DbDataReader reader)
        {
            _obj.AmountApplied = GetDouble(reader, "AmountApplied");
            _obj.SupplierPaymentID = GetInt32(reader, "SupplierPaymentID");
            _obj.SupplierPaymentLineID = GetInt32(reader, "SupplierPaymentLineID");
            _obj.IsDepositPayment = GetString(reader, "IsDepositPayment");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.PurchaseID = GetInt32(reader, "PurchaseID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SupplierPaymentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AmountApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountApplied);
            fields["SupplierPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.SupplierPaymentID);
            fields["SupplierPaymentLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SupplierPaymentLineID);
            fields["IsDepositPayment"] = DbMgr.CreateStringFieldEntry(_obj.IsDepositPayment);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID);

            return fields;
        }

        protected override object GetDbProperty(SupplierPaymentLine _obj, string property_name)
        {
            if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            else if (property_name.Equals("SupplierPayment"))
            {
                return RepositoryMgr.SupplierPaymentMgr.FindById(_obj.SupplierPaymentID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("SupplierPaymentLines");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySupplierPaymentLineID(int SupplierPaymentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierPaymentLines")
                .Criteria
                    .IsEqual("SupplierPaymentLines", "SupplierPaymentLineID", SupplierPaymentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySupplierPaymentLineID(int SupplierPaymentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SupplierPaymentLines")
                .Criteria
                    .IsEqual("SupplierPaymentLines", "SupplierPaymentLineID", SupplierPaymentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAllBySupplierPaymentID(int SupplierPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SupplierPaymentLines")
                .Criteria
                    .IsEqual("SupplierPaymentLines", "SupplierPaymentID", SupplierPaymentID);
            return clause;
        }


        public bool Exists(int? SupplierPaymentLineID)
        {
            if (SupplierPaymentLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySupplierPaymentLineID(SupplierPaymentLineID.Value)) != 0;
        }

        public override bool Exists(SupplierPaymentLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SupplierPaymentLineID);
        }

        protected override SupplierPaymentLine _FindByIntId(int? SupplierPaymentLineID)
        {
            if (SupplierPaymentLineID == null) return null;

            SupplierPaymentLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySupplierPaymentLineID(SupplierPaymentLineID.Value));
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

        protected override IList<SupplierPaymentLine>_FindAllCollection()
        {
            List<SupplierPaymentLine> _grp = new List<SupplierPaymentLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierPaymentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }

        public List<SupplierPaymentLine> List(int? SupplierPaymentID)
        {
            List<SupplierPaymentLine> _grp = new List<SupplierPaymentLine>();

            if (SupplierPaymentID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAllBySupplierPaymentID(SupplierPaymentID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SupplierPaymentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }
    }
}
