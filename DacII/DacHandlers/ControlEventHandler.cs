using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.DacHandlers
{
    using System.Windows.Forms;
    public class DacEventHandler
    {
        public enum EventTypes
        {
            Click,
            DoubleClick,
            AfterSelect,
            ValueChanged,
            CheckedChanged,
            SelectedIndexChanged
        }

        public DacEventHandler(Control c, EventTypes type, EventHandler handler)
        {
            mSender=c;
            mEventHandler=handler;
            mEventType=type;
        }

        protected EventTypes mEventType=EventTypes.Click;
        public EventTypes EventType
        {
            get { return mEventType; }
            set { mEventType=value; }
        }

        protected Control mSender=null;
        public Control Sender
        {
            get { return mSender; }
            set { mSender=value; }
        }

        protected EventHandler mEventHandler = null;
        public EventHandler Handler
        {
            get { return mEventHandler; }
            set { mEventHandler = value; }
        }

        protected bool mIsConnected = false;
        public bool IsConnected
        {
            get { return mIsConnected; }
        }


        public virtual void Connect()
        {
            if (mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.Click:
                    {
                        mSender.Click += mEventHandler;
                        break;
                    }
                case EventTypes.DoubleClick:
                    {
                        mSender.DoubleClick += mEventHandler;
                        break;
                    }
                default:
                    {
                        mSender.Click += mEventHandler;
                        break;
                    }
            }
            mIsConnected = true;
        }

        public virtual void Disconnect()
        {
            if (!mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.Click:
                    {
                        mSender.Click -= mEventHandler;
                        break;
                    }
                case EventTypes.DoubleClick:
                    {
                        mSender.DoubleClick -= mEventHandler;
                        break;
                    }
                default:
                    {
                        mSender.Click -= mEventHandler;
                        break;
                    }
            }
            mIsConnected = false;
        }
    }
}
