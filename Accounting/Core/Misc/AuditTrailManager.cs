using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public abstract class AuditTrailManager : EntityManager<AuditTrail>
    {
        public AuditTrailManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override AuditTrail _CreateDbEntity()
        {
            return new AuditTrail(true, this);
        }
        protected override AuditTrail _CreateEntity()
        {
            return new AuditTrail(false, this);
        }
        #endregion

        protected override void LoadFromReader(AuditTrail _obj, DbDataReader reader)
        {
            _obj.AuditTrailID = GetInt32(reader, "AuditTrailID");
            _obj.AuditTypeID = GetString(reader, "AuditTypeID");
            _obj.ChangeDate = GetDateTime(reader, "ChangeDate");
            _obj.Description = GetString(reader, "Description");
            _obj.IsReconciled = GetString(reader, "IsReconciled");
            _obj.OriginalDate = GetDateTime(reader, "OriginalDate");
            _obj.TransactionNumber = GetString(reader, "TransactionNumber");
            _obj.UserID = GetInt32(reader, "UserID");
            _obj.WasThirteenthPeriod = GetString(reader, "WasThirteenthPeriod");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AuditTrail _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AuditTrailID"] = DbMgr.CreateIntFieldEntry(_obj.AuditTrailID); //GetInt32(reader, "");
            fields["AuditTypeID"] = DbMgr.CreateStringFieldEntry(_obj.AuditTypeID); //GetString(reader, "");
            fields["ChangeDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.ChangeDate); //GetDateTime(reader, "");
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description); //GetString(reader, "");
            fields["IsReconciled"] = DbMgr.CreateStringFieldEntry(_obj.IsReconciled); //GetString(reader, "");
            fields["OriginalDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.OriginalDate); //GetDateTime(reader, "");
            fields["TransactionNumber"] = DbMgr.CreateStringFieldEntry(_obj.TransactionNumber); //GetString(reader, "");
            fields["UserID"] = DbMgr.CreateIntFieldEntry(_obj.UserID); //GetInt32(reader, "");
            fields["WasThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.WasThirteenthPeriod); //GetString(reader, "");

            return fields;
        }

        protected override object GetDbProperty(AuditTrail _obj, string property_name)
        {
            if (property_name.Equals("User"))
            {
                return RepositoryMgr.AuthUserMgr.FindByUserID(_obj.UserID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("AuditTrail");
        }

        private DbSelectStatement GetQuery_SelectByAuditTrailID(int AuditTrailID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("AuditTrail")
                .Criteria
                    .IsEqual("AuditTrail", "AuditTrailID", AuditTrailID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByAuditTrailID(int AuditTrailID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("AuditTrail")
                .Criteria
                    .IsEqual("AuditTrail", "AuditTrailID", AuditTrailID);

            return clause;
        }

        public bool Exists(int? AuditTrailID)
        {
            if (AuditTrailID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAuditTrailID(AuditTrailID.Value)) != 0;
        }

        public override bool Exists(AuditTrail _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.AuditTrailID);
        }

        protected override AuditTrail _FindByIntId(int? AuditTrailID)
        {
            if (AuditTrailID == null) return null;
            AuditTrail _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByAuditTrailID(AuditTrailID.Value));
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

        protected override IList<AuditTrail>_FindAllCollection()
        {
            List<AuditTrail> _grp = new List<AuditTrail>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                AuditTrail _obj =CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
