using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Cards
{
    public class CardType : Entity
    {
        public enum TypeID
        {
            Customer,
            Supplier,
            Employee,
            PersonalCard,
            None
        };

        internal CardType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

        public static string GetCardTypeID(TypeID typeid)
        {
            switch (typeid)
            {
                case TypeID.Customer:
                    return "C";
                case TypeID.Supplier:
                    return "S";
                case TypeID.Employee:
                    return "E";
                case TypeID.PersonalCard:
                    return "P";
                default:
                    return "P";
            }
        }

        public static TypeID GetTypeID(string CardTypeID)
        {
            if (CardTypeID == "C")
            {
                return TypeID.Customer;
            }
            else if (CardTypeID == "S")
            {
                return TypeID.Supplier;
            }
            else if (CardTypeID == "E")
            {
                return TypeID.Employee;
            }
            else if(CardTypeID=="P")
            {
                return TypeID.PersonalCard;
            }
            else
            {
                return TypeID.None;
            }
        }

        


        public TypeID Type
        {
            get
            {
                return GetTypeID(mCardTypeID);
            }
        }

        private string mCardTypeID="";
        public string CardTypeID
        {
            get {
                return mCardTypeID; 
            }            
            set { mCardTypeID = value;
            NotifyPropertyChanged("CardTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("CardTypeID", CardTypeID);
            }
        }

        private string mDescription="";
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value;
            NotifyPropertyChanged("Description");
            }
        }
    }
}
