using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Core.Security;
using Accounting.Bll;
using Accounting.Bll.Security;

namespace SyntechRpt.WinForms.Security
{
    public partial class FrmAuthRole : Form
    {
        TreeViewEventHandler mHandler = null;
        AuthRole mRole;
        public FrmAuthRole(AuthRole role)
        {
            mHandler = new TreeViewEventHandler(tree_AfterCheck);
            mRole = role;
            InitializeComponent();
        }

        private void FrmAuthRole_Load(object sender, EventArgs e)
        {
            txtRoleName.Text = mRole.RoleName;
            txtDescription.Text = mRole.Description;
            chkFullControl.Checked = mRole.IsFullControl;
            BuildItemTree(tvAuthItems);
            BuildRoleTree(tvAuthRoles);
        }

        private void BuildItemTree(TreeView tree)
        {
            tree.AfterCheck -= mHandler;
            IList<AuthItem> items = AccountantPool.Instance.CurrentAccountant.User.GetAuthItemHierarchy();
            foreach (AuthItem item in items)
            {
                TreeNode node = new TreeNode();
                tree.Nodes.Add(node);
                Build(node, item);
            }
            tree.AfterCheck += mHandler;
        }

        private void BuildRoleTree(TreeView tree)
        {
            tree.AfterCheck -= mHandler;
            IList<AuthRole> roles = AccountantPool.Instance.CurrentAccountant.User.GetAuthRoleHierachy();
            foreach (AuthRole role in roles)
            {
                if (mRole.Equals(role) || role.HasRole(mRole, true))
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

        void tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (sender == tvAuthItems)
            {
                TreeNode node = e.Node;
                AuthItem item = (AuthItem)node.Tag;
                bool accessible = node.Checked || (SubRoleCheckAccess(item));
                node.ForeColor =accessible ? Color.Black : Color.Red;
                node.ToolTipText = string.Format("{0} {1}", (accessible ? "(accessible)" : "(not accessible)"), item.Description);
            }
            else if (sender == tvAuthRoles)
            {
                foreach (TreeNode child_node in tvAuthItems.Nodes)
                {
                    BindTreeNode(child_node);
                }
            }
        }

        private void BindTreeNode(TreeNode node)
        {
            AuthItem item=(AuthItem)node.Tag;
            bool accessible = node.Checked || chkFullControl.Checked || SubRoleCheckAccess(item);
            node.ForeColor = accessible ? Color.Black : Color.Red;
            node.ToolTipText = string.Format("{0} {1}", (accessible ? "(accessible)" : "(not accessible)"), item.Description);
            foreach (TreeNode child_node in node.Nodes)
            {
                BindTreeNode(child_node);
            }
        }

        private string GetAuthItemType(AuthItem item)
        {
            int index = item.DisplayName.LastIndexOf(".");
            if (index == -1) return "";
            string type = item.DisplayName.Substring(index + 1);
            return type;
        }

        private int GetAuthItemImageIndex(AuthItem item)
        {
            string type = GetAuthItemType(item);
            if (type.Equals("Update"))
            {
                return 0;
            }
            else  if (type.Equals("Create"))
            {
                return 1;
            }
            else if (type.Equals("Delete"))
            {
                return 2;
            }
            else if (type.Equals("Read"))
            {
                return 3;
            }
            else if (type.Equals("Access"))
            {
                return 4;
            }
            else if (type.Equals("Index"))
            {
                return 5;
            }
            return 4;
        }

        private void Build(TreeNode node, AuthRole role)
        {
            node.Text = role.RoleName;
            node.Tag = role;
            node.ToolTipText = role.Description;
            node.Checked = mRole.HasRole(role, false);
            
        }

        private void Build(TreeNode node, AuthItem item)
        {
            bool accessible=mRole.CheckAccess(item);
            node.Text=item.DisplayName;
            node.ImageIndex = GetAuthItemImageIndex(item);
            node.Tag=item;
            node.ToolTipText=string.Format("{0} {1}", (accessible ? "(accessible)" : "(not accessible)"), item.Description);
            node.Checked=mRole.HasItem(item);
            node.ForeColor = accessible ? Color.Black : Color.Red;
            foreach(AuthItem child_item in item.Children)
            {
                TreeNode child_node=new TreeNode();
                node.Nodes.Add(child_node);
                Build(child_node, child_item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReviseRole()
        {
            mRole.IsFullControl = chkFullControl.Checked;
            mRole.Description = txtDescription.Text;
            mRole.RoleName = txtRoleName.Text;
            ReviseRoleItem(tvAuthItems);
            ReviseRoleRole(tvAuthRoles);
        }

        private void ReviseRoleRole(TreeView tv)
        {
            mRole.Children.Clear();
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
                if (!mRole.HasRole(role, false) && !mRole.Equals(role))
                {
                    mRole.Children.Add(role);
                }
            }
        }

        private void ReviseRoleItem(TreeView tv)
        {
            mRole.Items.Clear();
            foreach (TreeNode child_node in tv.Nodes)
            {
                ReviseRoleItem(child_node);
            }
        }

        private void ReviseRoleItem(TreeNode node)
        {
            if (node.Checked)
            {
                AuthItem item = (AuthItem)node.Tag;
                mRole.Items.Add(item);
            }
            foreach (TreeNode child_node in node.Nodes)
            {
                ReviseRoleItem(child_node);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            ReviseRole();
            BOUser current_user=AccountantPool.Instance.CurrentAccountant.User;
            current_user.UpdateAuthRole(mRole);
        }

        private void chkFullControl_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode child_node in tvAuthItems.Nodes)
            {
                BindTreeNode(child_node);
            }
        }

       
    }
}
