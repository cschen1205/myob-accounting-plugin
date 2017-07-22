using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Definitions;

namespace Accounting.Bll.Definitions
{
    using System.ComponentModel;
    public class BOListGender : BOList<BOGender>
    {
        private BindingList<Gender> mGenders = new BindingList<Gender>();
        public IList<Gender> Genders { get { return mGenders; } }

        public BOListGender(Accountant acc)
            : base(acc)
        {
            mObjectID = BOType.BOListGender;
            UpdateContent();
            mAccountant.GenderMgr.PropertyChanged += new PropertyChangedEventHandler(GenderMgr_PropertyChanged);
        }

        void GenderMgr_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateContent();
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            mGenders.Clear();
            IList<Gender> genders = mAccountant.GenderMgr.FindAllCollection();
            foreach (Gender gender in genders)
            {
                mGenders.Add(gender);
            }
        }

        public IList<Gender> DataSource
        {
            get
            {
                return mGenders;
            }
        }
    }
}
