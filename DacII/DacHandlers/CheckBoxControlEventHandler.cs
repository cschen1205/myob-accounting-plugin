using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.DacHandlers
{
    using System.Windows.Forms;
    class CheckBoxDacEventHandler : DacEventHandler
    {
        private CheckBox mCheckBoxSender;
        public CheckBoxDacEventHandler(CheckBox c, EventTypes type, EventHandler handler)
            : base(c, type, handler)
        {
            mCheckBoxSender = c;
        }

        public override void Connect()
        {
            if (mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.CheckedChanged:
                    {
                        mCheckBoxSender.CheckedChanged += mEventHandler;
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
                case EventTypes.CheckedChanged:
                    {
                        mCheckBoxSender.CheckedChanged -= mEventHandler;
                        break;
                    }
            }
            mIsConnected = false ;
        }
    }
}
