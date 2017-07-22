using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Accounting.Bll;
using System.Data.Common;

namespace Accounting.Bll.Util
{
    public class BOSql : BusinessObject
    {
        protected string mQueryId;
        public string QueryId
        {
            set { mQueryId = value; }
        }

        public string Query
        {
            get
            {
                return mAccountant.ConfigMgr.GetParamValue(mQueryId);
            }
            set
            {
                mAccountant.ConfigMgr.SetParam(mQueryId, value);
                OnQueryUpdated(value);
            }
        }

        public BOSql(Accountant accountant, string query_id)
            : base(accountant, BOContext.Record_Update)
        {
            mQueryId=query_id;
        }

        public delegate void QueryUpdatedHandler(string query);
        public event QueryUpdatedHandler QueryUpdated;
        private void OnQueryUpdated(string query)
        {
            if (QueryUpdated != null)
            {
                QueryUpdated(query);
            }
        }

        public object GetQueryDataGridView(string query)
        {
            DbDataAdapter adapter = mAccountant.DefaultMgrFactory.CreateDbDataAdapter(query);
            DataSet ADORecordset = new DataSet();
            adapter.Fill(ADORecordset, "SELECT");

            DataView table = ADORecordset.Tables["SELECT"].DefaultView;

            return table;
        }
    }
}
