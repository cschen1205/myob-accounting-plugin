using System;
using System.Drawing;
using System.Windows.Forms;

namespace DacII.WinForms.Jobs
{
    using DacII.Presenters;
    using DacII.DacHandlers;

    using Accounting.Bll;
    using Accounting.Bll.Jobs;
    using Accounting.Core.Jobs;
    using Accounting.Core.Data;
    using AdvancedDataGridView;

    public partial class FrmJobsList : BaseView
    {
        private Font mBoldFont;
        private BOListJob mModel;

        public FrmJobsList(ApplicationPresenter ap, BOListJob model)
            : base(ap)
        {
            InitializeComponent();
            mModel = model;

            BindViews();
            RegisterEventHandlers();
        }

        public BOListJob Model
        {
            get
            {
                return mModel;
            }
        }

        protected override void RegisterEventHandlers()
        {
            RegisterEventHandler(tgv, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgv_DoubleClick));
        }

        void tgv_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Job> node = GetSelectedDataNode(tgv);
            if (node != null)
            {
                mApplicationController.OpenJob(node.DataSource);
            }
        }

        protected override void LoadView()
        {
            if (mBoldFont == null)
            {
                mBoldFont = new Font(tgv.DefaultCellStyle.Font, FontStyle.Bold);
            }

            tgv.Nodes.Clear();
            tgv.Columns.Clear();

            tgv.Columns.Add(new TreeGridColumn());
            tgv.Columns.Add(new DataGridViewTextBoxColumn());
            tgv.Columns.Add(new DataGridViewTextBoxColumn());
            tgv.Columns.Add(new DataGridViewTextBoxColumn());

            tgv.Columns[0].Width = 180;
            tgv.Columns[1].Width = 180;
            tgv.Columns[2].Width = 40;
            tgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tgv.Columns[0].HeaderText = "Job";
            tgv.Columns[1].HeaderText = "Name";
            tgv.Columns[2].HeaderText = "Completed";
            tgv.Columns[3].HeaderText = "Description";

            foreach (TreeNode<Job> node in Model.Hierarchy[1])
            {
                PopulateTreeGridView(tgv, node);
            }
        }

        private void PopulateTreeGridView(TreeGridView tgv, TreeNode<Job> node)
        {
            Job _obj = node.DataSource;
            TreeGridNode tgnode = tgv.Nodes.Add(_obj, _obj.JobName, _obj.PercentCompleted, _obj.JobDescription);
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

        private void PopulateTreeGridView(TreeGridNode tgnode, TreeNode<Job> node)
        {
            if (node.DataSource.IsHeader)
            {
                tgnode.Cells[0].Style.Font = mBoldFont;
                //tgnode.DefaultCellStyle.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            foreach (TreeNode<Job> child_node in node.Children)
            {
                if (child_node.DataSource.IsHeader)
                {
                    Job _obj = child_node.DataSource;
                    tgchild_node = tgnode.Nodes.Add(_obj, _obj.JobName, _obj.PercentCompleted, _obj.JobDescription);
                    tgchild_node.Cells[0].Tag = child_node;
                }
                else
                {
                    Job _obj = child_node.DataSource;
                    tgchild_node = tgnode.Nodes.Add(_obj, _obj.JobName, _obj.PercentCompleted, _obj.JobDescription);
                    tgchild_node.Cells[0].Tag = child_node;
                }
                PopulateTreeGridView(tgchild_node, child_node);
            }
        }

        private TreeNode<Job> GetSelectedDataNode(TreeGridView tgv)
        {
            DataGridViewRow selected_row = GetSelectedDataGridViewRow(tgv);
            if (selected_row == null) return null;
            return (TreeNode<Job>) selected_row.Cells[0].Tag;
        }

        private DataGridViewRow GetSelectedDataGridViewRow(TreeGridView tgv)
        {
            if (tgv.SelectedRows.Count == 0) return null;
            if (tgv.SelectedRows[0].Cells.Count == 0) return null;
            return tgv.SelectedRows[0];
        }

        private void UpdateDataGridView(TreeGridView tgv, BOJob model)
        {
            Job job = model.DataSource;
            if (job == null) return;

            if (model.IsCreating)
            {
                LoadView();
                foreach (DataGridViewRow row in tgv.Rows)
                {
                    row.Selected = (row.Cells[0].Value.ToString() == job.JobNumber);
                }
            }
            else
            {
                DataGridViewRow view_row = GetSelectedDataGridViewRow(tgv);
                view_row.Cells[0].Value = job.JobNumber;
                view_row.Cells[1].Value = job.JobName;
                view_row.Cells[2].Value = job.PercentCompleted;
                view_row.Cells[3].Value = job.JobDescription;
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}