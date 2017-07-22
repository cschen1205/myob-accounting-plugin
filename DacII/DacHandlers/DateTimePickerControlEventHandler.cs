using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.DacHandlers
{
    using System.Windows.Forms;
    class DateTimePickerDacEventHandler : DacEventHandler
    {
        private DateTimePicker mDateTimePickerSender;
        public DateTimePickerDacEventHandler(DateTimePicker c, EventTypes type, EventHandler handler)
            : base(c, type, handler)
        {
            mDateTimePickerSender = c;
        }

        public override void  Connect()
        {
            if (mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.ValueChanged:
                {
                    mDateTimePickerSender.ValueChanged += mEventHandler;
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
                case EventTypes.ValueChanged:
                    {
                        mDateTimePickerSender.ValueChanged -= mEventHandler;
                        break;
                    }
            }

            mIsConnected = false;
        }
    }
}
