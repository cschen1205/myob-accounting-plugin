using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using Accounting.Db;

namespace Accounting.Core.Cryptography
{
    public class CryptorManager
    {
        private static volatile CryptorManager m_instance = null;
        private static object m_locker = new object();
        private string mDbCryptorKey = "1#1%2Kj2";

        private Dictionary<string, Cryptor> mCryptors = new Dictionary<string, Cryptor>();

        public static CryptorManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_locker)
                    {
                        if (m_instance == null)
                        {
                            m_instance = new CryptorManager();
                        }
                    }
                }
                return m_instance;
            }
        }

        private CryptorManager()
        {
            mCryptors["DES"] = new CryptorDES();
        }

        private string GenKey()
        {
            return CryptorUtil.Generate();
        }

        private Cryptor getCryptor(String id)
        {
            if (mCryptors.ContainsKey(id))
            {
                return mCryptors[id];
            }
            return null;
        }

        private Cryptor getCryptor()
        {
            return getCryptor("DES");
        }

        public string encrypt(string original_text)
        {
            if (original_text.CompareTo("") == 0) return "";
            return getCryptor().encrypt(original_text, mDbCryptorKey);
        }

        public string decrypt(string crypted_text)
        {
            if (crypted_text.CompareTo("") == 0) return "";
            return getCryptor().decrypt(crypted_text, mDbCryptorKey);
        }

    }

}
