namespace DacII.WinForms.Util
{
    partial class FrmReadBarcode
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
            this.components = new System.ComponentModel.Container();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btnScan = new System.Windows.Forms.VistaButton();
            this.lvBarcodes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ilSmall = new System.Windows.Forms.ImageList(this.components);
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.czRoundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.Color.AliceBlue;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBox.Location = new System.Drawing.Point(15, 29);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(508, 335);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.BackColor = System.Drawing.Color.Transparent;
            this.btnScan.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnScan.ButtonText = "Load and Scan";
            this.btnScan.Location = new System.Drawing.Point(529, 370);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(207, 32);
            this.btnScan.TabIndex = 1;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lvBarcodes
            // 
            this.lvBarcodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBarcodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvBarcodes.FullRowSelect = true;
            this.lvBarcodes.GridLines = true;
            this.lvBarcodes.Location = new System.Drawing.Point(529, 29);
            this.lvBarcodes.MultiSelect = false;
            this.lvBarcodes.Name = "lvBarcodes";
            this.lvBarcodes.Size = new System.Drawing.Size(207, 335);
            this.lvBarcodes.SmallImageList = this.ilSmall;
            this.lvBarcodes.TabIndex = 2;
            this.lvBarcodes.UseCompatibleStateImageBehavior = false;
            this.lvBarcodes.View = System.Windows.Forms.View.Details;
            this.lvBarcodes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvBarcodes_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barcode";
            this.columnHeader1.Width = 161;
            // 
            // ilSmall
            // 
            this.ilSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ilSmall.TransparentColor = System.Drawing.Color.Transparent;
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
            this.czRoundedGroupBox1.Caption = "";
            this.czRoundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox1.CaptionHeight = 25;
            this.czRoundedGroupBox1.CaptionVisible = true;
            this.czRoundedGroupBox1.Controls.Add(this.btnClose2);
            this.czRoundedGroupBox1.Controls.Add(this.label1);
            this.czRoundedGroupBox1.Controls.Add(this.picBox);
            this.czRoundedGroupBox1.Controls.Add(this.lvBarcodes);
            this.czRoundedGroupBox1.Controls.Add(this.lblStatus);
            this.czRoundedGroupBox1.Controls.Add(this.btnScan);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Location = new System.Drawing.Point(12, 8);
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.Size = new System.Drawing.Size(760, 415);
            this.czRoundedGroupBox1.TabIndex = 3;
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Location = new System.Drawing.Point(733, 4);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(16, 16);
            this.btnClose2.TabIndex = 94;
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step 1: Press Load && Scan button to start; Step 2: Double click the barcode obta" +
                "ined\r\n";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Location = new System.Drawing.Point(12, 383);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(165, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Press Load && Scan button to start";
            // 
            // FrmReadBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(776, 430);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Name = "FrmReadBarcode";
            this.Text = "Barcode Reader";
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.czRoundedGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.VistaButton btnScan;
        private System.Windows.Forms.ListView lvBarcodes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ImageList ilSmall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose2;
    }
}