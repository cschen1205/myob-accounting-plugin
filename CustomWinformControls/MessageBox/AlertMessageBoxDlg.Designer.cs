namespace System.Windows.Forms
{
    partial class AlertMessageBoxDlg
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
            this.roundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.roundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedGroupBox1
            // 
            this.roundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.roundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.roundedGroupBox1.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.roundedGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.roundedGroupBox1.BorderWidth = 1F;
            this.roundedGroupBox1.Caption = "";
            this.roundedGroupBox1.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.roundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.roundedGroupBox1.CaptionHeight = 25;
            this.roundedGroupBox1.CaptionVisible = true;
            this.roundedGroupBox1.Controls.Add(this.btnOK);
            this.roundedGroupBox1.Controls.Add(this.lblContent);
            this.roundedGroupBox1.CornerRadius = 5;
            this.roundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.roundedGroupBox1.DropShadowThickness = 3;
            this.roundedGroupBox1.DropShadowVisible = true;
            this.roundedGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.roundedGroupBox1.Name = "roundedGroupBox1";
            this.roundedGroupBox1.Size = new System.Drawing.Size(351, 345);
            this.roundedGroupBox1.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(262, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.ForeColor = System.Drawing.Color.Black;
            this.lblContent.Location = new System.Drawing.Point(13, 32);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(87, 13);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Alert Message";
            // 
            // AlertMessageBoxDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(375, 369);
            this.Controls.Add(this.roundedGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertMessageBoxDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomizedMessageBoxDlg";
            this.TransparencyKey = System.Drawing.Color.LightSlateGray;
            this.roundedGroupBox1.ResumeLayout(false);
            this.roundedGroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Label lblContent;
        private Button btnOK;
        private CZRoundedGroupBox roundedGroupBox1;
	}
}