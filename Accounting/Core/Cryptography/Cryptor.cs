using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Cryptography
{
    public abstract class Cryptor
    {
        public abstract string encrypt(string raw, string key);
        public abstract string decrypt(string encrypted, string key);
        public uint getMinKeyLength()
        {
            return 8;
        }
        uint getMaxKeyLength()
        {
            return 8;
        }
    }
}
