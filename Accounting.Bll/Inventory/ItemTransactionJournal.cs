using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Inventory
{
    using Accounting.Core.Inventory;
    using Accounting.Core.Purchases;
    using Accounting.Core.Sales;

    public class ItemTransactionJournal
    {
        public Item mItem = null;
        public Item Item
        {
            get
            {
                return mItem;
            }
            set
            {
                mItem = value;
            }
        }

        private InventoryAdjustmentLine mInventoryAdjustmentLine = null;
        public InventoryAdjustmentLine InventoryAdjustmentLine
        {
            get
            {
                return mInventoryAdjustmentLine; 
            }
            set
            {
                mInventoryAdjustmentLine = value;
            }
        }

        private ItemSaleLine mItemSaleLine = null;
        public ItemSaleLine ItemSaleLine
        {
            get
            {
                return mItemSaleLine;
            }
            set
            {
                mItemSaleLine = value;
            }
        }

        private ItemPurchaseLine mItemPurchaseLine = null;
        public ItemPurchaseLine ItemPurchaseLine
        {
            get
            {
                return mItemPurchaseLine;
            }
            set
            {
                mItemPurchaseLine = value;
            }
        }

        public object Line
        {
            get
            {
                if (mItemPurchaseLine != null) return mItemPurchaseLine;
                else if (mItemSaleLine != null) return mItemSaleLine;
                else if (mInventoryAdjustmentLine != null) return mInventoryAdjustmentLine;
                return null;
            }
        }

        public string Src
        {
            get
            {
                if (mPurchaseJournal != null) return "PJ";
                else if (mSaleJournal != null) return "SJ";
                else if (mInventoryAdjustment != null) return "IJ";
                return "NA";
            }
        }

        private Purchase mPurchaseJournal = null;
        public Purchase PurchaseJournal
        {
            get { return mPurchaseJournal; }
            set
            {
                mPurchaseJournal = value;
            }
        }

        private Sale mSaleJournal = null;
        public Sale SaleJournal
        {
            get { return mSaleJournal; }
            set
            {
                mSaleJournal = value;
            }
        }

        private InventoryAdjustment mInventoryAdjustment = null;
        public InventoryAdjustment InventoryAdjustmentJournal
        {
            get { return mInventoryAdjustment; }
            set { mInventoryAdjustment = value; }
        }

        public string Date
        {
            get
            {
                if (mPurchaseJournal != null) return mPurchaseJournal.PurchaseDate.Value.ToString("dd/MM/yyyy");
                else if (mSaleJournal != null) return mSaleJournal.InvoiceDate.Value.ToString("dd/MM/yyyy");
                else if (mInventoryAdjustment != null) return mInventoryAdjustment.Date.Value.ToString("dd/MM/yyyy");
                return "NA";
            }
        }

        public string JournalID
        {
            get
            {
                if (mPurchaseJournal != null) return mPurchaseJournal.PurchaseNumber;
                else if (mSaleJournal != null) return mSaleJournal.InvoiceNumber;
                else if (mInventoryAdjustment != null) return mInventoryAdjustment.InventoryJournalNumber;
                return "NA";
            }
        }

        public string ItemNumber
        {
            get
            {
                if (mItem != null)
                {
                    return mItem.ItemNumber;
                }
                return "NA";
            }
        }

        public string Memo
        {
            get
            {
                if (mPurchaseJournal != null) return mPurchaseJournal.Memo;
                else if (mSaleJournal != null) return mSaleJournal.Memo;
                else if (mInventoryAdjustment != null) return mInventoryAdjustment.Memo;
                return "NA";
            }
        }

        public double Quantity
        {
            get
            {
                
                if (mItemPurchaseLine != null)
                {
                    return mItemPurchaseLine.Quantity;
                }
                else if (mItemSaleLine != null)
                {
                    return mItemSaleLine.Quantity;
                }
                else if (mInventoryAdjustmentLine != null)
                {
                    return mInventoryAdjustmentLine.Quantity;
                }
                return 0;
            }
        }

        public string Amount
        {
            get
            {
                if (mPurchaseJournal != null && mItemPurchaseLine != null)
                {
                    return mPurchaseJournal.Currency.Format(mItemPurchaseLine.TaxBasisAmount);
                }
                else if (mSaleJournal != null && mItemSaleLine != null)
                {
                    return mSaleJournal.Currency.Format(mItemSaleLine.TaxBasisAmount);
                }
                else if (mInventoryAdjustment != null && mInventoryAdjustmentLine != null)
                {
                    return mInventoryAdjustment.Currency.Format(mInventoryAdjustmentLine.Amount);
                }
                return "NA";
            }
        }

    }
}
