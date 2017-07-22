using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Report.Inventory.Items
{
    using Accounting.Core.Misc;
    using Accounting.Core.Inventory;
    using Accounting.Bll;
    using System.Data;
    using System.IO;

    public class ItemsRegisterSummaryRpt : ReportTemplate
    {

        public ItemsRegisterSummaryRpt(Accountant acc)
            : base(acc)
        {
            
        }

        protected override Doddle.Reporting.Report BuildReport()
        {
            Doddle.Reporting.Report report = CreateReport("Items Register Summary");
            report.Source = new Doddle.Reporting.DataTableReportSource(BuildTable());

            return report;
        }

        public bool DisplayItemNumber { get; set; }
        public bool DisplayItemName { get; set; }
        public bool DisplayBatchNumber { get; set; }
        public bool DisplaySerialNumber { get; set; }
        public bool DisplayExpiryDate { get; set; }
        public bool DisplayBrand { get; set; }
        public bool DisplayColor { get; set; }
        public bool DisplayGender { get; set; }
        public bool DisplaySize { get; set; }
        public bool DisplayTotalValue { get; set; }
        public bool DisplayUnitsOnHand { get; set; }
        public bool DisplayItemDescription { get; set; }

        public enum FieldName
        {
            ItemNumber,
            ItemName,
            BatchNumber,
            SerialNumber,
            ExpiryDate,
            Brand,
            Color,
            Gender,
            Size,
            ItemDescription,
            UnitsOnHand,
            TotalValue
        }

        public Dictionary<FieldName, int> FieldOrder = new Dictionary<FieldName, int>();

        public bool ItemIsSold { set; get; }
        public bool ItemIsBought { set; get; }
        public bool ItemIsInventoried { get; set; }
        public string ItemFieldName { get; set; }
        public string ItemKeywords { get; set; }

        private DataTable BuildTable()
        {
            Dictionary<string, string> searchCriteria = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(ItemKeywords) && !string.IsNullOrEmpty(ItemFieldName))
            {
                searchCriteria[ItemFieldName] = ItemKeywords;
            }

            IList<Item> items = mAccountant.ItemMgr.FindFilteredCollection(ItemIsSold, ItemIsBought, ItemIsInventoried, searchCriteria);
            DataTable table = new DataTable();

            List<FieldName> names = new List<FieldName>();
            foreach(FieldName fn in FieldOrder.Keys)
            {
                names.Add(fn);
            }
            for (int i = 0; i < names.Count - 1; ++i)
            {
                for (int j = i + 1; j < names.Count; ++j)
                {
                    if (FieldOrder[names[i]] > FieldOrder[names[j]])
                    {
                        FieldName temp = names[i];
                        names[i] = names[j];
                        names[j] = temp;
                    }
                }
            }

            for(int i=0; i < names.Count; ++i)
            {
                FieldName fn = names[i];
                if (fn==FieldName.ItemNumber && DisplayItemNumber)
                {
                    table.Columns.Add("Item #");
                }
                else if (fn==FieldName.ItemName && DisplayItemName)
                {
                    table.Columns.Add("Name");
                }
                else if (fn==FieldName.BatchNumber && DisplayBatchNumber)
                {
                    table.Columns.Add("Batch #");
                }
                else if (fn==FieldName.SerialNumber && DisplaySerialNumber)
                {
                    table.Columns.Add("Serial #");
                }
                else if (fn==FieldName.ExpiryDate && DisplayExpiryDate)
                {
                    table.Columns.Add("Expiry Date");
                }
                else if (fn==FieldName.Brand && DisplayBrand)
                {
                    table.Columns.Add("Brand");
                }
                else if (fn==FieldName.Color && DisplayColor)
                {
                    table.Columns.Add("Color");
                }
                else if (fn==FieldName.Gender && DisplayGender)
                {
                    table.Columns.Add("Gender");
                }
                else if (fn==FieldName.Size && DisplaySize)
                {
                    table.Columns.Add("Size");
                }

               
                else if (fn == FieldName.TotalValue && DisplayTotalValue)
                {
                    table.Columns.Add("Current Value");
                }
                else if (fn == FieldName.UnitsOnHand && DisplayUnitsOnHand)
                {
                    table.Columns.Add("On Hand");
                }
              
                else if (fn == FieldName.ItemDescription && DisplayItemDescription)
                {
                    table.Columns.Add("Item Description");
                }
              
            }

            DataRow row=null;
            foreach (Item item in items)
            {
                row = table.NewRow();

                for (int i = 0; i < names.Count; ++i)
                {
                    FieldName fn = names[i];
                    if (fn==FieldName.ItemNumber && DisplayItemNumber)
                    {
                        row["Item #"] = item.ItemNumber;
                    }
                    if (fn==FieldName.ItemName && DisplayItemName)
                    {
                        row["Name"] = item.ItemName;
                    }
                    if (fn==FieldName.BatchNumber && DisplayBatchNumber)
                    {
                        row["Batch #"] = item.ItemAddOn.BatchNumber;
                    }
                    if (fn==FieldName.SerialNumber && DisplaySerialNumber)
                    {
                        row["Serial #"] = item.ItemAddOn.SerialNumber;
                    }
                    if (fn==FieldName.ExpiryDate && DisplayExpiryDate)
                    {
                        if (item.ItemAddOn.ExpiryDate != null)
                        {
                            row["Expiry Date"] = item.ItemAddOn.ExpiryDate.Value.ToString("yyyy-MMM-dd");
                        }
                        else
                        {
                            row["Expiry Date"] = "";
                        }

                    }
                    if (fn==FieldName.Brand && DisplayBrand)
                    {
                        row["Brand"] = item.ItemAddOn.Brand;
                    }
                    if (fn==FieldName.Color && DisplayColor)
                    {
                        row["Color"] = item.ItemAddOn.Color;
                    }
                    if (fn==FieldName.Gender && DisplayGender)
                    {
                        row["Gender"] = item.ItemAddOn.Gender;
                    }
                    if (fn==FieldName.Size && DisplaySize)
                    {
                        row["Size"] = item.ItemAddOn.ItemSize;
                    }

                
                    if (fn==FieldName.TotalValue && DisplayTotalValue)
                    {
                        row["Current Value"] = mAccountant.CurrencyMgr.Format(item.ValueOnHand);
                    }

                    if (fn==FieldName.UnitsOnHand && DisplayUnitsOnHand)
                    {
                        row["On Hand"] = item.QuantityOnHand.ToString();
                    }

                    
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
