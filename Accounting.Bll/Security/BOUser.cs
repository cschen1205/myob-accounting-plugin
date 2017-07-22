using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Security;
using Accounting.Core.Cards;

namespace Accounting.Bll.Security
{
    public class BOUser : BusinessObject
    {
        protected AuthUser mDataProxy=null;
        private AuthUser mDataSource = null;

        public static readonly string USER_NAME = "UserName";
        public static readonly string USER_ROLE = "UserRole";
        public static readonly string USER_DESCRIPTION = "Description";
        public static readonly string USER_PASSWORD = "Password";

        public BOUser(Accountant acc, AuthUser data, BOContext context)
            : base(acc, context)
        {
            mObjectID = BOType.BOUser;
            mDataSource = data;
            mDataProxy = data.Clone() as AuthUser;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(USER_NAME,
                USER_NAME,
                delegate()
                {
                    return mDataProxy.Username;
                }, 
                delegate(object value)
                {
                    mDataProxy.Username = (string)value;
                },
                delegate()
                {
                    if (IsUpdating)
                    {
                        return false;
                    }
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        string _val = value as string;
                        if (_val == "")
                        {
                            error=DecorateError(USER_NAME, "cannot be empty");
                            return false;
                        }
                        else
                        {
                            if (IsCreating)
                            {
                                if (mAccountant.AuthUserMgr.FindByUsername(mDataProxy.Username) != null)
                                {
                                    error = DecorateEntityAlreadyExistError(USER_NAME, mDataProxy.Username);
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                    error = DecorateTypeMismatchError(USER_NAME, "string");
                    return false;
                });

            AddProperty(USER_PASSWORD,
                USER_PASSWORD,
                delegate()
                {
                    return mDataProxy.Password;
                },
                delegate(object value)
                {
                    mDataProxy.Password = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(USER_PASSWORD, "string");
                    return false;
                });

            AddProperty(USER_ROLE,
                USER_ROLE,
                delegate()
                {
                    return mDataProxy.Role;
                },
                delegate(object value)
                {
                    mDataProxy.Role = (AuthRole)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is AuthRole)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(USER_ROLE, "AuthRole");
                    return false;
                });

            AddProperty(USER_DESCRIPTION,
                USER_DESCRIPTION,
                delegate()
                {
                    string card_id = mDataProxy.Description;
                    Employee employee = mAccountant.EmployeeMgr.FindByCardIdentification(card_id);
                    return employee;
                },
                delegate(object value)
                {
                    Employee _obj = value as Employee;
                    mDataProxy.Description = _obj.CardIdentification;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is Employee)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(USER_DESCRIPTION, "Employee");
                    return false;
                });
        }

        public AuthRole Role
        {
            get
            {
                if (mDataProxy == null)
                {
                    return null;
                }
                return mDataProxy.Role;
            }
        }

        protected override Accounting.Core.OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.AuthUserMgr.Store(mDataSource);
        }

        private static BOAuthItemFactory mAuthItemFactory = null;
        public IList<AuthItem> GetAuthItemHierarchy()
        {
            if (mAuthItemFactory == null)
            {
                mAuthItemFactory = new BOAuthItemFactory(mAccountant);
            }
            return mAuthItemFactory.AuthItemRoots;
        }

        public IList<AuthRole> GetAuthRoleHierachy()
        {
            return mAccountant.AuthRoleMgr.FindAllCollection();
        }

        public AuthUser Data
        {
            get
            {
                return mDataProxy;
            }
        }

        public bool Authenticate(string username, string password, out string error)
        {
            error = "";
            if (mAccountant.ConnectMgrFactories(out error))
            {
                bool valid_login;
                mDataProxy = mAccountant.AuthUserMgr.Authenticate(username, password, out error, out valid_login);
                return valid_login;
            }

            return false;
        }

        public virtual bool IsFullControl
        {
            get
            {
                //since nothing is created, the user is allowed to do whatever they want with the system 
                if (mDataProxy == null || mDataProxy.Role == null)
                {
                    if (mAccountant.AuthUserMgr.HasAuthUsers() == false)
                    {
                        return true;
                    }
                    return false;
                }
                return mDataProxy.Role.IsFullControl;
            }
        }

        public virtual bool CheckAccess(string objectid, string propertyname, string attribute)
        {
            //since nothing is created, the user is allowed to do whatever they want with the system 
            if (mDataProxy == null || mDataProxy.Role==null)
            {
                if (mAccountant.AuthUserMgr.HasAuthUsers() == false)
                {
                    return true;
                }
                return false;
            }

            string action = string.Format("{0}.{1}.{2}", objectid, propertyname, attribute);
            return mDataProxy.Role.CheckAccess(action);
        }

        public virtual bool CheckAccess(string objectid, string attribute)
        {
            //since nothing is created, the user is allowed to do whatever they want with the system 
            if (mDataProxy == null || mDataProxy.Role == null)
            {
                if (mAccountant.AuthUserMgr.HasAuthUsers() == false)
                {
                    return true;
                }
                return false;
            }

            string action = string.Format("{0}.{1}", objectid, attribute);
            return mDataProxy.Role.CheckAccess(action);
        }


        public virtual void RebuildSecurity(params string[] files)
        {
            mAccountant.ResetSecurity();
            if(files.Length > 0)
            {
                mAccountant.AuthItemMgr.RebuildAuthItemSchema(files[0]);
                if (files.Length > 1)
                {
                    mAccountant.AuthRoleMgr.RebuildAuthRoleSchema(files[1]);
                    if (files.Length > 2)
                    {
                        mAccountant.AuthUserMgr.RebuildAuthUserSchema(files[2]);
                    }
                }
            }

            string error;
            string username="Administrator";
            string password="";
            IList<AuthUser> users = mAccountant.AuthUserMgr.FindAllCollection();
            foreach (AuthUser user in users)
            {
                if (user.Role.IsFullControl)
                {
                    username = user.Username;
                    password = user.Password;
                    break;
                }
            }
            Authenticate(username, password, out error);
        }

        public string Password
        {
            get { return mDataProxy.Password; }
        }

        public string Username
        {
            get
            {
                return mDataProxy.Username;
            }
        }
    }
}
