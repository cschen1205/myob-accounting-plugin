using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DacII.WinForms.Security
{
    using DacII.Presenters;
    using Accounting.Core.Security;
    using Accounting.Bll;
    using Accounting.Bll.Security;
    using AdvancedDataGridView;

    public partial class FrmAuthRole : BaseView
    {
        TreeViewEventHandler mHandler = null;
        BORole mModel;
        private Font mBoldFont;

        public FrmAuthRole(ApplicationPresenter ap, BORole model)
            : base(ap)
        {
            mModel = model;
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();

            DacII.Util.DataGridViewHelper.UpdateColumnHeaderStyles(tgvAuthItems);
        }



        protected override void  LoadView()
        {
            mBoldFont = new Font(tgvAuthItems.DefaultCellStyle.Font, FontStyle.Bold);
            txtRoleName.Text = mModel.RoleName;
            txtDescription.Text = mModel.Description;
            chkFullControl.Checked = mModel.IsFullControl;

            BuildItemTree(tgvAuthItems);
            BuildRoleTree(tvAuthRoles);

            mApplicationController.mAccountant.LoadAuthItems();
        }

        //private void TriggerLoading()
        //{
        //    BOUser curr_user = mApplicationController.mAccountant.CurrentAuthUser;
        //    if (curr_user != null)
        //    {
        //        AuthRole curr_role = curr_user.Role;
        //        if (curr_role == null || curr_role.IsFullControl)
        //        {
        //            mApplicationController.Status = "Loading Auth Items...";

        //            mApplicationController.mAccountant.LoadAuthItems();

        //            mApplicationController.Status = "";
        //        }
        //    }
        //}

        private void BuildItemTree(TreeGridView tgv)
        {
            IList<AuthItem> items=mApplicationController.mAccountant.CurrentAuthUser.GetAuthItemHierarchy();
            foreach (AuthItem item in items)
            {
                PopulateTreeGridView(tgv, item);
            }
        }

        private void BuildRoleTree(TreeView tree)
        {
            tree.AfterCheck -= mHandler;
            IList<AuthRole> roles = mApplicationController.mAccountant.CurrentAuthUser.GetAuthRoleHierachy();
            foreach (AuthRole role in roles)
            {
                if (mModel.Equals(role) || role.HasRole(mModel.Data, true))
                {
                    continue;
                }
                TreeNode node = new TreeNode();
                tree.Nodes.Add(node);
                Build(node, role);
            }
            tree.AfterCheck += mHandler;
        }

        private bool SubRoleCheckAccess(AuthItem item)
        {
            foreach (TreeNode node in tvAuthRoles.Nodes)
            {
                if (node.Checked)
                {
                    AuthRole role = (AuthRole)node.Tag;
                    if (role.CheckAccess(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PopulateTreeGridView(TreeGridView tgv, AuthItem node)
        {
            TreeGridNode tgnode = tgv.Nodes.Add(node.DisplayName);
            tgnode.Cells[0].Tag = node;

            PopulateTreeGridView(tgnode, node);
            ExpandTreeGridView(tgnode);
        }

        private void ExpandTreeGridView(TreeGridNode tgnode)
        {
            tgnode.Expand();
            foreach (TreeGridNode tgchild_node in tgnode.Nodes)
            {
                ExpandTreeGridView(tgchild_node);
            }
        }

        private void PopulateTreeGridView(TreeGridNode tgnode, AuthItem node)
        {
            if (node.Type==AuthItem.AuthItemType.Category || node.Type==AuthItem.AuthItemType.Root)
            {
                tgnode.Cells[0].Style.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            foreach (AuthItem child_node in node.Children)
            {
                if (child_node.Type==AuthItem.AuthItemType.Category)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DisplayName, IsAuthItemEnabled(child_node), IsAuthItemVisible(child_node), IsAuthItemViewAll(child_node));
                    tgchild_node.ReadOnly = false;
                    tgchild_node.Frozen = false;
                    tgchild_node.Cells[0].Tag = child_node;
                    PopulateTreeGridView(tgchild_node, child_node);
                }
                else if (child_node.Type == AuthItem.AuthItemType.Property)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DisplayName, IsAuthItemEnabled(child_node), IsAuthItemVisible(child_node));
                    tgchild_node.Cells[0].Tag = child_node;
                    PopulateTreeGridView(tgchild_node, child_node);
                }
            }
        }

        private bool IsAuthItemEnabled(AuthItem node)
        {
            AuthItem enabled = GetAuthItemAttribute(node, BOPropertyAttrType.Enabled);
            if (enabled == null) return true;
            return mModel.ForbidItem(enabled) == false;
        }

        public bool IsAuthItemVisible(AuthItem node)
        {
            AuthItem visible=GetAuthItemAttribute(node, BOPropertyAttrType.Visible);
            if (visible == null) return true;
            return mModel.ForbidItem(visible)==false;
        }

        public bool IsAuthItemViewAll(AuthItem node)
        {
            AuthItem viewall = GetAuthItemAttribute(node, BOPropertyAttrType.ViewAll);
            if (viewall==null) return true;
            return mModel.ForbidItem(viewall) == false;
        }

        public AuthItem GetAuthItemAttribute(AuthItem node, string AttributeName)
        {
            foreach (AuthItem child_node in node.Children)
            {
                if (child_node.Type == AuthItem.AuthItemType.Attribute)
                {
                    if (child_node.ItemName.Equals(string.Format("{0}.{1}", node.ItemName, AttributeName)))
                    {
                        return child_node;
                    }
                }
            }
            return null;
        }

        private void Build(TreeNode node, AuthRole role)
        {
            node.Text = role.RoleName;
            node.Tag = role;
            node.ToolTipText = role.Description;
            node.Checked = mModel.ContainsRole(role, false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void ReviseRole()
        {
            mModel.IsFullControl = chkFullControl.Checked;
            mModel.Description = txtDescription.Text;
            mModel.RoleName = txtRoleName.Text;
            ReviseRoleItem(tgvAuthItems);
            ReviseRoleRole(tvAuthRoles);
        }

        private void ReviseRoleRole(TreeView tv)
        {
            mModel.Children.Clear();
            foreach (TreeNode child_node in tv.Nodes)
            {
                ReviseRoleRole(child_node);
            }
        }

        private void ReviseRoleRole(TreeNode node)
        {
            if (node.Checked)
            {
                AuthRole role = (AuthRole)node.Tag;
                if (!mModel.ContainsRole(role, false) && !mModel.Equals(role))
                {
                    mModel.Children.Add(role);
                }
            }
        }

        private void ReviseRoleItem(TreeGridView tv)
        {
            mModel.ForbiddenItems.Clear();
            foreach (TreeGridNode child_node in tv.Nodes)
            {
                ReviseRoleItem(child_node);
            }
        }

        private void ReviseRoleItem(TreeGridNode node)
        {
            AuthItem item = (AuthItem)node.Cells[0].Tag;
            int attribute_count = node.Cells.Count;
            if (item.Type != AuthItem.AuthItemType.Root)
            {
                if (attribute_count > 1 && node.Cells[1].Value != null)
                {
                    bool enabled = (bool)(node.Cells[1].Value);
                    if (enabled == false)
                    {
                        AuthItem attribute_item = GetAuthItemAttribute(item, BOPropertyAttrType.Enabled);
                        if (attribute_item != null)
                        {
                            mModel.ForbiddenItems.Add(attribute_item);
                        }
                    }
                }
                if (attribute_count > 2 && node.Cells[2].Value != null)
                {
                    bool visible = (bool)(node.Cells[2].Value);
                    if (visible == false)
                    {
                        AuthItem attribute_item = GetAuthItemAttribute(item, BOPropertyAttrType.Visible);
                        if (attribute_item != null)
                        {
                            mModel.ForbiddenItems.Add(attribute_item);
                        }
                    }
                }
                if (attribute_count > 3 && node.Cells[3].Value != null)
                {
                    bool viewall = (bool)(node.Cells[3].Value);
                    if (viewall == false)
                    {
                        AuthItem attribute_item = GetAuthItemAttribute(item, BOPropertyAttrType.ViewAll);
                        if (attribute_item != null)
                        {
                            mModel.ForbiddenItems.Add(attribute_item);
                        }
                    }
                }
            }
            foreach (TreeGridNode child_node in node.Nodes)
            {
                ReviseRoleItem(child_node);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            ReviseRole();
            mModel.Record();
        }

        private void chkFullControl_CheckedChanged(object sender, EventArgs e)
        {
            /*
            foreach (TreeNode child_node in tvAuthItems.Nodes)
            {
                BindTreeNode(child_node);
            }*/
        }
    }
}
