using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll
{
    public delegate object GetValueHandler();
    public delegate void SetValueHandler(object value);
    public delegate bool ValidateVisibleHandler();
    public delegate bool ValidateEnableHandler();
    public delegate bool ValidateValueHandler(object value, ref string error);

    public class BOProperty 
    {
        private GetValueHandler mGetValueHandler;
        private SetValueHandler mSetValueHandler;
        private ValidateEnableHandler mValidateEnableHandler;
        private ValidateVisibleHandler mValidateVisibleHandler;
        private ValidateValueHandler mValidateValueHandler;

        public GetValueHandler GetValueHandler { set { mGetValueHandler = value; } }
        public SetValueHandler SetValueHandler { set { mSetValueHandler = value; } }
        public ValidateEnableHandler ValidateEnableHandler { set { mValidateEnableHandler = value; } }
        public ValidateVisibleHandler ValidateVisibleHandler { set { mValidateVisibleHandler = value; } }
        public ValidateValueHandler ValidateValueHandler { set { mValidateValueHandler = value; } }

        private string mDescription;
        private string mPropertyName;

        public bool ValidateValue(object value, out string error)
        {
            error = "";
            if (mValidateValueHandler == null)
            {
                throw new NullReferenceException(string.Format("[{0}] does not have a validate value handler", PropertyName));
            }
            return mValidateValueHandler(value, ref error);
        }

        public string Description
        {
            get { return mDescription; }
            protected set { mDescription = value; }
        }

        public string PropertyName
        {
            get { return (mPropertyName ?? string.Empty).Trim(); }
            protected set { mPropertyName = value; }
        }

        public override string ToString()
        {
            return this.Description;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public BOProperty(
            string propertyName, 
            string description, 
            GetValueHandler getValueHandler,
            SetValueHandler setValueHandler,
            ValidateEnableHandler isEnableHandler,
            ValidateVisibleHandler isVisibleHandler,
            ValidateValueHandler validateValueHandler
            )
        {
            this.Description = description;
            this.PropertyName = propertyName;
            this.mGetValueHandler = getValueHandler;
            this.mSetValueHandler = setValueHandler;
            this.mValidateEnableHandler = isEnableHandler;
            this.mValidateVisibleHandler = isVisibleHandler;
            this.mValidateValueHandler = validateValueHandler;
        }

        public object Value
        {
            get
            {
               return mGetValueHandler();
            }
            set
            {
                mSetValueHandler(value);
            }
        }

        public bool Visible
        {
            get
            {
                return mValidateVisibleHandler();
            }
        }

        public bool Enabled
        {
            get
            {
                return mValidateEnableHandler();
            }
        }
    }
}
