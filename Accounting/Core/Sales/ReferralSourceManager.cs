using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class ReferralSourceManager : EntityManager<ReferralSource>
    {
        public ReferralSourceManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override ReferralSource _CreateDbEntity()
        {
            return new ReferralSource(true, this);
        }

        protected override ReferralSource _CreateEntity()
        {
            return new ReferralSource(false, this);
        }
        #endregion

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ReferralSources");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ReferralSource _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ReferralSourceID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ReferralSourceID);
            fields["ReferralSource"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectByReferralSourceID(int ReferralSourceID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ReferralSources")
                .Criteria
                    .IsEqual("ReferralSources", "ReferralSourceID", ReferralSourceID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountbyInvoiceDeliverID(int ReferralSourceID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ReferralSources")
                .Criteria
                    .IsEqual("ReferralSources", "ReferralSourceID", ReferralSourceID);

            return clause;
        }

     
        private bool Exists(int? ReferralSourceID)
        {
            if (ReferralSourceID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountbyInvoiceDeliverID(ReferralSourceID.Value)) != 0;
        }

        public override bool Exists(ReferralSource _obj)
        {
            return Exists(_obj.ReferralSourceID);
        }

        protected override void LoadFromReader(ReferralSource _obj, DbDataReader _reader)
        {
            _obj.ReferralSourceID =GetInt32(_reader, ("ReferralSourceID"));
            _obj.Description = GetString(_reader, "ReferralSource", "Description");
        }

        protected override ReferralSource _FindByIntId(int? ReferralSourceID)
        {
            if (Exists(ReferralSourceID))
            {
                ReferralSource _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByReferralSourceID(ReferralSourceID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<ReferralSource>_FindAllCollection()
        {
            List<ReferralSource> objs = new List<ReferralSource>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ReferralSource _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
