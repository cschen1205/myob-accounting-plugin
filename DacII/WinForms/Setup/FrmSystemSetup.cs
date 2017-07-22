using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DacII.Util;

namespace DacII.WinForms.Setup
{
    public partial class FrmSystemSetup : Form
    {
        public FrmSystemSetup()
        {
            InitializeComponent();
        }

        private void frmSystemSetup_Load(object sender, EventArgs e)
        {
            update_dgvCategories();
            update_dgvLocations();
            update_dgvCharacteristics();
            update_dgvWarranties();
        }

        private void update_dgvCharacteristics()
        {
            /*
            dgvCharacteristics.DataSource = CharacteristicManager.Instance.getTable();
            if (dgvCharacteristics.Columns.Count >= 2)
            {
                dgvCharacteristics.Columns[0].HeaderText = "Characteristic ID";
                dgvCharacteristics.Columns[0].Width = 150;
                dgvCharacteristics.Columns[1].HeaderText = "Description";
                dgvCharacteristics.Columns[1].Width = 200;
            }*/
        }

        private void update_dgvCategories()
        {
            /*
            dgvCategories.DataSource = CategoryManager.Instance.getTable();
            if (dgvCategories.Columns.Count >= 3)
            {
                dgvCategories.Columns[0].HeaderText = "Category ID";
                dgvCategories.Columns[0].Width = 150;
                dgvCategories.Columns[1].HeaderText = "Description";
                dgvCategories.Columns[1].Width = 200;
                dgvCategories.Columns[2].HeaderText = "Notes";
                dgvCategories.Columns[2].Width = 200;
            }
            */
        }

        private void update_dgvWarranties()
        {
            /*
            dgvWarranties.DataSource = WarrantyManager.Instance.getTable();
            if (dgvWarranties.Columns.Count >= 2)
            {
                dgvWarranties.Columns[0].HeaderText = "Warranty Code";
                dgvWarranties.Columns[0].Width = 150;
                dgvWarranties.Columns[1].HeaderText = "Description";
                dgvWarranties.Columns[1].Width = 200;
            }
             * */
        }

        private void update_dgvLocations()
        {
            /*
            dgvLocations.DataSource = LocationManager.Instance.getTable();
            if (dgvLocations.Columns.Count >= 3)
            {
                dgvLocations.Columns[0].HeaderText = "Location ID";
                dgvLocations.Columns[0].Width = 150;
                dgvLocations.Columns[1].HeaderText = "Description";
                dgvLocations.Columns[1].Width = 200;
                dgvLocations.Columns[2].HeaderText = "Notes";
                dgvLocations.Columns[2].Width = 200;
            }*/
        }


        private void btnNewCharacteristic_Click(object sender, EventArgs e)
        {
            txtCharacteristicID.Text = "";
            txtCharacteristicDescription.Text = "";

            tcCharacteristics.SelectedIndex = 1;
        }

        private void btnUpdateCharacteristic_Click(object sender, EventArgs e)
        {
            /*
            bool record = true;

            if (CharacteristicManager.Instance.exists(txtCharacteristicID.Text))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show("Do you want to record the current characteristic?", "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    record = false;
                }
            }

            if (record)
            {
                CharacteristicManager.Instance.set(txtCharacteristicID.Text, txtCharacteristicDescription.Text);
                tcCharacteristics.SelectedIndex = 0;
                update_dgvCharacteristics();
            }*/
        }

        private void dgvCharacteristics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tcCharacteristics.SelectedIndex = 1;
            update_detailCharacteristic();
        }

        private void update_detailCharacteristic()
        {
            if (dgvCharacteristics.SelectedRows.Count==0)
            {
                return;
            }

            string characteristic_id = this.dgvCharacteristics.SelectedRows[0].Cells[0].Value.ToString();
            string description = this.dgvCharacteristics.SelectedRows[0].Cells[1].Value.ToString();

            txtCharacteristicID.Text = characteristic_id;
            txtCharacteristicDescription.Text = description;
        }

        private void btnDelCharacteristic_Click(object sender, EventArgs e)
        {
            /*
            if (!(SysUtil.isRowSelected(dgvCharacteristics)))
            {
                return;
            }

            bool delete = true;

            string characteristic_id = this.dgvCharacteristics.SelectedRows[0].Cells[0].Value.ToString();

            if (CharacteristicManager.Instance.exists(characteristic_id))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show(string.Format("Do you want to delete the current characteristic {0}?", characteristic_id), "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    delete = false;
                }
            }

            if (delete)
            {
                CharacteristicManager.Instance.delete(characteristic_id);
                tcCharacteristics.SelectedIndex = 0;
                update_dgvCharacteristics();
            }*/
            
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = "";
            txtCategoryDescription.Text = "";
            txtCategoryNotes.Text = "";

            tcCategories.SelectedIndex = 1;
        }

        private void btnDelCategory_Click(object sender, EventArgs e)
        {
            /*
            if (!(SysUtil.isRowSelected(dgvCategories)))
            {
                return;
            }

            bool delete = true;

            string id = this.dgvCategories.SelectedRows[0].Cells[0].Value.ToString();

            if (CategoryManager.Instance.exists(id))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show(string.Format("Do you want to delete the current category {0}?", id), "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    delete = false;
                }
            }

            if (delete)
            {
                CategoryManager.Instance.delete(id);
                tcCategories.SelectedIndex = 0;
                update_dgvCategories();
            }*/
        }

        private void dgvCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tcCategories.SelectedIndex = 1;
            update_detailCategory();
        }

        private void update_detailCategory()
        {
            if (dgvCategories.SelectedRows.Count==0)
            {
                return;
            }

            string id = this.dgvCategories.SelectedRows[0].Cells[0].Value.ToString();
            string description = this.dgvCategories.SelectedRows[0].Cells[1].Value.ToString();
            string notes = this.dgvCategories.SelectedRows[0].Cells[2].Value.ToString();

            txtCategoryID.Text = id;
            txtCategoryDescription.Text = description;
            txtCategoryNotes.Text = notes;
        }

        private void update_detailWarranty()
        {
            if (dgvWarranties.SelectedRows.Count==0)
            {
                return;
            }

            string id = this.dgvWarranties.SelectedRows[0].Cells[0].Value.ToString();
            string description = this.dgvWarranties.SelectedRows[0].Cells[1].Value.ToString();

            txtWarrantyID.Text = id;
            txtWarrantyDescription.Text = description;
        }

        private void update_detailLocation()
        {
            if (dgvLocations.SelectedRows.Count==0)
            {
                return;
            }

            string id = this.dgvLocations.SelectedRows[0].Cells[0].Value.ToString();
            string description = this.dgvLocations.SelectedRows[0].Cells[1].Value.ToString();
            string notes = this.dgvLocations.SelectedRows[0].Cells[2].Value.ToString();

            
            txtLocationID.Text = id;
            txtLocationDescription.Text = description;
            txtLocationNotes.Text = notes;
        }

        private void btnRecordCategory_Click(object sender, EventArgs e)
        {
            /*
            bool record = true;

            if (CategoryManager.Instance.exists(txtCategoryID.Text))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show("Do you want to record the current category?", "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    record = false;
                }
            }

            if (record)
            {
                CategoryManager.Instance.set(txtCategoryID.Text, txtCategoryDescription.Text, txtCategoryNotes.Text);
                tcCategories.SelectedIndex = 0;
                update_dgvCategories();
            }*/
        }

        private void dgvCharacteristics_SelectionChanged(object sender, EventArgs e)
        {
            update_detailCharacteristic();
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            update_detailCategory();
        }

        private void btnNewLocation_Click(object sender, EventArgs e)
        {
            txtLocationID.Text = "";
            txtLocationDescription.Text = "";
            txtLocationNotes.Text = "";

            tcLocations.SelectedIndex = 1;
        }

        private void btnDelLocation_Click(object sender, EventArgs e)
        {
            /*
            if (!(SysUtil.isRowSelected(dgvLocations)))
            {
                return;
            }

            bool delete = true;

            string id = this.dgvLocations.SelectedRows[0].Cells[0].Value.ToString();

            if (LocationManager.Instance.exists(id))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show(string.Format("Do you want to delete the current category {0}?", id), "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    delete = false;
                }
            }

            if (delete)
            {
                LocationManager.Instance.delete(id);
                tcLocations.SelectedIndex = 0;
                update_dgvLocations();
            }*/
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            update_detailLocation();
        }

        private void dgvLocations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tcLocations.SelectedIndex = 1;
            update_detailLocation();
        }

        private void btnRecordLocation_Click(object sender, EventArgs e)
        {/*
            bool record = true;

            if (LocationManager.Instance.exists(txtLocationID.Text))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show("Do you want to record the current location?", "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    record = false;
                }
            }

            if (record)
            {
                LocationManager.Instance.set(txtLocationID.Text, txtLocationDescription.Text, txtLocationNotes.Text);
                tcLocations.SelectedIndex = 0;
                update_dgvLocations();
            }*/
        }

        private void btnNewWarranty_Click(object sender, EventArgs e)
        {
            txtWarrantyID.Text = "";
            txtWarrantyDescription.Text = "";

            tcWarranties.SelectedIndex = 1;
        }

        private void btnDelWarranty_Click(object sender, EventArgs e)
        {
            if (dgvWarranties.SelectedRows.Count==0)
            {
                return;
            }

            //bool delete = true;

            string id = this.dgvWarranties.SelectedRows[0].Cells[0].Value.ToString();

            /*
            if (WarrantyManager.Instance.exists(id))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show(string.Format("Do you want to delete the current category {0}?", id), "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    delete = false;
                }
            }

            if (delete)
            {
                WarrantyManager.Instance.delete(id);
                tcWarranties.SelectedIndex = 0;
                update_dgvWarranties();
            }
             * */
        }

        private void dgvWarranties_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tcWarranties.SelectedIndex = 1;
            update_detailWarranty();
        }

        private void dgvWarranties_SelectionChanged(object sender, EventArgs e)
        {
            update_detailWarranty();
        }

        private void btnRecordWarranty_Click(object sender, EventArgs e)
        {
            /*
            bool record = true;

            if (WarrantyManager.Instance.exists(txtWarrantyID.Text))
            {
                DialogResult result = DialogResult.Cancel;
                result = MessageBox.Show("Do you want to record the current location?", "Confirm Record", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    record = false;
                }
            }

            if (record)
            {
                WarrantyManager.Instance.set(txtWarrantyID.Text, txtWarrantyDescription.Text);
                tcWarranties.SelectedIndex = 0;
                update_dgvWarranties();
            }
             * */
        }
    }
}