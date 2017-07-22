using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Purchases;

namespace Accounting.Bll.Purchases.PurchaseLines
{
    public abstract class BOPurchaseLine : BusinessObject
    {
        private Purchase mPurchaseEntity;
        private PurchaseLine mDataSource;  

        protected void Update(PurchaseLine new_line)
        {
            if (RecordContext == BOContext.Record_Create)
            {
                mPurchaseEntity.PurchaseLines.Add(new_line);
                mPurchaseEntity.Evaluate();
            }
            else
            {
                mDataSource.AssignFrom(new_line);
                mPurchaseEntity.Evaluate();
            }
        }

        public abstract void Update();

        public BOPurchaseLine(Accountant accountant, Purchase _purchase, PurchaseLine _line, BOContext context)
            : base(accountant, context)
        {
            mObjectID = BOType.BOPurchaseLine;
            mPurchaseEntity = _purchase;
            mDataSource = _line;
            mDataSource.Purchase = _purchase;
        }

        

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mPurchaseEntity.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mPurchaseEntity.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mPurchaseEntity.AllowDelete;
            }
        }


    }
}
