namespace DacII.WinForms.DbSync
{
    partial class FrmRestorePoints
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
            this.groupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.lstRestorePoints = new System.Windows.Forms.ListBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.groupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.groupBox1.BorderWidth = 1F;
            this.groupBox1.Caption = "Restore Points";
            this.groupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.groupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.groupBox1.CaptionHeight = 25;
            this.groupBox1.CaptionVisible = true;
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.lstRestorePoints);
            this.groupBox1.Controls.Add(this.BtnRestore);
            this.groupBox1.CornerRadius = 5;
            this.groupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.groupBox1.DropShadowThickness = 3;
            this.groupBox1.DropShadowVisible = true;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lstRestorePoints
            // 
            this.lstRestorePoints.FormattingEnabled = true;
            this.lstRestorePoints.Location = new System.Drawing.Point(4, 32);
            this.lstRestorePoints.Name = "lstRestorePoints";
            this.lstRestorePoints.Size = new System.Drawing.Size(335, 238);
            this.lstRestorePoints.TabIndex = 0;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnCancel.Location = new System.Drawing.Point(264, 276);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 30);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnRestore
            // 
            this.BtnRestore.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnRestore.Image = global::DacII.Properties.Resources.restore_16x16;
            this.BtnRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnRestore.Location = new System.Drawing.Point(183, 276);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(75, 30);
            this.BtnRestore.TabIndex = 3;
            this.BtnRestore.Text = "Restore";
            this.BtnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRestore.UseVisualStyleBackColor = true;
            // 
            // FrmRestorePoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(371, 343);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRestorePoints";
            this.Text = "Restore Points";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox groupBox1;
        private System.Windows.Forms.ListBox lstRestorePoints;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnRestore;
    }
}