using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Accounting.Bll;
using Accounting.Bll.Sales;
using Accounting.Core.Cards;
using Accounting.Core.Definitions;

namespace Wao.Sales
{
    public partial class SalesRegister : System.Web.UI.Page
    {
        private BOListSale mModel = new BOListSale(AccountantPool.Instance.CurrentAccountant);

        private void Page_Init(object sender, System.EventArgs e)
        {
            //this.EnableViewState = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime start_date = DateTime.Now.AddYears(-2);
            DateTime end_date = DateTime.Now;
            if (IsPostBack)
            {
                DateTime date;
                if (DateTime.TryParse(txtStartDate.Text, out date)) start_date = date;
                if (DateTime.TryParse(txtEndDate.Text, out date)) end_date = date;
            }
            else
            {
                txtStartDate.Text = start_date.ToShortDateString();
                txtEndDate.Text = end_date.ToShortDateString();
                List<Customer> _grp_customer = (List<Customer>) mModel.List("Customer");
                List<Status> _grp_status = (List<Status>)mModel.List("InvoiceStatus");
                foreach (Customer _customer in _grp_customer)
                {
                    cboCard.Items.Add(new ListItem { Text = _customer.ToString(), Value = _customer.CustomerID.ToString() });
                }
                foreach (Status _status in _grp_status)
                {
                    cboStatus.Items.Add(new ListItem { Text = _status.ToString(), Value = _status.StatusID.ToString() });
                }
            }
            
            gridView.DataSource = mModel.DataGridView(start_date, end_date, null, null);
            gridView.DataBind();
        }

        protected void btnSearch_OnClicked(object sender, EventArgs e)
        {
            //  bind the data
            //System.Threading.Thread.Sleep(2000);

            DateTime start_date = DateTime.Now.AddYears(-2);
            DateTime end_date = DateTime.Now;

            DateTime date;
            if (DateTime.TryParse(txtStartDate.Text, out date)) start_date = date;
            if (DateTime.TryParse(txtEndDate.Text, out date)) end_date = date;

            Customer _customer = null;
            Status _status = null;

            if (chkCard.Checked)
            {
                _customer = mModel.Accountant.CustomerMgr.Retrieve(int.Parse(cboCard.SelectedValue));
            }
            if (chkStatus.Checked)
            {
                _status = mModel.Accountant.StatusMgr.Retrieve(cboStatus.SelectedValue);
            }
            gridView.PageSize = int.Parse(cboPageSize.SelectedValue.ToString());
            gridView.DataSource = mModel.DataGridView(start_date, end_date, _customer, _status);
            gridView.DataBind();
        }

        protected void GridView1_RowDataBound(object sender,
                         GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());

                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record " + DataBinder.Eval(e.Row.DataItem, "ID") + "')");


                BOSale sale=mModel.GetItem(ID);
                string sale_status = "Quote";
                if (sale is BOSaleOpenInvoice)
                {
                    sale_status = "OpenInvoice";
                }
                else if (sale is BOSaleOrder)
                {
                    sale_status = "Order";
                }
                else if (sale is BOSaleClosedInvoice)
                {
                    sale_status = "ClosedInvoice";
                }
                else if (sale is BOSaleCreditReturn)
                {
                    sale_status = "CreditReturn";
                }

                l = (LinkButton)e.Row.FindControl("LinkButton2");
                l.Attributes.Add("onclick", "window.location = '"+sale_status+".aspx?ID=" +ID + "';");

                Label status = (Label)e.Row.FindControl("lblSaleStatus");
                status.Text = sale_status;
            }
        }

        protected void GridView1_RowCommand(object sender,
                         GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                // get the categoryID of the clicked row

                int ID = Convert.ToInt32(e.CommandArgument);
                // Delete the record 

                //DeleteRecordByID(categoryID);
                // Implement this on your own :) 

            }
           
        }

        protected void GridView1_RowDeleted(object sender,
                        GridViewDeletedEventArgs e)
        {
        }

        protected void GridView1_RowDeleting(object sender,
                        GridViewDeleteEventArgs e)
        {
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gridView.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gridView.DataSource = dataView;
                gridView.DataBind();
            }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }
    }
}
