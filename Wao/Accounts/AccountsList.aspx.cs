using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.Bll;
using Accounting.Bll.Accounts;

namespace Wao.Accounts
{
    public partial class AccountsList : System.Web.UI.Page
    {
        private BOListAccount mModel = new BOListAccount(AccountantPool.Instance.CurrentAccountant);

        protected void Page_Load(object sender, EventArgs e)
        {
            //dgvAccounts.DataSource=mModel.
        }
    }
}
