using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class InvoiceTypeManager : EntityManager<InvoiceType>
    {
        public InvoiceTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override InvoiceType _CreateDbEntity()
        {
            return new InvoiceType(true, this);
        }

        protected override InvoiceType _CreateEntity()
        {
            return new InvoiceType(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(InvoiceType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["InvoiceTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.InvoiceTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private InvoiceType mDefaultInvoiceType=null;
        public InvoiceType DefaultInvoiceType
        {
            get
            {
                if (mDefaultInvoiceType == null)
                {
                    mDefaultInvoiceType = CreateEntity();
                }
                return mDefaultInvoiceType;
            }
        }
        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InvoiceType");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByInvoiceTypeID(string InvoiceTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InvoiceType")
                .Criteria.IsEqual("InvoiceType", "InvoiceTypeID", InvoiceTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInvoiceTypeID(string InvoiceTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("InvoiceType")
                .Criteria.IsEqual("InvoiceType", "InvoiceTypeID", InvoiceTypeID);

            return clause;
        }

        private bool Exists(string InvoiceTypeID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByInvoiceTypeID(InvoiceTypeID)) != 0;
        }

        public override bool Exists(InvoiceType _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByInvoiceTypeID(_obj.InvoiceTypeID)) != 0;
        }

        protected override void LoadFromReader(InvoiceType _obj, DbDataReader reader)
        {
            _obj.InvoiceTypeID =GetString(reader, ("InvoiceTypeID"));
            _obj.Description =GetString(reader, ("Description"));
        }

        protected override InvoiceType _FindByTextId(string InvoiceTypeID)
        {
            if (Exists(InvoiceTypeID))
            {
                InvoiceType _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByInvoiceTypeID(InvoiceTypeID));
                return _obj;
            }
            else
            {
                return DefaultInvoiceType;
            }
        }

        protected override IList<InvoiceType>_FindAllCollection()
        {
            List<InvoiceType> objs = new List<InvoiceType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                InvoiceType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
