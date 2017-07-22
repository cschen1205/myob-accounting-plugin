using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.DacHandlers
{
    using System.Windows.Forms;
    class TreeViewDacEventHandler : DacEventHandler
    {
        private TreeViewEventHandler mHandler;
        private TreeView mTreeViewSender;

        public TreeViewDacEventHandler(TreeView c, EventTypes type, TreeViewEventHandler handler)
            : base(c, type, null)
        {
            mHandler=handler;
            mTreeViewSender = c;
        }

        public override void Connect()
        {
            if (!mIsConnected)
            {
                return;
            }

            switch (mEventType)
            {
                case EventTypes.AfterSelect:
                    {
                        mTreeViewSender.AfterSelect += mHandler;
                        break;
                    }
            }

            mIsConnected = false;
        }

        public override void Disconnect()
        {
            if (mIsConnected) return;

            switch (mEventType)
            {
                case EventTypes.AfterSelect:
                    {
                        mTreeViewSender.AfterSelect -= mHandler;
                        break;
                    }
            }

            mIsConnected = false;
        }
    }
}
