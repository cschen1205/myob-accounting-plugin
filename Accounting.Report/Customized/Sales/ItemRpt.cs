using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Accounting.Core.Misc;
using Accounting.Core.Inventory;
using Accounting.Bll;
using System.Data;

namespace Accounting.Report.Customized.Sales
{
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
            Doddle.Reporting.Report report = CreateReport("Analyse Sales [Item]");

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
        public bool DisplaySaleAmount { get; set; }
        public bool DisplayCostOfSalesAmount { get; set; }
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
            SaleAmount,
            CostOfSalesAmount,
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

                else if (fn==FieldName.SaleAmount && DisplaySaleAmount)
                {
                    table.Columns.Add("Sales");

                }
                else if (fn==FieldName.CostOfSalesAmount && DisplayCostOfSalesAmount)
                {
                    table.Columns.Add("Cost of Sales");
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

            

            double TotalSaleAmount = 0;
            double TotalCostOfSalesAmount = 0;
            double TotalGrossProfit = 0;
            double TotalProfitMargin = 0;
            DataRow row=null;
            foreach (Item item in items)
            {
                row = table.NewRow();

                double SaleAmount=0;
                double ProfitMargin=0;
                double GrossProfit=0;
                double CostOfSalesAmount=0;

                List<ItemSalesHistory> itemSalesHistories = mAccountant.ItemSalesHistoryMgr.List(item.ItemID, YearFrom, YearTo);
                SaleAmount = 0;
                if (DisplaySaleAmount || DisplayGrossProfit)
                {
                    foreach (ItemSalesHistory history in itemSalesHistories)
                    {
                        SaleAmount += history.SaleAmount;
                    }
                }

                CostOfSalesAmount = 0;
                if (DisplayCostOfSalesAmount || DisplayGrossProfit)
                {
                    foreach (ItemSalesHistory history in itemSalesHistories)
                    {
                        CostOfSalesAmount += history.CostOfSalesAmount;
                    }
                }

                GrossProfit = SaleAmount - CostOfSalesAmount;

                ProfitMargin = 0;
                if (SaleAmount != 0) ProfitMargin = GrossProfit * 100 / SaleAmount;

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

                    

                    if (fn==FieldName.SaleAmount && DisplaySaleAmount)
                    {
                        row["Sales"] = mAccountant.CurrencyMgr.Format(SaleAmount);
                    }

                 

                    if (fn == FieldName.CostOfSalesAmount && DisplayCostOfSalesAmount)
                    {
                        row["Cost of Sales"] = mAccountant.CurrencyMgr.Format(CostOfSalesAmount);
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
                        foreach (ItemSalesHistory history in itemSalesHistories)
                        {
                            UnitsSold += history.UnitsSold;
                        }
                        row["Units Sold"] = UnitsSold;
                    }
                    if (fn==FieldName.AverageCost && DisplayAverageCost)
                    {
                        row["Average Cost"] = mAccountant.CurrencyMgr.Format(item.PositiveAverageCost);
                    }
                }

                TotalSaleAmount += SaleAmount;
                TotalProfitMargin += ProfitMargin;
                TotalGrossProfit += GrossProfit;
                TotalCostOfSalesAmount += CostOfSalesAmount;

                table.Rows.Add(row);
            }

            int itemCount = items.Count;
            row = table.NewRow();
            if (DisplaySaleAmount)
            {
                 row["Sales"]=mAccountant.CurrencyMgr.Format(TotalSaleAmount / itemCount);
            }
            if (DisplayCostOfSalesAmount)
            {
                row["Cost of Sales"] = mAccountant.CurrencyMgr.Format(TotalCostOfSalesAmount / itemCount);
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
