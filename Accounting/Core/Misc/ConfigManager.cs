using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.Common;
using Accounting.Db;
using Accounting.Core.Cryptography;
using Accounting.Core.Enumeration;
using Accounting.Util;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public class ConfigManager : EntityManager<Config>
    {
        public ConfigManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override Config _CreateDbEntity()
        {
            return new Config(true, this);
        }

        protected override Config _CreateEntity()
        {
            return new Config(false, this);
        }

        public Month.LongEnum PL_Filtered_Month
        {
            get 
            {
                string param_value=GetParamValue("PL_Filtered_Month");
                if (param_value.Equals(""))
                {
                    return Month.LongEnum.July;
                }
                else
                {
                    return Month.String2LongEnum(param_value);
                }
            }
            set
            {
                SetParam("PL_Filtered_Month", value.ToString());
            }
        }

        private string mPrefix="";
        public string Prefix
        {
            get { return mPrefix; }
            set { mPrefix = value; }
        }

        public void SetParam(string name, string value)
        {
            CryptorManager cm = CryptorManager.Instance;

            string dbparamname = string.Format("{0}_{1}", Prefix, name);
            string ConfigName = cm.encrypt(dbparamname);
            string ConfigValue = cm.encrypt(value);

            Config _obj = null;
            if (ParamExists(name))
            {
                _obj = FindByConfigName(ConfigName);
                _obj.ConfigValue = ConfigValue;
            }
            else
            {
                _obj = CreateEntity();
                _obj.ConfigName = ConfigName;
                _obj.ConfigValue = ConfigValue;
            }

            Store(_obj);
        }

        public bool ParamExists(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;

            CryptorManager cm = CryptorManager.Instance;

            string dbparamname = string.Format("{0}_{1}", Prefix, name);
            string ConfigName = cm.encrypt(dbparamname);

            return Exists(ConfigName);
        }

        public bool Exists(string ConfigName)
        {
            if (string.IsNullOrEmpty(ConfigName)) return false;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Configs")
                .Criteria
                    .IsEqual("Configs", "ConfigName", ConfigName);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public Config FindByParamName(string name)
        {
            string dbparamname = string.Format("{0}_{1}", Prefix, name);
            CryptorManager cm = CryptorManager.Instance;
            string ConfigName = cm.encrypt(dbparamname);

            return FindByConfigName(ConfigName);
        }

        public Config FindByConfigName(string ConfigName)
        {
            Config _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Configs")
                .Criteria
                    .IsEqual("Configs", "ConfigName", ConfigName);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        public override bool Exists(Config _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ConfigName);
        }

        protected override void LoadFromReader(Config _obj, DbDataReader reader)
        {
            _obj.ConfigID = GetInt32(reader, "ConfigID");
            _obj.ConfigName = GetString(reader, "ConfigName");
            _obj.ConfigValue = GetString(reader, "ConfigValue");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Config _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ConfigID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ConfigID);
            fields["ConfigName"] = DbMgr.CreateStringFieldEntry(_obj.ConfigName);
            fields["ConfigValue"] = DbMgr.CreateStringFieldEntry(_obj.ConfigValue);

            return fields;
        }

        public string GetParamValue(string name)
        {
            if (ParamExists(name))
            {
                Config _obj=FindByParamName(name);
                CryptorManager cm = CryptorManager.Instance;
                return cm.decrypt(_obj.ConfigValue);
            }
            else
            {
                return "";
            }
        }

        protected override IList<Config>_FindAllCollection()
        {
            List<Config> _grp = new List<Config>();

             DbSelectStatement clause = DbMgr.CreateSelectClause();
             clause
                 .SelectAll()
                 .From("Configs");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Config _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
        
    }
}
