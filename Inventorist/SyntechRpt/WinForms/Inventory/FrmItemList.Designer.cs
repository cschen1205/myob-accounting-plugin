namespace SyntechRpt.WinForms.Inventory
{
    partial class FrmItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemList));
            this.tabControlItemScreen = new System.Windows.Forms.TabControl();
            this.tabPageAllItems = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.tabPageSoldItems = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSold = new System.Windows.Forms.DataGridView();
            this.lblCountSold = new System.Windows.Forms.Label();
            this.tabPageBoughtItems = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvBought = new System.Windows.Forms.DataGridView();
            this.lblCountBought = new System.Windows.Forms.Label();
            this.tabPageIntentoriedItems = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvInventoried = new System.Windows.Forms.DataGridView();
            this.lblCountInventoried = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateItem = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelItem = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cboSearchFieldName = new System.Windows.Forms.ComboBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.txtSearchFieldValue = new System.Windows.Forms.TextBox();
            this.tabControlItemScreen.SuspendLayout();
            this.tabPageAllItems.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.tabPageSoldItems.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSold)).BeginInit();
            this.tabPageBoughtItems.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBought)).BeginInit();
            this.tabPageIntentoriedItems.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoried)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlItemScreen
            // 
            resources.ApplyResources(this.tabControlItemScreen, "tabControlItemScreen");
            this.tabControlItemScreen.Controls.Add(this.tabPageAllItems);
            this.tabControlItemScreen.Controls.Add(this.tabPageSoldItems);
            this.tabControlItemScreen.Controls.Add(this.tabPageBoughtItems);
            this.tabControlItemScreen.Controls.Add(this.tabPageIntentoriedItems);
            this.tabControlItemScreen.Name = "tabControlItemScreen";
            this.tabControlItemScreen.SelectedIndex = 0;
            // 
            // tabPageAllItems
            // 
            this.tabPageAllItems.Controls.Add(this.groupBox1);
            this.tabPageAllItems.Controls.Add(this.lblCountAll);
            resources.ApplyResources(this.tabPageAllItems, "tabPageAllItems");
            this.tabPageAllItems.Name = "tabPageAllItems";
            this.tabPageAllItems.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.dgvAll);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvAll, "dgvAll");
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.ReadOnly = true;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.ShowEditingIcon = false;
            this.dgvAll.DoubleClick += new System.EventHandler(this.dgvAll_DoubleClick);
            // 
            // lblCountAll
            // 
            resources.ApplyResources(this.lblCountAll, "lblCountAll");
            this.lblCountAll.Name = "lblCountAll";
            // 
            // tabPageSoldItems
            // 
            this.tabPageSoldItems.Controls.Add(this.groupBox3);
            this.tabPageSoldItems.Controls.Add(this.lblCountSold);
            resources.ApplyResources(this.tabPageSoldItems, "tabPageSoldItems");
            this.tabPageSoldItems.Name = "tabPageSoldItems";
            this.tabPageSoldItems.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.dgvSold);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // dgvSold
            // 
            this.dgvSold.AllowUserToAddRows = false;
            this.dgvSold.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvSold, "dgvSold");
            this.dgvSold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSold.Name = "dgvSold";
            this.dgvSold.ReadOnly = true;
            this.dgvSold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSold.ShowEditingIcon = false;
            this.dgvSold.DoubleClick += new System.EventHandler(this.dgvSold_DoubleClick);
            // 
            // lblCountSold
            // 
            resources.ApplyResources(this.lblCountSold, "lblCountSold");
            this.lblCountSold.Name = "lblCountSold";
            // 
            // tabPageBoughtItems
            // 
            this.tabPageBoughtItems.Controls.Add(this.groupBox4);
            this.tabPageBoughtItems.Controls.Add(this.lblCountBought);
            resources.ApplyResources(this.tabPageBoughtItems, "tabPageBoughtItems");
            this.tabPageBoughtItems.Name = "tabPageBoughtItems";
            this.tabPageBoughtItems.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.dgvBought);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // dgvBought
            // 
            this.dgvBought.AllowUserToAddRows = false;
            this.dgvBought.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvBought, "dgvBought");
            this.dgvBought.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBought.Name = "dgvBought";
            this.dgvBought.ReadOnly = true;
            this.dgvBought.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBought.ShowEditingIcon = false;
            this.dgvBought.DoubleClick += new System.EventHandler(this.dgvBought_DoubleClick);
            // 
            // lblCountBought
            // 
            resources.ApplyResources(this.lblCountBought, "lblCountBought");
            this.lblCountBought.Name = "lblCountBought";
            // 
            // tabPageIntentoriedItems
            // 
            this.tabPageIntentoriedItems.Controls.Add(this.groupBox5);
            this.tabPageIntentoriedItems.Controls.Add(this.lblCountInventoried);
            resources.ApplyResources(this.tabPageIntentoriedItems, "tabPageIntentoriedItems");
            this.tabPageIntentoriedItems.Name = "tabPageIntentoriedItems";
            this.tabPageIntentoriedItems.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.dgvInventoried);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // dgvInventoried
            // 
            this.dgvInventoried.AllowUserToAddRows = false;
            this.dgvInventoried.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvInventoried, "dgvInventoried");
            this.dgvInventoried.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoried.Name = "dgvInventoried";
            this.dgvInventoried.ReadOnly = true;
            this.dgvInventoried.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoried.ShowEditingIcon = false;
            this.dgvInventoried.DoubleClick += new System.EventHandler(this.dgvInventoried_DoubleClick);
            // 
            // lblCountInventoried
            // 
            resources.ApplyResources(this.lblCountInventoried, "lblCountInventoried");
            this.lblCountInventoried.Name = "lblCountInventoried";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnCreateItem);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnDelItem);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::SyntechRpt.Properties.Resources.cancel_record24;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateItem
            // 
            this.btnCreateItem.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.btnCreateItem, "btnCreateItem");
            this.btnCreateItem.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateItem.Name = "btnCreateItem";
            this.btnCreateItem.UseVisualStyleBackColor = false;
            this.btnCreateItem.Click += new System.EventHandler(this.btnCreateItem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Image = global::SyntechRpt.Properties.Resources.reset;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelItem
            // 
            this.btnDelItem.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.btnDelItem, "btnDelItem");
            this.btnDelItem.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.UseVisualStyleBackColor = false;
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // gbSearch
            // 
            resources.ApplyResources(this.gbSearch, "gbSearch");
            this.gbSearch.Controls.Add(this.cboSearchFieldName);
            this.gbSearch.Controls.Add(this.btnSearchItem);
            this.gbSearch.Controls.Add(this.txtSearchFieldValue);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.TabStop = false;
            // 
            // cboSearchFieldName
            // 
            this.cboSearchFieldName.FormattingEnabled = true;
            resources.ApplyResources(this.cboSearchFieldName, "cboSearchFieldName");
            this.cboSearchFieldName.Name = "cboSearchFieldName";
            // 
            // btnSearchItem
            // 
            resources.ApplyResources(this.btnSearchItem, "btnSearchItem");
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // txtSearchFieldValue
            // 
            resources.ApplyResources(this.txtSearchFieldValue, "txtSearchFieldValue");
            this.txtSearchFieldValue.Name = "txtSearchFieldValue";
            // 
            // FrmItemsList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlItemScreen);
            this.Name = "FrmItemsList";
            this.Load += new System.EventHandler(this.frmItemScreen_Load);
            this.tabControlItemScreen.ResumeLayout(false);
            this.tabPageAllItems.ResumeLayout(false);
            this.tabPageAllItems.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.tabPageSoldItems.ResumeLayout(false);
            this.tabPageSoldItems.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSold)).EndInit();
            this.tabPageBoughtItems.ResumeLayout(false);
            this.tabPageBoughtItems.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBought)).EndInit();
            this.tabPageIntentoriedItems.ResumeLayout(false);
            this.tabPageIntentoriedItems.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoried)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlItemScreen;
        private System.Windows.Forms.TabPage tabPageAllItems;
        private System.Windows.Forms.TabPage tabPageSoldItems;
        private System.Windows.Forms.TabPage tabPageBoughtItems;
        private System.Windows.Forms.TabPage tabPageIntentoriedItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelItem;
        private System.Windows.Forms.Button btnCreateItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvSold;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvBought;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvInventoried;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.Label lblCountSold;
        private System.Windows.Forms.Label lblCountBought;
        private System.Windows.Forms.Label lblCountInventoried;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.ComboBox cboSearchFieldName;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.TextBox txtSearchFieldValue;
    }
}