using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Sales;

namespace Accounting.Bll.Sales.SaleLines
{
    public abstract class BOSaleLine : BusinessObject
    {
        private Sale mSaleEntity;
        private SaleLine mDataSource;

        protected void Update(SaleLine data_proxy)
        {
            if (RecordContext == BOContext.Record_Create)
            {
                mSaleEntity.SaleLines.Add(data_proxy);
                mSaleEntity.Evaluate();
            }
            else
            {
                mDataSource.AssignFrom(data_proxy);
                mSaleEntity.Evaluate();
            }
        }

        public abstract void Update();

        public BOSaleLine(Accountant accountant, Sale _sale, SaleLine _line, BOContext context)
            : base(accountant, context)
        {
            mObjectID = BOType.BOSaleLine;
            mSaleEntity = _sale;
            mDataSource = _line;
            mDataSource.Sale = _sale;
        }

        public Sale Sale
        {
            get { return mSaleEntity; }
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mSaleEntity.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mSaleEntity.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mSaleEntity.AllowDelete;
            }
        }

    }
}
