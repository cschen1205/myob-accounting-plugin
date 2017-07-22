using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class InvoiceDeliveryManager : EntityManager<InvoiceDelivery>
    {
        public InvoiceDeliveryManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override InvoiceDelivery _CreateDbEntity()
        {
            return new InvoiceDelivery(true, this);
        }

        protected override InvoiceDelivery _CreateEntity()
        {
            return new InvoiceDelivery(false, this);
        }


        public override Dictionary<string, DbFieldEntry> GetFields(InvoiceDelivery _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["InvoiceDeliveryID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InvoiceDelivery");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByInvoiceDeliveryID(string InvoiceDeliveryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("InvoiceDelivery")
                .Criteria.IsEqual("InvoiceDelivery", "InvoiceDeliveryID", InvoiceDeliveryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountbyInvoiceDeliverID(string InvoiceDeliveryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("InvoiceDelivery")
                .Criteria.IsEqual("InvoiceDelivery", "InvoiceDeliveryID", InvoiceDeliveryID);

            return clause;
        }

        private bool Exists(string InvoiceDeliveryID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountbyInvoiceDeliverID(InvoiceDeliveryID)) != 0;
        }

        public override bool Exists(InvoiceDelivery _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountbyInvoiceDeliverID(_obj.InvoiceDeliveryID)) != 0;
        }

        protected override void LoadFromReader(InvoiceDelivery _obj, DbDataReader _reader)
        {
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        protected override InvoiceDelivery _FindByTextId(string InvoiceDeliveryID)
        {
            if (Exists(InvoiceDeliveryID))
            {
                InvoiceDelivery _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByInvoiceDeliveryID(InvoiceDeliveryID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<InvoiceDelivery>_FindAllCollection()
        {
            List<InvoiceDelivery> objs = new List<InvoiceDelivery>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                InvoiceDelivery _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
