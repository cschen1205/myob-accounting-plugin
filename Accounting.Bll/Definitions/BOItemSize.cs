using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Definitions
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    public class BOItemSize : BusinessObject
    {
        public static string ITEM_SIZE_ID = "ItemSizeID";
        public static string DESCRIPTION = "Description";

        private ItemSize mDataProxy;
        private ItemSize mDataSource;

        public BOItemSize(Accountant acc, ItemSize _obj, BOContext state)
            : base(acc, state)
        {
            mObjectID = BOType.BOItemSize;
            mDataSource = _obj;
            mDataProxy = _obj.Clone() as ItemSize;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region ITEM_SIZE_ID
            AddProperty(ITEM_SIZE_ID,
                ITEM_SIZE_ID,
                delegate()
                {
                    return mDataProxy.ItemSizeID;
                },
                delegate(object value)
                {
                    mDataProxy.ItemSizeID = (string)value;
                },
                delegate()
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        return CanEdit;
                    }
                    else if (this.RecordContext == BOContext.Record_Update)
                    {
                        return false;
                    }
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 1, 5, out error))
                        {
                            if (this.RecordContext == BOContext.Record_Create)
                            {
                                string itemsizeid = value as string;
                                itemsizeid = itemsizeid.Trim();
                                if (mAccountant.ItemSizeMgr.ExistsByItemSizeID(itemsizeid))
                                {
                                    error = DecorateEntityAlreadyExistError(ITEM_SIZE_ID, itemsizeid);
                                    return false;
                                }
                            }
                            return true;
                        }
                        error = DecorateError(ITEM_SIZE_ID, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ITEM_SIZE_ID, "string");
                    }
                    return false;
                });
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
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 1, 255, out error))
                        {
                            if (this.RecordContext == BOContext.Record_Create)
                            {
                                string description = value as string;
                                description = description.Trim();
                                if (mAccountant.ItemSizeMgr.ExistsByDescription(description))
                                {
                                    error = DecorateEntityAlreadyExistError(DESCRIPTION, description);
                                    return false;
                                }
                            }
                            else if (this.RecordContext == BOContext.Record_Update)
                            {
                                string description = value as string;
                                description = description.Trim();
                                ItemSize itemsize = mAccountant.ItemSizeMgr.FindByDescription(description);
                                if (itemsize != null && itemsize.ItemSizeID != mDataProxy.ItemSizeID)
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
                });
            #endregion
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.ItemSizeMgr.Store(mDataSource);
        }

        protected override OpResult _Delete()
        {
            return mAccountant.ItemSizeMgr.Delete(mDataSource);
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
