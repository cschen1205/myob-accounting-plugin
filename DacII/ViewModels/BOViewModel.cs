using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DacII.ViewModels
{
    using Accounting.Core;
    using Accounting.Bll;
    using System.Drawing;

    public class BOViewModel
    {
        BusinessObject mModel = null;

        public BOViewModel(BusinessObject model)
        {
            Model = model;
        }

        public BusinessObject Model
        {
            set
            {
                if (mModel != null)
                {
                    mModel.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(mModel_PropertyChanged);
                }
                mModel = value;
                mModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mModel_PropertyChanged);
            }
        }

        void mModel_Invalidated()
        {
            UpdateView();
        }

        void mModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == BusinessObject.DATA_STORE)
            {
                UpdateView();
            }
            else
            {
                UpdateProperty(e.PropertyName);
            }
        }

        private ErrorProvider mErrorProvider = null;
        public ErrorProvider ErrorProvider
        {
            set { mErrorProvider = value; }
        }

        private Dictionary<string, Label> mControlLabels = new Dictionary<string, Label>();

        Dictionary<string, VistaButton> mVistaButtons = new Dictionary<string, VistaButton>();
        Dictionary<string, Button> mButtons = new Dictionary<string, Button>();
        Dictionary<string, CheckBox> mCheckBoxes = new Dictionary<string, CheckBox>();
        Dictionary<string, ComboBox> mComboBoxes = new Dictionary<string, ComboBox>();
        Dictionary<string, TextBoxBase> mTextBoxes = new Dictionary<string, TextBoxBase>();
        Dictionary<string, Label> mLabels = new Dictionary<string, Label>();
        Dictionary<string, DateTimePicker> mDateTimePickers = new Dictionary<string, DateTimePicker>();
        
        public void BindView(string property_name, Label lbl, DateTimePicker view)
        {
            view.Tag = property_name;
            mDateTimePickers[property_name] = view;
            mControlLabels[property_name] = lbl;
            view.ValueChanged += new EventHandler(DateTimePicker_ValueChanged);
        }

        void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            if (dtp.Visible == false) return;
            string property_name = dtp.Tag as string;
            string error;
            if (mModel.ValidateValue(property_name, dtp.Value, out error))
            {
                mModel.SetPropertyValue(property_name, dtp.Value);
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(dtp, "");
                }
            }
            else
            {
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(dtp, error);
                }
            }
        }

        public void BindView(string property_name, Button view)
        {
            view.Tag = property_name;
            mButtons[property_name] = view;
        }

        public void BindView(string property_name, VistaButton view)
        {
            view.Tag = property_name;
            mVistaButtons[property_name] = view;
        }

        public void BindView(string property_name, Label view)
        {
            view.Tag = property_name;
            mLabels[property_name] = view;
        }

        public void BindView(string property_name, Label label, TextBox view)
        {
            mTextBoxes[property_name] = view;
            mControlLabels[property_name] = label;
            view.Tag = property_name;
            view.TextChanged += new EventHandler(TextBox_TextChanged);
        }

        public void BindView(string property_name, Label label, MaskedTextBox view)
        {
            mTextBoxes[property_name] = view;
            mControlLabels[property_name] = label;
            view.Tag = property_name;
            view.TextChanged += new EventHandler(TextBox_TextChanged);
        }

        public void BindView(string property_name, Label lbl, ComboBox view)
        {
            view.Tag = property_name;
            mComboBoxes[property_name] = view;
            mControlLabels[property_name] = lbl;

            view.DropDownStyle = ComboBoxStyle.DropDownList;
            view.DrawMode = DrawMode.OwnerDrawFixed;
            view.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            view.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            view.KeyDown += new KeyEventHandler(ComboBox_KeyDown);
        }

        void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ComboBox view = sender as ComboBox;
                view.SelectedIndex = -1;
            }
        }

        void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.Visible == false) return;
            string property_name = combo.Tag as string;
            string error;
            if (mModel.ValidateValue(property_name, combo.SelectedItem, out error))
            {
                mModel.SetPropertyValue(property_name, combo.SelectedItem);
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(combo, "");
                }
            }
            else
            {
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(combo, error);
                }
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox view = sender as ComboBox;

            string text = view.Items[e.Index].ToString();
            Font font = view.Font;

            if (view.Enabled)
            {
                e.DrawBackground();
                if ((e.State & DrawItemState.Focus) > 0)
                    e.Graphics.DrawString(text, font, SystemBrushes.HighlightText, e.Bounds);
                else
                    e.Graphics.DrawString(text, font, SystemBrushes.ControlText, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);

                e.Graphics.DrawString(text, font, Brushes.Black, e.Bounds);
            }
        }

        public void BindView(string property_name, CheckBox view)
        {
            view.Tag = property_name;
            mCheckBoxes[property_name] = view;
            view.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
        }

        void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = sender as CheckBox;
            if (chkbox.Visible == false) return;
            string property_name = chkbox.Tag as string;
            string error;
            if (mModel.ValidateValue(property_name, chkbox.Checked, out error))
            {
                mModel.SetPropertyValue(property_name, chkbox.Checked);
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(chkbox, "");
                }
            }
            else
            {
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(chkbox, error);
                }
            }
        }

        public bool ValidateModel()
        {
            List<string> errors = new List<string>();
            string error;
            TextBoxBase txtbox;
            CheckBox chkbox;
            ComboBox cbobox;

            foreach (string property_name in mTextBoxes.Keys)
            {
                txtbox = mTextBoxes[property_name];
                if (txtbox.Visible == false) continue;
                if (!mModel.ValidateValue(property_name, txtbox.Text, out error))
                {
                    errors.Add(error);
                }
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(txtbox, error);
                }
            }
            foreach (string property_name in mCheckBoxes.Keys)
            {
                chkbox = mCheckBoxes[property_name];
                if (chkbox.Visible == false) continue;
                if (!mModel.ValidateValue(property_name, chkbox.Checked, out error))
                {
                    errors.Add(error);
                }
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(chkbox, error);
                }
            }
            foreach (string property_name in mComboBoxes.Keys)
            {
                cbobox = mComboBoxes[property_name];
                if (cbobox.Visible == false) continue;
                if (!mModel.ValidateValue(property_name, cbobox.SelectedItem, out error))
                {
                    errors.Add(error);
                }
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(cbobox, error);
                }
            }
            foreach (string property_name in mDateTimePickers.Keys)
            {
                DateTimePicker dtp = mDateTimePickers[property_name];
                if (dtp.Visible == false) continue;
                if (dtp.Checked)
                {
                    if (!mModel.ValidateValue(property_name, dtp.Value, out error))
                    {
                        errors.Add(error);
                    }
                }
                else
                {
                    if (!mModel.ValidateValue(property_name, null, out error))
                    {
                        errors.Add(error);
                    }
                }
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(dtp, error);
                }
            }

            if (errors.Count > 0)
            {
                StringBuilder sb=new StringBuilder();
                sb.Append("User inputs failed the following validations:\r\n");
                foreach (string err in errors)
                {
                    sb.AppendFormat("{0}\r\n", err);
                }
                MessageBox.Show(sb.ToString(), "Validation Error");
                return false;
            }
            return true;
        }

        void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxBase textbox = sender as TextBoxBase;
            if (textbox.Visible == false) return;
            string property_name = textbox.Tag as string;
            string error;
           if(mModel.ValidateValue(property_name, textbox.Text, out error))
            {
                mModel.SetPropertyValue(property_name, textbox.Text);
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(textbox, "");
                }
           }
           else
           {
                if (mErrorProvider != null)
                {
                    mErrorProvider.SetError(textbox, error);
                }
            }
        }

        private void UpdateProperty(string property_name)
        {
            ComboBox cboview;
            Label lblview;
            Button btnview;
            DateTimePicker dtpview;

            if(mTextBoxes.ContainsKey(property_name))
            {
                TextBoxBase tbview = mTextBoxes[property_name];
                string text=mModel.GetPropertyValue<string>(property_name);
                if (tbview.Text != text)
                {
                    tbview.TextChanged-=new EventHandler(TextBox_TextChanged);
                    tbview.Text = text;
                    tbview.TextChanged += new EventHandler(TextBox_TextChanged);
                }
                tbview.Enabled = mModel.IsPropertyEnabled(property_name);
                tbview.Visible = mModel.IsPropertyVisible(property_name);
            }
            
            if(mCheckBoxes.ContainsKey(property_name))
            {
                CheckBox chkview = mCheckBoxes[property_name];
                bool is_checked=mModel.GetPropertyValue<bool>(property_name);
                if(chkview.Checked != is_checked)
                {
                    chkview.CheckedChanged -= new EventHandler(CheckBox_CheckedChanged);
                    chkview.Checked = is_checked;
                    chkview.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                }
                chkview.Enabled = mModel.IsPropertyEnabled(property_name);
                chkview.Visible = mModel.IsPropertyVisible(property_name);
            }
            
            if (mComboBoxes.ContainsKey(property_name))
            {
                cboview = mComboBoxes[property_name];

                object item = mModel.GetPropertyValue<object>(property_name);

                object selected_item = cboview.SelectedItem;
                if (selected_item != item)
                {
                    cboview.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                    cboview.SelectedItem = item;
                    cboview.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                }
                cboview.Enabled = mModel.IsPropertyEnabled(property_name);
                cboview.Visible = mModel.IsPropertyVisible(property_name);
            }
            
            if(mLabels.ContainsKey(property_name))
            {
                lblview = mLabels[property_name];
                lblview.Text = mModel.GetPropertyValue<string>(property_name);
            }
            
            if(mButtons.ContainsKey(property_name))
            {
                btnview = mButtons[property_name];
                btnview.Text = mModel.GetPropertyValue<string>(property_name);
                btnview.Enabled = mModel.IsPropertyEnabled(property_name);
                btnview.Visible = mModel.IsPropertyVisible(property_name);
            }

            VistaButton btnview2;
            if (mButtons.ContainsKey(property_name))
            {
                btnview2 = mVistaButtons[property_name];
                btnview2.ButtonText = mModel.GetPropertyValue<string>(property_name);
                btnview2.Enabled = mModel.IsPropertyEnabled(property_name);
                btnview2.Visible = mModel.IsPropertyVisible(property_name);
            }
            
            if(mDateTimePickers.ContainsKey(property_name))
            {
                dtpview = mDateTimePickers[property_name];
             
                dtpview.ValueChanged -= new EventHandler(DateTimePicker_ValueChanged);

                DateTime? val = mModel.GetPropertyValue<DateTime?>(property_name);

                DateTime? selected_val = dtpview.Value;
                if (!dtpview.Checked) selected_val = null;

                if (selected_val != val)
                {
                    if (val == null)
                    {
                        dtpview.Checked = false;
                    }
                    else
                    {
                        dtpview.Checked = true;
                        dtpview.Value = val.Value;
                    }
                }

                dtpview.ValueChanged += new EventHandler(DateTimePicker_ValueChanged);

                dtpview.Visible = mModel.IsPropertyVisible(property_name);
                dtpview.Enabled = mModel.IsPropertyEnabled(property_name);
            }
        }

        public void UpdateView()
        {
           
            CheckBox chkview;
            ComboBox cboview;
            Label lblview;
            Button btnview;
            DateTimePicker dtpview;

            TextBoxBase tbview;
            foreach (string property_name in mTextBoxes.Keys)
            {
                tbview = mTextBoxes[property_name];
               
                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                tbview.Enabled = enabled;
                tbview.Visible = visible;

                string text=mModel.GetPropertyValue<string>(property_name);
                if (tbview.Text != text)
                {
                    tbview.TextChanged -= new EventHandler(TextBox_TextChanged);
                    tbview.Text = text;
                    tbview.TextChanged += new EventHandler(TextBox_TextChanged);
                }

                lblview = mControlLabels[property_name];
                if (lblview != null)
                {
                    mControlLabels[property_name].Visible = visible;
                }
            }
            
            foreach (string property_name in mCheckBoxes.Keys)
            {
                chkview = mCheckBoxes[property_name];

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);
               
                chkview.AutoCheck = enabled;
                chkview.Visible = visible;

                chkview.CheckedChanged -= new EventHandler(CheckBox_CheckedChanged);   
                chkview.Checked = mModel.GetPropertyValue<bool>(property_name);
                chkview.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);   
            }
            
            foreach (string property_name in mComboBoxes.Keys)
            {
                cboview = mComboBoxes[property_name];
              
                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                cboview.Enabled = enabled;
                cboview.Visible = visible;

                object item = mModel.GetPropertyValue<object>(property_name);

                cboview.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                if (item == null && mModel.IsCreating)
                {
                    if (cboview.Items.Count > 0)
                    {
                        cboview.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboview.SelectedItem = item;
                }
                cboview.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

                lblview = mControlLabels[property_name];
                if (lblview != null)
                {
                    lblview.Visible = visible;
                }
            }
            
            foreach (string property_name in mLabels.Keys)
            {
                lblview = mLabels[property_name];
                
                bool visible = mModel.IsPropertyVisible(property_name);

                lblview.Visible = visible;
                lblview.Text = mModel.GetPropertyValue<string>(property_name);
            }
            
            foreach (string property_name in mButtons.Keys)
            {
                btnview = mButtons[property_name];
                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                btnview.Enabled = enabled;
                btnview.Visible = visible;

                btnview.Text = mModel.GetPropertyValue<string>(property_name);
            }

            VistaButton btnview2;
            foreach (string property_name in mVistaButtons.Keys)
            {
                btnview2 = mVistaButtons[property_name];
                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                btnview2.Enabled = enabled;
                btnview2.Visible = visible;

                btnview2.ButtonText = mModel.GetPropertyValue<string>(property_name);
            }
            
            foreach (string property_name in mDateTimePickers.Keys)
            {
                dtpview = mDateTimePickers[property_name];
                
                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);
                
                dtpview.Enabled = enabled;
                dtpview.Visible = visible;

                dtpview.ValueChanged -= new EventHandler(DateTimePicker_ValueChanged);
                DateTime? val = mModel.GetPropertyValue<DateTime?>(property_name);
                if (val == null)
                {
                    dtpview.Checked = false;
                }
                else
                {
                    dtpview.Checked = true;
                    dtpview.Value = val.Value;
                }
                dtpview.ValueChanged += new EventHandler(DateTimePicker_ValueChanged);

                lblview = mControlLabels[property_name];
                if (lblview != null)
                {
                    lblview.Visible = visible;
                }
            }
        }
    }
}
