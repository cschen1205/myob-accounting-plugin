using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeWebUI;

namespace Wao
{
    public partial class WaoDefault : System.Web.UI.MasterPage
    {
        public OfficeRibbon MainRibbon { get { return this.OfficeRibbonWao; } }
        public OfficeWorkspace MainWorkspace { get { return this.WorkspaceWao; } }
        public Manager MainManager { get { return this.ManagerWao; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            this.OfficeRibbonWao.ExtraText = "CodeZone Pte Ltd - Accounting";

            base.OnInit(e);
        }

        protected void Goto_Home(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}
