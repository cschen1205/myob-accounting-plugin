namespace DacII.WinForms.Jobs
{
    partial class FrmJobsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tgv = new AdvancedDataGridView.TreeGridView();
            this.gbFilter = new System.Windows.Forms.CZRoundedGroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tgv)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.czRoundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tgv
            // 
            this.tgv.AllowUserToAddRows = false;
            this.tgv.AllowUserToDeleteRows = false;
            this.tgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.tgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.tgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tgv.ImageList = null;
            this.tgv.Location = new System.Drawing.Point(9, 30);
            this.tgv.Name = "tgv";
            this.tgv.RowHeadersVisible = false;
            this.tgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tgv.ShowLines = false;
            this.tgv.Size = new System.Drawing.Size(726, 441);
            this.tgv.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.BackgroundColor = System.Drawing.Color.White;
            this.gbFilter.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbFilter.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbFilter.BorderWidth = 1F;
            this.gbFilter.Caption = "Actions";
            this.gbFilter.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbFilter.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbFilter.CaptionHeight = 25;
            this.gbFilter.CaptionVisible = true;
            this.gbFilter.Controls.Add(this.button1);
            this.gbFilter.Controls.Add(this.btnClose);
            this.gbFilter.Controls.Add(this.btnPrint);
            this.gbFilter.CornerRadius = 5;
            this.gbFilter.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbFilter.DropShadowThickness = 3;
            this.gbFilter.DropShadowVisible = true;
            this.gbFilter.Location = new System.Drawing.Point(758, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(92, 151);
            this.gbFilter.TabIndex = 5;
            this.gbFilter.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(6, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 32);
            this.button1.TabIndex = 93;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(6, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 32);
            this.btnClose.TabIndex = 93;
            this.btnClose.Text = "&Refresh";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(6, 28);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 32);
            this.btnPrint.TabIndex = 94;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // czRoundedGroupBox1
            // 
            this.czRoundedGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.czRoundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox1.BorderWidth = 1F;
            this.czRoundedGroupBox1.Caption = "Projects --> Listing";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.btnClose2);
            this.czRoundedGroupBox1.Controls.Add(this.tgv);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(748, 483);
            this.czRoundedGroupBox1.TabIndex = 6;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Location = new System.Drawing.Point(719, 5);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 94;
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmJobsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(853, 490);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.gbFilter);
            this.Name = "FrmJobsList";
            this.Text = "Projects";
            ((System.ComponentModel.ISupportInitialize)(this.tgv)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedDataGridView.TreeGridView tgv;
        private System.Windows.Forms.CZRoundedGroupBox gbFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.Button btnClose2;

    }
}