using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using System.Data.Common;
    using System.Data.Odbc;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Core.Jobs;

    public class DbJobManager : JobManager
    {
        public DbJobManager(DbManager mgr)
            : base(mgr)
        {
              
        }

        protected override OpResult _Store(Job _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Job object cannot be created as it is null");
            }

            bool is_creating = !Exists(_obj);

            DbInsertStatement clause = DbMgr.CreateInsertClause();
            clause.InsertColumn("JobNumber", DbMgr.CreateStringFieldEntry(_obj.JobNumber));
            clause.InsertColumn("JobName", DbMgr.CreateStringFieldEntry(_obj.JobName));

            if (_obj.ParentJob != null)
            {
                clause.InsertColumn("SubjobOf", DbMgr.CreateStringFieldEntry(_obj.ParentJob.JobNumber));
            }

            clause.InsertColumn("Header", DbMgr.CreateStringFieldEntry(_obj.IsHeader ? "H" : "D"));
            clause.InsertColumn("Description", DbMgr.CreateStringFieldEntry(_obj.JobDescription));
            clause.InsertColumn("Contact", DbMgr.CreateStringFieldEntry(_obj.ContactName));
            clause.InsertColumn("PercentComplete", DbMgr.CreateDoubleFieldEntry(_obj.PercentCompleted));

            if (_obj.StartDate != null)
            {
                clause.InsertColumn("StartDate", DbMgr.CreateDateTimeFieldEntry(_obj.StartDate));
            }

            if (_obj.FinishDate != null)
            {
                clause.InsertColumn("FinishDate", DbMgr.CreateDateTimeFieldEntry(_obj.FinishDate));
            }

            clause.InsertColumn("Manager", DbMgr.CreateStringFieldEntry(_obj.Manager));

            if (_obj.Customer != null)
            {
                clause.InsertColumn("LinkedCustomer", DbMgr.CreateStringFieldEntry(_obj.Customer.Name));
            }

            clause.InsertColumn("InactiveJob", DbMgr.CreateStringFieldEntry(_obj.IsInactive));
            clause.InsertColumn("TrackReimburseables", DbMgr.CreateStringFieldEntry(_obj.IsTrackingReimburseable));

            clause.Into("Import_Jobs");

            //Console.Write(clause.ToString());


            OdbcConnection m_OdbcConnection = DbMgr.DbConnection as OdbcConnection;
            OdbcCommand cmdSQLInsert = m_OdbcConnection.CreateCommand();
            OdbcTransaction myTrans = m_OdbcConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = clause.ToString();
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (OdbcException ex)
            {
                myTrans.Rollback();
                Log(ex.Message);
                //Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());

            }
            catch (Exception ex)
            {
                Log(ex.Message);
                //Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }

            if (is_creating)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            }
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
        }
    }
}
