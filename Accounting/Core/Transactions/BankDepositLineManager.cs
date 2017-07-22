using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public class BankDepositLineManager : EntityManager<BankDepositLine>
    {
        public BankDepositLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BankDepositLine _CreateDbEntity()
        {
            return new BankDepositLine(true, this);
        }
        protected override BankDepositLine _CreateEntity()
        {
            return new BankDepositLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(BankDepositLine _obj, DbDataReader reader)
        {
            _obj.AmountDeposited = GetDouble(reader, "AmountDeposited");
            _obj.BankDepositID = GetInt32(reader, "BankDepositID");
            _obj.BankDepositLineID = GetInt32(reader, "BankDepositLineID");
            _obj.DepositStatusID = GetString(reader, "DepositStatusID");
            _obj.JournalTypeID = GetString(reader, "JournalTypeID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.SourceID = GetInt32(reader, "SourceID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(BankDepositLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AmountDeposited"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountDeposited); //GetDouble(reader, "AmountDeposited");
            fields["BankDepositID"] = DbMgr.CreateIntFieldEntry(_obj.BankDepositID); //GetInt32(reader, "BankDepositID");
            fields["BankDepositLineID"] = DbMgr.CreateIntFieldEntry(_obj.BankDepositLineID); //GetInt32(reader, "BankDepositLineID");
            fields["DepositStatusID"] = DbMgr.CreateStringFieldEntry(_obj.DepositStatusID); //GetString(reader, "DepositStatusID");
            fields["JournalTypeID"] = DbMgr.CreateStringFieldEntry(_obj.JournalTypeID); //GetString(reader, "JournalTypeID");
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); //GetInt32(reader, "LineNumber");
            fields["SourceID"] = DbMgr.CreateIntFieldEntry(_obj.SourceID); //GetInt32(reader, "SourceID");

            return fields;
        }

        protected override object GetDbProperty(BankDepositLine _obj, string property_name)
        {
            if(property_name.Equals("DepositStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.DepositStatusID);
            }
            else if (property_name.Equals("JournalType"))
            {
                return RepositoryMgr.JournalTypeMgr.FindById(_obj.JournalTypeID);
            }
            else if (property_name.Equals("DepositStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.DepositStatusID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("BankDepositLines");
        }

        private DbSelectStatement GetQuery_SelectByBankDepositLineID(int BankDepositLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("BankDepositLines")
                .Criteria
                    .IsEqual("BankDepositLines", "BankDepositLineID", BankDepositLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBankDepositLineID(int BankDepositLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("BankDepositLines")
                .Criteria
                    .IsEqual("BankDepositLines", "BankDepositLineID", BankDepositLineID);

            return clause;
        }

        public bool Exists(int? BankDepositLineID)
        {
            if (BankDepositLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByBankDepositLineID(BankDepositLineID.Value)) != 0;
        }


        public override bool Exists(BankDepositLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.BankDepositLineID);
        }

        protected override BankDepositLine _FindByIntId(int? BankDepositLineID)
        {
            if (BankDepositLineID == null) return null;

            BankDepositLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByBankDepositLineID(BankDepositLineID.Value));
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

        protected override IList<BankDepositLine>_FindAllCollection()
        {
            List<BankDepositLine> _grp = new List<BankDepositLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                BankDepositLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
