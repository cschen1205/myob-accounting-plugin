using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Jobs
{
    using Accounting.Core;
    using Accounting.Core.Jobs;
    using Accounting.Core.Cards;

    public class BOJob : BusinessObject
    {
        public static string JOB_NUMBER = "JobNumber";
        public static string JOB_NAME = "JobName";
        public static string CONTACT_NAME = "ContactName";
        public static string IS_TRACKING_REIMBURSEABLE = "IsTrackingReimburseable";
        public static string IS_HEADER = "IsHeader";
        public static string IS_ACTIVE = "IsActive";
        public static string MANAGER = "Manager";
        public static string CUSTOMER = "Customer";
        public static string PARENT_JOB = "ParentJob";
        public static string PERCENT_COMPLETED = "PercentCompleted";
        public static string START_DATE = "StartDate";
        public static string FINISH_DATE = "FinishDate";
        public static string JOB_LEVEL = "JobLevel";
        public static string JOB_DESCRIPTION = "JobDescription";

        public Job DataSource
        {
            get { return mDataProxy; }
        }

        private Job mDataProxy;
        private Job mDataSource;
        public BOJob(Accountant accountant, Job job, BOContext _state)
            : base(accountant, _state)
        {
            mObjectID = BOType.BOJob;
            mDataProxy = job.Clone() as Job;
            mDataSource = job;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region JOB_NUMBER
            AddProperty(JOB_NUMBER,
                JOB_NUMBER,
                delegate()
                {
                    return mDataProxy.JobNumber;
                },
                delegate(object value)
                {
                    mDataProxy.JobNumber = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 1, 5, out error))
                        {
                            return true;
                        }
                        error = DecorateError(JOB_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(JOB_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region JOB_NAME
            AddProperty(JOB_NAME,
                JOB_NAME,
                delegate()
                {
                    return mDataProxy.JobName;
                },
                delegate(object value)
                {
                    mDataProxy.JobName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 1, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(JOB_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(JOB_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region CONTACT_NAME
            AddProperty(CONTACT_NAME,
                CONTACT_NAME,
                delegate()
                {
                    return mDataProxy.ContactName;
                },
                delegate(object value)
                {
                    mDataProxy.ContactName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CONTACT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CONTACT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region IS_TRACKING_REIMBURSEABLE
            AddProperty(IS_TRACKING_REIMBURSEABLE,
                IS_TRACKING_REIMBURSEABLE,
                delegate()
                {
                    return mDataProxy.IsTrackingReimburseable.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.IsTrackingReimburseable = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_TRACKING_REIMBURSEABLE, "bool");
                    return false;
                });
            #endregion

            #region IS_HEADER
            AddProperty(IS_HEADER,
                IS_HEADER,
                delegate()
                {
                    return mDataProxy.IsHeader.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.IsHeader = (bool)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_HEADER, "bool");
                    return false;
                });
            #endregion

            #region IS_ACTIVE
            AddProperty(IS_ACTIVE,
                IS_ACTIVE,
                delegate()
                {
                    return mDataProxy.IsInactive.Equals("N");
                },
                delegate(object value)
                {
                    mDataProxy.IsInactive = (bool)value ? "N" : "Y";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_ACTIVE, "bool");
                    return false;
                });
            #endregion

            #region MANAGER
            AddProperty(MANAGER,
                MANAGER,
                delegate()
                {
                    return mDataProxy.Manager;
                },
                delegate(object value)
                {
                    mDataProxy.Manager = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(MANAGER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(MANAGER, "string");
                    }
                    return false;
                });
            #endregion

            #region CUSTOMER
            AddProperty(CUSTOMER,
                CUSTOMER,
                delegate()
                {
                    return mDataProxy.Customer;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Customer = null;
                    }
                    else if (value is Customer)
                    {
                        mDataProxy.Customer = value as Customer;
                    }
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Customer)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(CUSTOMER, "Customer");
                    return false;
                });
            #endregion

            #region PARENT_JOB
            AddProperty(PARENT_JOB,
                PARENT_JOB,
                delegate()
                {
                    return mDataProxy.ParentJob;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.ParentJob = null;
                    }
                    else if (value is Job)
                    {
                        mDataProxy.ParentJob = value as Job;
                    }

                    if (mDataProxy.ParentJob == null)
                    {
                        mDataProxy.JobLevel = 1;
                    }
                    else
                    {
                        mDataProxy.JobLevel = mDataProxy.ParentJob.JobLevel + 1;
                    }
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Job)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(PARENT_JOB, "Job");
                    return false;
                });
            #endregion

            #region PERCENT_COMPLETED
            AddProperty(PERCENT_COMPLETED,
                PERCENT_COMPLETED,
                delegate()
                {
                    return mDataProxy.PercentCompleted;
                },
                delegate(object value)
                {
                    mDataProxy.PercentCompleted = double.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsNumeric(value as string, 2, 2, out error))
                        {
                            double result = double.Parse(value as string);
                            if (result > 100)
                            {
                                error = DecorateError(PERCENT_COMPLETED, "must not be larger than 100%");
                                return false;
                            }
                            return true;
                        }
                        error = DecorateError(PERCENT_COMPLETED, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(PERCENT_COMPLETED, "string");
                    }
                    return false;
                });
            #endregion

            #region START_DATE
            AddProperty(START_DATE,
                START_DATE,
                delegate()
                {
                    return mDataProxy.StartDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.StartDate = null;
                    }
                    else
                    {
                        mDataProxy.StartDate = value as DateTime?;
                    }
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is DateTime?)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(START_DATE, "DateTime?");
                    return false;
                });
            #endregion

            #region FINISH_DATE
            AddProperty(FINISH_DATE,
                FINISH_DATE,
                delegate()
                {
                    return mDataProxy.FinishDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.FinishDate = null;
                    }
                    else if (value is DateTime?)
                    {
                        mDataProxy.FinishDate = value as DateTime?;
                    }
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is DateTime?)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(FINISH_DATE, "DateTime?"); 
                    return false;
                });
            #endregion

            #region JOB_LEVEL
            AddProperty(JOB_LEVEL,
                JOB_LEVEL,
                delegate()
                {
                    return mDataProxy.JobLevel;
                },
                delegate(object value)
                {
                    mDataProxy.JobLevel = int.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsInteger(value as string, 1, false, out error))
                        {
                            return true;
                        }
                        error = DecorateError(JOB_LEVEL, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(JOB_LEVEL, "string");
                    }
                    return false;
                });
            #endregion

            #region JOB_DESCRIPTION
            AddProperty(JOB_DESCRIPTION,
                JOB_DESCRIPTION,
                delegate()
                {
                    return mDataProxy.JobDescription;
                },
                delegate(object value)
                {
                    mDataProxy.JobDescription = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(JOB_DESCRIPTION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(JOB_DESCRIPTION, "string");
                    }
                    return false;
                });
            #endregion
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.JobMgr.Store(mDataSource);
        }

        protected override OpResult _Delete()
        {
            return mAccountant.JobMgr.Delete(mDataProxy);
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mDataProxy.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mDataProxy.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mDataProxy.AllowDelete;
            }
        }

    }
}
