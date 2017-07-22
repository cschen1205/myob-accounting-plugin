using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.DacHandlers
{
    using System.Windows.Forms;
    public class ComboBoxDacEventHandler : DacEventHandler
    {
        ComboBox mComboBoxSender = null;
        public ComboBoxDacEventHandler(ComboBox c, EventTypes type, EventHandler handler)
            : base(c, type, handler)
        {
            mComboBoxSender = c;
        }

        public override void Connect()
        {
            if (mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.SelectedIndexChanged:
                    {
                        mComboBoxSender.SelectedIndexChanged += mEventHandler;
                        break;
                    }
            }

            mIsConnected = true;
        }

        public override void Disconnect()
        {
            if (!mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.SelectedIndexChanged:
                    {
                        mComboBoxSender.SelectedIndexChanged -= mEventHandler;
                        break;
                    }
            }

            mIsConnected = false;
        }
    }
}
