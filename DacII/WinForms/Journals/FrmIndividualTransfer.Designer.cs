namespace DacII.WinForms.Journals
{
    partial class FrmIndividualTransfer
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
            this.gbSelectTransferLocation = new System.Windows.Forms.CZRoundedGroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.gbSelectTheTransferType = new System.Windows.Forms.CZRoundedGroupBox();
            this.rbConsignmentReturn = new System.Windows.Forms.RadioButton();
            this.rbTransfer = new System.Windows.Forms.RadioButton();
            this.gbItem = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.gbQty = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtTransferringQty = new System.Windows.Forms.TextBox();
            this.lblTransferringQty = new System.Windows.Forms.Label();
            this.txtQtyOnHand = new System.Windows.Forms.TextBox();
            this.lblQtyOnHand = new System.Windows.Forms.Label();
            this.gbRef = new System.Windows.Forms.CZRoundedGroupBox();
            this.txtRefNote = new System.Windows.Forms.TextBox();
            this.lblRefNote = new System.Windows.Forms.Label();
            this.txtTrnsReferenceNo = new System.Windows.Forms.TextBox();
            this.lblTrnsReferenceNo = new System.Windows.Forms.Label();
            this.gbDatePrint = new System.Windows.Forms.CZRoundedGroupBox();
            this.dtpSelectDate = new System.Windows.Forms.DateTimePicker();
            this.lblSelectTheDate = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSelectTransferLocation.SuspendLayout();
            this.gbSelectTheTransferType.SuspendLayout();
            this.gbItem.SuspendLayout();
            this.gbQty.SuspendLayout();
            this.gbRef.SuspendLayout();
            this.gbDatePrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectTransferLocation
            // 
            this.gbSelectTransferLocation.BackgroundColor = System.Drawing.Color.White;
            this.gbSelectTransferLocation.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbSelectTransferLocation.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbSelectTransferLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbSelectTransferLocation.BorderWidth = 1F;
            this.gbSelectTransferLocation.Caption = "";
            this.gbSelectTransferLocation.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbSelectTransferLocation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbSelectTransferLocation.CaptionHeight = 25;
            this.gbSelectTransferLocation.CaptionVisible = true;
            this.gbSelectTransferLocation.Controls.Add(this.dtpDate);
            this.gbSelectTransferLocation.Controls.Add(this.cboTo);
            this.gbSelectTransferLocation.Controls.Add(this.lblTo);
            this.gbSelectTransferLocation.Controls.Add(this.cboFrom);
            this.gbSelectTransferLocation.Controls.Add(this.lblDate);
            this.gbSelectTransferLocation.Controls.Add(this.lblFrom);
            this.gbSelectTransferLocation.CornerRadius = 5;
            this.gbSelectTransferLocation.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbSelectTransferLocation.DropShadowThickness = 3;
            this.gbSelectTransferLocation.DropShadowVisible = true;
            this.gbSelectTransferLocation.Location = new System.Drawing.Point(321, 12);
            this.gbSelectTransferLocation.Name = "gbSelectTransferLocation";
            this.gbSelectTransferLocation.Size = new System.Drawing.Size(309, 91);
            this.gbSelectTransferLocation.TabIndex = 10;
            this.gbSelectTransferLocation.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(39, 55);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // cboTo
            // 
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(192, 29);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(106, 21);
            this.cboTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTo.Location = new System.Drawing.Point(169, 32);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To";
            // 
            // cboFrom
            // 
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.Location = new System.Drawing.Point(39, 29);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(121, 21);
            this.cboFrom.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Location = new System.Drawing.Point(6, 59);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Location = new System.Drawing.Point(6, 32);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // gbSelectTheTransferType
            // 
            this.gbSelectTheTransferType.BackgroundColor = System.Drawing.Color.White;
            this.gbSelectTheTransferType.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbSelectTheTransferType.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbSelectTheTransferType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbSelectTheTransferType.BorderWidth = 1F;
            this.gbSelectTheTransferType.Caption = "";
            this.gbSelectTheTransferType.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbSelectTheTransferType.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbSelectTheTransferType.CaptionHeight = 25;
            this.gbSelectTheTransferType.CaptionVisible = true;
            this.gbSelectTheTransferType.Controls.Add(this.rbConsignmentReturn);
            this.gbSelectTheTransferType.Controls.Add(this.rbTransfer);
            this.gbSelectTheTransferType.CornerRadius = 5;
            this.gbSelectTheTransferType.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbSelectTheTransferType.DropShadowThickness = 3;
            this.gbSelectTheTransferType.DropShadowVisible = true;
            this.gbSelectTheTransferType.Location = new System.Drawing.Point(10, 12);
            this.gbSelectTheTransferType.Name = "gbSelectTheTransferType";
            this.gbSelectTheTransferType.Size = new System.Drawing.Size(305, 86);
            this.gbSelectTheTransferType.TabIndex = 9;
            this.gbSelectTheTransferType.TabStop = false;
            // 
            // rbConsignmentReturn
            // 
            this.rbConsignmentReturn.AutoSize = true;
            this.rbConsignmentReturn.BackColor = System.Drawing.Color.Transparent;
            this.rbConsignmentReturn.Location = new System.Drawing.Point(11, 56);
            this.rbConsignmentReturn.Name = "rbConsignmentReturn";
            this.rbConsignmentReturn.Size = new System.Drawing.Size(121, 17);
            this.rbConsignmentReturn.TabIndex = 0;
            this.rbConsignmentReturn.TabStop = true;
            this.rbConsignmentReturn.Text = "Consignment Return";
            this.rbConsignmentReturn.UseVisualStyleBackColor = false;
            // 
            // rbTransfer
            // 
            this.rbTransfer.AutoSize = true;
            this.rbTransfer.BackColor = System.Drawing.Color.Transparent;
            this.rbTransfer.Location = new System.Drawing.Point(11, 33);
            this.rbTransfer.Name = "rbTransfer";
            this.rbTransfer.Size = new System.Drawing.Size(64, 17);
            this.rbTransfer.TabIndex = 0;
            this.rbTransfer.TabStop = true;
            this.rbTransfer.Text = "Transfer";
            this.rbTransfer.UseVisualStyleBackColor = false;
            // 
            // gbItem
            // 
            this.gbItem.BackgroundColor = System.Drawing.Color.White;
            this.gbItem.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbItem.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbItem.BorderWidth = 1F;
            this.gbItem.Caption = "";
            this.gbItem.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbItem.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbItem.CaptionHeight = 25;
            this.gbItem.CaptionVisible = true;
            this.gbItem.Controls.Add(this.txtDescription);
            this.gbItem.Controls.Add(this.cboItemCode);
            this.gbItem.Controls.Add(this.lblDescription);
            this.gbItem.Controls.Add(this.lblItemCode);
            this.gbItem.CornerRadius = 5;
            this.gbItem.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbItem.DropShadowThickness = 3;
            this.gbItem.DropShadowVisible = true;
            this.gbItem.Location = new System.Drawing.Point(12, 104);
            this.gbItem.Name = "gbItem";
            this.gbItem.Size = new System.Drawing.Size(618, 86);
            this.gbItem.TabIndex = 11;
            this.gbItem.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(167, 50);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(428, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(9, 49);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(139, 21);
            this.cboItemCode.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(164, 33);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.BackColor = System.Drawing.Color.Transparent;
            this.lblItemCode.Location = new System.Drawing.Point(6, 33);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(55, 13);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "Item Code";
            // 
            // gbQty
            // 
            this.gbQty.BackgroundColor = System.Drawing.Color.White;
            this.gbQty.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbQty.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbQty.BorderWidth = 1F;
            this.gbQty.Caption = "";
            this.gbQty.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbQty.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbQty.CaptionHeight = 25;
            this.gbQty.CaptionVisible = true;
            this.gbQty.Controls.Add(this.txtTransferringQty);
            this.gbQty.Controls.Add(this.lblTransferringQty);
            this.gbQty.Controls.Add(this.txtQtyOnHand);
            this.gbQty.Controls.Add(this.lblQtyOnHand);
            this.gbQty.CornerRadius = 5;
            this.gbQty.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbQty.DropShadowThickness = 3;
            this.gbQty.DropShadowVisible = true;
            this.gbQty.Location = new System.Drawing.Point(10, 196);
            this.gbQty.Name = "gbQty";
            this.gbQty.Size = new System.Drawing.Size(305, 94);
            this.gbQty.TabIndex = 12;
            this.gbQty.TabStop = false;
            // 
            // txtTransferringQty
            // 
            this.txtTransferringQty.Location = new System.Drawing.Point(156, 50);
            this.txtTransferringQty.Name = "txtTransferringQty";
            this.txtTransferringQty.Size = new System.Drawing.Size(139, 20);
            this.txtTransferringQty.TabIndex = 2;
            // 
            // lblTransferringQty
            // 
            this.lblTransferringQty.AutoSize = true;
            this.lblTransferringQty.BackColor = System.Drawing.Color.Transparent;
            this.lblTransferringQty.Location = new System.Drawing.Point(153, 33);
            this.lblTransferringQty.Name = "lblTransferringQty";
            this.lblTransferringQty.Size = new System.Drawing.Size(82, 13);
            this.lblTransferringQty.TabIndex = 0;
            this.lblTransferringQty.Text = "Transferring Qty";
            // 
            // txtQtyOnHand
            // 
            this.txtQtyOnHand.Location = new System.Drawing.Point(11, 50);
            this.txtQtyOnHand.Name = "txtQtyOnHand";
            this.txtQtyOnHand.Size = new System.Drawing.Size(139, 20);
            this.txtQtyOnHand.TabIndex = 2;
            // 
            // lblQtyOnHand
            // 
            this.lblQtyOnHand.AutoSize = true;
            this.lblQtyOnHand.BackColor = System.Drawing.Color.Transparent;
            this.lblQtyOnHand.Location = new System.Drawing.Point(8, 33);
            this.lblQtyOnHand.Name = "lblQtyOnHand";
            this.lblQtyOnHand.Size = new System.Drawing.Size(69, 13);
            this.lblQtyOnHand.TabIndex = 0;
            this.lblQtyOnHand.Text = "Qty On Hand";
            // 
            // gbRef
            // 
            this.gbRef.BackgroundColor = System.Drawing.Color.White;
            this.gbRef.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbRef.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbRef.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbRef.BorderWidth = 1F;
            this.gbRef.Caption = "";
            this.gbRef.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbRef.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbRef.CaptionHeight = 25;
            this.gbRef.CaptionVisible = true;
            this.gbRef.Controls.Add(this.txtRefNote);
            this.gbRef.Controls.Add(this.lblRefNote);
            this.gbRef.Controls.Add(this.txtTrnsReferenceNo);
            this.gbRef.Controls.Add(this.lblTrnsReferenceNo);
            this.gbRef.CornerRadius = 5;
            this.gbRef.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbRef.DropShadowThickness = 3;
            this.gbRef.DropShadowVisible = true;
            this.gbRef.Location = new System.Drawing.Point(321, 196);
            this.gbRef.Name = "gbRef";
            this.gbRef.Size = new System.Drawing.Size(309, 94);
            this.gbRef.TabIndex = 12;
            this.gbRef.TabStop = false;
            // 
            // txtRefNote
            // 
            this.txtRefNote.Location = new System.Drawing.Point(115, 57);
            this.txtRefNote.Name = "txtRefNote";
            this.txtRefNote.Size = new System.Drawing.Size(171, 20);
            this.txtRefNote.TabIndex = 2;
            // 
            // lblRefNote
            // 
            this.lblRefNote.AutoSize = true;
            this.lblRefNote.BackColor = System.Drawing.Color.Transparent;
            this.lblRefNote.Location = new System.Drawing.Point(8, 60);
            this.lblRefNote.Name = "lblRefNote";
            this.lblRefNote.Size = new System.Drawing.Size(50, 13);
            this.lblRefNote.TabIndex = 0;
            this.lblRefNote.Text = "Ref Note";
            // 
            // txtTrnsReferenceNo
            // 
            this.txtTrnsReferenceNo.Location = new System.Drawing.Point(115, 30);
            this.txtTrnsReferenceNo.Name = "txtTrnsReferenceNo";
            this.txtTrnsReferenceNo.Size = new System.Drawing.Size(171, 20);
            this.txtTrnsReferenceNo.TabIndex = 2;
            // 
            // lblTrnsReferenceNo
            // 
            this.lblTrnsReferenceNo.AutoSize = true;
            this.lblTrnsReferenceNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTrnsReferenceNo.Location = new System.Drawing.Point(8, 33);
            this.lblTrnsReferenceNo.Name = "lblTrnsReferenceNo";
            this.lblTrnsReferenceNo.Size = new System.Drawing.Size(101, 13);
            this.lblTrnsReferenceNo.TabIndex = 0;
            this.lblTrnsReferenceNo.Text = "Trns. Reference No";
            // 
            // gbDatePrint
            // 
            this.gbDatePrint.BackgroundColor = System.Drawing.Color.White;
            this.gbDatePrint.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbDatePrint.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbDatePrint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbDatePrint.BorderWidth = 1F;
            this.gbDatePrint.Caption = "";
            this.gbDatePrint.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbDatePrint.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbDatePrint.CaptionHeight = 25;
            this.gbDatePrint.CaptionVisible = true;
            this.gbDatePrint.Controls.Add(this.dtpSelectDate);
            this.gbDatePrint.Controls.Add(this.lblSelectTheDate);
            this.gbDatePrint.Controls.Add(this.btnPrint);
            this.gbDatePrint.CornerRadius = 5;
            this.gbDatePrint.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbDatePrint.DropShadowThickness = 3;
            this.gbDatePrint.DropShadowVisible = true;
            this.gbDatePrint.Location = new System.Drawing.Point(12, 296);
            this.gbDatePrint.Name = "gbDatePrint";
            this.gbDatePrint.Size = new System.Drawing.Size(303, 71);
            this.gbDatePrint.TabIndex = 13;
            this.gbDatePrint.TabStop = false;
            // 
            // dtpSelectDate
            // 
            this.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSelectDate.Location = new System.Drawing.Point(98, 35);
            this.dtpSelectDate.Name = "dtpSelectDate";
            this.dtpSelectDate.Size = new System.Drawing.Size(115, 20);
            this.dtpSelectDate.TabIndex = 2;
            // 
            // lblSelectTheDate
            // 
            this.lblSelectTheDate.AutoSize = true;
            this.lblSelectTheDate.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectTheDate.Location = new System.Drawing.Point(6, 39);
            this.lblSelectTheDate.Name = "lblSelectTheDate";
            this.lblSelectTheDate.Size = new System.Drawing.Size(85, 13);
            this.lblSelectTheDate.TabIndex = 1;
            this.lblSelectTheDate.Text = "Select The Date";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(219, 32);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Location = new System.Drawing.Point(433, 344);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(92, 23);
            this.btnTransfer.TabIndex = 0;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(531, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // FrmIndividualTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(639, 379);
            this.Controls.Add(this.gbDatePrint);
            this.Controls.Add(this.gbRef);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.gbQty);
            this.Controls.Add(this.gbItem);
            this.Controls.Add(this.gbSelectTransferLocation);
            this.Controls.Add(this.gbSelectTheTransferType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIndividualTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Individual Transfer";
            this.gbSelectTransferLocation.ResumeLayout(false);
            this.gbSelectTransferLocation.PerformLayout();
            this.gbSelectTheTransferType.ResumeLayout(false);
            this.gbSelectTheTransferType.PerformLayout();
            this.gbItem.ResumeLayout(false);
            this.gbItem.PerformLayout();
            this.gbQty.ResumeLayout(false);
            this.gbQty.PerformLayout();
            this.gbRef.ResumeLayout(false);
            this.gbRef.PerformLayout();
            this.gbDatePrint.ResumeLayout(false);
            this.gbDatePrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CZRoundedGroupBox gbSelectTransferLocation;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.CZRoundedGroupBox gbSelectTheTransferType;
        private System.Windows.Forms.RadioButton rbConsignmentReturn;
        private System.Windows.Forms.RadioButton rbTransfer;
        private System.Windows.Forms.CZRoundedGroupBox gbItem;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.CZRoundedGroupBox gbQty;
        private System.Windows.Forms.TextBox txtTransferringQty;
        private System.Windows.Forms.Label lblTransferringQty;
        private System.Windows.Forms.TextBox txtQtyOnHand;
        private System.Windows.Forms.Label lblQtyOnHand;
        private System.Windows.Forms.CZRoundedGroupBox gbRef;
        private System.Windows.Forms.TextBox txtRefNote;
        private System.Windows.Forms.Label lblRefNote;
        private System.Windows.Forms.TextBox txtTrnsReferenceNo;
        private System.Windows.Forms.Label lblTrnsReferenceNo;
        private System.Windows.Forms.CZRoundedGroupBox gbDatePrint;
        private System.Windows.Forms.DateTimePicker dtpSelectDate;
        private System.Windows.Forms.Label lblSelectTheDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnClose;
    }
}