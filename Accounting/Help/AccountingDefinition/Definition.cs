using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Help.AccountingDefinition
{
    public class Definition
    {
        private string mTerm;
        private string mDescription;
        private string mComment;

        public string Term
        {
            get { return mTerm; }
            set { mTerm = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string Comment
        {
            get { return mComment; }
            set { mComment = value; }
        }
    }
}
