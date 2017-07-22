using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.Bll;

namespace DacII
{
    public class BOViewModel<BO> 
        where BO : BusinessObject
    {
        private ErrorProvider mErrorProvider = null;
        public ErrorProvider ErrorProvider
        {
            set { mErrorProvider = value; }
        }

        public delegate void ImportFromViewDelegate(BO model);
        public delegate void ExportToViewDelegate(BO model);
        public delegate void CommandDelegate(object sender, EventArgs args);

        private Dictionary<string, Label> mControlLabels = new Dictionary<string, Label>();

        public List<ImportFromViewDelegate> mImportDelegates = new List<ImportFromViewDelegate>();
        public List<ExportToViewDelegate> mExportDelegates = new List<ExportToViewDelegate>();

        Dictionary<string, Button> mButtons = new Dictionary<string, Button>();
        Dictionary<string, CheckBox> mCheckBoxes = new Dictionary<string, CheckBox>();
        Dictionary<string, ComboBox> mComboBoxes = new Dictionary<string, ComboBox>();
        Dictionary<string, TextBox> mTextBoxes = new Dictionary<string, TextBox>();
        Dictionary<string, Label> mLabels = new Dictionary<string, Label>();
        Dictionary<string, DateTimePicker> mDateTimePickers = new Dictionary<string, DateTimePicker>();

        Dictionary<string, EventHandler> mButtonClickedHandlers = new Dictionary<string, EventHandler>();
        Dictionary<string, EventHandler> mCheckBoxValueChangedHandlers = new Dictionary<string, EventHandler>();
        Dictionary<string, EventHandler> mComboBoxValueChangedHandlers = new Dictionary<string, EventHandler>();
        Dictionary<string, EventHandler> mTextBoxValueChangedHandlers = new Dictionary<string, EventHandler>();
        Dictionary<string, EventHandler> mLabelClickedHandlers = new Dictionary<string, EventHandler>();
        Dictionary<string, EventHandler> mDateTimePickerValueChangedHandlers = new Dictionary<string, EventHandler>();

        Dictionary<string, bool> mButtonClickedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, bool> mCheckBoxValueChangedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, bool> mComboBoxValueChangedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, bool> mTextBoxValueChangedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, bool> mLabelClickedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, bool> mDateTimePickerValueChangedHandlerAdded = new Dictionary<string, bool>();

        Dictionary<string, bool> mButtonAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mCheckBoxAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mComboBoxAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mTextBoxAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mLabelAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mDateTimePickerAccess_Value = new Dictionary<string, bool>();

        Dictionary<string, bool> mButtonAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mCheckBoxAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mComboBoxAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mTextBoxAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mLabelAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mDateTimePickerAccess_Enabled = new Dictionary<string, bool>();

        Dictionary<string, bool> mButtonAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mCheckBoxAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mComboBoxAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mTextBoxAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mLabelAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mDateTimePickerAccess_Visible = new Dictionary<string, bool>();

        bool DefaultTextBoxAccess_Visible=false;
        bool DefaultTextBoxAccess_Value = false;
        bool DefaultTextBoxAccess_Enabled = false;

        bool DefaultCheckBoxAccess_Visible = false;
        bool DefaultCheckBoxAccess_Value = false;
        bool DefaultCheckBoxAccess_Enabled = false;

        bool DefaultComboBoxAccess_Visible = false;
        bool DefaultComboBoxAccess_Value = false;
        bool DefaultComboBoxAccess_Enabled = false;

        bool DefaultLabelAccess_Visible = false;
        bool DefaultLabelAccess_Value = false;
        bool DefaultLabelAccess_Enabled = false;

        bool DefaultButtonAccess_Visible = false;
        bool DefaultButtonAccess_Value = false;
        bool DefaultButtonAccess_Enabled = false;

        bool DefaultDateTimePickerAccess_Visible = false;
        bool DefaultDateTimePickerAccess_Value = false;
        bool DefaultDateTimePickerAccess_Enabled = false;

      

        public void BindExportDelegate(ExportToViewDelegate callback)
        {
            mExportDelegates.Add(callback);
        }

        public void BindImportDelegate(ImportFromViewDelegate callback)
        {
            mImportDelegates.Add(callback);
        }

        private BO mModel;
        public BO Model
        {
            set 
            { 
                mModel = value;
                mModel.Revised += new BusinessObject.RevisedHandler(Model_ExportDataToUI);
            }
        }

        public void BindView(string property_name, Label lbl, DateTimePicker view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate delg)
        {
            mDateTimePickers[property_name] = view;
            mControlLabels[property_name] = lbl;
            if (access_enabled != null) mDateTimePickerAccess_Enabled[property_name] = access_enabled.Value;
            if (access_value != null) mDateTimePickerAccess_Value[property_name] = access_value.Value;
            if (access_visible != null) mDateTimePickerAccess_Visible[property_name] = access_visible.Value;
            EventHandler handler = null;
            if (delg != null) handler = new EventHandler(delg);
            mDateTimePickerValueChangedHandlers[property_name] = handler;
            mDateTimePickerValueChangedHandlerAdded[property_name] = false;
        }

        public void BindView(string property_name, Button view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate delg)
        {
            mButtons[property_name] = view;
            if (access_enabled != null) mButtonAccess_Enabled[property_name] = access_enabled.Value;
            if (access_value != null) mButtonAccess_Value[property_name] = access_value.Value;
            if (access_visible != null) mButtonAccess_Visible[property_name] = access_visible.Value;
            EventHandler handler = null;
            if (delg != null) handler = new EventHandler(delg);
            mButtonClickedHandlers[property_name] = handler;
            mButtonClickedHandlerAdded[property_name] = false;
        }

        public void BindView(string property_name, Label view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate delg)
        {
            mLabels[property_name] = view;
            if (access_enabled != null) mLabelAccess_Enabled[property_name] = access_enabled.Value;
            if (access_value != null) mLabelAccess_Value[property_name] = access_value.Value;
            if (access_visible != null) mLabelAccess_Visible[property_name] = access_visible.Value;
            EventHandler handler = null;
            if (delg != null) handler = new EventHandler(delg);
            mLabelClickedHandlers[property_name] = handler;
            mLabelClickedHandlerAdded[property_name] = false;
        }

        public void BindView(string property_name, Label label, TextBox view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate delg)
        {
            mTextBoxes[property_name] = view;
            mControlLabels[property_name] = label;
            view.Tag = property_name;
            view.TextChanged += new EventHandler(TextBoxValidateHandler);
            if(access_enabled!=null) mTextBoxAccess_Enabled[property_name] = access_enabled.Value;
            if(access_value!=null) mTextBoxAccess_Value[property_name] = access_value.Value;
            if(access_visible!=null) mTextBoxAccess_Visible[property_name] = access_visible.Value;
            EventHandler handler = null;
            if (delg != null) handler = new EventHandler(delg);
            mTextBoxValueChangedHandlers[property_name] = handler;
            mTextBoxValueChangedHandlerAdded[property_name] = false;
        }

        void TextBoxValidateHandler(object sender, EventArgs e)
        {
            TextBox textbox=sender as TextBox;
            string property_name=textbox.Tag as string;
            string error;
            mModel.ValidateValue(property_name, textbox.Text, out error);
            if (mErrorProvider != null)
            {
                mErrorProvider.SetError(textbox, error);
            }
        }

        public void BindView(string property_name, Label lbl, ComboBox view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate delg)
        {
            mComboBoxes[property_name] = view;
            mControlLabels[property_name] = lbl;
            if(access_enabled!=null) mComboBoxAccess_Enabled[property_name] = access_enabled.Value;
            if(access_value!=null) mComboBoxAccess_Value[property_name] = access_value.Value;
            if(access_visible!=null) mComboBoxAccess_Visible[property_name] = access_visible.Value;
            EventHandler handler = null;
            if (delg != null) handler = new EventHandler(delg);
            mComboBoxValueChangedHandlers[property_name] = handler;
            mComboBoxValueChangedHandlerAdded[property_name] = false;
        }

        public void BindView(string property_name, CheckBox view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate delg)
        {
            mCheckBoxes[property_name] = view;
            if(access_enabled!=null) mCheckBoxAccess_Enabled[property_name] = access_enabled.Value;
            if(access_value!=null) mCheckBoxAccess_Value[property_name] = access_value.Value;
            if(access_visible!=null) mCheckBoxAccess_Visible[property_name] = access_visible.Value;
            EventHandler handler = null;
            if (delg != null) handler = new EventHandler(delg);
            mCheckBoxValueChangedHandlers[property_name] = handler;
            mCheckBoxValueChangedHandlerAdded[property_name] = false;
        }

        public bool Model_ImportDataFromUI()
        {
            List<string> errors = new List<string>();
            string error;
            TextBox txtbox;
            CheckBox chkbox;
            ComboBox cbobox;

            foreach (string property_name in mTextBoxes.Keys)
            {
                txtbox = mTextBoxes[property_name];
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

            foreach (string property_name in mTextBoxes.Keys)
            {
                mModel.SetPropertyValue(property_name, mTextBoxes[property_name].Text);
            }
            foreach (string property_name in mCheckBoxes.Keys)
            {
                mModel.SetPropertyValue(property_name, mCheckBoxes[property_name].Checked);
            }
            foreach (string property_name in mComboBoxes.Keys)
            {
                mModel.SetPropertyValue(property_name, mComboBoxes[property_name].SelectedItem);
            }
            foreach (string property_name in mDateTimePickers.Keys)
            {
                DateTimePicker dtp = mDateTimePickers[property_name];
                if (dtp.Checked)
                {
                    mModel.SetPropertyValue(property_name, dtp.Value);
                }
                else
                {
                    mModel.SetPropertyValue(property_name, null);
                }
            }

            foreach (ImportFromViewDelegate callback in mImportDelegates)
            {
                callback(mModel);
            }

            mModel.Revise();

            return true;
        }

        public void Model_ExportDataToUI()
        {
            TextBox tbview;
            CheckBox chkview;
            ComboBox cboview;
            Label lblview;
            Button btnview;
            DateTimePicker dtpview;
            bool access_enabled;
            bool access_visible;
            bool access_value;

            foreach (string property_name in mTextBoxes.Keys)
            {
                tbview = mTextBoxes[property_name];
                if (mTextBoxValueChangedHandlerAdded[property_name] == true && mTextBoxValueChangedHandlers[property_name] != null)
                {
                    tbview.TextChanged -= mTextBoxValueChangedHandlers[property_name];
                    mTextBoxValueChangedHandlerAdded[property_name] = false;
                }
            }
            foreach (string property_name in mCheckBoxes.Keys)
            {
                chkview = mCheckBoxes[property_name];
                if (mCheckBoxValueChangedHandlerAdded[property_name] == true && mCheckBoxValueChangedHandlers[property_name] != null)
                {
                    chkview.CheckedChanged -= mCheckBoxValueChangedHandlers[property_name];
                    mCheckBoxValueChangedHandlerAdded[property_name] = false;
                }
            }
            foreach (string property_name in mComboBoxes.Keys)
            {
                cboview = mComboBoxes[property_name];
                if (mComboBoxValueChangedHandlerAdded[property_name] == true && mComboBoxValueChangedHandlers[property_name] != null)
                {
                    cboview.SelectedIndexChanged -= mComboBoxValueChangedHandlers[property_name];
                    mComboBoxValueChangedHandlerAdded[property_name] = false;
                }
            }
            foreach (string property_name in mLabels.Keys)
            {
                lblview = mLabels[property_name];
                if (mLabelClickedHandlerAdded[property_name] == true && mLabelClickedHandlers[property_name] != null)
                {
                    lblview.Click -= mLabelClickedHandlers[property_name];
                    mLabelClickedHandlerAdded[property_name] = false;
                }
            }
            foreach (string property_name in mButtons.Keys)
            {
                btnview = mButtons[property_name];
                if (mButtonClickedHandlerAdded[property_name] == true && mButtonClickedHandlers[property_name] != null)
                {
                    btnview.Click -= mButtonClickedHandlers[property_name];
                    mButtonClickedHandlerAdded[property_name] = false;
                }
            }
            foreach (string property_name in mDateTimePickers.Keys)
            {
                dtpview = mDateTimePickers[property_name];
                if (mDateTimePickerValueChangedHandlerAdded[property_name] == true && mDateTimePickerValueChangedHandlers[property_name] != null)
                {
                    dtpview.ValueChanged -= mDateTimePickerValueChangedHandlers[property_name];
                    mDateTimePickerValueChangedHandlerAdded[property_name] = false;
                }
            }

            foreach (string property_name in mTextBoxes.Keys)
            {
                tbview = mTextBoxes[property_name];
                access_visible = mTextBoxAccess_Visible.ContainsKey(property_name) ? mTextBoxAccess_Visible[property_name] : DefaultTextBoxAccess_Visible;
                access_enabled = mTextBoxAccess_Enabled.ContainsKey(property_name) ? mTextBoxAccess_Enabled[property_name] : DefaultTextBoxAccess_Enabled;
                access_value = mTextBoxAccess_Value.ContainsKey(property_name) ? mTextBoxAccess_Value[property_name] : DefaultTextBoxAccess_Value;

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name); 
                if(access_enabled) tbview.Enabled = enabled;
                if(access_visible) tbview.Visible = visible;
                if(access_value) tbview.Text = mModel.GetPropertyValue<string>(property_name);

                if (access_enabled && access_visible)
                {
                    if (mTextBoxValueChangedHandlerAdded[property_name] == false && mTextBoxValueChangedHandlers[property_name] != null)
                    {
                        tbview.TextChanged += mTextBoxValueChangedHandlers[property_name];
                        mTextBoxValueChangedHandlerAdded[property_name] = true;
                    }
                }

                lblview = mControlLabels[property_name];
                if (lblview != null)
                {
                    mControlLabels[property_name].Enabled = enabled;
                    mControlLabels[property_name].Visible = visible;
                }
            }
            
            foreach (string property_name in mCheckBoxes.Keys)
            {
                chkview = mCheckBoxes[property_name];
                access_visible = mCheckBoxAccess_Visible.ContainsKey(property_name) ? mCheckBoxAccess_Visible[property_name] : DefaultCheckBoxAccess_Visible;
                access_enabled = mCheckBoxAccess_Enabled.ContainsKey(property_name) ? mCheckBoxAccess_Enabled[property_name] : DefaultCheckBoxAccess_Enabled;
                access_value = mCheckBoxAccess_Value.ContainsKey(property_name) ? mCheckBoxAccess_Value[property_name] : DefaultCheckBoxAccess_Value;

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                if (access_enabled) chkview.Enabled = enabled;
                if (access_visible) chkview.Visible = visible;
                if(access_value) chkview.Checked = mModel.GetPropertyValue<bool>(property_name);

                if (access_visible && access_enabled)
                {
                    if (mCheckBoxValueChangedHandlerAdded[property_name] == false && mCheckBoxValueChangedHandlers[property_name] != null)
                    {
                        chkview.CheckedChanged += mCheckBoxValueChangedHandlers[property_name];
                        mCheckBoxValueChangedHandlerAdded[property_name] = true;
                    }
                }
            }
            
            foreach (string property_name in mComboBoxes.Keys)
            {
                cboview = mComboBoxes[property_name];
                access_visible = mComboBoxAccess_Visible.ContainsKey(property_name) ? mComboBoxAccess_Visible[property_name] : DefaultComboBoxAccess_Visible;
                access_enabled = mComboBoxAccess_Enabled.ContainsKey(property_name) ? mComboBoxAccess_Enabled[property_name] : DefaultComboBoxAccess_Enabled;
                access_value = mComboBoxAccess_Value.ContainsKey(property_name) ? mComboBoxAccess_Value[property_name] : DefaultComboBoxAccess_Value;

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                if (access_enabled) cboview.Enabled = enabled;
                if (access_visible) cboview.Visible = visible;

                if(access_value) cboview.SelectedItem = mModel.GetPropertyValue<object>(property_name);

                if (access_visible && access_enabled)
                {
                    if (mComboBoxValueChangedHandlerAdded[property_name] == false && mComboBoxValueChangedHandlers[property_name] != null)
                    {
                        cboview.SelectedIndexChanged += mComboBoxValueChangedHandlers[property_name];
                        mComboBoxValueChangedHandlerAdded[property_name] = true;
                    }
                }

                lblview = mControlLabels[property_name];
                if (lblview != null)
                {
                    lblview.Enabled = enabled;
                    lblview.Visible = visible;
                }
            }
            
            foreach (string property_name in mLabels.Keys)
            {
                lblview = mLabels[property_name];
                access_visible = mLabelAccess_Visible.ContainsKey(property_name) ? mLabelAccess_Visible[property_name] : DefaultLabelAccess_Visible;
                access_enabled = mLabelAccess_Enabled.ContainsKey(property_name) ? mLabelAccess_Enabled[property_name] : DefaultLabelAccess_Enabled;
                access_value = mLabelAccess_Value.ContainsKey(property_name) ? mLabelAccess_Value[property_name] : DefaultLabelAccess_Value;

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                if (access_enabled) lblview.Enabled = enabled;
                if (access_visible) lblview.Visible = visible;

                if (access_value) lblview.Text = mModel.GetPropertyValue<string>(property_name);

                if (access_visible && access_enabled)
                {
                    if (mLabelClickedHandlerAdded[property_name] == false && mLabelClickedHandlers[property_name] != null)
                    {
                        lblview.Click += mLabelClickedHandlers[property_name];
                        mLabelClickedHandlerAdded[property_name] = true;
                    }
                }
            }
            
            foreach (string property_name in mButtons.Keys)
            {
                btnview = mButtons[property_name];
                access_visible = mButtonAccess_Visible.ContainsKey(property_name) ? mButtonAccess_Visible[property_name] : DefaultButtonAccess_Visible;
                access_enabled = mButtonAccess_Enabled.ContainsKey(property_name) ? mButtonAccess_Enabled[property_name] : DefaultButtonAccess_Enabled;
                access_value = mButtonAccess_Value.ContainsKey(property_name) ? mButtonAccess_Value[property_name] : DefaultButtonAccess_Value;

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                if (access_enabled) btnview.Enabled = enabled;
                if (access_visible) btnview.Visible = visible;

                if (access_value) btnview.Text = mModel.GetPropertyValue<string>(property_name);

                if (access_visible && access_enabled)
                {
                    if (mButtonClickedHandlerAdded[property_name] == false && mButtonClickedHandlers[property_name] != null)
                    {
                        btnview.Click += mButtonClickedHandlers[property_name];
                        mButtonClickedHandlerAdded[property_name] = true;
                    }
                }
            }
            
            foreach (string property_name in mDateTimePickers.Keys)
            {
                dtpview = mDateTimePickers[property_name];
                access_visible = mDateTimePickerAccess_Visible.ContainsKey(property_name) ? mDateTimePickerAccess_Visible[property_name] : DefaultDateTimePickerAccess_Visible;
                access_enabled = mDateTimePickerAccess_Enabled.ContainsKey(property_name) ? mDateTimePickerAccess_Enabled[property_name] : DefaultDateTimePickerAccess_Enabled;
                access_value = mDateTimePickerAccess_Value.ContainsKey(property_name) ? mDateTimePickerAccess_Value[property_name] : DefaultDateTimePickerAccess_Value;

                bool enabled = mModel.IsPropertyEnabled(property_name);
                bool visible = mModel.IsPropertyVisible(property_name);

                if (access_enabled) dtpview.Enabled = enabled;
                if (access_visible) dtpview.Visible = visible;

                if (access_value)
                {
                    DateTime? val=mModel.GetPropertyValue<DateTime?>(property_name);
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

                if (access_visible && access_enabled)
                {
                    if (mDateTimePickerValueChangedHandlerAdded[property_name] == false && mDateTimePickerValueChangedHandlers[property_name] != null)
                    {
                        dtpview.ValueChanged += mDateTimePickerValueChangedHandlers[property_name];
                        mDateTimePickerValueChangedHandlerAdded[property_name] = true;
                    }
                }

                lblview = mControlLabels[property_name];
                if (lblview != null)
                {
                    lblview.Enabled = enabled;
                    lblview.Visible = visible;
                }
            }

            foreach (ExportToViewDelegate callback in mExportDelegates)
            {
                callback(mModel);
            }

            
        }

        public bool PersistData()
        {
            OpResult result = mModel.Record();
            return result.IsValid;
        }
    }
}
