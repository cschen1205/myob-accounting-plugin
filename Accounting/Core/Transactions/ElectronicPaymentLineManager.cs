using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class ElectronicPaymentLineManager : EntityManager<ElectronicPaymentLine>
    {
        public ElectronicPaymentLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ElectronicPaymentLine _CreateDbEntity()
        {
            return new ElectronicPaymentLine(true, this);
        }
        protected override ElectronicPaymentLine _CreateEntity()
        {
            return new ElectronicPaymentLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(ElectronicPaymentLine _obj, DbDataReader reader)
        {
            _obj.ElectronicPaymentLineID = GetInt32(reader, "ElectronicPaymentLineID");
            _obj.ElectronicPaymentID = GetInt32(reader, "ElectronicPaymentID");
            _obj.SourceID = GetInt32(reader, "SourceID");
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.AmountPaid = GetDouble(reader, "AmountPaid");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ElectronicPaymentLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ElectronicPaymentLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ElectronicPaymentLineID); //GetInt32(reader, "ElectronicPaymentLineID");
            fields["ElectronicPaymentID"] = DbMgr.CreateIntFieldEntry(_obj.ElectronicPaymentID); //GetInt32(reader, "ElectronicPaymentID");
            fields["SourceID"] = DbMgr.CreateIntFieldEntry(_obj.SourceID); //GetInt32(reader, "SourceID");
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID); //GetString(reader, "JournalTypeID");
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID); //GetString(reader, "PaymentStatusID");
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); //GetInt32(reader, "LineNumber");
            fields["AmountPaid"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid); //GetDouble(reader, "AmountPaid");
           
            return fields;
        }

        protected override object GetDbProperty(ElectronicPaymentLine _obj, string property_name)
        {
            if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            else if (property_name.Equals("PaymentStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.PaymentStatusID);
            }
            else if (property_name.Equals("ElectronicPayment"))
            {
                return RepositoryMgr.ElectronicPaymentMgr.FindById(_obj.ElectronicPaymentID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ElectronicPaymentLines");
        }

        private DbSelectStatement GetQuery_SelectByElectronicPaymentLineID(int ElectronicPaymentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ElectronicPaymentLines")
                .Criteria
                    .IsEqual("ElectronicPaymentLines", "ElectronicPaymentLineID", ElectronicPaymentLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByElectronicPaymentLineID(int ElectronicPaymentLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ElectronicPaymentLines")
                .Criteria
                    .IsEqual("ElectronicPaymentLines", "ElectronicPaymentLineID", ElectronicPaymentLineID);

            return clause;
        }

        public bool Exists(int? ElectronicPaymentLineID)
        {
            if (ElectronicPaymentLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByElectronicPaymentLineID(ElectronicPaymentLineID.Value)) != 0;
        }

        public override bool Exists(ElectronicPaymentLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ElectronicPaymentLineID);
        }

        protected override ElectronicPaymentLine _FindByIntId(int? ElectronicPaymentLineID)
        {
            if (ElectronicPaymentLineID == null) return null;
            ElectronicPaymentLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByElectronicPaymentLineID(ElectronicPaymentLineID.Value));
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

        protected override IList<ElectronicPaymentLine>_FindAllCollection()
        {
            List<ElectronicPaymentLine> _grp = new List<ElectronicPaymentLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ElectronicPaymentLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
