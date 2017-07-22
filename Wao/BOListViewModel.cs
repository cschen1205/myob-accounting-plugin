using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.Bll;

namespace Wao
{
    public class BOListViewModel<BO> 
        where BO : BusinessObject
    {
        public delegate void CommandDelegate(object sender, EventArgs args);
        public delegate void DataFillDelegate();

        public enum BOListViewIDType
        {
            INTEGER,
            STRING,
        }

        private BOListViewIDType mListViewIDType=BOListViewIDType.STRING;
        private BOListViewModel(BOListViewIDType ListViewIDType)
        {
            mListViewIDType = ListViewIDType;
        }

        public static BOListViewModel<BO> InstantiateWithIntegerID()
        {
            return new BOListViewModel<BO>(BOListViewIDType.INTEGER);
        }

        public static BOListViewModel<BO> InstantiateWithStringID()
        {
            return new BOListViewModel<BO>(BOListViewIDType.STRING);
        }

        private Dictionary<string, DataGridView> mDataGridViews=new Dictionary<string,DataGridView>();
        private Dictionary<string, DataFillDelegate> mDataGridViewFillCallback = new Dictionary<string, DataFillDelegate>();
        private Dictionary<string, bool> mDataGridViewAccess_Visible = new Dictionary<string, bool>();
        private Dictionary<string, bool> mDataGridViewAccess_Enabled = new Dictionary<string, bool>();
        private Dictionary<string, bool> mDataGridViewAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mDataGridViewDoubleClickedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, EventHandler> mDataGridViewDoubleClickedHandlers = new Dictionary<string, EventHandler>();

        Dictionary<string, Button> mCreateCommands = new Dictionary<string, Button>();
        Dictionary<string, bool> mCreateCommandAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mCreateCommandAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mCreateCommandAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mCreateCommandClickedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, EventHandler> mCreateCommandClickedHandlers = new Dictionary<string, EventHandler>();

        Dictionary<string, Button> mDeleteCommands = new Dictionary<string, Button>();
        Dictionary<string, bool> mDeleteCommandAccess_Value = new Dictionary<string, bool>();
        Dictionary<string, bool> mDeleteCommandAccess_Enabled = new Dictionary<string, bool>();
        Dictionary<string, bool> mDeleteCommandAccess_Visible = new Dictionary<string, bool>();
        Dictionary<string, bool> mDeleteCommandClickedHandlerAdded = new Dictionary<string, bool>();
        Dictionary<string, EventHandler> mDeleteCommandClickedHandlers = new Dictionary<string, EventHandler>();

        bool DefaultDeleteCommandAccess_Visible = false;
        bool DefaultDeleteCommandAccess_Value = false;
        bool DefaultDeleteCommandAccess_Enabled = false;

        bool DefaultCreateCommandAccess_Visible = false;
        bool DefaultCreateCommandAccess_Value = false;
        bool DefaultCreateCommandAccess_Enabled = false;

        bool DefaultDataGridViewAccess_Visible = false;
        bool DefaultDataGridViewAccess_Value = false;
        bool DefaultDataGridViewAccess_Enabled = false;

        public void BindView(string property_name, DataGridView view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate doubleclick_callback, DataFillDelegate datafill_callback)
        {
            mDataGridViews[property_name] = view;
            mDataGridViewFillCallback[property_name] = datafill_callback;

            if (access_enabled != null) mDataGridViewAccess_Enabled[property_name] = access_enabled.Value;
            if (access_value != null) mDataGridViewAccess_Value[property_name] = access_value.Value;
            if (access_visible != null) mDataGridViewAccess_Visible[property_name] = access_visible.Value;
            mDataGridViewDoubleClickedHandlerAdded[property_name] = false;

            if (doubleclick_callback == null) mDataGridViewDoubleClickedHandlers[property_name] = null;
            else mDataGridViewDoubleClickedHandlers[property_name] = new EventHandler(doubleclick_callback);
        }

        public void BindCreateCommand(string property_name, Button view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate callback)
        {
            mCreateCommands[property_name] = view;
            if (access_enabled != null) mCreateCommandAccess_Enabled[property_name] = access_enabled.Value;
            if (access_value != null) mCreateCommandAccess_Value[property_name] = access_value.Value;
            if (access_visible != null) mCreateCommandAccess_Visible[property_name] = access_visible.Value;
            mCreateCommandClickedHandlerAdded[property_name] = false;

            if (callback == null) mCreateCommandClickedHandlers[property_name] = null;
            else mCreateCommandClickedHandlers[property_name] = new EventHandler(callback);
        }

        public void BindDeleteCommand(string property_name, Button view, bool? access_enabled, bool? access_visible, bool? access_value, CommandDelegate callback)
        {
            mDeleteCommands[property_name] = view;
            if (access_enabled != null) mDeleteCommandAccess_Enabled[property_name] = access_enabled.Value;
            if (access_value != null) mDeleteCommandAccess_Value[property_name] = access_value.Value;
            if (access_visible != null) mDeleteCommandAccess_Visible[property_name] = access_visible.Value;
            mDeleteCommandClickedHandlerAdded[property_name] = false;

            if (callback == null) mDeleteCommandClickedHandlers[property_name] = null;
            else mDeleteCommandClickedHandlers[property_name] = new EventHandler(callback);
        }

        private BOList<BO> mListModel;
        public BOList<BO> ListModel
        {
            set 
            { 
                mListModel = value; 
                mListModel.Revised+=new BusinessObject.RevisedHandler(ViewListModel);
            }
        }

        public BO CreateInstance(params object[] options)
        {
            BO instance = mListModel.CreateItem(options);
            return instance;
        }

        public BO GetInstance(DataGridView dgv, params object[] options)
        {
            if (mListViewIDType==BOListViewIDType.STRING)
            {
                string instanceID;
                if (DataGridView_GetSelectedInstanceID(dgv, out instanceID))
                {
                    BO instance = mListModel.GetItem(instanceID, options);
                    return instance;
                }
            }
            else if(mListViewIDType==BOListViewIDType.INTEGER)
            {
                int instanceID;
                if (DataGridView_GetSelectedInstanceID(dgv, out instanceID))
                {
                    BO instance = mListModel.GetItem(instanceID);
                    return instance;
                }
            }
            
            return null;
        }

        public void DeleteInstance(DataGridView dgv)
        {
            if (mListViewIDType==BOListViewIDType.STRING)
            {
                string instanceID;
                if (DataGridView_GetSelectedInstanceID(dgv, out instanceID))
                {
                    OpResult result = mListModel.Delete(instanceID);
                }
            }
            else if(mListViewIDType==BOListViewIDType.INTEGER)
            {
                int instanceID;
                if (DataGridView_GetSelectedInstanceID(dgv, out instanceID))
                {
                    mListModel.Delete(instanceID);
                }
            }
        }

        public void ViewListModel()
        {
            DataGridView dgview;
            bool access_enabled;
            bool access_visible;
            bool access_value;

            foreach (string property_name in mDataGridViews.Keys)
            {
                dgview = mDataGridViews[property_name];
                access_visible = mDataGridViewAccess_Visible.ContainsKey(property_name) ? mDataGridViewAccess_Visible[property_name] : DefaultDataGridViewAccess_Visible;
                access_enabled = mDataGridViewAccess_Enabled.ContainsKey(property_name) ? mDataGridViewAccess_Enabled[property_name] : DefaultDataGridViewAccess_Enabled;
                access_value = mDataGridViewAccess_Value.ContainsKey(property_name) ? mDataGridViewAccess_Value[property_name] : DefaultDataGridViewAccess_Value;

                if (access_enabled) dgview.Enabled = mListModel.IsPropertyEnabled(property_name);
                if (access_visible) dgview.Visible = mListModel.IsPropertyVisible(property_name);
                if (access_value)
                {
                    mDataGridViewFillCallback[property_name]();
                    //dgview.Text = mListModel.GetPropertyValue<string>(property_name);
                }
                if (access_enabled && access_visible)
                {
                    if (mDataGridViewDoubleClickedHandlerAdded[property_name] == false && mDataGridViewDoubleClickedHandlers[property_name] != null)
                    {
                        dgview.DoubleClick += mDataGridViewDoubleClickedHandlers[property_name];
                        mDataGridViewDoubleClickedHandlerAdded[property_name] = true;
                    }
                }
                else
                {
                    if (mDataGridViewDoubleClickedHandlerAdded[property_name] == true && mDataGridViewDoubleClickedHandlers[property_name] != null)
                    {
                        dgview.DoubleClick -= mDataGridViewDoubleClickedHandlers[property_name];
                        mDataGridViewDoubleClickedHandlerAdded[property_name] = false;
                    }
                }
            }

            Button btnview;
            foreach (string property_name in mCreateCommands.Keys)
            {
                btnview = mCreateCommands[property_name];
                access_visible = mCreateCommandAccess_Visible.ContainsKey(property_name) ? mCreateCommandAccess_Visible[property_name] : DefaultCreateCommandAccess_Visible;
                access_enabled = mCreateCommandAccess_Enabled.ContainsKey(property_name) ? mCreateCommandAccess_Enabled[property_name] : DefaultCreateCommandAccess_Enabled;
                //access_value = mCreateCommandAccess_Value.ContainsKey(property_name) ? mCreateCommandAccess_Value[property_name] : DefaultCreateCommandAccess_Value;

                if (access_enabled) btnview.Enabled = mListModel.IsPropertyEnabled(property_name);
                if (access_visible) btnview.Visible = mListModel.IsPropertyVisible(property_name);
                //if (access_value) btnview.Text = mListModel.GetPropertyValue<string>(property_name);

                if (access_visible && access_enabled)
                {
                    if (mCreateCommandClickedHandlerAdded[property_name] == false && mCreateCommandClickedHandlers[property_name] != null)
                    {
                        btnview.Click += mCreateCommandClickedHandlers[property_name];
                        mCreateCommandClickedHandlerAdded[property_name] = true;
                    }
                }
                else
                {
                    if (mCreateCommandClickedHandlerAdded[property_name] == true && mCreateCommandClickedHandlers[property_name] != null)
                    {
                        btnview.Click -= mCreateCommandClickedHandlers[property_name];
                        mCreateCommandClickedHandlerAdded[property_name] = false;
                    }
                }
            }

            foreach (string property_name in mDeleteCommands.Keys)
            {
                btnview = mDeleteCommands[property_name];
                access_visible = mDeleteCommandAccess_Visible.ContainsKey(property_name) ? mDeleteCommandAccess_Visible[property_name] : DefaultDeleteCommandAccess_Visible;
                access_enabled = mDeleteCommandAccess_Enabled.ContainsKey(property_name) ? mDeleteCommandAccess_Enabled[property_name] : DefaultDeleteCommandAccess_Enabled;
                access_value = mDeleteCommandAccess_Value.ContainsKey(property_name) ? mDeleteCommandAccess_Value[property_name] : DefaultDeleteCommandAccess_Value;

                if (access_enabled) btnview.Enabled = mListModel.IsPropertyEnabled(property_name);
                if (access_visible) btnview.Visible = mListModel.IsPropertyVisible(property_name);
                //if (access_value) btnview.Text = mListModel.GetPropertyValue<string>(property_name);

                if (access_visible && access_enabled)
                {
                    if (mDeleteCommandClickedHandlerAdded[property_name] == false && mDeleteCommandClickedHandlers[property_name] != null)
                    {
                        btnview.Click += mDeleteCommandClickedHandlers[property_name];
                        mDeleteCommandClickedHandlerAdded[property_name] = true;
                    }
                }
                else
                {
                    if (mDeleteCommandClickedHandlerAdded[property_name] == true && mDeleteCommandClickedHandlers[property_name] != null)
                    {
                        btnview.Click -= mDeleteCommandClickedHandlers[property_name];
                        mDeleteCommandClickedHandlerAdded[property_name] = false;
                    }
                }
            }
        }

        private bool DataGridView_GetSelectedInstanceID(DataGridView dgv, out int SelectedInstanceID)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                SelectedInstanceID = 0;
                return false;
            }
            SelectedInstanceID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            return true;
        }

        private bool DataGridView_GetSelectedInstanceID(DataGridView dgv, out string SelectedInstanceID)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                SelectedInstanceID = "";
                return false;
            }
            SelectedInstanceID = dgv.SelectedRows[0].Cells[0].Value.ToString();
            return true;
        }

        public object DataGridView(string property_name, params object[] options)
        {
            return mListModel.DataGridView(property_name, options);
        }
    
    }
}
