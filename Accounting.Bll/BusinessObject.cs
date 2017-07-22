using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Accounting.Bll
{
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using Accounting.Core;
    using Accounting.Bll.Security;
    using System.Linq.Expressions;

    public abstract class BusinessObject : INotifyPropertyChanged
    {
        public static string PERSIST_OBJECT = "PersistBusinessObject";
        public static string DELETE_OBJECT = "DeleteBusinessObject";
        public static readonly string DATA_STORE = "DataStore";

        protected string mObjectID="BusinessObject";
        public string ObjectID
        {
            get { return mObjectID; }
        }

        public string DecorateError(string target, string error)
        {
            return string.Format("{0}.{1} {2}", ObjectID, target, error);
        }

        public string DecorateTypeMismatchError(string target, string target_type)
        {
            string error = string.Format("{0}.{1} must be of type {2}", ObjectID, target, target_type);
            return error;
        }

        public string DecorateEntityAlreadyExistError(string target, object value)
        {
            return string.Format("{0}.{1} (value = {2}) already exists", ObjectID, target, value);
        }

        public string DecorateInputTypeMismatchError(string target, string target_type)
        {
            string error = string.Format("{0}.{1} must be input as {2}", ObjectID, target, target_type);
            return error;
        }

        private Dictionary<string, BOProperty> mProperties = new Dictionary<string, BOProperty>();

        public Dictionary<string, BOProperty> Properties
        {
            get { return mProperties; }
        }

        protected BOProperty GetProperty(string propertyName)
        {
            if (mProperties.ContainsKey(propertyName))
            {
                return mProperties[propertyName];
            }
            return null;
        }

        protected virtual void InitializeProperties()
        {
            AddProperty(PERSIST_OBJECT,
                PERSIST_OBJECT,
                delegate() { return "Record"; },
                delegate(object value) { },
                delegate() { return CanEdit; },
                delegate() { return CanEdit; },
                delegate(object value, ref string error) { return true; });

            AddProperty(DELETE_OBJECT,
                DELETE_OBJECT,
                delegate() { return "Delete"; },
                delegate(object value) { },
                delegate() { return CanDelete; },
                delegate() { return CanDelete; },
                delegate(object value, ref string error) { return true; });
        }

        protected virtual void AddProperty(string propertyName, 
            string description,
            GetValueHandler getValueHandler,
            SetValueHandler setValueHandler,
            ValidateEnableHandler isEnableHandler,
            ValidateVisibleHandler isVisibleHandler,
            ValidateValueHandler validateHandler)
        {
            BOProperty property = new BOProperty(
                propertyName, 
                description,
                getValueHandler,
                setValueHandler,
                isEnableHandler,
                isVisibleHandler,
                validateHandler
                );

            if (mProperties.ContainsKey(propertyName))
            {
                throw new Exception(string.Format("property {0} already exists", propertyName));
            }

            mProperties[propertyName] = property;
        }

        protected virtual void AddProperty(string propertyName,
            string description,
            GetValueHandler getValueHandler,
            SetValueHandler setValueHandler,
            ValidateEnableHandler isEnableHandler,
            ValidateVisibleHandler isVisibleHandler)
        {
            BOProperty property = new BOProperty(
                propertyName,
                description,
                getValueHandler,
                setValueHandler,
                isEnableHandler,
                isVisibleHandler,
                null
                );

            if (mProperties.ContainsKey(propertyName))
            {
                throw new Exception(string.Format("property {0} already exists", propertyName));
            }

            mProperties[propertyName] = property;
        }

        public static bool IsWithinRange(string text, int minLength, int maxLength, out string error, params string[] options)
        {
            error = "";
            if (text.Length > maxLength || text.Length < minLength)
            {
                error = string.Format("must contain only {0}-{1} characters", minLength, maxLength);
                return false;
            }
            return true;
        }

        /// <summary>
        /// method for validating a url with regular expressions
        /// </summary>
        /// <param name="url">url we're validating</param>
        /// <returns>true if valid, otherwise false</returns>
        private static string UrlPatternExpression = @"^((http|https|ftp)\://|)[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
        //private static string UrlPatternExpression = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
        public static bool IsValidUrl(string url, int minLength, int maxLength, out string error, params string[] options)
        {
            error = "";
            if (minLength == 0 && url.Length == 0)
            {
                return true;
            }

            if (IsWithinRange(url, minLength, maxLength, out error, options))
            {
                Regex reg = new Regex(UrlPatternExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (reg.IsMatch(url))
                {
                    return true;
                }
            }
            error = string.Format("must be{0} a valid url containing only {1}-{2}", (minLength==0 ? "" : " either empty or"), minLength, maxLength);
            return false;
        }

        /// <summary>
        /// Regular expression, which is used to validate an E-Mail address.
        /// </summary>
        public const string MatchEmailPattern =
                  @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        /// <summary>
        /// Checks whether the given Email-Parameter is a valid E-Mail address.
        /// </summary>
        /// <param name="email">Parameter-string that contains an E-Mail address.</param>
        /// <returns>True, when Parameter-string is not null and 
        /// contains a valid E-Mail address;
        /// otherwise false.</returns>
        public static bool IsValidEmail(string email, int minLength, int maxLength, out string error, params string[] options)
        {
            error = "";
            if (minLength == 0 && email.Length == 0)
            {
                return true;
            }
            
            if(IsWithinRange(email, minLength, maxLength, out error, options))
            {
                if (Regex.IsMatch(email, MatchEmailPattern))
                {
                    return true;
                }
            }
            error =string.Format( "must be{0} a valid email address containing {1}-{2} characters", (minLength == 0 ? "" : " either empy or"), minLength, maxLength);
            return false;
        }

        public static bool IsValidAccountNumber(string account_number, out string error)
        {
            error="";
            if (account_number.Length != 6)
            {
                error = string.Format("must be in the format of x-xxxx (x is an integer)");
                return false;
            }

            if (!Regex.IsMatch(account_number, "^[0-9]-[0-9]{4}"))
            {
                error = string.Format("must be in the format of x-xxxx (x is an integer)");
                return false;
            }
            return true;
        }

        public static bool IsValidPhoneNumber(string phone_number, int minLength, int maxLength, out string error, params string[] options)
        {
            return IsAlphaNumeric(phone_number, minLength, maxLength, out error, "- ");
        }

        public static bool IsAlphaNumeric(string text, int minLength, int maxLength, out string error, params string[] options)
        {
            error = "";
            string extra_allowed="";
            if (options.Length > 0)
            {
                extra_allowed = options[0] as string;
            }
            string expression = string.Format("^[0-9a-zA-Z{0}]*$", extra_allowed);
            Regex regex = new Regex(expression);
            if (regex.IsMatch(text))
            {
                if (text.Length <= maxLength && text.Length >= minLength)
                {
                    return true;
                }
                error = string.Format("must contain only {0}-{1} characters", minLength, maxLength);
            }
            else
            {
                error = string.Format("must be alphanumeric characters and contain only {0}-{1} characters", minLength, maxLength);
            }
            return false;
        }

        public static bool IsAlphabet(string text, int minLength, int maxLength, out string error, params string[] options)
        {
            error = "";
            string extra_allowed = "";
            if (options.Length > 0)
            {
                extra_allowed = options[0] as string;
            }
            string expression = string.Format("^[a-zA-Z{0}]*$", extra_allowed);
            Regex regex = new Regex(expression);
            if (regex.IsMatch(text))
            {
                if (text.Length <= maxLength && text.Length >= minLength)
                {
                    return true;
                }
                error = string.Format("must contain only {0}-{1} characters", minLength, maxLength);
            }
            else
            {
                error = string.Format("must be alphabet characters and contain only {0}-{1} characters", minLength, maxLength);
            }
            return false;
        }

        public static bool IsNumeric(string text, int integer_digits, int decimal_digits, out string error)
        {
            error = "";
            double result;
            if (double.TryParse(text, out result))
            {
                return true;
            }

            error=string.Format("must be a {0}.{1}xN number", integer_digits, decimal_digits);
            return false;
        }

        public static bool IsInteger(string text, int max_digits, bool can_be_negative, out string error)
        {
            error = "";
            int result;
            if (int.TryParse(text, out result))
            {
                if (result < Math.Pow(10, max_digits))
                {
                    if (result < 0 && !can_be_negative)
                    {
                        error = string.Format("must be a {0}xN positive integer", max_digits);
                        return false;
                    }
                    return true;
                }
                error = string.Format("must be a {0}xN integer", max_digits);
                return false;
            }
            error="must be an integer";
            return false;
        }

        public virtual bool IsPropertyEnabled(string propertyName)
        {
            BOProperty property = GetProperty(propertyName);
            if (mAccountant.CurrentAuthUser.CheckAccess(mObjectID, propertyName, BOPropertyAttrType.Enabled))
            {
                if (property == null)
                {
                    throw new NotImplementedException(string.Format("[{0}] does not exists", propertyName));
                }
                return property.Enabled;
            }
            return false;
        }

        public virtual bool IsPropertyVisible(string propertyName)
        {
            BOProperty property = GetProperty(propertyName);
            if (mAccountant.CurrentAuthUser.CheckAccess(mObjectID, propertyName, BOPropertyAttrType.Visible))
            {
                if (property == null)
                {
                    throw new NotImplementedException(string.Format("[{0}] does not exists", propertyName));
                }
                return property.Visible;
            }
            return false;
        }

        public virtual bool CanEdit
        {
            get { return true; }
        }

        public virtual bool CanDelete
        {
            get { return false; }
        }

        public virtual void SetPropertyValue(string propertyName, object propertyValue)
        {
            BOProperty property = GetProperty(propertyName);
            if (property == null)
            {
                throw new NotImplementedException(string.Format("[{0}] does not exists", propertyName));
            }
            property.Value = propertyValue;
        }

        public virtual bool ValidateValue(string propertyName, object propertyValue, out string error)
        {
            BOProperty property = GetProperty(propertyName);
            if (property == null)
            {
                throw new NotImplementedException(string.Format("[{0}] does not exists", propertyName));
            }
            return property.ValidateValue(propertyValue, out error);
        }



        public virtual T GetPropertyValue<T>(string propertyName)
        {
            BOProperty property = GetProperty(propertyName);
            if (property == null)
            {
                throw new NotImplementedException(string.Format("[{0}] does not exists", propertyName));
            }
            object value = property.Value;

            if (value is T)
            {
                return (T)value;
            }
            else if (typeof(T)==typeof(string))
            {
                return (T)Convert.ChangeType(Convert.ToString(value), typeof(T));
            }

            try
            {
                return (T)value;
            }
            catch (NullReferenceException nre)
            {
                throw new NullReferenceException(string.Format("Failed to cast property [{0}] to {1}", propertyName, typeof(T).ToString()));
            }
            catch (InvalidCastException ice)
            {
                throw new InvalidCastException(string.Format("Failed to cast property [{0}] to {1}", propertyName, typeof(T).ToString()));
            }
        }

        protected Accountant mAccountant;
        public Accountant Accountant
        {
            get { return mAccountant; }
        }

        public BusinessObject(Accountant accountant, BOContext state)
        {
            mAccountant = accountant;
            mAccountant.DataStoreInvalidated += new RepositoryManager.DataStoreInvalidatedHandler(OnDataStoreInvalidated);
            mRecordContext = state;
            InitializeProperties();
        }

        protected virtual void OnDataStoreInvalidated()
        {
            UpdateContent();
            NotifyPropertyChanged(DATA_STORE);
        }

        protected virtual void UpdateContent()
        {
            Console.WriteLine("Update DataSource Default: {0}", ObjectID);
        }

        public void InvalidateDataStore()
        {
            mAccountant.InvalidateDataStore();
        }

        public enum BOContext
        {
            Record_Update,
            Record_Create
        };

        private BOContext mRecordContext;
        protected BOContext RecordContext
        {
            get { return mRecordContext; }
        }

        public bool IsCreating
        {
            get { return mRecordContext == BOContext.Record_Create; }
            set
            {
                if (value)
                {
                    mRecordContext = BOContext.Record_Create;
                }
            }
        }

        public bool IsUpdating
        {
            get { return mRecordContext == BOContext.Record_Update; }
        }
   
        protected string CleanString(string s)
        {
            return (s ?? string.Empty).Trim();
        }

        protected virtual OpResult _Record()
        {
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.NoActionTaken, null);
        }

        public virtual OpResult Record()
        {
            OpResult result  = _Record();
            return result;
        }

        protected virtual OpResult _Delete()
        {
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NoActionTaken, null);
        }

        public virtual OpResult Delete()
        {
            OpResult result = _Delete();
            return result;
        }

        public void Log(string message)
        {
            Accounting.Util.AppEnv.Instance.Log(message);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }        
    }
}
