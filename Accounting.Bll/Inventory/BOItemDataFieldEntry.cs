using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Inventory
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Core.Definitions;

    public class BOItemDataFieldEntry : BusinessObject
    {

        public static string DATA_FIELD = "DataField";
        public static string ITEM = "Item";
        public static string CONTENT = "Content";

        private ItemDataFieldEntry mDataProxy;
        private ItemDataFieldEntry mDataSource;
        private Item mItem;

        public BOItemDataFieldEntry(Accountant acc, ItemDataFieldEntry _obj, Item _item, BOContext state)
            : base(acc, state)
        {
            mObjectID = BOType.BOItemDataFieldEntry;
            mDataSource = _obj;
            mDataProxy = _obj.Clone() as ItemDataFieldEntry;
            mDataProxy.Item = _item;
            mItem = _item;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region DATA_FIELD
            AddProperty(DATA_FIELD,
                DATA_FIELD,
                delegate()
                {
                    return mDataProxy.DataField;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.DataField = null;
                    }
                    else
                    {
                        mDataProxy.DataField = value as DataField;
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
                    else if (value is DataField)
                    {
                        DataField df = value as DataField;
                        if (this.RecordContext == BOContext.Record_Create)
                        {
                            if (mAccountant.ItemDataFieldEntryMgr.ExistsByItemNumberAndDataFieldID(mDataProxy.ItemNumber, df.DataFieldID))
                            {
                                error = DecorateEntityAlreadyExistError(DATA_FIELD, df.DataFieldName);
                                return false;
                            }
                        }
                        else if (this.RecordContext == BOContext.Record_Update)
                        {
                            ItemDataFieldEntry idfe = mAccountant.ItemDataFieldEntryMgr.FindByItemNumberAndDataFieldID(mDataProxy.ItemNumber, df.DataFieldID);
                            if (idfe != null && idfe.DataFieldID.Value != df.DataFieldID.Value)
                            {
                                error = DecorateEntityAlreadyExistError(DATA_FIELD, df.DataFieldName);
                                return false;
                            }
                        }
                        return true;
                    }
                    error = DecorateTypeMismatchError(DATA_FIELD, "DataField");
                    return false;
                });
            #endregion

            #region ITEM
            AddProperty(ITEM,
                ITEM,
                delegate()
                {
                    return mDataProxy.Item;
                },
                delegate(object value)
                {
                    mDataProxy.Item = value as Item;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is Item)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ITEM, "Item"); 
                    return false;
                });
            #endregion

            #region CONTENT
            AddProperty(CONTENT,
                CONTENT,
                delegate()
                {
                    return mDataProxy.Content;
                },
                delegate(object value)
                {
                    if (value is string)
                    {
                        mDataProxy.Content = (string)value;
                    }
                    else
                    {
                        throw new Exception("Content must be of type string");
                    }
                },
                delegate()
                {
                    return true;
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
                            return true;
                        }
                        error = DecorateError(CONTENT, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CONTENT, "string");
                    }
                    return false;
                });
            #endregion
        }


        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            OpResult result = mAccountant.ItemDataFieldEntryMgr.Store(mDataSource);
            if (result.Status == OpResult.ResultStatus.Created || result.Status == OpResult.ResultStatus.CreatedWithException)
            {
                mItem.ItemDataFieldEntries.Add(mDataSource);
            }
            return result;
        }

        protected override OpResult _Delete()
        {
            OpResult result = mAccountant.ItemDataFieldEntryMgr.Delete(mDataSource);
            if (result.Status == OpResult.ResultStatus.ExistsAndDeleted)
            {
                mItem.ItemDataFieldEntries.Remove(mDataSource);
            }
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
