using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class CustomerDiscountLineManager : EntityManager<CustomerDiscountLine>
    {
        public CustomerDiscountLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CustomerDiscountLine _CreateDbEntity()
        {
            return new CustomerDiscountLine(true, this);
        }
        protected override CustomerDiscountLine _CreateEntity()
        {
            return new CustomerDiscountLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(CustomerDiscountLine _obj, DbDataReader reader)
        {
            _obj.AmountApplied = GetDouble(reader, "AmountApplied");
            _obj.CustomerDiscountID = GetInt32(reader, "CustomerDiscountID");
            _obj.CustomerDiscountLineID = GetInt32(reader, "CustomerDiscountLineID");
            _obj.IsDepositPayment = GetString(reader, "IsDepositPayment");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.SaleID = GetInt32(reader, "SaleID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CustomerDiscountLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AmountApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountApplied);
            fields["CustomerDiscountID"] = DbMgr.CreateIntFieldEntry(_obj.CustomerDiscountID);
            fields["CustomerDiscountLineID"] = DbMgr.CreateIntFieldEntry(_obj.CustomerDiscountLineID);
            fields["IsDepositPayment"] = DbMgr.CreateStringFieldEntry(_obj.IsDepositPayment);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);

            return fields;
        }

        protected override object GetDbProperty(CustomerDiscountLine _obj, string property_name)
        {
            if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            else if (property_name.Equals("CustomerDiscount"))
            {
                return RepositoryMgr.CustomerDiscountMgr.FindById(_obj.CustomerDiscountID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("CustomerDiscountLines");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCustomerDiscountLineID(int CustomerDiscountLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerDiscountLines")
                .Criteria
                    .IsEqual("CustomerDiscountLines", "CustomerDiscountLineID", CustomerDiscountLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomerDiscountLineID(int CustomerDiscountLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CustomerDiscountLines")
                .Criteria
                    .IsEqual("CustomerDiscountLines", "CustomerDiscountLineID", CustomerDiscountLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAllByCustomerDiscountID(int CustomerDiscountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerDiscountLines")
                .Criteria
                    .IsEqual("CustomerDiscountLines", "CustomerDiscountID", CustomerDiscountID);
            return clause;
        }


        public bool Exists(int? CustomerDiscountLineID)
        {
            if (CustomerDiscountLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomerDiscountLineID(CustomerDiscountLineID.Value)) != 0;
        }

        public override bool Exists(CustomerDiscountLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CustomerDiscountLineID);
        }

        protected override CustomerDiscountLine _FindByIntId(int? CustomerDiscountLineID)
        {
            if (CustomerDiscountLineID == null) return null;

            CustomerDiscountLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCustomerDiscountLineID(CustomerDiscountLineID.Value));
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

        protected override IList<CustomerDiscountLine>_FindAllCollection()
        {
            List<CustomerDiscountLine> _grp = new List<CustomerDiscountLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerDiscountLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }

        public List<CustomerDiscountLine> List(int? CustomerDiscountID)
        {
            List<CustomerDiscountLine> _grp = new List<CustomerDiscountLine>();

            if (CustomerDiscountID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAllByCustomerDiscountID(CustomerDiscountID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerDiscountLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }
    }
}
