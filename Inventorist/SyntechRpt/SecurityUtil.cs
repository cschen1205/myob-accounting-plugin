using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Bll;
using Accounting.Bll.Security;

namespace SyntechRpt
{
    public class SecurityUtil
    {
        public static bool CheckAccessSilent(string action)
        {
            BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
            if (current_user.CheckAccess(action))
            {
                return true;
            }
            return false;
        }

        public static bool CheckAccess(string action)
        {
            BOUser current_user = AccountantPool.Instance.CurrentAccountant.User;
            if (current_user.CheckAccess(action))
            {
                return true;
            }
            else
            {
                Util.WinFormUtil.Alert(string.Format("Your current role as {0} does not allow you to access this feature", current_user.Role));
                return false;
            }
        }
    }
}
