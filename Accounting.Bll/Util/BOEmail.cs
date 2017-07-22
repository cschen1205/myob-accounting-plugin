using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Util
{
    using Accounting.Core.Cards;

    public class BOEmail : BusinessObject
    {
        public BOEmail(Accountant acc)
            : base(acc, BOContext.Record_Create)
        {

        }

        private string mSubject=null;
        public string Subject
        {
            get { return mSubject; }
            set
            {
                mSubject = value;
            }
        }

        private string mBody = null;
        public string Body
        {
            get { return mBody; }
            set
            {
                mBody = value;
            }
        }

        public List<string> mAttachments = new List<string>();
        public List<string> Attachments
        {
            get { return mAttachments; }
        }

        public IList<Card> AllCards
        {
            get
            {
                return mAccountant.CardMgr.FindAllCollection();
            }
        }

        public IList<Supplier> AllSuppliers
        {
            get
            {
                return mAccountant.SupplierMgr.FindAllCollection();
            }
        }

        public IList<Customer> AllCustomers
        {
            get
            {
                return mAccountant.CustomerMgr.FindAllCollection();
            }
        }

        public IList<Employee> AllEmployees
        {
            get
            {
                return mAccountant.EmployeeMgr.FindAllCollection();
            }
        }


    }
}
