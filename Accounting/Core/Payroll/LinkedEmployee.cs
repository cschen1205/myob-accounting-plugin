﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Payroll
{
    public class LinkedEmployee : Entity
    {
        internal LinkedEmployee(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mLinkedEmployeeID;
        public int? LinkedEmployeeID
        {
            get { return mLinkedEmployeeID; }
            set
            {
                mLinkedEmployeeID = value;
                NotifyPropertyChanged("LinkedEmployeeID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("LinkedEmployeeID", LinkedEmployeeID);
            }
        }

        private int? mCategoryID;
        public int? CategoryID
        {
            get { return mCategoryID; }
            set
            {
                mCategoryID = value;
                NotifyPropertyChanged("CategoryID");
            }
        }

        #region CategoryType
        private Definitions.CategoryType mCategoryType = null;
        public Definitions.CategoryType CategoryType
        {
            get
            {
                if (mCategoryType == null) mCategoryType = (Definitions.CategoryType)BuildProperty(this, "Category");
                return mCategoryType;
            }
            set
            {
                mCategoryType = value;
                NotifyPropertyChanged("CategoryType");
            }
        }
        private string mCategoryTypeID;
        public string CategoryTypeID
        {
            get
            {
                if (mCategoryType != null) return mCategoryType.CategoryTypeID;
                return mCategoryTypeID;
            }
            set
            {
                mCategoryTypeID = value;
                NotifyPropertyChanged("CategoryTypeID");
            }
        }
        #endregion

        #region Card
        private Cards.Card mCard = null;
        public Cards.Card Card
        {
            get
            {
                if (mCard == null) mCard = (Cards.Card)BuildProperty(this, "Card");
                return mCard;
            }
            set
            {
                mCard = value;
                NotifyPropertyChanged("Card");
            }
        }
        private int? mCardRecordID;
        public int? CardRecordID
        {
            get
            {
                if (mCard != null) return mCard.CardRecordID;
                return mCardRecordID;
            }
            set
            {
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
        }
        #endregion

    }

}
