using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class SettledCreditLineManager : EntityManager<SettledCreditLine>
    {
        public SettledCreditLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SettledCreditLine _CreateDbEntity()
        {
            return new SettledCreditLine(true, this);
        }
        protected override SettledCreditLine _CreateEntity()
        {
            return new SettledCreditLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(SettledCreditLine _obj, DbDataReader reader)
        {
            _obj.AmountApplied = GetDouble(reader, "AmountApplied");
            _obj.IsDepositPayment = GetString(reader, "IsDepositPayment");
            _obj.IsDiscount = GetString(reader, "IsDiscount");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.SaleID = GetInt32(reader, "SaleID");
            _obj.SettledCreditLineID = GetInt32(reader, "SettledCreditLineID");
            _obj.SettledCreditID = GetInt32(reader, "SettledCreditID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SettledCreditLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountApplied); 
            fields["IsDepositPayment"] = DbMgr.CreateStringFieldEntry(_obj.IsDepositPayment); 
            fields["IsDiscount"] = DbMgr.CreateStringFieldEntry(_obj.IsDiscount); 
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); 
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID); 
            fields["SettledCreditLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SettledCreditLineID); 
            fields["SettledCreditID"] = DbMgr.CreateIntFieldEntry(_obj.SettledCreditID); 

            return fields;
        }

        protected override object GetDbProperty(SettledCreditLine _obj, string property_name)
        {
            if (property_name.Equals("SettledCredit"))
            {
                return RepositoryMgr.SettledCreditMgr.FindById(_obj.SettledCreditID);
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("SettledCreditLines");
        }

        private DbSelectStatement GetQuery_SelectBySettledCreditLineID(int SettledCreditLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SettledCreditLines")
                .Criteria
                    .IsEqual("SettledCreditLines", "SettledCreditLineID", SettledCreditLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySettledCreditLineID(int SettledCreditLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SettledCreditLines")
                .Criteria
                    .IsEqual("SettledCreditLines", "SettledCreditLineID", SettledCreditLineID);
            return clause;
        }

        public bool Exists(int? SettledCreditLineID)
        {
            if (SettledCreditLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySettledCreditLineID(SettledCreditLineID.Value)) != 0;
        }

        public override bool Exists(SettledCreditLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SettledCreditLineID);
        }

        protected override SettledCreditLine _FindByIntId(int? SettledCreditLineID)
        {
            if (SettledCreditLineID == null) return null;

            SettledCreditLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySettledCreditLineID(SettledCreditLineID.Value));
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

        protected override IList<SettledCreditLine>_FindAllCollection()
        {
            List<SettledCreditLine> _grp = new List<SettledCreditLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SettledCreditLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Read();
            _cmd.Dispose();

            return _grp;
        }
    }
}
