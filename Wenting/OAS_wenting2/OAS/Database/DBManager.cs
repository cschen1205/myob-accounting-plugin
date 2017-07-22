using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OAS.Database
{
    public class DBManager
    {
        private string mConnStr;
        private static DBManager mInstance;
        private static object mLockObject = new object();
        private string mHostName;
        private string mDatabaseName;
        private string mUsername;
        private string mPassword;
        private string mConfigPath;
        private bool mLocalhost;
        private OASDB mOASDB;

        private DBManager()
        {
            mConfigPath = "";
            mOASDB = new OASDB(this);
        }

        public void DeleteTable(string tableName)
        {
            string query = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='"+tableName+"') DROP TABLE "+tableName;
            ExecuteNonQuery(query);
        }

        public void GetTables(List<string> tables)
        {
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
            using (SqlConnection conn = new SqlConnection(mConnStr))
            {
                conn.Open();
                using (SqlCommand cmm = new SqlCommand(query, conn))
                {
                    SqlDataReader dr=cmm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tables.Add((string)dr["TABLE_NAME"]);
                        }
                    }
                    dr.Close();
                }
            }
        }

        public void GetColumnInfo(Dictionary<string, string> columns, string tableName)
        {
            string query = "select column_name, data_type from information_schema.columns where table_name = '" + tableName + "' order by ordinal_position";

            using (SqlConnection conn = new SqlConnection(mConnStr))
            {
                conn.Open();
                using (SqlCommand cmm = new SqlCommand(query, conn))
                {
                    SqlDataReader dr = cmm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            columns.Add((string)dr["column_name"], (string)dr["data_type"]);
                        }
                    }
                    dr.Close();
                }
            }
        }

        public void CreateTable(string tableName, Dictionary<string, string> itemPairs, string primaryKey, Dictionary<string, string> foreignKeys)
        {
            DeleteTable(tableName);
            
            string query="CREATE TABLE "+tableName+" (";

            foreach(string key in itemPairs.Keys)
            {
                if (key == primaryKey)
                {
                    query += key + " " + itemPairs[key] + " PRIMARY KEY, ";
                }
                else
                {
                    if (foreignKeys.ContainsKey(key))
                    {
                        query += key + " " + itemPairs[key] + " REFERENCES "+foreignKeys[key]+", ";
                    }
                    else
                    {
                        query += key + " " + itemPairs[key] + ", ";
                    }
                }
            }
            query = query.Substring(0, query.Length - 2);
            query += ");";

            ExecuteNonQuery(query);
        }

        public enum FIELDTYPE
        {
            INTEGER_AUTOINC,
            VARCHAR_1,
            VARCHAR_2,
            VARCHAR_3,
            VARCHAR_4,
            VARCHAR_5,
            VARCHAR_6,
            VARCHAR_8,
            VARCHAR_10,
            VARCHAR_11,
            VARCHAR_13,
            VARCHAR_15,
            VARCHAR_16,
            VARCHAR_19,
            VARCHAR_20,
            VARCHAR_21,
            VARCHAR_25,
            VARCHAR_26,
            VARCHAR_30,
            VARCHAR_32,
            VARCHAR_34,
            VARCHAR_40,
            VARCHAR_50,
            VARCHAR_52,
            VARCHAR_255,
            VARCHAR_256,
            VARCHAR,
            DATETIME,
            INTEGER,
            DOUBLE
        };

        public string this[FIELDTYPE index]
        {
            get
            {
                switch(index)
                {
                    case FIELDTYPE.INTEGER_AUTOINC:
                        return "INTEGER NOT NULL IDENTITY(1,1)";
                    case FIELDTYPE.VARCHAR:
                        return "VARCHAR";
                    case FIELDTYPE.VARCHAR_1:
                        return "VARCHAR(1)";
                    case FIELDTYPE.VARCHAR_2:
                        return "VARCHAR(2)";
                    case FIELDTYPE.VARCHAR_3:
                        return "VARCHAR(3)";
                    case FIELDTYPE.VARCHAR_4:
                        return "VARCHAR(4)";
                    case FIELDTYPE.VARCHAR_5:
                        return "VARCHAR(5)";
                    case FIELDTYPE.VARCHAR_6:
                        return "VARCHAR(6)";
                    case FIELDTYPE.VARCHAR_8:
                        return "VARCHAR(8)";
                    case FIELDTYPE.VARCHAR_10:
                        return "VARCHAR(10)";
                    case FIELDTYPE.VARCHAR_11:
                        return "VARCHAR(11)";
                    case FIELDTYPE.VARCHAR_13:
                        return "VARCHAR(13)";
                    case FIELDTYPE.VARCHAR_15:
                        return "VARCHAR(15)";
                    case FIELDTYPE.VARCHAR_16:
                        return "VARCHAR(16)";
                    case FIELDTYPE.VARCHAR_19:
                        return "VARCHAR(19)";
                    case FIELDTYPE.VARCHAR_20:
                        return "VARCHAR(20)";
                    case FIELDTYPE.VARCHAR_21:
                        return "VARCHAR(21)";
                    case FIELDTYPE.VARCHAR_25:
                        return "VARCHAR(25)";
                    case FIELDTYPE.VARCHAR_26:
                        return "VARCHAR(26)";
                    case FIELDTYPE.VARCHAR_30:
                        return "VARCHAR(30)";
                    case FIELDTYPE.VARCHAR_32:
                        return "VARCHAR(32)";
                    case FIELDTYPE.VARCHAR_34:
                        return "VARCHAR(34)";
                    case FIELDTYPE.VARCHAR_40:
                        return "VARCHAR(40)";
                    case FIELDTYPE.VARCHAR_50:
                        return "VARCHAR(50)";
                    case FIELDTYPE.VARCHAR_52:
                        return "VARCHAR(52)";
                    case FIELDTYPE.VARCHAR_255:
                        return "VARCHAR(255)";
                    case FIELDTYPE.VARCHAR_256:
                        return "VARCHAR(256)";
                    case FIELDTYPE.DATETIME:
                        return "DATETIME";
                    case FIELDTYPE.INTEGER:
                        return "INTEGER";
                    case FIELDTYPE.DOUBLE:
                        return "DOUBLE PRECISION";
                    default:
                        return "VARCHAR(255)";
                }
                
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(mConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Initialize(string xmlFile)
        {
            mConfigPath = xmlFile;


            if (LoadConfig())
            {
                CreateConnectionString();
            }
        }

        public OASDB OASDB
        {
            get
            {
                return mOASDB;
            }
        }

        public string ConnectionString
        {
            get
            {
                return mConnStr;
            }
        }

        public bool Setup(string host, string database, string username, string password, bool localhost)
        {
            mHostName = host;
            mDatabaseName = database;
            mUsername = username;
            mPassword = password;
            mLocalhost = localhost;

            CreateConnectionString();
            SaveConfig();

            mOASDB.Setup();

            return true;
        }

        private void CreateConnectionString()
        {
            if (mLocalhost)
            {
                mConnStr = "Data Source=" + mHostName + ";Initial Catalog=" + mDatabaseName + ";Integrated Security=True";
            }
            else
            {
                mConnStr = "Data Source=" + mHostName + ";Initial Catalog=" + mDatabaseName + ";User Id=" + mUsername + ";Password=" + mPassword + ";";
            }
        }

        private void SaveConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode decl = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmlDoc.AppendChild(decl);

            XmlElement xmlRoot = xmlDoc.CreateElement("", "config", "");
            xmlDoc.AppendChild(xmlRoot);

            XmlAttribute xmlHost = xmlDoc.CreateAttribute("host");
            xmlHost.Value = mHostName;
            xmlRoot.Attributes.Append(xmlHost);

            XmlAttribute xmlDatabase = xmlDoc.CreateAttribute("database");
            xmlDatabase.Value = mDatabaseName;
            xmlRoot.Attributes.Append(xmlDatabase);

            XmlAttribute xmlUsername = xmlDoc.CreateAttribute("username");
            xmlUsername.Value = mUsername;
            xmlRoot.Attributes.Append(xmlUsername);

            XmlAttribute xmlPassword = xmlDoc.CreateAttribute("password");
            xmlPassword.Value = mPassword;
            xmlRoot.Attributes.Append(xmlPassword);

            XmlAttribute xmlLocalhost = xmlDoc.CreateAttribute("localhost");
            if (mLocalhost)
            {
                xmlLocalhost.Value = "true";
            }
            else
            {
                xmlLocalhost.Value = "false";
            }
            xmlRoot.Attributes.Append(xmlLocalhost);

            xmlDoc.Save(mConfigPath);
        }

        private bool LoadConfig()
        {
            if (File.Exists(mConfigPath))
            {
                FileStream fs = new FileStream(mConfigPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fs);

                XmlElement xmlRoot = xmldoc.DocumentElement;
                foreach (XmlAttribute attribute in xmlRoot.Attributes)
                {
                    if (attribute.Name == "host")
                    {
                        mHostName = attribute.Value;
                    }
                    else if (attribute.Name == "database")
                    {
                        mDatabaseName = attribute.Value;
                    }
                    else if (attribute.Name == "username")
                    {
                        mUsername = attribute.Value;
                    }
                    else if (attribute.Name == "password")
                    {
                        mPassword = attribute.Value;
                    }
                    else if (attribute.Name == "localhost")
                    {
                        if (attribute.Value == "true")
                        {
                            mLocalhost = true;
                        }
                        else
                        {
                            mLocalhost = false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public static DBManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLockObject)
                    {
                        if (mInstance == null)
                        {
                            mInstance = new DBManager();
                        }
                    }
                }

                return mInstance;
            }
        }
    }
}
