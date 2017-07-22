using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class MiscNumber : Entity
    {
        //1 for Invoice#; 
        //2 for PO#; 
        //3 for computer-generated max Invoice#; 
        //4 for computer-generated max PO#
        //5 for InventoryJournalNumber

        internal MiscNumber(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }


        public enum NumberType
        {
            InvoiceNumber=1,
            PurchaseNumber=2,
            MaxInvoiceNumber=3,
            MaxPurchaseNumber=4,
            InventoryJournalNumber=5
        }

        private int? mID;
        public int? ID
        {
            get { return mID; }
            set
            {
                mID = value;
                NotifyPropertyChanged("ID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ID", ID);
            }
        }

        private NumberType mType;
        public NumberType type
        {
            get { return mType; }
            set
            {
                mType = value;
                NotifyPropertyChanged("type");
            }
        }

        private string mSignature = "";
        public string signature
        {
            get { return mSignature; }
            set
            {
                mSignature = value;
                NotifyPropertyChanged("signature");
            }
        }

       
    }
}
