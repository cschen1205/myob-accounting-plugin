using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Definitions
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    public class BOGender : BusinessObject
    {
        public static string GENDER_ID = "GenderID";
        public static string DESCRIPTION = "Description";

        private Gender mDataProxy;
        private Gender mDataSource;

        public BOGender(Accountant acc, Gender _obj, BOContext state)
            : base(acc, state)
        {
            mObjectID = BOType.BOGender;

            mDataSource = _obj;
            mDataProxy = _obj.Clone() as Gender;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region GENDER_ID
            AddProperty(GENDER_ID,
                GENDER_ID,
                GenderID_Get,
                GenderID_Set,
                GenderID_IsEnabled,
                GenderID_IsVisible,
                GenderID_Validate);
            #endregion

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate()
                {
                    return mDataProxy.Description;
                },
                delegate(object value)
                {
                    mDataProxy.Description = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                Description_Validate);
            #endregion
        }

        public object GenderID_Get()
        {
            return mDataProxy.GenderID;
        }

        public void GenderID_Set(object value)
        {
            mDataProxy.GenderID = (string)value;
        }

        public bool GenderID_IsEnabled()
        {
            if (this.RecordContext == BusinessObject.BOContext.Record_Update)
            {
                return false;
            }
            return true;
        }

        public bool GenderID_IsVisible()
        {
            return true;
        }

        public bool GenderID_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsWithinRange(value as string, 1, 1, out error))
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        string gender_id = value as string;
                        gender_id = gender_id.Trim();
                        if (mAccountant.GenderMgr.ExistsByGenderID(gender_id))
                        {
                            error = DecorateEntityAlreadyExistError(GENDER_ID, gender_id);
                            return false;
                        }
                    }
                    return true;
                }
                error = DecorateError(GENDER_ID, error);
            }
            else
            {
                error = DecorateTypeMismatchError(GENDER_ID, "string");
            }
            return false;
        }

        public bool Description_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsWithinRange(value as string, 0, 255, out error))
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        string description = value as string;
                        description = description.Trim();
                        if (mAccountant.GenderMgr.ExistsByDescription(description))
                        {
                            error = DecorateEntityAlreadyExistError(DESCRIPTION, description);
                            return false;
                        }
                    }
                    else if (this.RecordContext == BOContext.Record_Update)
                    {
                        string description = value as string;
                        description = description.Trim();
                        Gender gender = mAccountant.GenderMgr.FindByDescription(description);
                        if (gender != null && gender.GenderID != mDataProxy.GenderID)
                        {
                            error = DecorateEntityAlreadyExistError(DESCRIPTION, description);
                            return false;
                        }
                    }
                    return true;
                }
                error = DecorateError(DESCRIPTION, error);
            }
            else
            {
                error = DecorateTypeMismatchError(DESCRIPTION, "string");
            }
            return false;
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.GenderMgr.Store(mDataSource);
        }

        protected override OpResult _Delete()
        {
            return mAccountant.GenderMgr.Delete(mDataSource);
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
