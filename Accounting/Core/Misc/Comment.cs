using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Misc
{
    public class Comment : Entity
    {
        #region +(Constructor)
        internal Comment(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        

        #region CommentID
        private int? mCommentID;
        public int? CommentID
        {
            get { return mCommentID; }
            set 
            {
                mCommentID = value;
                NotifyPropertyChanged("CommentID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CommentID", CommentID);
            }
        }

        #region Text
        private string mText;
        public string Text
        {
            get { return mText; }
            set 
            {
                mText = value;
                NotifyPropertyChanged("Text");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mText;
        }

        public override bool Equals(object obj)
        {
            if (obj is Comment)
            {
                Comment _obj = (Comment)obj;
                return _obj.CommentID == mCommentID; 
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
