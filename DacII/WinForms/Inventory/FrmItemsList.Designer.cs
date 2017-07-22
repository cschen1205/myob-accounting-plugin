namespace DacII.WinForms.Inventory
{
    partial class FrmItemsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemsList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlItemScreen = new System.Windows.Forms.TabControl();
            this.tabPageAllItems = new System.Windows.Forms.TabPage();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.tabPageSoldItems = new System.Windows.Forms.TabPage();
            this.lblCountSold = new System.Windows.Forms.Label();
            this.dgvSold = new System.Windows.Forms.DataGridView();
            this.tabPageBoughtItems = new System.Windows.Forms.TabPage();
            this.dgvBought = new System.Windows.Forms.DataGridView();
            this.lblCountBought = new System.Windows.Forms.Label();
            this.tabPageIntentoriedItems = new System.Windows.Forms.TabPage();
            this.lblCountInventoried = new System.Windows.Forms.Label();
            this.dgvInventoried = new System.Windows.Forms.DataGridView();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.btnCreateItem = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.CZRoundedGroupBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnPrintItemsList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboSearchFieldName = new System.Windows.Forms.ComboBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.txtSearchFieldValue = new System.Windows.Forms.TextBox();
            this.czRoundedGroupBox1 = new System.Windows.Forms.CZRoundedGroupBox();
            this.czRoundedGroupBox2 = new System.Windows.Forms.CZRoundedGroupBox();
            this.tabControlItemScreen.SuspendLayout();
            this.tabPageAllItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.tabPageSoldItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSold)).BeginInit();
            this.tabPageBoughtItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBought)).BeginInit();
            this.tabPageIntentoriedItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoried)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.czRoundedGroupBox1.SuspendLayout();
            this.czRoundedGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlItemScreen
            // 
            resources.ApplyResources(this.tabControlItemScreen, "tabControlItemScreen");
            this.tabControlItemScreen.Controls.Add(this.tabPageAllItems);
            this.tabControlItemScreen.Controls.Add(this.tabPageSoldItems);
            this.tabControlItemScreen.Controls.Add(this.tabPageBoughtItems);
            this.tabControlItemScreen.Controls.Add(this.tabPageIntentoriedItems);
            this.tabControlItemScreen.HotTrack = true;
            this.tabControlItemScreen.Name = "tabControlItemScreen";
            this.tabControlItemScreen.SelectedIndex = 0;
            // 
            // tabPageAllItems
            // 
            this.tabPageAllItems.Controls.Add(this.lblCountAll);
            this.tabPageAllItems.Controls.Add(this.dgvAll);
            resources.ApplyResources(this.tabPageAllItems, "tabPageAllItems");
            this.tabPageAllItems.Name = "tabPageAllItems";
            this.tabPageAllItems.UseVisualStyleBackColor = true;
            // 
            // lblCountAll
            // 
            resources.ApplyResources(this.lblCountAll, "lblCountAll");
            this.lblCountAll.Name = "lblCountAll";
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvAll, "dgvAll");
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAll.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.ReadOnly = true;
            this.dgvAll.RowHeadersVisible = false;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.ShowEditingIcon = false;
            this.dgvAll.DoubleClick += new System.EventHandler(this.OpenFrom_AllItems);
            // 
            // tabPageSoldItems
            // 
            this.tabPageSoldItems.Controls.Add(this.lblCountSold);
            this.tabPageSoldItems.Controls.Add(this.dgvSold);
            resources.ApplyResources(this.tabPageSoldItems, "tabPageSoldItems");
            this.tabPageSoldItems.Name = "tabPageSoldItems";
            this.tabPageSoldItems.UseVisualStyleBackColor = true;
            // 
            // lblCountSold
            // 
            resources.ApplyResources(this.lblCountSold, "lblCountSold");
            this.lblCountSold.Name = "lblCountSold";
            // 
            // dgvSold
            // 
            this.dgvSold.AllowUserToAddRows = false;
            this.dgvSold.AllowUserToDeleteRows = false;
            this.dgvSold.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvSold.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgvSold, "dgvSold");
            this.dgvSold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSold.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSold.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSold.Name = "dgvSold";
            this.dgvSold.ReadOnly = true;
            this.dgvSold.RowHeadersVisible = false;
            this.dgvSold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSold.ShowEditingIcon = false;
            this.dgvSold.DoubleClick += new System.EventHandler(this.OpenFrom_SoldItems);
            // 
            // tabPageBoughtItems
            // 
            this.tabPageBoughtItems.Controls.Add(this.dgvBought);
            this.tabPageBoughtItems.Controls.Add(this.lblCountBought);
            resources.ApplyResources(this.tabPageBoughtItems, "tabPageBoughtItems");
            this.tabPageBoughtItems.Name = "tabPageBoughtItems";
            this.tabPageBoughtItems.UseVisualStyleBackColor = true;
            // 
            // dgvBought
            // 
            this.dgvBought.AllowUserToAddRows = false;
            this.dgvBought.AllowUserToDeleteRows = false;
            this.dgvBought.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvBought.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.dgvBought, "dgvBought");
            this.dgvBought.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBought.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBought.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBought.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBought.Name = "dgvBought";
            this.dgvBought.ReadOnly = true;
            this.dgvBought.RowHeadersVisible = false;
            this.dgvBought.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBought.ShowEditingIcon = false;
            this.dgvBought.DoubleClick += new System.EventHandler(this.OpenFrom_BoughtItems);
            // 
            // lblCountBought
            // 
            resources.ApplyResources(this.lblCountBought, "lblCountBought");
            this.lblCountBought.Name = "lblCountBought";
            // 
            // tabPageIntentoriedItems
            // 
            this.tabPageIntentoriedItems.Controls.Add(this.lblCountInventoried);
            this.tabPageIntentoriedItems.Controls.Add(this.dgvInventoried);
            resources.ApplyResources(this.tabPageIntentoriedItems, "tabPageIntentoriedItems");
            this.tabPageIntentoriedItems.Name = "tabPageIntentoriedItems";
            this.tabPageIntentoriedItems.UseVisualStyleBackColor = true;
            // 
            // lblCountInventoried
            // 
            resources.ApplyResources(this.lblCountInventoried, "lblCountInventoried");
            this.lblCountInventoried.Name = "lblCountInventoried";
            // 
            // dgvInventoried
            // 
            this.dgvInventoried.AllowUserToAddRows = false;
            this.dgvInventoried.AllowUserToDeleteRows = false;
            this.dgvInventoried.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(210)))), ((int)(((byte)(241)))));
            this.dgvInventoried.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dgvInventoried, "dgvInventoried");
            this.dgvInventoried.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventoried.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventoried.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(126)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventoried.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvInventoried.Name = "dgvInventoried";
            this.dgvInventoried.ReadOnly = true;
            this.dgvInventoried.RowHeadersVisible = false;
            this.dgvInventoried.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoried.ShowEditingIcon = false;
            this.dgvInventoried.DoubleClick += new System.EventHandler(this.OpenFrom_InventoriedItems);
            // 
            // imgLst
            // 
            this.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imgLst, "imgLst");
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnCreateItem
            // 
            resources.ApplyResources(this.btnCreateItem, "btnCreateItem");
            this.btnCreateItem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCreateItem.BackgroundImage = global::DacII.Properties.Resources.add_16x16;
            this.btnCreateItem.Name = "btnCreateItem";
            this.btnCreateItem.UseVisualStyleBackColor = false;
            this.btnCreateItem.Click += new System.EventHandler(this.btnCreateItem_Click);
            // 
            // gbSearch
            // 
            resources.ApplyResources(this.gbSearch, "gbSearch");
            this.gbSearch.BackgroundColor = System.Drawing.Color.White;
            this.gbSearch.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.gbSearch.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.gbSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.gbSearch.BorderWidth = 1F;
            this.gbSearch.Caption = "Inventory --> Items List";
            this.gbSearch.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.gbSearch.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.gbSearch.CaptionHeight = 25;
            this.gbSearch.CaptionVisible = true;
            this.gbSearch.Controls.Add(this.btnClose2);
            this.gbSearch.Controls.Add(this.tabControlItemScreen);
            this.gbSearch.CornerRadius = 5;
            this.gbSearch.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.gbSearch.DropShadowThickness = 3;
            this.gbSearch.DropShadowVisible = true;
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.TabStop = false;
            // 
            // btnClose2
            // 
            resources.ApplyResources(this.btnClose2, "btnClose2");
            this.btnClose2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose2.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose2.FlatAppearance.BorderSize = 0;
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintItemsList
            // 
            resources.ApplyResources(this.btnPrintItemsList, "btnPrintItemsList");
            this.btnPrintItemsList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrintItemsList.BackgroundImage = global::DacII.Properties.Resources.print_32x32;
            this.btnPrintItemsList.FlatAppearance.BorderSize = 0;
            this.btnPrintItemsList.Name = "btnPrintItemsList";
            this.btnPrintItemsList.UseVisualStyleBackColor = false;
            this.btnPrintItemsList.Click += new System.EventHandler(this.btnPrintItemsListSummary_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImage = global::DacII.Properties.Resources.cancel_16x16;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboSearchFieldName
            // 
            resources.ApplyResources(this.cboSearchFieldName, "cboSearchFieldName");
            this.cboSearchFieldName.FormattingEnabled = true;
            this.cboSearchFieldName.Name = "cboSearchFieldName";
            // 
            // btnSearchItem
            // 
            resources.ApplyResources(this.btnSearchItem, "btnSearchItem");
            this.btnSearchItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchItem.BackgroundImage = global::DacII.Properties.Resources.reset_16x16;
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.UseVisualStyleBackColor = false;
            this.btnSearchItem.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearchFieldValue
            // 
            resources.ApplyResources(this.txtSearchFieldValue, "txtSearchFieldValue");
            this.txtSearchFieldValue.Name = "txtSearchFieldValue";
            // 
            // czRoundedGroupBox1
            // 
            resources.ApplyResources(this.czRoundedGroupBox1, "czRoundedGroupBox1");
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
            this.czRoundedGroupBox1.Controls.Add(this.label1);
            this.czRoundedGroupBox1.Controls.Add(this.cboSearchFieldName);
            this.czRoundedGroupBox1.Controls.Add(this.label2);
            this.czRoundedGroupBox1.Controls.Add(this.txtSearchFieldValue);
            this.czRoundedGroupBox1.CornerRadius = 5;
            this.czRoundedGroupBox1.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox1.DropShadowThickness = 3;
            this.czRoundedGroupBox1.DropShadowVisible = true;
            this.czRoundedGroupBox1.Name = "czRoundedGroupBox1";
            this.czRoundedGroupBox1.DoubleClick += new System.EventHandler(this.OpenFrom_AllItems);
            // 
            // czRoundedGroupBox2
            // 
            resources.ApplyResources(this.czRoundedGroupBox2, "czRoundedGroupBox2");
            this.czRoundedGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.czRoundedGroupBox2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.czRoundedGroupBox2.BackgroundGradientMode = System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxGradientMode.Vertical;
            this.czRoundedGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.czRoundedGroupBox2.BorderWidth = 1F;
            this.czRoundedGroupBox2.Caption = "";
            this.czRoundedGroupBox2.CaptionAlignment = System.Windows.Forms.CZRoundedGroupBox.CaptionAlignmentEnum.Center;
            this.czRoundedGroupBox2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.czRoundedGroupBox2.CaptionHeight = 25;
            this.czRoundedGroupBox2.CaptionVisible = true;
            this.czRoundedGroupBox2.Controls.Add(this.btnClose);
            this.czRoundedGroupBox2.Controls.Add(this.btnPrintItemsList);
            this.czRoundedGroupBox2.Controls.Add(this.btnCreateItem);
            this.czRoundedGroupBox2.Controls.Add(this.btnSearchItem);
            this.czRoundedGroupBox2.CornerRadius = 5;
            this.czRoundedGroupBox2.Corners = ((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners)((((System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthWest | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.NorthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthEast)
                        | System.Windows.Forms.CZRoundedGroupBox.RoundedGroupBoxCorners.SouthWest)));
            this.czRoundedGroupBox2.DropShadowThickness = 3;
            this.czRoundedGroupBox2.DropShadowVisible = true;
            this.czRoundedGroupBox2.Name = "czRoundedGroupBox2";
            // 
            // FrmItemsList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.czRoundedGroupBox2);
            this.Controls.Add(this.czRoundedGroupBox1);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmItemsList";
            this.tabControlItemScreen.ResumeLayout(false);
            this.tabPageAllItems.ResumeLayout(false);
            this.tabPageAllItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.tabPageSoldItems.ResumeLayout(false);
            this.tabPageSoldItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSold)).EndInit();
            this.tabPageBoughtItems.ResumeLayout(false);
            this.tabPageBoughtItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBought)).EndInit();
            this.tabPageIntentoriedItems.ResumeLayout(false);
            this.tabPageIntentoriedItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoried)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.czRoundedGroupBox1.ResumeLayout(false);
            this.czRoundedGroupBox1.PerformLayout();
            this.czRoundedGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlItemScreen;
        private System.Windows.Forms.TabPage tabPageAllItems;
        private System.Windows.Forms.TabPage tabPageSoldItems;
        private System.Windows.Forms.TabPage tabPageBoughtItems;
        private System.Windows.Forms.TabPage tabPageIntentoriedItems;
        private System.Windows.Forms.Button btnCreateItem;
        private System.Windows.Forms.DataGridView dgvSold;
        private System.Windows.Forms.DataGridView dgvBought;
        private System.Windows.Forms.DataGridView dgvInventoried;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.Label lblCountSold;
        private System.Windows.Forms.Label lblCountBought;
        private System.Windows.Forms.Label lblCountInventoried;
        private System.Windows.Forms.CZRoundedGroupBox gbSearch;
        private System.Windows.Forms.ComboBox cboSearchFieldName;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.TextBox txtSearchFieldValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintItemsList;
        private System.Windows.Forms.ImageList imgLst;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox1;
        private System.Windows.Forms.CZRoundedGroupBox czRoundedGroupBox2;
        private System.Windows.Forms.Button btnClose2;
    }
}