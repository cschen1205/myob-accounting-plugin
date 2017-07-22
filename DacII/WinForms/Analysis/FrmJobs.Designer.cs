namespace DacII.WinForms.Analysis
{
    partial class FrmJobs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tgvPLStatement = new AdvancedDataGridView.TreeGridView();
            this.colAccountName = new AdvancedDataGridView.TreeGridColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpTerms = new System.Windows.Forms.CZRoundedGroupBox();
            this.ddtvJob = new System.Windows.Forms.TreeView();
            this.roundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.PrintDoc = new System.Drawing.Printing.PrintDocument();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblJobNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblJobName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPercentCompleted = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tgvPLStatement)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpTerms.SuspendLayout();
            this.roundedGroupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tgvPLStatement
            // 
            this.tgvPLStatement.AllowUserToAddRows = false;
            this.tgvPLStatement.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.tgvPLStatement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tgvPLStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tgvPLStatement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tgvPLStatement.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tgvPLStatement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colAmount,
            this.colPercent});
            this.tgvPLStatement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgvPLStatement.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tgvPLStatement.ImageList = null;
            this.tgvPLStatement.Location = new System.Drawing.Point(1, 26);
            this.tgvPLStatement.Name = "tgvPLStatement";
            this.tgvPLStatement.ReadOnly = true;
            this.tgvPLStatement.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tgvPLStatement.RowHeadersVisible = false;
            this.tgvPLStatement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgvPLStatement.ShowCellErrors = false;
            this.tgvPLStatement.ShowCellToolTips = false;
            this.tgvPLStatement.ShowEditingIcon = false;
            this.tgvPLStatement.ShowLines = false;
            this.tgvPLStatement.ShowRowErrors = false;
            this.tgvPLStatement.Size = new System.Drawing.Size(622, 393);
            this.tgvPLStatement.TabIndex = 1;
            // 
            // colAccountName
            // 
            this.colAccountName.DefaultNodeImage = null;
            this.colAccountName.Frozen = true;
            this.colAccountName.HeaderText = "Account";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAccountName.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Selected Period";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 150;
            // 
            // colPercent
            // 
            this.colPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPercent.HeaderText = "Year to Date";
            this.colPercent.Name = "colPercent";
            this.colPercent.ReadOnly = true;
            this.colPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpTerms);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.roundedGroupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(868, 429);
            this.splitContainer1.SplitterDistance = 236;
            this.splitContainer1.TabIndex = 96;
            // 
            // grpTerms
            // 
            this.grpTerms.BackgroundColor = System.Drawing.Color.White;
            this.grpTerms.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.grpTerms.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.grpTerms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.grpTerms.BorderWidth = 1F;
            this.grpTerms.Caption = "Projects";
            this.grpTerms.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.grpTerms.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.grpTerms.CaptionHeight = 25;
            this.grpTerms.CaptionVisible = true;
            this.grpTerms.Controls.Add(this.ddtvJob);
            this.grpTerms.CornerRadius = 5;
            this.grpTerms.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.grpTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTerms.DropShadowThickness = 3;
            this.grpTerms.DropShadowVisible = true;
            this.grpTerms.Location = new System.Drawing.Point(0, 0);
            this.grpTerms.Name = "grpTerms";
            this.grpTerms.Size = new System.Drawing.Size(236, 429);
            this.grpTerms.TabIndex = 15;
            this.grpTerms.TabStop = false;
            // 
            // ddtvJob
            // 
            this.ddtvJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddtvJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ddtvJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddtvJob.Location = new System.Drawing.Point(4, 27);
            this.ddtvJob.Name = "ddtvJob";
            this.ddtvJob.Size = new System.Drawing.Size(224, 393);
            this.ddtvJob.TabIndex = 95;
            this.ddtvJob.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ddtvJob_AfterSelect);
            // 
            // roundedGroupBox1
            // 
            this.roundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.roundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.roundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.roundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.roundedGroupBox1.BorderWidth = 1F;
            this.roundedGroupBox1.Caption = "Project Details";
            this.roundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.roundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.roundedGroupBox1.CaptionHeight = 25;
            this.roundedGroupBox1.CaptionVisible = true;
            this.roundedGroupBox1.Controls.Add(this.tgvPLStatement);
            this.roundedGroupBox1.CornerRadius = 5;
            this.roundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.roundedGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedGroupBox1.DropShadowThickness = 3;
            this.roundedGroupBox1.DropShadowVisible = true;
            this.roundedGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.roundedGroupBox1.Name = "roundedGroupBox1";
            this.roundedGroupBox1.Size = new System.Drawing.Size(628, 429);
            this.roundedGroupBox1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::DacII.Properties.Resources.caption_office_2007;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(880, 25);
            this.toolStrip1.TabIndex = 99;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Text = "toolStripButton1";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::DacII.Properties.Resources.print_32x32;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Text = "toolStripButton2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblJobNumber,
            this.lblJobName,
            this.lblPercentCompleted});
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(880, 22);
            this.statusStrip1.TabIndex = 100;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(64, 17);
            this.lblJobNumber.Text = "Job Number";
            // 
            // lblJobName
            // 
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(54, 17);
            this.lblJobName.Text = "Job Name";
            // 
            // lblPercentCompleted
            // 
            this.lblPercentCompleted.Name = "lblPercentCompleted";
            this.lblPercentCompleted.Size = new System.Drawing.Size(98, 17);
            this.lblPercentCompleted.Text = "Percent Completed";
            // 
            // FrmJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(880, 482);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmJobs";
            this.Text = "Jobs Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.tgvPLStatement)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpTerms.ResumeLayout(false);
            this.roundedGroupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdvancedDataGridView.TreeGridView tgvPLStatement;
        private AdvancedDataGridView.TreeGridColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercent;
        private System.Windows.Forms.TreeView ddtvJob;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Drawing.Printing.PrintDocument PrintDoc;
        private System.Windows.Forms.CZRoundedGroupBox grpTerms;
        private System.Windows.Forms.CZRoundedGroupBox roundedGroupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblJobNumber;
        private System.Windows.Forms.ToolStripStatusLabel lblJobName;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripStatusLabel lblPercentCompleted;

    }
}