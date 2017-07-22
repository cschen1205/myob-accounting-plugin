using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SwissArmyKnife.IO
{
    public class FileUtil
    {
        public static byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

        public static string GetFilename(string filepath)
        {
            return System.IO.Path.GetFileName(filepath);
        }

        
    }
}
