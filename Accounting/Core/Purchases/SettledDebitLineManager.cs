using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class SettledDebitLineManager : EntityManager<SettledDebitLine>
    {
        public SettledDebitLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SettledDebitLine _CreateDbEntity()
        {
            return new SettledDebitLine(true, this);
        }
        protected override SettledDebitLine _CreateEntity()
        {
            return new SettledDebitLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(SettledDebitLine _obj, DbDataReader reader)
        {
            _obj.AmountApplied = GetDouble(reader, "AmountApplied");
            _obj.IsDepositPayment = GetString(reader, "IsDepositPayment");
            _obj.IsDiscount = GetString(reader, "IsDiscount");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.PurchaseID = GetInt32(reader, "PurchaseID");
            _obj.SettledDebitLineID = GetInt32(reader, "SettledDebitLineID");
            _obj.SettledDebitID = GetInt32(reader, "SettledDebitID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SettledDebitLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountApplied"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountApplied); 
            fields["IsDepositPayment"] = DbMgr.CreateStringFieldEntry(_obj.IsDepositPayment); 
            fields["IsDiscount"] = DbMgr.CreateStringFieldEntry(_obj.IsDiscount); 
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); 
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID); 
            fields["SettledDebitLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SettledDebitLineID); 
            fields["SettledDebitID"] = DbMgr.CreateIntFieldEntry(_obj.SettledDebitID); 

            return fields;
        }

        protected override object GetDbProperty(SettledDebitLine _obj, string property_name)
        {
            if (property_name.Equals("SettledDebit"))
            {
                return RepositoryMgr.SettledDebitMgr.FindById(_obj.SettledDebitID);
            }
            else if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("SettledDebitLines");
        }

        private DbSelectStatement GetQuery_SelectBySettledDebitLineID(int SettledDebitLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SettledDebitLines")
                .Criteria
                    .IsEqual("SettledDebitLines", "SettledDebitLineID", SettledDebitLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySettledDebitLineID(int SettledDebitLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SettledDebitLines")
                .Criteria
                    .IsEqual("SettledDebitLines", "SettledDebitLineID", SettledDebitLineID);
            return clause;
        }

        public bool Exists(int? SettledDebitLineID)
        {
            if (SettledDebitLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySettledDebitLineID(SettledDebitLineID.Value)) != 0;
        }

        public override bool Exists(SettledDebitLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SettledDebitLineID);
        }

        protected override SettledDebitLine _FindByIntId(int? SettledDebitLineID)
        {
            if (SettledDebitLineID == null) return null;

            SettledDebitLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySettledDebitLineID(SettledDebitLineID.Value));
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

        protected override IList<SettledDebitLine>_FindAllCollection()
        {
            List<SettledDebitLine> _grp = new List<SettledDebitLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SettledDebitLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Read();
            _cmd.Dispose();

            return _grp;
        }
    }
}
