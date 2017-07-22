using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class Status : Entity
    {
        public enum StatusType
        {
            Quote,
            Order,
            Open,
            Closed,
            Credit,
            Debit,
            ClosedPending,
            NonChargeable,
            Unselected,
            Selected,
            ReadyToPay,
            Paid
        };

        public static string StatusType2ID(StatusType status)
        {
            switch (status)
            {
                case StatusType.Order:
                    return "OR";
                case StatusType.Closed:
                    return "C";
                case StatusType.ClosedPending:
                    return "CP";
                case StatusType.Credit:
                    return "CR";
                case StatusType.Open:
                    return "O";
                case StatusType.Quote:
                    return "Q";
                case  StatusType.Debit:
                    return "DR";
                case StatusType.NonChargeable:
                    return "N";
                case StatusType.Unselected:
                    return "U";
                case StatusType.Selected:
                    return "S";
                case StatusType.ReadyToPay:
                    return "R";
                case StatusType.Paid:
                    return "P";
                default:
                    return "";
            }
        }

        #region Type
        public StatusType Type
        {
            get
            {
                if (mStatusID == "O")
                {
                    return StatusType.Open;
                }
                else if (mStatusID == "C")
                {
                    return StatusType.Closed;
                }
                else if (mStatusID == "CR")
                {
                    return StatusType.Credit;
                }
                else if (mStatusID == "Q")
                {
                    return StatusType.Quote;
                }
                else if (mStatusID == "OR")
                {
                    return StatusType.Order;
                }
                else if (mStatusID == "CP")
                {
                    return StatusType.ClosedPending;
                }
                else if (mStatusID == "N")
                {
                    return StatusType.NonChargeable;
                }
                else if (mStatusID == "DR")
                {
                    return StatusType.Debit;
                }
                else if (mStatusID == "U")
                {
                    return StatusType.Unselected;
                }
                else if (mStatusID == "S")
                {
                    return StatusType.Selected;
                }
                else if(mStatusID=="R")
                {
                    return StatusType.ReadyToPay;
                }
                else if (mStatusID == "P")
                {
                    return StatusType.Paid;
                }
                return StatusType.Unselected;
            }
        }
        #endregion

        #region StatusID
        private string mStatusID="";
        public string StatusID
        {
            get { return mStatusID; }
            set 
            {
                mStatusID = value;
                NotifyPropertyChanged("StatusID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("StatusID", StatusID);
            }
        }

        #region Status constructor
        internal Status(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

       

        #region Description
        private string mDescription="";
        public string Description
        {
            get { return mDescription; }
            set 
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return Description;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Status))
            {
                return false; 
            }
            Status rhs = (Status)obj;
            if (rhs.StatusID == StatusID)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
