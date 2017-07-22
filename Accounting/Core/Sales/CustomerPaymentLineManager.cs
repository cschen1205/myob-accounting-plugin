using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class CustomerPaymentLineManager : EntityManager<CustomerPaymentLine>
    {
        public CustomerPaymentLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CustomerPaymentLine _CreateDbEntity()
        {
            return new CustomerPaymentLine(true, this);
        }
        protected override CustomerPaymentLine _CreateEntity()
        {
            return new CustomerPaymentLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(CustomerPaymentLine _obj, DbDataReader reader)
        {
            _obj.AmountApplied = GetDouble(reader, "AmountApplied");
            _obj.CustomerPaymentID = GetInt32(reader, "CustomerPaymentID");
            _obj.CustomerPaymentLineID = GetInt32(reader, "CustomerPaymentLineID");
            _obj.IsDepositPayment = GetString(reader, "IsDepositPayment");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.SaleID = GetInt32(reader, "SaleID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CustomerPaymentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AmountApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountApplied);
            fields["CustomerPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.CustomerPaymentID);
            fields["CustomerPaymentLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CustomerPaymentLineID);
            fields["IsDepositPayment"] = DbMgr.CreateStringFieldEntry(_obj.IsDepositPayment);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);

            return fields;
        }

        protected override object GetDbProperty(CustomerPaymentLine _obj, string property_name)
        {
            if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            else if (property_name.Equals("CustomerPayment"))
            {
                return RepositoryMgr.CustomerPaymentMgr.FindById(_obj.CustomerPaymentID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll().From("CustomerPaymentLines");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCustomerPaymentLineID(int CustomerPaymentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerPaymentLines")
                .Criteria
                    .IsEqual("CustomerPaymentLines", "CustomerPaymentLineID", CustomerPaymentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomerPaymentLineID(int CustomerPaymentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CustomerPaymentLines")
                .Criteria
                    .IsEqual("CustomerPaymentLines", "CustomerPaymentLineID", CustomerPaymentLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAllByCustomerPaymentID(int CustomerPaymentID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomerPaymentLines")
                .Criteria
                    .IsEqual("CustomerPaymentLines", "CustomerPaymentID", CustomerPaymentID);
            return clause;
        }


        public bool Exists(int? CustomerPaymentLineID)
        {
            if (CustomerPaymentLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomerPaymentLineID(CustomerPaymentLineID.Value)) != 0;
        }

        public override bool Exists(CustomerPaymentLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CustomerPaymentLineID);
        }

        protected override CustomerPaymentLine _FindByIntId(int? CustomerPaymentLineID)
        {
            if (CustomerPaymentLineID == null) return null;

            CustomerPaymentLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCustomerPaymentLineID(CustomerPaymentLineID.Value));
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

        protected override IList<CustomerPaymentLine>_FindAllCollection()
        {
            List<CustomerPaymentLine> _grp = new List<CustomerPaymentLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerPaymentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }

        public List<CustomerPaymentLine> List(int? CustomerPaymentID)
        {
            List<CustomerPaymentLine> _grp = new List<CustomerPaymentLine>();

            if (CustomerPaymentID == null) return _grp;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAllByCustomerPaymentID(CustomerPaymentID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomerPaymentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();
            return _grp;
        }
    }
}
