using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class SuperannuationManager : EntityManager<Superannuation>
    {
        public SuperannuationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override Superannuation _CreateDbEntity()
        {
            return new Superannuation(true, this);
        }
        protected override Superannuation _CreateEntity()
        {
            return new Superannuation(false, this);
        }
        #endregion

        protected override void LoadFromReader(Superannuation _obj, DbDataReader reader)
        {

            _obj.SuperannuationID = GetInt32(reader, "SuperannuationID");
           
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Superannuation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();


           

            return fields;
        }

        protected override object GetDbProperty(Superannuation _obj, string property_name)
        {
            if (property_name.Equals("ExpenseAccountID"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.ExpenseAccountID);
            }
 
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll().From("Superannuation");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySuperannuationID(int SuperannuationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("Superannuation")
                .Criteria
                    .IsEqual("Superannuation", "SuperannuationID", SuperannuationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySuperannuationID(int SuperannuationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("Superannuation")
                .Criteria
                    .IsEqual("Superannuation", "SuperannuationID", SuperannuationID);

            return clause;
        }

        public bool Exists(int? SuperannuationID)
        {
            if (SuperannuationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySuperannuationID(SuperannuationID.Value)) != 0;
        }

        public override bool Exists(Superannuation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SuperannuationID);
        }

        protected override Superannuation _FindByIntId(int? SuperannuationID)
        {
            if (SuperannuationID == null) return null;
            Superannuation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySuperannuationID(SuperannuationID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj =CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override IList<Superannuation>_FindAllCollection()
        {
            List<Superannuation> _grp = new List<Superannuation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Superannuation _obj =CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
