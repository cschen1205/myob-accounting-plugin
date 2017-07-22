using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Definitions;

namespace Accounting.Bll.Definitions
{
    using System.ComponentModel;
    public class BOListDataField : BOList<BODataField>
    {
        private BindingList<DataField> mDataFields = new BindingList<DataField>();
        public BOListDataField(Accountant acc)
            : base(acc)
        {
            mObjectID = BOType.BOListDataField;
            UpdateContent();
            mAccountant.DataFieldMgr.PropertyChanged += new PropertyChangedEventHandler(DataFieldMgr_PropertyChanged);
        }

        void DataFieldMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            mDataFields.Clear();

            IList<DataField> datafields=mAccountant.DataFieldMgr.FindAllCollection();
            foreach (DataField datafield in datafields)
            {
                mDataFields.Add(datafield);
            }
        }

        public IList<DataField> DataSource
        {
            get
            {
                return mDataFields;
            }
        }

    }
}
