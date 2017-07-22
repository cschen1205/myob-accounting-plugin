using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Definitions
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    public class BODataField : BusinessObject
    {
        public static string DATA_FIELD_TYPE = "DataFieldType";
        public static string DATA_FIELD_NAME = "DataFieldName";

        private DataField mDataProxy;
        private DataField mDataSource;

        protected override OpResult _Delete()
        {
            return mAccountant.DataFieldMgr.Delete(mDataSource);
        }

        public BODataField(Accountant acc, DataField _obj, BOContext state)
            : base(acc, state)
        {
            mObjectID = BOType.BODataField;

            mDataSource = _obj;
            mDataProxy = _obj.Clone() as DataField;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region DATA_FIELD_NAME
            AddProperty(DATA_FIELD_NAME,
                DATA_FIELD_NAME,
                delegate()
                {
                    return mDataProxy.DataFieldName;
                },
                delegate(object value)
                {
                    mDataProxy.DataFieldName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
               DataFieldName_Validate);
               
            #endregion 

            #region DATA_FIELD_TYPE
            AddProperty(DATA_FIELD_TYPE,
                DATA_FIELD_TYPE,
                delegate()
                {
                    return mDataProxy.DataFieldType;
                },
                delegate(object value)
                {
                    if (value is string)
                    {
                        mDataProxy.DataFieldType = (string)value;
                    }
                    else
                    {
                        throw new Exception("DataFieldType must be of type string");
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
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 1, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(DATA_FIELD_TYPE, error); 
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(DATA_FIELD_TYPE, "string"); 
                    }
                    return false;
                });
            #endregion
        }

        public bool DataFieldName_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsWithinRange(value as string, 1, 56, out error))
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        string datafieldname = value as string;
                        datafieldname = datafieldname.Trim();
                        if (mAccountant.DataFieldMgr.ExistsByDataFieldName(datafieldname))
                        {
                            error = DecorateEntityAlreadyExistError(DATA_FIELD_NAME, datafieldname);
                            return false;
                        }
                    }
                    else if (this.RecordContext == BOContext.Record_Update)
                    {
                        string datafieldname = value as string;
                        datafieldname = datafieldname.Trim();
                        DataField df = mAccountant.DataFieldMgr.FindById(datafieldname);
                        if (df != null && df.DataFieldID.Value != mDataProxy.DataFieldID.Value)
                        {
                            error = DecorateEntityAlreadyExistError(DATA_FIELD_NAME, datafieldname);
                            return false;
                        }
                    }
                    return true;
                }
                error = DecorateError(DATA_FIELD_NAME, error);
                
            }
            else
            {
                error = DecorateTypeMismatchError(DATA_FIELD_NAME, "string");
            }

            
            
            return false;
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            OpResult result = mAccountant.DataFieldMgr.Store(mDataSource);
            return result;
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
