using System;
using System.Collections.Generic;

namespace DacII.WinForms
{
    using DacII.Presenters;
    using DacII.DacHandlers;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    public class BaseView : Form
    {
        private Dictionary<Control, DacEventHandler> mEventHandlers = new Dictionary<Control, DacEventHandler>();
        protected ApplicationPresenter mApplicationController = null;

        public BaseView(ApplicationPresenter main_controller)
        {
            mApplicationController = main_controller;
            Load += new EventHandler(AccForm_Load);
        }

        public BaseView()
        {

        }

        protected void GoBack()
        {
            this.Close();
        }      

        void AccForm_Load(object sender, EventArgs e)
        {
            SafeLoadView();
        }

        protected void RegisterEventHandler(Control c, DacEventHandler.EventTypes event_type, EventHandler handler)
        {
            mEventHandlers[c] = new DacEventHandler(c, event_type, handler);
        }

        protected void RegisterEventHandler(TreeView c, DacEventHandler.EventTypes event_type, TreeViewEventHandler handler)
        {
            mEventHandlers[c] = new TreeViewDacEventHandler(c, event_type, handler);
        }

        protected void RegisterEventHandler(DateTimePicker c, DacEventHandler.EventTypes event_type, EventHandler handler)
        {
            mEventHandlers[c] = new DateTimePickerDacEventHandler(c, event_type, handler);
        }

        protected void RegisterEventHandler(ComboBox c, DacEventHandler.EventTypes event_type, EventHandler handler)
        {
            mEventHandlers[c] = new ComboBoxDacEventHandler(c, event_type, handler);
        }

        protected void RegisterEventHandler(CheckBox c, DacEventHandler.EventTypes event_type, EventHandler handler)
        {
            mEventHandlers[c] = new CheckBoxDacEventHandler(c, event_type, handler);
        }

        public void DoShow()
        {
            if (Visible)
            {
                Activate();
            }
            else
            {
                Show();
            }
        }

        public bool DoDialog()
        {
            return ShowDialog()==DialogResult.OK;
        }

        protected virtual void LoadView()
        {
            
        }

        protected void ConnectEvents()
        {
            foreach (DacEventHandler handler in mEventHandlers.Values)
            {
                handler.Connect();
            }
        }

        private void DisconnectEvents()
        {
            foreach (DacEventHandler handler in mEventHandlers.Values)
            {
                handler.Disconnect();
            }
        }

        public void UpdateView()
        {
            _UpdateView();
        }

        protected virtual void _UpdateView()
        {
            SafeLoadView();
        }

        protected void SafeLoadView()
        {
            DisconnectEvents();
            LoadView();
            ConnectEvents();
        }

        protected virtual void BindViews()
        {

        }

        protected virtual void RegisterEventHandlers()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AccForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.DoubleBuffered = true;
            this.Name = "BaseView";
            this.ResumeLayout(false);

        }
    }
}
