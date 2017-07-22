using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyntechRpt
{
    public class LightItem
    {
        public enum ItemGender
        {
            Male,
            Female
        }

        public enum ItemSize
        {
            XL,
            L,
            M,
            S,
        }

        public string ItemNumber="";
        public string ItemName = "";
        public int RecordIndex;
        public string Brand="";
        public string SerialNumber="";
        public string BatchNumber="";
        public DateTime ExpiryDate=DateTime.MinValue;
        public ItemSize Size=ItemSize.M;
        public string Color;
        public ItemGender Gender=ItemGender.Male;
    }
}
