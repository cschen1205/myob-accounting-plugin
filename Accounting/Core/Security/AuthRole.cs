using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Security
{
    public class AuthRole : Entity
    {
        internal AuthRole(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
            
        }

    
        public void RemoveRole(AuthRole role)
        {
            Children.Remove(role);
        }

        public bool ForbidItem(AuthItem _item)
        {
            foreach (AuthItem item in ForbiddenItems)
            {
                if(item.Equals(_item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasRole(AuthRole role, bool recursive)
        {
            foreach (AuthRole child_role in Children)
            {
                if (child_role.Equals(role))
                {
                    return true;
                }
                if (recursive)
                {
                    if (child_role.HasRole(role, recursive))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckAccess(string action)
        {
            AuthItem item = RepositoryMgr.AuthItemMgr.FindById(action);
            if (item == null)
            {
                return true;
            }
            return CheckAccess(item);
        }

        public bool CheckAccess(AuthItem item_to_chk)
        {
            if (FullControl.Equals("1"))
            {
                return true;
            }
           
            foreach (AuthRole child_role in Children)
            {
                if (child_role.CheckAccess(item_to_chk))
                {
                    return true;
                }
            }

            foreach (AuthItem item in ForbiddenItems)
            {
                if (item.Equals(item_to_chk))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is AuthRole)
            {
                AuthRole _obj = obj as AuthRole;
                if (string.IsNullOrEmpty(_obj.RoleName)) return false;
                if (_obj.RoleName.Equals(RoleName))
                {
                    return true;
                }
            }
            return false;
        }


        private string mFullControl = "0";
        public string FullControl
        {
            get { return mFullControl; }
            set 
            {
                mFullControl = value;
                NotifyPropertyChanged("FullControl");
            }
        }



        public override string ToString()
        {
            return RoleName;
        }

        private int? mRoleID;
        public int? RoleID
        {
            get { return mRoleID; }
            set { mRoleID = value; }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RoleID", RoleID);
            }
        }

        private string mRoleName=null;
        public string RoleName
        {
            get { return mRoleName; }
            set
            {
                mRoleName = value;
                NotifyPropertyChanged("FullControl");
            }
        }

        public List<AuthRole> mChildren=null;
        public List<AuthRole> Children
        {
            get
            {
                if (mChildren == null)
                {
                    if (FromDb)
                    {
                        mChildren = (List<AuthRole>)BuildProperty(this, "Children");
                    }
                    else
                    {
                        mChildren = new List<AuthRole>();
                    }
                }
                return mChildren;
            }
        }

        public List<AuthItem> mItems = null;
        public List<AuthItem> ForbiddenItems
        {
            get
            {
                if (mItems == null)
                {
                    if (FromDb)
                    {
                        mItems = (List<AuthItem>)BuildProperty(this, "Items");
                    }
                    else
                    {
                        mItems = new List<AuthItem>();
                    }
                }
                return mItems;
            }
        }

        private string mDescription = "";
        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        public bool IsFullControl
        {
            get
            {
                if (FullControl.Equals("1"))
                {
                    return true;
                }
                foreach(AuthRole role in Children)
                {
                    if (role.IsFullControl)
                    {
                        return true;
                    }
                }
                return false;
            }
            set
            {
                if (value)
                {
                    FullControl = "1";
                }
                else
                {
                    FullControl = "0";
                }
            }
        }

       
    }
}
