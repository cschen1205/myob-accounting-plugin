using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace OAS
{
    public partial class Setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         protected void btnSetup_Click(object sender, EventArgs e)
        {
            Database.DBManager.Instance.Setup(txtHost.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text, chkLocalHost.Checked);

            List<string> tables = new List<string>();
            Database.DBManager.Instance.GetTables(tables);
            lblInfo.Text = "You have successfully setup your database " + txtDatabase.Text + "\n";
            lblInfo.Text += "A total of " + tables.Count + " tables has been created\n";
            lblInfo.Text += "<ol>";
            foreach (string table_name in tables)
            {
                lblInfo.Text += ("<li>" + table_name);
                Dictionary<string, string> columns = new Dictionary<string, string>();
                Database.DBManager.Instance.GetColumnInfo(columns, table_name);
                lblInfo.Text += "<table>";
                foreach (string column_name in columns.Keys)
                {
                    lblInfo.Text += ("<tr><td>" + column_name + "</td><td>" + columns[column_name] + "</td></tr>");
                }
                lblInfo.Text += "</table>";
            }
            lblInfo.Text += "</ol>";
        }
    }
}
