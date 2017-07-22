using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Accounting.Report.Customized.Purchases
{
    using Accounting.Core.Misc;
    using Accounting.Core.Inventory;
    using Accounting.Bll;
    using System.Data;

    public class ItemRpt : ReportTemplate
    {

        public int YearFrom { get; set; }
        public int YearTo { get; set; }

        public ItemRpt(Accountant acc)
            : base(acc)
        {

        }
      
        

        protected override Doddle.Reporting.Report BuildReport()
        {
            Doddle.Reporting.Report report = CreateReport("Analyse Purchases [Item]");

            string subtitle = report.TextFields.SubTitle;
            if (YearFrom == YearTo)
            {
                if (!string.IsNullOrEmpty(subtitle))
                {
                    subtitle += string.Format("\r\n{0}", YearFrom);
                }
                else
                {
                    subtitle += string.Format("{0}", YearFrom);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(subtitle))
                {
                    subtitle += string.Format("\r\n{0} - {1}", YearFrom, YearTo);
                }
                else
                {
                    subtitle += string.Format("{0} - {1}", YearFrom, YearTo);
                }
            }

            report.TextFields.SubTitle = subtitle;

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
        public bool DisplayPurchaseAmount { get; set; }
        public bool DisplayCostOfPurchasesAmount { get; set; }
        public bool DisplayGrossProfit { get; set; }
        public bool DisplayProfitMargin { get; set; }
        public bool DisplayUnitsSold { get; set; }
        public bool DisplayAverageCost { get; set; }

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
            PurchaseAmount,
            CostOfPurchasesAmount,
            GrossProfit,
            ProfitMargin,
            UnitsSold,
            AverageCost
        }

        public Dictionary<FieldName, int> FieldOrder = new Dictionary<FieldName, int>();

        private DataTable BuildTable()
        {
            IList<Item> items = mAccountant.ItemMgr.FindAllCollection();
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

                else if (fn==FieldName.PurchaseAmount && DisplayPurchaseAmount)
                {
                    table.Columns.Add("Purchases");

                }
                else if (fn==FieldName.CostOfPurchasesAmount && DisplayCostOfPurchasesAmount)
                {
                    table.Columns.Add("Cost of Purchases");
                }
                else if (fn==FieldName.GrossProfit && DisplayGrossProfit)
                {
                    table.Columns.Add("Gross Profit");
                }
                else if (fn==FieldName.ProfitMargin && DisplayProfitMargin)
                {
                    table.Columns.Add("%Margin");
                }
                else if (fn==FieldName.UnitsSold && DisplayUnitsSold)
                {
                    table.Columns.Add("Units Sold");
                }
                else if (fn==FieldName.AverageCost && DisplayAverageCost)
                {
                    table.Columns.Add("Average Cost");
                }
            }

            

            double TotalPurchaseAmount = 0;
            double TotalCostOfPurchasesAmount = 0;
            double TotalGrossProfit = 0;
            double TotalProfitMargin = 0;
            DataRow row=null;
            foreach (Item item in items)
            {
                row = table.NewRow();

                double PurchaseAmount=0;
                double ProfitMargin=0;
                double GrossProfit=0;
                double CostOfPurchasesAmount=0;

                List<ItemPurchasesHistory> itemPurchasesHistories = mAccountant.ItemPurchasesHistoryMgr.List(item.ItemID, YearFrom, YearTo);
                PurchaseAmount = 0;
                if (DisplayPurchaseAmount || DisplayGrossProfit)
                {
                    foreach (ItemPurchasesHistory history in itemPurchasesHistories)
                    {
                        PurchaseAmount += history.PurchaseAmount;
                    }
                }

                CostOfPurchasesAmount = 0;
                if (DisplayCostOfPurchasesAmount || DisplayGrossProfit)
                {
                    foreach (ItemPurchasesHistory history in itemPurchasesHistories)
                    {
                        CostOfPurchasesAmount += history.PurchaseAmount;
                    }
                }

                GrossProfit = PurchaseAmount - CostOfPurchasesAmount;

                ProfitMargin = 0;
                if (PurchaseAmount != 0) ProfitMargin = GrossProfit * 100 / PurchaseAmount;

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

                    

                    if (fn==FieldName.PurchaseAmount && DisplayPurchaseAmount)
                    {
                        row["Purchases"] = mAccountant.CurrencyMgr.Format(PurchaseAmount);
                    }

                 

                    if (fn == FieldName.CostOfPurchasesAmount && DisplayCostOfPurchasesAmount)
                    {
                        row["Cost of Purchases"] = mAccountant.CurrencyMgr.Format(CostOfPurchasesAmount);
                    }

                    
                    if (fn==FieldName.GrossProfit && DisplayGrossProfit)
                    {
                        row["Gross Profit"] = mAccountant.CurrencyMgr.Format(GrossProfit);
                    }

                    
                    if (fn==FieldName.ProfitMargin && DisplayProfitMargin)
                    {
                        row["%Margin"] = mAccountant.CurrencyMgr.FormatPercent(ProfitMargin);
                    }

                    if (fn==FieldName.UnitsSold && DisplayUnitsSold)
                    {
                        double UnitsSold = 0;
                        foreach (ItemPurchasesHistory history in itemPurchasesHistories)
                        {
                            UnitsSold += history.UnitsBought;
                        }
                        row["Units Sold"] = UnitsSold;
                    }
                    if (fn==FieldName.AverageCost && DisplayAverageCost)
                    {
                        row["Average Cost"] = mAccountant.CurrencyMgr.Format(item.PositiveAverageCost);
                    }
                }

                TotalPurchaseAmount += PurchaseAmount;
                TotalProfitMargin += ProfitMargin;
                TotalGrossProfit += GrossProfit;
                TotalCostOfPurchasesAmount += CostOfPurchasesAmount;

                table.Rows.Add(row);
            }

            int itemCount = items.Count;
            row = table.NewRow();
            if (DisplayPurchaseAmount)
            {
                 row["Purchases"]=mAccountant.CurrencyMgr.Format(TotalPurchaseAmount / itemCount);
            }
            if (DisplayCostOfPurchasesAmount)
            {
                row["Cost of Purchases"] = mAccountant.CurrencyMgr.Format(TotalCostOfPurchasesAmount / itemCount);
            }
            if (DisplayProfitMargin)
            {
                row["%Margin"] = mAccountant.CurrencyMgr.FormatPercent(TotalProfitMargin / itemCount);
            }
            if (DisplayGrossProfit)
            {
                row["Gross Profit"] = mAccountant.CurrencyMgr.Format(TotalGrossProfit / itemCount);
            }
            table.Rows.Add(row);

            return table;
        }

        
    }
}
