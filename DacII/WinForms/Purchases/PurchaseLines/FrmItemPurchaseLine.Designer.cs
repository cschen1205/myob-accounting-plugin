namespace DacII.WinForms.Purchases.PurchaseLines
{
    partial class FrmItemPurchaseLine
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
            this.btnOK = new System.Windows.Forms.Button();
            this.gbItemPurchaseLine = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cboTax = new System.Windows.Forms.ComboBox();
            this.lblJob = new System.Windows.Forms.Label();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.lblReceived = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbItemPurchaseLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(212, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.Record);
            // 
            // gbItemPurchaseLine
            // 
            this.gbItemPurchaseLine.BackgroundColor = System.Drawing.Color.White;
            this.gbItemPurchaseLine.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbItemPurchaseLine.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbItemPurchaseLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbItemPurchaseLine.BorderWidth = 1F;
            this.gbItemPurchaseLine.Caption = "";
            this.gbItemPurchaseLine.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbItemPurchaseLine.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbItemPurchaseLine.CaptionHeight = 25;
            this.gbItemPurchaseLine.CaptionVisible = true;
            this.gbItemPurchaseLine.Controls.Add(this.txtDiscount);
            this.gbItemPurchaseLine.Controls.Add(this.txtPrice);
            this.gbItemPurchaseLine.Controls.Add(this.lblDiscount);
            this.gbItemPurchaseLine.Controls.Add(this.txtReceived);
            this.gbItemPurchaseLine.Controls.Add(this.txtQuantity);
            this.gbItemPurchaseLine.Controls.Add(this.lblPrice);
            this.gbItemPurchaseLine.Controls.Add(this.cboLocation);
            this.gbItemPurchaseLine.Controls.Add(this.cboJob);
            this.gbItemPurchaseLine.Controls.Add(this.lblLocation);
            this.gbItemPurchaseLine.Controls.Add(this.cboTax);
            this.gbItemPurchaseLine.Controls.Add(this.lblJob);
            this.gbItemPurchaseLine.Controls.Add(this.cboItem);
            this.gbItemPurchaseLine.Controls.Add(this.lblReceived);
            this.gbItemPurchaseLine.Controls.Add(this.lblTax);
            this.gbItemPurchaseLine.Controls.Add(this.lblQuantity);
            this.gbItemPurchaseLine.Controls.Add(this.lblItem);
            this.gbItemPurchaseLine.CornerRadius = 5;
            this.gbItemPurchaseLine.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbItemPurchaseLine.DropShadowThickness = 3;
            this.gbItemPurchaseLine.DropShadowVisible = true;
            this.gbItemPurchaseLine.Location = new System.Drawing.Point(12, 12);
            this.gbItemPurchaseLine.Name = "gbItemPurchaseLine";
            this.gbItemPurchaseLine.Size = new System.Drawing.Size(356, 228);
            this.gbItemPurchaseLine.TabIndex = 3;
            this.gbItemPurchaseLine.TabStop = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(86, 111);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtDiscount.TabIndex = 6;
            this.txtDiscount.Text = "0";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(86, 85);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.Text = "0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscount.Location = new System.Drawing.Point(15, 114);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(69, 13);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Discount (%):";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(249, 59);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(85, 20);
            this.txtReceived.TabIndex = 6;
            this.txtReceived.Text = "0";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(86, 59);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.Text = "1";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Location = new System.Drawing.Point(15, 88);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price:";
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(86, 191);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(100, 21);
            this.cboLocation.TabIndex = 5;
            // 
            // cboJob
            // 
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(86, 164);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(100, 21);
            this.cboJob.TabIndex = 5;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Location = new System.Drawing.Point(15, 194);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(71, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Sell Location:";
            // 
            // cboTax
            // 
            this.cboTax.FormattingEnabled = true;
            this.cboTax.Location = new System.Drawing.Point(86, 137);
            this.cboTax.Name = "cboTax";
            this.cboTax.Size = new System.Drawing.Size(100, 21);
            this.cboTax.TabIndex = 5;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.BackColor = System.Drawing.Color.Transparent;
            this.lblJob.Location = new System.Drawing.Point(15, 167);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(27, 13);
            this.lblJob.TabIndex = 4;
            this.lblJob.Text = "Job:";
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(86, 30);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(248, 21);
            this.cboItem.TabIndex = 5;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.OnItemChanged);
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.BackColor = System.Drawing.Color.Transparent;
            this.lblReceived.Location = new System.Drawing.Point(192, 62);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(56, 13);
            this.lblReceived.TabIndex = 4;
            this.lblReceived.Text = "Received:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.BackColor = System.Drawing.Color.Transparent;
            this.lblTax.Location = new System.Drawing.Point(15, 140);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(28, 13);
            this.lblTax.TabIndex = 4;
            this.lblTax.Text = "Tax:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Location = new System.Drawing.Point(15, 62);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantiy:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.BackColor = System.Drawing.Color.Transparent;
            this.lblItem.Location = new System.Drawing.Point(15, 33);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.TabIndex = 4;
            this.lblItem.Text = "Item:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(293, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmItemPurchaseLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 281);
            this.Controls.Add(this.gbItemPurchaseLine);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemPurchaseLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Purchase Line";
            this.gbItemPurchaseLine.ResumeLayout(false);
            this.gbItemPurchaseLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CZRoundedGroupBox gbItemPurchaseLine;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.ComboBox cboTax;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label lblReceived;
    }
}