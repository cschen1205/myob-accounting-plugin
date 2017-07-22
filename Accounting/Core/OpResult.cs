using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
    public class OpResult
    {
        private Entity mTarget = null;

        private OpResult()
        {

        }

        public string Error
        {
            get
            {
                if (mErrors.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string error in mErrors)
                    {
                        sb.AppendFormat("{0}\r\n", error);
                    }
                    return sb.ToString();   
                }
                return "";
            }
        }

        public Entity Target
        {
            get { return mTarget; }
            set { mTarget = value; }
        }

        public static OpResult NotifyDeleteAction(ResultStatus status, Entity target, params string[] errors)
        {
            OpResult result = new OpResult();
            result.Status = status;
            foreach (string error in errors)
            {
                result.Errors.Add(error);
            }
            result.Target = target;
            result.OpAction = Action.Delete;
            return result;
        }

        public static OpResult NotifyReviseAction(ResultStatus status, Entity target, params string[] errors)
        {
            OpResult result = new OpResult();
            result.Status = status;
            foreach (string error in errors)
            {
                result.Errors.Add(error);
            }
            result.Target = target;
            result.OpAction = Action.Revise;
            return result;
        }

        public static OpResult NotifyStoreAction(ResultStatus status, Entity target, params string[] errors)
        {
            OpResult result = new OpResult();
            result.Status = status;
            foreach (string error in errors)
            {
                result.Errors.Add(error);
            }
            result.Target = target;
            result.OpAction = Action.Store;
            return result;
        }

        private List<string> mErrors=new List<string>();
        public List<string> Errors
        {
            get { return mErrors; }
        }

        public enum ResultStatus
        {
            Created,
            Updated,
            Revised,
            ObjectIsNull,
            ExistsAndDeleted,
            NotCreatedDue2Exists,
            NotExists,
            NoActionTaken,
            ObjectIsDirty,
            ObjectIsVolatile,
            UpdatedWithException,
            CreatedWithException,
            CreateFailedOnCriteria,
            UpdateFailedOnCriteria,
        }

        public enum Action
        {
            Delete,
            Revise,
            Store
        }

        private ResultStatus mStatus = ResultStatus.ObjectIsDirty;
        public ResultStatus Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        private Action mAction = Action.Revise;
        public Action OpAction
        {
            get { return mAction; }
            set { mAction = value; }
        }
    }
}
