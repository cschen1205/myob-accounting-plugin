using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.Core.Sales;
using Accounting.Bll;
using Accounting.Bll.Sales;
using Accounting.Core.Cards;
using Accounting.Core.Misc;
using Accounting.Core.Terms;

namespace Wao.Sales
{
    public partial class OpenInvoice : System.Web.UI.Page
    {
        private BOSaleOpenInvoice mModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    lblAppTitle.Text = "Sales - Enter Sales - Edit Open Invoice [ID=" + Request["ID"] + "]";
                    Sale sale = AccountantPool.Instance.CurrentAccountant.SaleMgr.Retrieve(int.Parse(Request["ID"]));
                    mModel = AccountantPool.Instance.CurrentAccountant.SaleFactory.GetSaleOpenInvoice(sale);
                }
                else
                {
                    lblAppTitle.Text = "Sales - Enter Sales - Create Open Invoice";
                    mModel = AccountantPool.Instance.CurrentAccountant.SaleFactory.CreateSaleOpenInvoice();
                }

                List<Employee> _salesperson_grp = (List<Employee>)mModel.List("Salesperson");
                foreach (Employee _saleperson in _salesperson_grp)
                {
                    ListItem item=new ListItem { Text = _saleperson.ToString(), Value = _saleperson.EmployeeID.Value.ToString() };
                    if (_saleperson.Equals(mModel.SalesPerson))
                    {
                        item.Selected = true;
                    }
                    cboSalesperson.Items.Add(item);
                }

                if (mModel.InvoiceDate != null)
                {
                    txtDate.Text = mModel.InvoiceDate.Value.ToString("dd/MM/yyyy");
                }

                if (mModel.PromisedDate != null)
                {
                    txtPromisedDate.Text = mModel.PromisedDate.Value.ToString("dd/MM/yyyy");
                }

                txtMemo.Text = mModel.Memo;

                List<Comment> _comment_grp = (List<Comment>)mModel.List("Comment");
                foreach (Comment _comment in _comment_grp)
                {
                    ListItem item = new ListItem { Text = _comment.ToString(), Value = _comment.CommentID.Value.ToString() };
                    if (_comment.Text.Equals(mModel.Comment))
                    {
                        item.Selected = true;
                    }
                    cboComment.Items.Add(item);
                }

                List<Terms> _terms_grp = (List<Terms>)mModel.List("Terms");
                foreach (Terms _terms in _terms_grp)
                {
                    ListItem item = new ListItem { Text = _terms.ToString(), Value = _terms.TermsID.Value.ToString() };
                    if (_terms.Equals(mModel.Terms))
                    {
                        item.Selected = true;
                    }
                    cboTerms.Items.Add(item);
                }

                List<ReferralSource> _source_grp = (List<ReferralSource>)mModel.List("ReferralSource");
                foreach (ReferralSource _source in _source_grp)
                {
                    ListItem item = new ListItem { Text = _source.ToString(), Value = _source.ReferralSourceID.Value.ToString() };
                    cboReferralSource.Items.Add(item);
                }

                List<Customer> _customer_grp = (List<Customer>)mModel.List("Customer");
                foreach (Customer _customer in _customer_grp)
                {
                    ListItem item = new ListItem { Text = _customer.ToString(), Value = _customer.CustomerID.Value.ToString() };
                    if (_customer.Equals(mModel.Customer))
                    {
                        item.Selected = true;
                    }
                    cboCustomer.Items.Add(item);
                }
            }

            
        }

        protected void cboCustomer_OnSelectedIndexChanged(object sender, EventArgs args)
        {
            int ID=int.Parse(cboCustomer.SelectedValue);
            Customer _customer=mModel.Accountant.CustomerMgr.Retrieve(ID);
            if (_customer != null)
            {
                txtPhone1.Text = _customer.Address1.Phone1;
                txtCity.Text = _customer.Address1.City;
            }
            
        }
    }
}
