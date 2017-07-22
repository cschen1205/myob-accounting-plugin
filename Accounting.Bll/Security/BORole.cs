using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Security
{
    using Accounting.Core.Security;

    public class BORole : BusinessObject
    {
        private AuthRole mDataProxy;
        private AuthRole mDataSource;
        public BORole(Accountant acc, AuthRole data, BOContext context)
            : base(acc, context)
        {
            mObjectID = BOType.BORole;
            mDataSource = data;
            mDataProxy = data.Clone() as AuthRole;
        }

        public AuthRole Data
        {
            get { return mDataProxy; }
        }

        public string RoleName
        {
            get { return mDataProxy.RoleName; }
            set { mDataProxy.RoleName=value; }
        }

        public string Description
        {
            get { return mDataProxy.Description; }
            set { mDataProxy.Description=value; }
        }

        public bool IsFullControl
        {
            get { return mDataProxy.IsFullControl; }
            set { mDataProxy.IsFullControl=value; }
        }

        protected override Accounting.Core.OpResult _Delete()
        {
            return mAccountant.AuthRoleMgr.Delete(mDataSource);
        }

        protected override Accounting.Core.OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.AuthRoleMgr.Store(mDataSource);
        }

        public bool ContainsRole(AuthRole role, bool recursive)
        {
            return mDataProxy.HasRole(role, recursive);
        }

        public bool ForbidItem(AuthItem item)
        {
            return mDataProxy.ForbidItem(item);
        }

        public IList<AuthItem> ForbiddenItems
        {
            get
            {
                return mDataProxy.ForbiddenItems;
            }
        }

        public IList<AuthRole> Children
        {
            get
            {
                return mDataProxy.Children;
            }
        }


    }
}
