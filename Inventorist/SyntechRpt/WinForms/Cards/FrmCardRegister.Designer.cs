namespace SyntechRpt.WinForms.Cards
{
    partial class FrmCardRegister
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
            this.tc = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.tpCustomers = new System.Windows.Forms.TabPage();
            this.lblCountCustomers = new System.Windows.Forms.Label();
            this.btnCloseCustomers = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnDelCustomer = new System.Windows.Forms.Button();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.tpSuppliers = new System.Windows.Forms.TabPage();
            this.lblCountSuppliers = new System.Windows.Forms.Label();
            this.btnCloseSuppliers = new System.Windows.Forms.Button();
            this.btnDelSupplier = new System.Windows.Forms.Button();
            this.btnCreateSupplier = new System.Windows.Forms.Button();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.tpEmployees = new System.Windows.Forms.TabPage();
            this.lblCountEmployees = new System.Windows.Forms.Label();
            this.btnCloseEmployees = new System.Windows.Forms.Button();
            this.btnDelEmployee = new System.Windows.Forms.Button();
            this.btnCreateEmployee = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.tc.SuspendLayout();
            this.tpAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.tpCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tpSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.tpEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Controls.Add(this.tpAll);
            this.tc.Controls.Add(this.tpCustomers);
            this.tc.Controls.Add(this.tpSuppliers);
            this.tc.Controls.Add(this.tpEmployees);
            this.tc.Location = new System.Drawing.Point(12, 12);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(654, 441);
            this.tc.TabIndex = 0;
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.btnClose);
            this.tpAll.Controls.Add(this.lblCountAll);
            this.tpAll.Controls.Add(this.btnDel);
            this.tpAll.Controls.Add(this.dgvAll);
            this.tpAll.Location = new System.Drawing.Point(4, 22);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(646, 415);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "All";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnClose.Location = new System.Drawing.Point(584, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblCountAll
            // 
            this.lblCountAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountAll.AutoSize = true;
            this.lblCountAll.Location = new System.Drawing.Point(6, 396);
            this.lblCountAll.Name = "lblCountAll";
            this.lblCountAll.Size = new System.Drawing.Size(59, 13);
            this.lblCountAll.TabIndex = 1;
            this.lblCountAll.Text = "# Found: 0";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDel.Location = new System.Drawing.Point(522, 353);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 56);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "Delete";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAll.Location = new System.Drawing.Point(6, 6);
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(634, 341);
            this.dgvAll.TabIndex = 0;
            this.dgvAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAll_MouseDoubleClick);
            // 
            // tpCustomers
            // 
            this.tpCustomers.Controls.Add(this.lblCountCustomers);
            this.tpCustomers.Controls.Add(this.btnCloseCustomers);
            this.tpCustomers.Controls.Add(this.dgvCustomers);
            this.tpCustomers.Controls.Add(this.btnDelCustomer);
            this.tpCustomers.Controls.Add(this.btnCreateCustomer);
            this.tpCustomers.Location = new System.Drawing.Point(4, 22);
            this.tpCustomers.Name = "tpCustomers";
            this.tpCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomers.Size = new System.Drawing.Size(646, 415);
            this.tpCustomers.TabIndex = 1;
            this.tpCustomers.Text = "Customers";
            this.tpCustomers.UseVisualStyleBackColor = true;
            // 
            // lblCountCustomers
            // 
            this.lblCountCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountCustomers.AutoSize = true;
            this.lblCountCustomers.Location = new System.Drawing.Point(6, 396);
            this.lblCountCustomers.Name = "lblCountCustomers";
            this.lblCountCustomers.Size = new System.Drawing.Size(59, 13);
            this.lblCountCustomers.TabIndex = 5;
            this.lblCountCustomers.Text = "# Found: 0";
            // 
            // btnCloseCustomers
            // 
            this.btnCloseCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseCustomers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseCustomers.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnCloseCustomers.Location = new System.Drawing.Point(584, 353);
            this.btnCloseCustomers.Name = "btnCloseCustomers";
            this.btnCloseCustomers.Size = new System.Drawing.Size(56, 56);
            this.btnCloseCustomers.TabIndex = 4;
            this.btnCloseCustomers.Text = "Close";
            this.btnCloseCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCloseCustomers.UseVisualStyleBackColor = false;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCustomers.Location = new System.Drawing.Point(6, 6);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(634, 341);
            this.dgvCustomers.TabIndex = 3;
            this.dgvCustomers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCustomers_MouseDoubleClick);
            // 
            // btnDelCustomer
            // 
            this.btnDelCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCustomer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCustomer.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelCustomer.Location = new System.Drawing.Point(522, 353);
            this.btnDelCustomer.Name = "btnDelCustomer";
            this.btnDelCustomer.Size = new System.Drawing.Size(56, 56);
            this.btnDelCustomer.TabIndex = 2;
            this.btnDelCustomer.Text = "Delete";
            this.btnDelCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelCustomer.UseVisualStyleBackColor = false;
            this.btnDelCustomer.Click += new System.EventHandler(this.btnDelCustomer_Click);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCustomer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCustomer.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateCustomer.Location = new System.Drawing.Point(460, 353);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(56, 56);
            this.btnCreateCustomer.TabIndex = 1;
            this.btnCreateCustomer.Text = "Create";
            this.btnCreateCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateCustomer.UseVisualStyleBackColor = false;
            this.btnCreateCustomer.Click += new System.EventHandler(this.btnCreateCustomer_Click);
            // 
            // tpSuppliers
            // 
            this.tpSuppliers.Controls.Add(this.lblCountSuppliers);
            this.tpSuppliers.Controls.Add(this.btnCloseSuppliers);
            this.tpSuppliers.Controls.Add(this.btnDelSupplier);
            this.tpSuppliers.Controls.Add(this.btnCreateSupplier);
            this.tpSuppliers.Controls.Add(this.dgvSuppliers);
            this.tpSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tpSuppliers.Name = "tpSuppliers";
            this.tpSuppliers.Size = new System.Drawing.Size(646, 415);
            this.tpSuppliers.TabIndex = 2;
            this.tpSuppliers.Text = "Suppliers";
            this.tpSuppliers.UseVisualStyleBackColor = true;
            // 
            // lblCountSuppliers
            // 
            this.lblCountSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountSuppliers.AutoSize = true;
            this.lblCountSuppliers.Location = new System.Drawing.Point(3, 396);
            this.lblCountSuppliers.Name = "lblCountSuppliers";
            this.lblCountSuppliers.Size = new System.Drawing.Size(59, 13);
            this.lblCountSuppliers.TabIndex = 5;
            this.lblCountSuppliers.Text = "# Found: 0";
            // 
            // btnCloseSuppliers
            // 
            this.btnCloseSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseSuppliers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSuppliers.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnCloseSuppliers.Location = new System.Drawing.Point(584, 353);
            this.btnCloseSuppliers.Name = "btnCloseSuppliers";
            this.btnCloseSuppliers.Size = new System.Drawing.Size(56, 56);
            this.btnCloseSuppliers.TabIndex = 0;
            this.btnCloseSuppliers.Text = "Close";
            this.btnCloseSuppliers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCloseSuppliers.UseVisualStyleBackColor = false;
            this.btnCloseSuppliers.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelSupplier
            // 
            this.btnDelSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSupplier.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelSupplier.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelSupplier.Location = new System.Drawing.Point(522, 353);
            this.btnDelSupplier.Name = "btnDelSupplier";
            this.btnDelSupplier.Size = new System.Drawing.Size(56, 56);
            this.btnDelSupplier.TabIndex = 4;
            this.btnDelSupplier.Text = "Delete";
            this.btnDelSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelSupplier.UseVisualStyleBackColor = false;
            this.btnDelSupplier.Click += new System.EventHandler(this.btnDelSupplier_Click);
            // 
            // btnCreateSupplier
            // 
            this.btnCreateSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSupplier.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSupplier.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateSupplier.Location = new System.Drawing.Point(460, 353);
            this.btnCreateSupplier.Name = "btnCreateSupplier";
            this.btnCreateSupplier.Size = new System.Drawing.Size(56, 56);
            this.btnCreateSupplier.TabIndex = 3;
            this.btnCreateSupplier.Text = "Create";
            this.btnCreateSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateSupplier.UseVisualStyleBackColor = false;
            this.btnCreateSupplier.Click += new System.EventHandler(this.btnCreateSupplier_Click);
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSuppliers.Location = new System.Drawing.Point(6, 6);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(634, 341);
            this.dgvSuppliers.TabIndex = 1;
            this.dgvSuppliers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvSuppliers_MouseDoubleClick);
            // 
            // tpEmployees
            // 
            this.tpEmployees.Controls.Add(this.lblCountEmployees);
            this.tpEmployees.Controls.Add(this.btnCloseEmployees);
            this.tpEmployees.Controls.Add(this.btnDelEmployee);
            this.tpEmployees.Controls.Add(this.btnCreateEmployee);
            this.tpEmployees.Controls.Add(this.dgvEmployees);
            this.tpEmployees.Location = new System.Drawing.Point(4, 22);
            this.tpEmployees.Name = "tpEmployees";
            this.tpEmployees.Size = new System.Drawing.Size(646, 415);
            this.tpEmployees.TabIndex = 3;
            this.tpEmployees.Text = "Employees";
            this.tpEmployees.UseVisualStyleBackColor = true;
            // 
            // lblCountEmployees
            // 
            this.lblCountEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountEmployees.AutoSize = true;
            this.lblCountEmployees.Location = new System.Drawing.Point(3, 396);
            this.lblCountEmployees.Name = "lblCountEmployees";
            this.lblCountEmployees.Size = new System.Drawing.Size(59, 13);
            this.lblCountEmployees.TabIndex = 6;
            this.lblCountEmployees.Text = "# Found: 0";
            // 
            // btnCloseEmployees
            // 
            this.btnCloseEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseEmployees.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseEmployees.Image = global::SyntechRpt.Properties.Resources.cancel_record;
            this.btnCloseEmployees.Location = new System.Drawing.Point(584, 353);
            this.btnCloseEmployees.Name = "btnCloseEmployees";
            this.btnCloseEmployees.Size = new System.Drawing.Size(56, 56);
            this.btnCloseEmployees.TabIndex = 5;
            this.btnCloseEmployees.Text = "Close";
            this.btnCloseEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCloseEmployees.UseVisualStyleBackColor = false;
            // 
            // btnDelEmployee
            // 
            this.btnDelEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelEmployee.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelEmployee.Image = global::SyntechRpt.Properties.Resources.delete_line;
            this.btnDelEmployee.Location = new System.Drawing.Point(522, 353);
            this.btnDelEmployee.Name = "btnDelEmployee";
            this.btnDelEmployee.Size = new System.Drawing.Size(56, 56);
            this.btnDelEmployee.TabIndex = 4;
            this.btnDelEmployee.Text = "Delete";
            this.btnDelEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelEmployee.UseVisualStyleBackColor = false;
            this.btnDelEmployee.Click += new System.EventHandler(this.btnDelEmployee_Click);
            // 
            // btnCreateEmployee
            // 
            this.btnCreateEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateEmployee.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateEmployee.Image = global::SyntechRpt.Properties.Resources.new_line;
            this.btnCreateEmployee.Location = new System.Drawing.Point(460, 353);
            this.btnCreateEmployee.Name = "btnCreateEmployee";
            this.btnCreateEmployee.Size = new System.Drawing.Size(56, 56);
            this.btnCreateEmployee.TabIndex = 3;
            this.btnCreateEmployee.Text = "Create";
            this.btnCreateEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateEmployee.UseVisualStyleBackColor = false;
            this.btnCreateEmployee.Click += new System.EventHandler(this.btnCreateEmployee_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmployees.Location = new System.Drawing.Point(6, 6);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(634, 341);
            this.dgvEmployees.TabIndex = 1;
            this.dgvEmployees.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployees_MouseDoubleClick);
            // 
            // FrmCardRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 465);
            this.Controls.Add(this.tc);
            this.Name = "FrmCardRegister";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FrmCards_Load);
            this.tc.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            this.tpAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.tpCustomers.ResumeLayout(false);
            this.tpCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tpSuppliers.ResumeLayout(false);
            this.tpSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.tpEmployees.ResumeLayout(false);
            this.tpEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.TabPage tpCustomers;
        private System.Windows.Forms.Button btnCloseSuppliers;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.TabPage tpSuppliers;
        private System.Windows.Forms.TabPage tpEmployees;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnDelCustomer;
        private System.Windows.Forms.Button btnCreateCustomer;
        private System.Windows.Forms.Button btnDelSupplier;
        private System.Windows.Forms.Button btnCreateSupplier;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.Button btnDelEmployee;
        private System.Windows.Forms.Button btnCreateEmployee;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnCloseEmployees;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCloseCustomers;
        private System.Windows.Forms.Label lblCountCustomers;
        private System.Windows.Forms.Label lblCountSuppliers;
        private System.Windows.Forms.Label lblCountEmployees;
    }
}