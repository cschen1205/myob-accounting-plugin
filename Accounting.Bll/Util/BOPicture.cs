using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Util
{
    public class BOPicture : BusinessObject
    {
        public BOPicture(Accountant accountant, BOContext context)
            : base(accountant, context)
        {
        }

        private string mPicture="";

        public String Picture
        {
            get
            {
                return mPicture;
            }
            set
            {
                mPicture = value;
            }
        }

        public string PicturePath
        {
            get
            {
                if (mPicture == "") return null;
                string picture_path = mAccountant.GetFullPath("Graphics\\" + mPicture);
                return picture_path;
            }
        }

    }
}
