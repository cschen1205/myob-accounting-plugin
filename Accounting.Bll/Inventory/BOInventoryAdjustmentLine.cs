using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Inventory
{
    using Accounting.Core.Inventory;
    using Accounting.Core.Jobs;
    using Accounting.Core.Accounts;

    public class BOInventoryAdjustmentLine : BusinessObject
    {
        private InventoryAdjustment mInventoryAdjustmentEntity;
        private InventoryAdjustmentLine mDataSource;
        private InventoryAdjustmentLine mDataProxy;

        public static readonly string AMOUNT = "Amount";
        public static string JOB = "Job";
        public static string UNIT_COST = "UnitCost";
        public static string ACCOUNT = "Account";
        public static string QUANTITY = "Quantity";
        public static string ITEM = "Item";
        public static string MEMO = "Memo";

        public void Update()
        {
            if (RecordContext == BOContext.Record_Create)
            {
                Console.WriteLine("I called this");
                mInventoryAdjustmentEntity.Lines.Add(mDataProxy);
                mInventoryAdjustmentEntity.Evaluate();
            }
            else
            {
                mDataSource.AssignFrom(mDataProxy);
                mInventoryAdjustmentEntity.Evaluate();
            }
        }

        public BOInventoryAdjustmentLine(Accountant accountant, InventoryAdjustment _ia, InventoryAdjustmentLine _line, BOContext context)
            : base(accountant, context)
        {
            mObjectID = BOType.BOInventoryAdjustmentLine;
            mInventoryAdjustmentEntity = _ia;
            mDataSource = _line;
            mDataSource.InventoryAdjustment = _ia;
            mDataProxy = mDataSource.Clone() as InventoryAdjustmentLine;
            mDataProxy.Evaluate();
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();


            #region DISCOUNT
            AddProperty(AMOUNT,
                AMOUNT,
                delegate()
                {
                    return mDataProxy.Amount;
                },
                delegate(object value)
                {
                    mDataProxy.Amount = double.Parse(value as string);
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
                        //9xN (with a maximum of two decimal places. Decimal point counts as one place.)
                        if (IsNumeric(value as string, 6, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(AMOUNT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(AMOUNT, "string");
                    }
                    return false;
                });
            #endregion

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mDataProxy.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Job = null;
                    }
                    else if (value is Job)
                    {
                        mDataProxy.Job = value as Job;
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
                    error = DecorateTypeMismatchError(JOB, "Job");
                    return false;
                });
            #endregion

            #region UNIT_COST
            AddProperty(UNIT_COST,
                UNIT_COST,
                delegate()
                {
                    return mDataProxy.UnitCost;
                },
                delegate(object value)
                {
                    mDataProxy.UnitCost = double.Parse(value as string);
                    mDataProxy.Evaluate();
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
                        if (IsNumeric(value as string, 11, 4, out error))
                        {
                            return true;
                        }
                        error = DecorateError(UNIT_COST, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(UNIT_COST, "string");
                    }
                    return false;
                });
            #endregion

            #region ACCOUNT
            AddProperty(ACCOUNT,
                ACCOUNT,
                delegate()
                {
                    return mDataProxy.Account;
                },
                delegate(object value)
                {
                    //Console.WriteLine("Account Set: I am called");
                    if (value == null)
                    {
                        mDataProxy.Account = null;
                        //Console.WriteLine("Account Set: null");
                        return;
                    }
                    mDataProxy.Account = value as Account;
                    //Console.WriteLine("Account Set: right");
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
                        error = DecorateError(ACCOUNT, "cannot be empty");
                        return false;
                    }
                    else if (value is Account)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ACCOUNT, "TaxCode");
                    return false;
                });
            #endregion

            #region QUANTITY
            AddProperty(QUANTITY,
                QUANTITY,
                delegate()
                {
                    return mDataProxy.Quantity;
                },
                delegate(object value)
                {
                    mDataProxy.Quantity = double.Parse(value as string);
                    mDataProxy.Evaluate();
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
                        if (IsNumeric(value as string, 8, 3, out error))
                        {
                            double result = double.Parse(value as string);
                            if (result <= 0)
                            {
                                error = DecorateError(QUANTITY, "must be positive");
                                return false;
                            }
                            return true;
                        }
                        error = DecorateError(QUANTITY, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(QUANTITY, "string");
                    }
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
                    if (value is Item)
                    {
                        mDataProxy.Item = value as Item;
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
                        error = DecorateError(ITEM, "cannot be empty");
                        return false;
                    }
                    else if (value is Item)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ITEM, "Item");
                    return false;
                });
            #endregion

            #region MEMO
            AddProperty(MEMO,
                MEMO,
                delegate()
                {
                    return ""; //return mDataProxy.Memo;
                },
                delegate(object value)
                {
                    //mDataProxy.Memo = value as string;
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
                        return true;
                    }
                    error = DecorateTypeMismatchError(MEMO, "string");
                    return false;
                });
            #endregion
        }

        public InventoryAdjustment InventoryAdjustment
        {
            get { return mInventoryAdjustmentEntity; }
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mInventoryAdjustmentEntity.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mInventoryAdjustmentEntity.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mInventoryAdjustmentEntity.AllowDelete;
            }
        }
    }
}
