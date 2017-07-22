using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Cards;
using Accounting.Core.Currencies;
using Accounting.Core;

namespace Accounting.Bll.Cards
{
    public abstract class BOCard : BusinessObject
    {
        private Card mCard;

        public static string CARD_IDENTIFICATION = "CardIdentification";
        public static string NAME = "Name";
        public static string IS_INACTIVE = "IsInactive";
        public static string IS_ACTIVE = "IsActive";
        public static string IS_INDIVIDUAL = "IsIndividual";
        public static string CURRENCY = "Currency";

        public static string ADDRESS1_LINE1="Address1Line1";
        public static string ADDRESS1_LINE2="Address1Line2";
        public static string ADDRESS1_LINE3="Address1Line3";
        public static string ADDRESS1_LINE4="Address1Line4";
        public static string ADDRESS1_PHONE1="Address1Phone1";
        public static string ADDRESS1_PHONE2="Address1Phone2";
        public static string ADDRESS1_PHONE3 = "Address1Phone3";
        public static string ADDRESS1_CITY="Address1City";
        public static string ADDRESS1_COUNTRY="Address1Country";
        public static string ADDRESS1_EMAIL="Address1Email";
        public static string ADDRESS1_WEBSITE="Address1Website";
        public static string ADDRESS1_FAX="Address1Fax";
        public static string ADDRESS1_CONTACT_NAME="Address1ContactName";
        public static string ADDRESS1_STATE = "Address1State";
        public static string ADDRESS1_SOLUTATION = "Address1Solutation";
        public static string ADDRESS1_POSTCODE = "Address1Postcode";

        public static string ADDRESS2_LINE1 = "Address2Line1";
        public static string ADDRESS2_LINE2 = "Address2Line2";
        public static string ADDRESS2_LINE3 = "Address2Line3";
        public static string ADDRESS2_LINE4 = "Address2Line4";
        public static string ADDRESS2_PHONE1 = "Address2Phone1";
        public static string ADDRESS2_PHONE2 = "Address2Phone2";
        public static string ADDRESS2_PHONE3 = "Address2Phone3";
        public static string ADDRESS2_CITY = "Address2City";
        public static string ADDRESS2_COUNTRY = "Address2Country";
        public static string ADDRESS2_EMAIL = "Address2Email";
        public static string ADDRESS2_WEBSITE = "Address2Website";
        public static string ADDRESS2_FAX = "Address2Fax";
        public static string ADDRESS2_CONTACT_NAME = "Address2ContactName";
        public static string ADDRESS2_STATE = "Address2State";
        public static string ADDRESS2_SOLUTATION = "Address2Solutation";
        public static string ADDRESS2_POSTCODE = "Address2Postcode";

        public static string ADDRESS3_LINE1 = "Address3Line1";
        public static string ADDRESS3_LINE2 = "Address3Line2";
        public static string ADDRESS3_LINE3 = "Address3Line3";
        public static string ADDRESS3_LINE4 = "Address3Line4";
        public static string ADDRESS3_PHONE1 = "Address3Phone1";
        public static string ADDRESS3_PHONE2 = "Address3Phone2";
        public static string ADDRESS3_PHONE3 = "Address3Phone3";
        public static string ADDRESS3_CITY = "Address3City";
        public static string ADDRESS3_COUNTRY = "Address3Country";
        public static string ADDRESS3_EMAIL = "Address3Email";
        public static string ADDRESS3_WEBSITE = "Address3Website";
        public static string ADDRESS3_FAX = "Address3Fax";
        public static string ADDRESS3_CONTACT_NAME = "Address3ContactName";
        public static string ADDRESS3_STATE = "Address3State";
        public static string ADDRESS3_SOLUTATION = "Address3Solutation";
        public static string ADDRESS3_POSTCODE = "Address3Postcode";

        public static string ADDRESS4_LINE1 = "Address4Line1";
        public static string ADDRESS4_LINE2 = "Address4Line2";
        public static string ADDRESS4_LINE3 = "Address4Line3";
        public static string ADDRESS4_LINE4 = "Address4Line4";
        public static string ADDRESS4_PHONE1 = "Address4Phone1";
        public static string ADDRESS4_PHONE2 = "Address4Phone2";
        public static string ADDRESS4_PHONE3 = "Address4Phone3";
        public static string ADDRESS4_CITY = "Address4City";
        public static string ADDRESS4_COUNTRY = "Address4Country";
        public static string ADDRESS4_EMAIL = "Address4Email";
        public static string ADDRESS4_WEBSITE = "Address4Website";
        public static string ADDRESS4_FAX = "Address4Fax";
        public static string ADDRESS4_CONTACT_NAME = "Address4ContactName";
        public static string ADDRESS4_STATE = "Address4State";
        public static string ADDRESS4_SOLUTATION = "Address4Solutation";
        public static string ADDRESS4_POSTCODE = "Address4Postcode";

        public static string ADDRESS5_LINE1 = "Address5Line1";
        public static string ADDRESS5_LINE2 = "Address5Line2";
        public static string ADDRESS5_LINE3 = "Address5Line3";
        public static string ADDRESS5_LINE4 = "Address5Line4";
        public static string ADDRESS5_PHONE1 = "Address5Phone1";
        public static string ADDRESS5_PHONE2 = "Address5Phone2";
        public static string ADDRESS5_PHONE3 = "Address5Phone3";
        public static string ADDRESS5_CITY = "Address5City";
        public static string ADDRESS5_COUNTRY = "Address5Country";
        public static string ADDRESS5_EMAIL = "Address5Email";
        public static string ADDRESS5_WEBSITE = "Address5Website";
        public static string ADDRESS5_FAX = "Address5Fax";
        public static string ADDRESS5_CONTACT_NAME = "Address5ContactName";
        public static string ADDRESS5_STATE = "Address5State";
        public static string ADDRESS5_SOLUTATION = "Address5Solutation";
        public static string ADDRESS5_POSTCODE = "Address5Postcode";

        public static string CUSTOM_FIELD1 = "CustomField1";
        public static string CUSTOM_FIELD2 = "CustomField2";
        public static string CUSTOM_FIELD3 = "CustomField3";

        public static string STATEMENT_TEXT = "StatementText";

        public Card Card
        {
            get { return mCard; }
        }

        public BOCard(Accountant accountant, Card _obj, BOContext _state)
            : base(accountant, _state)
        {
            mObjectID = BOType.BOCard;
            mCard = _obj;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region CARD_IDENTIFICATION
            AddProperty(CARD_IDENTIFICATION,
                CARD_IDENTIFICATION,
                delegate()
                {
                    if (RecordContext == BusinessObject.BOContext.Record_Create)
                    {
                        if (mCard is Customer)
                        {
                            return mAccountant.CustomerMgr.GenerateCardIdentification();
                        }
                        else if (mCard is Supplier)
                        {
                            return mAccountant.SupplierMgr.GenerateCardIdentification();
                        }
                        else if (mCard is Employee)
                        {
                            return mAccountant.EmployeeMgr.GenerateCardIdentification();
                        }
                    }
                    return mCard.CardIdentification;
                },
                delegate(object value)
                {
                    mCard.CardIdentification = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 1, 16, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CARD_IDENTIFICATION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CARD_IDENTIFICATION, "string");
                    }
                    return false;
                });
            #endregion

            #region NAME
            AddProperty(NAME,
                NAME,
                delegate()
                {
                    return mCard.Name;
                },
                delegate(object value)
                {
                    mCard.Name = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 1, 52, out error))
                        {
                            return true;
                        }
                        error = DecorateError(NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region IS_INACTIVE
            AddProperty(IS_INACTIVE,
                IS_INACTIVE,
                delegate()
                {
                    return mCard.IsInactive.Equals("Y");
                },
                delegate(object value)
                {
                    mCard.IsInactive = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_INACTIVE, "bool");
                    return false;
                });
            #endregion

            #region IS_ACTIVE
            AddProperty(IS_ACTIVE,
                IS_ACTIVE,
                delegate()
                {
                    return mCard.IsInactive.Equals("N");
                },
                delegate(object value)
                {
                    mCard.IsInactive = (bool)value ? "N" : "Y";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_ACTIVE, "bool");
                    return false;
                });
            #endregion

            #region IS_INDIVIDUAL
            AddProperty(IS_INDIVIDUAL,
                IS_INDIVIDUAL,
                delegate()
                {
                    return mCard.IsIndividual.Equals("Y");
                },
                delegate(object value)
                {
                    mCard.IsIndividual = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_INDIVIDUAL, "bool"); 
                    return false;
                });
            #endregion

            #region CURRENCY
            AddProperty(CURRENCY,
                CURRENCY,
                delegate()
                {
                    return mCard.Currency;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mCard.Currency = null;
                    }
                    else
                    {
                        mCard.Currency = value as Currency;
                    }
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Currency)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CURRENCY, "Currency"); 
                    }
                    return false;
                });
            #endregion

            #region STATEMENT_TEXT
            AddProperty(STATEMENT_TEXT,
                STATEMENT_TEXT,
                delegate()
                {
                    return mAccountant.DataFileInformationMgr.Company.CompanyName.ToUpper();
                },
                delegate(object value)
                {
                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                });
            #endregion

            #region CUSTOM_FIELD1
            AddProperty(CUSTOM_FIELD1,
                CUSTOM_FIELD1,
                delegate()
                {
                    return mCard.CustomField1;
                },
                delegate(object value)
                {
                    mCard.CustomField1 = (string) value ;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CUSTOM_FIELD1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOM_FIELD1, "string");
                    }
                    return false;
                });
            #endregion

            #region CUSTOM_FIELD2
            AddProperty(CUSTOM_FIELD2,
                CUSTOM_FIELD2,
                delegate()
                {
                    return mCard.CustomField2;
                },
                delegate(object value)
                {
                    mCard.CustomField2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CUSTOM_FIELD2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOM_FIELD2, "string");
                    }
                    return false;
                });
            #endregion

            #region CUSTOM_FIELD3
            AddProperty(CUSTOM_FIELD3,
                CUSTOM_FIELD3,
                delegate()
                {
                    return mCard.CustomField3;
                },
                delegate(object value)
                {
                    mCard.CustomField3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CUSTOM_FIELD3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOM_FIELD3, "string");
                    }
                    return false;
                });
            #endregion

        

            InitializeAddress1();
            InitializeAddress2();
            InitializeAddress3();
            InitializeAddress4();
            InitializeAddress5();
        }

        private void InitializeAddress1()
        {
            #region Address1.Line1
            AddProperty(ADDRESS1_LINE1,
                ADDRESS1_LINE1,
                delegate()
                {
                    return mCard.Address1.StreetLine1;
                },
                delegate(object value)
                {
                    mCard.Address1.StreetLine1 = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_LINE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_LINE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Line2
            AddProperty(ADDRESS1_LINE2,
                ADDRESS1_LINE2,
                delegate()
                {
                    return mCard.Address1.StreetLine2;
                },
                delegate(object value)
                {
                    mCard.Address1.StreetLine2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_LINE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_LINE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Line3
            AddProperty(ADDRESS1_LINE3,
                ADDRESS1_LINE3,
                delegate()
                {
                    return mCard.Address1.StreetLine3;
                },
                delegate(object value)
                {
                    mCard.Address1.StreetLine3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_LINE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_LINE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Line4
            AddProperty(ADDRESS1_LINE4,
                ADDRESS1_LINE4,
                delegate()
                {
                    return mCard.Address1.StreetLine4;
                },
                delegate(object value)
                {
                    mCard.Address1.StreetLine4 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_LINE4, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_LINE4, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Country
            AddProperty(ADDRESS1_COUNTRY,
                ADDRESS1_COUNTRY,
                delegate()
                {
                    return mCard.Address1.Country;
                },
                delegate(object value)
                {
                    mCard.Address1.Country = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_COUNTRY, error);
                    }
                    else
                    {
                        error = DecorateError(ADDRESS1_COUNTRY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.City
            AddProperty(ADDRESS1_CITY,
                ADDRESS1_CITY,
                delegate()
                {
                    return mCard.Address1.City;
                },
                delegate(object value)
                {
                    mCard.Address1.City = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_CITY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_CITY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Email
            AddProperty(ADDRESS1_EMAIL,
                ADDRESS1_EMAIL,
                delegate()
                {
                    return mCard.Address1.Email;
                },
                delegate(object value)
                {
                    mCard.Address1.Email = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidEmail(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_EMAIL, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_EMAIL, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Website
            AddProperty(ADDRESS1_WEBSITE,
                ADDRESS1_WEBSITE,
                delegate()
                {
                    return mCard.Address1.Website;
                },
                delegate(object value)
                {
                    mCard.Address1.Website = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidUrl(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_WEBSITE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_WEBSITE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Fax
            AddProperty(ADDRESS1_FAX,
                ADDRESS1_FAX,
                delegate()
                {
                    return mCard.Address1.Fax;
                },
                delegate(object value)
                {
                    mCard.Address1.Fax = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_FAX, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_FAX, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.ContactName
            AddProperty(ADDRESS1_CONTACT_NAME,
                ADDRESS1_CONTACT_NAME,
                delegate()
                {
                    return mCard.Address1.ContactName;
                },
                delegate(object value)
                {
                    mCard.Address1.ContactName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_CONTACT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_CONTACT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Phone1
            AddProperty(ADDRESS1_PHONE1,
                ADDRESS1_PHONE1,
                delegate()
                {
                    return mCard.Address1.Phone1;
                },
                delegate(object value)
                {
                    mCard.Address1.Phone1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_PHONE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_PHONE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Phone2
            AddProperty(ADDRESS1_PHONE2,
                ADDRESS1_PHONE2,
                delegate()
                {
                    return mCard.Address1.Phone2;
                },
                delegate(object value)
                {
                    mCard.Address1.Phone2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_PHONE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_PHONE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Phone3
            AddProperty(ADDRESS1_PHONE3,
                ADDRESS1_PHONE3,
                delegate()
                {
                    return mCard.Address1.Phone3;
                },
                delegate(object value)
                {
                    mCard.Address1.Phone3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_PHONE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_PHONE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.State
            AddProperty(ADDRESS1_STATE,
                ADDRESS1_STATE,
                delegate()
                {
                    return mCard.Address1.State;
                },
                delegate(object value)
                {
                    mCard.Address1.State = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_STATE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_STATE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Solutation
            AddProperty(ADDRESS1_SOLUTATION,
                ADDRESS1_SOLUTATION,
                delegate()
                {
                    return mCard.Address1.Solutation;
                },
                delegate(object value)
                {
                    mCard.Address1.Solutation = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 15, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_SOLUTATION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_SOLUTATION, "string");
                    }
                    return false;
                });
            #endregion

            #region Address1.Postcode
            AddProperty(ADDRESS1_POSTCODE,
                ADDRESS1_POSTCODE,
                delegate()
                {
                    return mCard.Address1.Postcode;
                },
                delegate(object value)
                {
                    mCard.Address1.Postcode = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 10, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS1_POSTCODE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS1_POSTCODE, "string");
                    }
                    return false;
                });
            #endregion
        }

        private void InitializeAddress2()
        {
            #region Address2.Line1
            AddProperty(ADDRESS2_LINE1,
                ADDRESS2_LINE1,
                delegate()
                {
                    return mCard.Address2.StreetLine1;
                },
                delegate(object value)
                {
                    mCard.Address2.StreetLine1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_LINE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_LINE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Line2
            AddProperty(ADDRESS2_LINE2,
                ADDRESS2_LINE2,
                delegate()
                {
                    return mCard.Address2.StreetLine2;
                },
                delegate(object value)
                {
                    mCard.Address2.StreetLine2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_LINE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_LINE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Line3
            AddProperty(ADDRESS2_LINE3,
                ADDRESS2_LINE3,
                delegate()
                {
                    return mCard.Address2.StreetLine3;
                },
                delegate(object value)
                {
                    mCard.Address2.StreetLine3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_LINE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_LINE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Line4
            AddProperty(ADDRESS2_LINE4,
                ADDRESS2_LINE4,
                delegate()
                {
                    return mCard.Address2.StreetLine4;
                },
                delegate(object value)
                {
                    mCard.Address2.StreetLine4 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_LINE4, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_LINE4, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Country
            AddProperty(ADDRESS2_COUNTRY,
                ADDRESS2_COUNTRY,
                delegate()
                {
                    return mCard.Address2.Country;
                },
                delegate(object value)
                {
                    mCard.Address2.Country = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_COUNTRY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_COUNTRY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.City
            AddProperty(ADDRESS2_CITY,
                ADDRESS2_CITY,
                delegate()
                {
                    return mCard.Address2.City;
                },
                delegate(object value)
                {
                    mCard.Address2.City = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_CITY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_CITY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Email
            AddProperty(ADDRESS2_EMAIL,
                ADDRESS2_EMAIL,
                delegate()
                {
                    return mCard.Address2.Email;
                },
                delegate(object value)
                {
                    mCard.Address2.Email = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidEmail(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_EMAIL, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_EMAIL, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Website
            AddProperty(ADDRESS2_WEBSITE,
                ADDRESS2_WEBSITE,
                delegate()
                {
                    return mCard.Address2.Website;
                },
                delegate(object value)
                {
                    mCard.Address2.Website = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidUrl(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_WEBSITE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_WEBSITE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Fax
            AddProperty(ADDRESS2_FAX,
                ADDRESS2_FAX,
                delegate()
                {
                    return mCard.Address2.Fax;
                },
                delegate(object value)
                {
                    mCard.Address2.Fax = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_FAX, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_FAX, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.ContactName
            AddProperty(ADDRESS2_CONTACT_NAME,
                ADDRESS2_CONTACT_NAME,
                delegate()
                {
                    return mCard.Address2.ContactName;
                },
                delegate(object value)
                {
                    mCard.Address2.ContactName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_CONTACT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_CONTACT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Phone1
            AddProperty(ADDRESS2_PHONE1,
                ADDRESS2_PHONE1,
                delegate()
                {
                    return mCard.Address2.Phone1;
                },
                delegate(object value)
                {
                    mCard.Address2.Phone1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_PHONE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_PHONE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Phone2
            AddProperty(ADDRESS2_PHONE2,
                ADDRESS2_PHONE2,
                delegate()
                {
                    return mCard.Address2.Phone2;
                },
                delegate(object value)
                {
                    mCard.Address2.Phone2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_PHONE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_PHONE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Phone3
            AddProperty(ADDRESS2_PHONE3,
                ADDRESS2_PHONE3,
                delegate()
                {
                    return mCard.Address2.Phone3;
                },
                delegate(object value)
                {
                    mCard.Address2.Phone3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_PHONE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_PHONE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.State
            AddProperty(ADDRESS2_STATE,
                ADDRESS2_STATE,
                delegate()
                {
                    return mCard.Address2.State;
                },
                delegate(object value)
                {
                    mCard.Address2.State = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_STATE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_STATE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Solutation
            AddProperty(ADDRESS2_SOLUTATION,
                ADDRESS2_SOLUTATION,
                delegate()
                {
                    return mCard.Address2.Solutation;
                },
                delegate(object value)
                {
                    mCard.Address2.Solutation = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 15, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_SOLUTATION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_SOLUTATION, "string");
                    }
                    return false;
                });
            #endregion

            #region Address2.Postcode
            AddProperty(ADDRESS2_POSTCODE,
                ADDRESS2_POSTCODE,
                delegate()
                {
                    return mCard.Address2.Postcode;
                },
                delegate(object value)
                {
                    mCard.Address2.Postcode = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 10, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS2_POSTCODE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS2_POSTCODE, "string");
                    }
                    return false;
                });
            #endregion
        }

        private void InitializeAddress3()
        {
            #region Address3.Line1
            AddProperty(ADDRESS3_LINE1,
                ADDRESS3_LINE1,
                delegate()
                {
                    return mCard.Address3.StreetLine1;
                },
                delegate(object value)
                {
                    mCard.Address3.StreetLine1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_LINE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_LINE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Line2
            AddProperty(ADDRESS3_LINE2,
                ADDRESS3_LINE2,
                delegate()
                {
                    return mCard.Address3.StreetLine2;
                },
                delegate(object value)
                {
                    mCard.Address3.StreetLine2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_LINE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_LINE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Line3
            AddProperty(ADDRESS3_LINE3,
                ADDRESS3_LINE3,
                delegate()
                {
                    return mCard.Address3.StreetLine3;
                },
                delegate(object value)
                {
                    mCard.Address3.StreetLine3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_LINE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_LINE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Line4
            AddProperty(ADDRESS3_LINE4,
                ADDRESS3_LINE4,
                delegate()
                {
                    return mCard.Address3.StreetLine4;
                },
                delegate(object value)
                {
                    mCard.Address3.StreetLine4 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_LINE4, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_LINE4, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Country
            AddProperty(ADDRESS3_COUNTRY,
                ADDRESS3_COUNTRY,
                delegate()
                {
                    return mCard.Address3.Country;
                },
                delegate(object value)
                {
                    mCard.Address3.Country = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_COUNTRY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_COUNTRY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.City
            AddProperty(ADDRESS3_CITY,
                ADDRESS3_CITY,
                delegate()
                {
                    return mCard.Address3.City;
                },
                delegate(object value)
                {
                    mCard.Address3.City = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_CITY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_CITY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Email
            AddProperty(ADDRESS3_EMAIL,
                ADDRESS3_EMAIL,
                delegate()
                {
                    return mCard.Address3.Email;
                },
                delegate(object value)
                {
                    mCard.Address3.Email = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidEmail(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_EMAIL, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_EMAIL, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Website
            AddProperty(ADDRESS3_WEBSITE,
                ADDRESS3_WEBSITE,
                delegate()
                {
                    return mCard.Address3.Website;
                },
                delegate(object value)
                {
                    mCard.Address3.Website = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidUrl(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_WEBSITE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_WEBSITE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Fax
            AddProperty(ADDRESS3_FAX,
                ADDRESS3_FAX,
                delegate()
                {
                    return mCard.Address3.Fax;
                },
                delegate(object value)
                {
                    mCard.Address3.Fax = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_FAX, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_FAX, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.ContactName
            AddProperty(ADDRESS3_CONTACT_NAME,
                ADDRESS3_CONTACT_NAME,
                delegate()
                {
                    return mCard.Address3.ContactName;
                },
                delegate(object value)
                {
                    mCard.Address3.ContactName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_CONTACT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_CONTACT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Phone1
            AddProperty(ADDRESS3_PHONE1,
                ADDRESS3_PHONE1,
                delegate()
                {
                    return mCard.Address3.Phone1;
                },
                delegate(object value)
                {
                    mCard.Address3.Phone1 = (string)value;
                },
                delegate()
                {
                    return  CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_PHONE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_PHONE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Phone2
            AddProperty(ADDRESS3_PHONE2,
                ADDRESS3_PHONE2,
                delegate()
                {
                    return mCard.Address3.Phone2;
                },
                delegate(object value)
                {
                    mCard.Address3.Phone2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_PHONE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_PHONE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Phone3
            AddProperty(ADDRESS3_PHONE3,
                ADDRESS3_PHONE3,
                delegate()
                {
                    return mCard.Address3.Phone3;
                },
                delegate(object value)
                {
                    mCard.Address3.Phone3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_PHONE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_PHONE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.State
            AddProperty(ADDRESS3_STATE,
                ADDRESS3_STATE,
                delegate()
                {
                    return mCard.Address3.State;
                },
                delegate(object value)
                {
                    mCard.Address3.State = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_STATE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_STATE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Solutation
            AddProperty(ADDRESS3_SOLUTATION,
                ADDRESS3_SOLUTATION,
                delegate()
                {
                    return mCard.Address3.Solutation;
                },
                delegate(object value)
                {
                    mCard.Address3.Solutation = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 15, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_SOLUTATION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_SOLUTATION, "string");
                    }
                    return false;
                });
            #endregion

            #region Address3.Postcode
            AddProperty(ADDRESS3_POSTCODE,
                ADDRESS3_POSTCODE,
                delegate()
                {
                    return mCard.Address3.Postcode;
                },
                delegate(object value)
                {
                    mCard.Address3.Postcode = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 10, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS3_POSTCODE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS3_POSTCODE, "string");
                    }
                    return false;
                });
            #endregion
        }

        private void InitializeAddress4()
        {
            #region Address4.Line1
            AddProperty(ADDRESS4_LINE1,
                ADDRESS4_LINE1,
                delegate()
                {
                    return mCard.Address4.StreetLine1;
                },
                delegate(object value)
                {
                    mCard.Address4.StreetLine1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_LINE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_LINE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Line2
            AddProperty(ADDRESS4_LINE2,
                ADDRESS4_LINE2,
                delegate()
                {
                    return mCard.Address4.StreetLine2;
                },
                delegate(object value)
                {
                    mCard.Address4.StreetLine2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_LINE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_LINE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Line3
            AddProperty(ADDRESS4_LINE3,
                ADDRESS4_LINE3,
                delegate()
                {
                    return mCard.Address4.StreetLine3;
                },
                delegate(object value)
                {
                    mCard.Address4.StreetLine3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_LINE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_LINE3, "string");
                    }
                    return false;
                });
            #endregion 

            #region Address4.Line4
            AddProperty(ADDRESS4_LINE4,
                ADDRESS4_LINE4,
                delegate()
                {
                    return mCard.Address4.StreetLine4;
                },
                delegate(object value)
                {
                    mCard.Address4.StreetLine4 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_LINE4, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_LINE4, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Country
            AddProperty(ADDRESS4_COUNTRY,
                ADDRESS4_COUNTRY,
                delegate()
                {
                    return mCard.Address4.Country;
                },
                delegate(object value)
                {
                    mCard.Address4.Country = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_COUNTRY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_COUNTRY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.City
            AddProperty(ADDRESS4_CITY,
                ADDRESS4_CITY,
                delegate()
                {
                    return mCard.Address4.City;
                },
                delegate(object value)
                {
                    mCard.Address4.City = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_CITY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_CITY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Email
            AddProperty(ADDRESS4_EMAIL,
                ADDRESS4_EMAIL,
                delegate()
                {
                    return mCard.Address4.Email;
                },
                delegate(object value)
                {
                    mCard.Address4.Email = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidEmail(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_EMAIL, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_EMAIL, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Website
            AddProperty(ADDRESS4_WEBSITE,
                ADDRESS4_WEBSITE,
                delegate()
                {
                    return mCard.Address4.Website;
                },
                delegate(object value)
                {
                    mCard.Address4.Website = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidUrl(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_WEBSITE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_WEBSITE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Fax
            AddProperty(ADDRESS4_FAX,
                ADDRESS4_FAX,
                delegate()
                {
                    return mCard.Address4.Fax;
                },
                delegate(object value)
                {
                    mCard.Address4.Fax = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_FAX, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_FAX, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.ContactName
            AddProperty(ADDRESS4_CONTACT_NAME,
                ADDRESS4_CONTACT_NAME,
                delegate()
                {
                    return mCard.Address4.ContactName;
                },
                delegate(object value)
                {
                    mCard.Address4.ContactName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_CONTACT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_CONTACT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Phone1
            AddProperty(ADDRESS4_PHONE1,
                ADDRESS4_PHONE1,
                delegate()
                {
                    return mCard.Address4.Phone1;
                },
                delegate(object value)
                {
                    mCard.Address4.Phone1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_PHONE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_PHONE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Phone2
            AddProperty(ADDRESS4_PHONE2,
                ADDRESS4_PHONE2,
                delegate()
                {
                    return mCard.Address4.Phone2;
                },
                delegate(object value)
                {
                    mCard.Address4.Phone2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_PHONE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_PHONE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Phone3
            AddProperty(ADDRESS4_PHONE3,
                ADDRESS4_PHONE3,
                delegate()
                {
                    return mCard.Address4.Phone3;
                },
                delegate(object value)
                {
                    mCard.Address4.Phone3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_PHONE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_PHONE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.State
            AddProperty(ADDRESS4_STATE,
                ADDRESS4_STATE,
                delegate()
                {
                    return mCard.Address4.State;
                },
                delegate(object value)
                {
                    mCard.Address4.State = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_STATE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_STATE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Solutation
            AddProperty(ADDRESS4_SOLUTATION,
                ADDRESS4_SOLUTATION,
                delegate()
                {
                    return mCard.Address4.Solutation;
                },
                delegate(object value)
                {
                    mCard.Address4.Solutation = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 15, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_SOLUTATION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_SOLUTATION, "string");
                    }
                    return false;
                });
            #endregion

            #region Address4.Postcode
            AddProperty(ADDRESS4_POSTCODE,
                ADDRESS4_POSTCODE,
                delegate()
                {
                    return mCard.Address4.Postcode;
                },
                delegate(object value)
                {
                    mCard.Address4.Postcode = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 10, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS4_POSTCODE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS4_POSTCODE, "string");
                    }
                    return false;
                });
            #endregion
        }

        private void InitializeAddress5()
        {
            #region Address5.Line1
            AddProperty(ADDRESS5_LINE1,
                ADDRESS5_LINE1,
                delegate()
                {
                    return mCard.Address5.StreetLine1;
                },
                delegate(object value)
                {
                    mCard.Address5.StreetLine1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_LINE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_LINE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Line2
            AddProperty(ADDRESS5_LINE2,
                ADDRESS5_LINE2,
                delegate()
                {
                    return mCard.Address5.StreetLine2;
                },
                delegate(object value)
                {
                    mCard.Address5.StreetLine2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_LINE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_LINE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Line3
            AddProperty(ADDRESS5_LINE3,
                ADDRESS5_LINE3,
                delegate()
                {
                    return mCard.Address5.StreetLine3;
                },
                delegate(object value)
                {
                    mCard.Address5.StreetLine3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_LINE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_LINE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Line4
            AddProperty(ADDRESS5_LINE4,
                ADDRESS5_LINE4,
                delegate()
                {
                    return mCard.Address5.StreetLine4;
                },
                delegate(object value)
                {
                    mCard.Address5.StreetLine4 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_LINE4, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_LINE4, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Country
            AddProperty(ADDRESS5_COUNTRY,
                ADDRESS5_COUNTRY,
                delegate()
                {
                    return mCard.Address5.Country;
                },
                delegate(object value)
                {
                    mCard.Address5.Country = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_COUNTRY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_COUNTRY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.City
            AddProperty(ADDRESS5_CITY,
                ADDRESS5_CITY,
                delegate()
                {
                    return mCard.Address5.City;
                },
                delegate(object value)
                {
                    mCard.Address5.City = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_CITY, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_CITY, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Email
            AddProperty(ADDRESS5_EMAIL,
                ADDRESS5_EMAIL,
                delegate()
                {
                    return mCard.Address5.Email;
                },
                delegate(object value)
                {
                    mCard.Address5.Email = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidEmail(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_EMAIL, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_EMAIL, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Website
            AddProperty(ADDRESS5_WEBSITE,
                ADDRESS5_WEBSITE,
                delegate()
                {
                    return mCard.Address5.Website;
                },
                delegate(object value)
                {
                    mCard.Address5.Website = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidUrl(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_WEBSITE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_WEBSITE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Fax
            AddProperty(ADDRESS5_FAX,
                ADDRESS5_FAX,
                delegate()
                {
                    return mCard.Address5.Fax;
                },
                delegate(object value)
                {
                    mCard.Address5.Fax = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_FAX, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_FAX, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.ContactName
            AddProperty(ADDRESS5_CONTACT_NAME,
                ADDRESS5_CONTACT_NAME,
                delegate()
                {
                    return mCard.Address5.ContactName;
                },
                delegate(object value)
                {
                    mCard.Address5.ContactName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_CONTACT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_CONTACT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Phone1
            AddProperty(ADDRESS5_PHONE1,
                ADDRESS5_PHONE1,
                delegate()
                {
                    return mCard.Address5.Phone1;
                },
                delegate(object value)
                {
                    mCard.Address5.Phone1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_PHONE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_PHONE1, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Phone2
            AddProperty(ADDRESS5_PHONE2,
                ADDRESS5_PHONE2,
                delegate()
                {
                    return mCard.Address5.Phone2;
                },
                delegate(object value)
                {
                    mCard.Address5.Phone2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_PHONE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_PHONE2, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Phone3
            AddProperty(ADDRESS5_PHONE3,
                ADDRESS5_PHONE3,
                delegate()
                {
                    return mCard.Address5.Phone3;
                },
                delegate(object value)
                {
                    mCard.Address5.Phone3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 21, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_PHONE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_PHONE3, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.State
            AddProperty(ADDRESS5_STATE,
                ADDRESS5_STATE,
                delegate()
                {
                    return mCard.Address5.State;
                },
                delegate(object value)
                {
                    mCard.Address5.State = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 256, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_STATE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_STATE, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Solutation
            AddProperty(ADDRESS5_SOLUTATION,
                ADDRESS5_SOLUTATION,
                delegate()
                {
                    return mCard.Address5.Solutation;
                },
                delegate(object value)
                {
                    mCard.Address5.Solutation = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 15, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_SOLUTATION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_SOLUTATION, "string");
                    }
                    return false;
                });
            #endregion

            #region Address5.Postcode
            AddProperty(ADDRESS5_POSTCODE,
                ADDRESS5_POSTCODE,
                delegate()
                {
                    return mCard.Address5.Postcode;
                },
                delegate(object value)
                {
                    mCard.Address5.Postcode = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsValidPhoneNumber(value as string, 0, 10, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ADDRESS5_POSTCODE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ADDRESS5_POSTCODE, "string");
                    }
                    return false;
                });
            #endregion
        }
        

        public object DataGridView_ContactLog(DateTime start_time, DateTime end_time)
        {
            return mAccountant.ContactLogMgr.Table(this.mCard, start_time, end_time);
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mCard.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mCard.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return false;
                }
                return mCard.AllowDelete;
            }
        }
    }
}
