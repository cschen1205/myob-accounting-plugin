using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using Accounting.Db;
using Accounting.Db.Myob;
using Accounting.Core.Inventory;
using Accounting.Core.Sales;
using Accounting.Bll;

namespace SyntechRpt.WinForms
{
    public partial class FrmReportItems : Form
    {
        private static object missing = Type.Missing;
        public FrmReportItems()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            dlgSave.Filter = "Excel Files (*.xlsx)|*.xlsx|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                string filename = dlgSave.FileName;

                Excel.Application app =new Excel.Application();
                app.Visible = false;
                app.DisplayAlerts = false;

                Excel.Workbooks wbs=app.Workbooks as Excel.Workbooks;
                Excel.Workbook wb=wbs.Add(1);
                
                Excel.Worksheet ws=wb.Worksheets[1] as Excel.Worksheet;

                PopulateData(ws);

                SaveWorkBook(wb, filename);
                wb.Close(missing, missing, missing);

                app.DisplayAlerts = true;
                app.Quit();
            }
        }

        private void SaveWorkBook(Excel.Workbook wb, string filename)
        {
            string extension = System.IO.Path.GetExtension(filename);
            if (extension.Equals(".xlsx"))
            {
                wb.SaveAs(filename, missing,
                missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlShared,
                Excel.XlSaveConflictResolution.xlLocalSessionChanges, missing, missing, missing, missing);
            }
            else if (extension.Equals(".pdf"))
            {
                string paramExportFilePath = filename;
                Excel.XlFixedFormatType paramExportFormat = Excel.XlFixedFormatType.xlTypePDF;
                Excel.XlFixedFormatQuality paramExportQuality =
                    Excel.XlFixedFormatQuality.xlQualityStandard;
                bool paramOpenAfterPublish = false;
                bool paramIncludeDocProps = true;
                bool paramIgnorePrintAreas = true;
                object paramFromPage = Type.Missing;
                object paramToPage = Type.Missing;
                // Save it in the target format.
                wb.ExportAsFixedFormat(paramExportFormat,
                        paramExportFilePath, paramExportQuality,
                        paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage,
                        paramToPage, paramOpenAfterPublish,
                        missing);
            }
        }

        private void PopulateData(Excel.Worksheet ws)
        {
            Sheet1 sh1 = Globals.Sheet1;
            Sheet2 sh2 = Globals.Sheet2;

            int year_from=int.Parse(txtFromYear.Text);
            int year_to=int.Parse(txtToYear.Text);

            int SaleAmountColIndex = 0;
            int CostOfSalesAmountColIndex = 0;
            int GrossProfitColIndex = 0;
            int ProfitMarginColIndex = 0;
            double TotalSaleAmount = 0;
            double TotalCostOfSalesAmount = 0;
            double TotalGrossProfit = 0;
            double TotalProfitMargin = 0;

            bool oldSh2Locked = sh2.Locked;
            sh2.Locked = false;

            Excel.Range cell = null;

            Accountant _obj = AccountantPool.Instance.CurrentAccountant;
            
            IList<Item> items = _obj.ItemMgr.List();

            int columnIndex = 1;
            int rowOffset = 7;

            if (chkItemNumber.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Item #";
                cell.Font.Bold = true;
            }
            if (chkItemName.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Name";
                cell.Font.Bold = true;
            }
            if (chkBatchNumber.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Batch #";
                cell.Font.Bold = true;
            }
            if (chkSerialNumber.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Serial #";
                cell.Font.Bold = true;
            }
            if (chkExpiryDate.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Expiry Date";
                cell.Font.Bold = true;
            }
            if (chkBrand.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Brand";
                cell.Font.Bold = true;
            }
            if (chkColor.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Color";
                cell.Font.Bold = true;
            }
            if (chkGender.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Gender";
                cell.Font.Bold = true;
            }
            if (chkSize.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Size";
                cell.Font.Bold = true;
            }
           
            if (chkSaleAmount.Checked)
            {
                SaleAmountColIndex = columnIndex;
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Sales";
                cell.Font.Bold = true;
            }
            if (chkCostOfSalesAmount.Checked)
            {
                CostOfSalesAmountColIndex = columnIndex;
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Cost of Sales";
                cell.Font.Bold = true;
            }
            if (chkGrossProfit.Checked)
            {
                GrossProfitColIndex = columnIndex;
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Gross Profit";
                cell.Font.Bold = true;
            }
            if (chkProfitMargin.Checked)
            {
                ProfitMarginColIndex = columnIndex;
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "%Margin";
                cell.Font.Bold = true;
            }

            if (chkUnitsSold.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Units Sold";
                cell.Font.Bold = true;
            }
            if (chkAverageCost.Checked)
            {
                cell = ws.Cells[rowOffset, columnIndex++] as Excel.Range;
                cell.Value2 = "Average Cost";
                cell.Font.Bold = true;
            }

            int totalColCount = columnIndex - 1;
            ws.get_Range(ws.Cells[1, 1], ws.Cells[1, totalColCount]).Merge(missing);
            cell = ws.Cells[1, 1] as Excel.Range;
            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            cell.Font.Bold = true;
            cell.Value2 = _obj.DataFileInformationMgr.Company.CompanyName;

            ws.get_Range(ws.Cells[2, 1], ws.Cells[2, totalColCount]).Merge(missing);
            cell = ws.Cells[2, 1] as Excel.Range;
            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            cell.Font.Italic = true;
            cell.RowHeight = 48;
            cell.Value2 = _obj.DataFileInformationMgr.Company.Address;

            ws.get_Range(ws.Cells[3, 1], ws.Cells[3, totalColCount]).Merge(missing);
            cell = ws.Cells[3, 1] as Excel.Range;
            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            cell.Font.Bold = true;
            cell.Value2 = "Analyse Sales [Item]";

            ws.get_Range(ws.Cells[4, 1], ws.Cells[4, totalColCount]).Merge(missing);
            cell = ws.Cells[4, 1] as Excel.Range;
            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            cell.Font.Bold = true;
            if (year_from == year_to)
                cell.Value2 = string.Format("{0}", year_from);
            else
                cell.Value2 = string.Format("{0} - {1}", year_from, year_to);

            ws.get_Range(ws.Cells[5, 1], ws.Cells[5, totalColCount]).Merge(missing);
            cell = ws.Cells[5, 1] as Excel.Range;
            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            cell.Font.Bold = true;
            cell.Value2 = DateTime.Now.ToString("yyyy-MMM-dd");

            ws.get_Range(ws.Cells[6, 1], ws.Cells[6, totalColCount]).Merge(missing);
            cell = ws.Cells[6, 1] as Excel.Range;
            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            cell.Font.Bold = true;
            cell.Value2 = DateTime.Now.ToString("HH:mm:ss");

            rowOffset++;

            int itemCount = items.Count;
            for (int i = 0; i < itemCount; ++i)
            {
                columnIndex = 1;

                LightItem _lght = sh2.GetItem(items[i].ItemNumber);

                if (chkItemNumber.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = items[i].ItemNumber;
                }

                if (chkItemName.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = items[i].ItemName;
                }

                if (chkBatchNumber.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.BatchNumber;
                }

                if (chkSerialNumber.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.SerialNumber;
                }

                if (chkExpiryDate.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.ExpiryDate.ToString("yyyy-MMM-dd");
                }

                if (chkBrand.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.Brand;
                }

                if (chkColor.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.Color;
                }

                if (chkGender.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.Gender.ToString();
                }

                if (chkSize.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _lght.Size.ToString();
                }

               
                

                List<ItemSalesHistory> itemSalesHistories = _obj.ItemSalesHistoryMgr.List(items[i].ItemID, year_from, year_to);
                double SaleAmount = 0;
                if (chkSaleAmount.Checked || chkGrossProfit.Checked)
                {
                    
                    foreach (ItemSalesHistory history in itemSalesHistories)
                    {
                        SaleAmount+=history.SaleAmount;
                    }

                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _obj.CurrencyMgr.Format(SaleAmount);
                }

                double CostOfSalesAmount = 0;
                if (chkCostOfSalesAmount.Checked || chkGrossProfit.Checked)
                {
                    
                    foreach (ItemSalesHistory history in itemSalesHistories)
                    {
                        CostOfSalesAmount += history.CostOfSalesAmount;
                    }

                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _obj.CurrencyMgr.Format(CostOfSalesAmount);
                }

                double GrossProfit = SaleAmount - CostOfSalesAmount;
                if (chkGrossProfit.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _obj.CurrencyMgr.Format(GrossProfit);
                }

                double margin = 0;
                if (SaleAmount != 0) margin = GrossProfit * 100 / SaleAmount;
                if (chkProfitMargin.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _obj.CurrencyMgr.FormatPercent(margin);
                }

                if (chkUnitsSold.Checked)
                {
                    double UnitsSold = 0;
                    foreach (ItemSalesHistory history in itemSalesHistories)
                    {
                        UnitsSold += history.UnitsSold;
                    }

                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = UnitsSold.ToString();
                }

                if (chkAverageCost.Checked)
                {
                    cell = ws.Cells[i + rowOffset, columnIndex++] as Excel.Range;
                    cell.Value2 = _obj.CurrencyMgr.Format(items[i].PositiveAverageCost);
                }

                TotalSaleAmount += SaleAmount;
                TotalProfitMargin += margin;
                TotalGrossProfit += GrossProfit;
                TotalCostOfSalesAmount += CostOfSalesAmount;
            }

            if (chkSaleAmount.Checked)
            {
                cell = ws.Cells[itemCount + rowOffset, SaleAmountColIndex] as Excel.Range;
                cell.Value2 = _obj.CurrencyMgr.Format(TotalSaleAmount / itemCount);
            }
            if (chkCostOfSalesAmount.Checked)
            {
                cell = ws.Cells[itemCount + rowOffset, CostOfSalesAmountColIndex] as Excel.Range;
                cell.Value2 = _obj.CurrencyMgr.Format(TotalCostOfSalesAmount / itemCount);
            }
            if (chkProfitMargin.Checked)
            {
                cell = ws.Cells[itemCount + rowOffset, ProfitMarginColIndex] as Excel.Range;
                cell.Value2 = _obj.CurrencyMgr.FormatPercent(TotalProfitMargin / itemCount);
            }
            if (chkGrossProfit.Checked)
            {
                cell = ws.Cells[itemCount + rowOffset, GrossProfitColIndex] as Excel.Range;
                cell.Value2 = _obj.CurrencyMgr.Format(TotalGrossProfit/itemCount);
            }


            ws.UsedRange.Columns.AutoFit();

            sh2.Locked = oldSh2Locked;
        }

        
        private void lblFrom_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateAndEmail_Click(object sender, EventArgs e)
        {
            string filename = string.Format("{0}\\RptItems_{1}.xlsx", Application.StartupPath, DateTime.Now.ToString("yyyyMMdd_HHmm"));

            Excel.Application app = new Excel.Application();
            app.Visible = false;
            app.DisplayAlerts = false;

            Excel.Workbooks wbs = app.Workbooks as Excel.Workbooks;
            Excel.Workbook wb = wbs.Add(1);

            Excel.Worksheet ws = wb.Worksheets[1] as Excel.Worksheet;

            PopulateData(ws);

            SaveWorkBook(wb, filename);

            wb.Close(missing, missing, missing);

            app.DisplayAlerts = true;
            app.Quit();

            Email.FrmEmail frm = new SyntechRpt.WinForms.Email.FrmEmail();
            frm.Attachments.Add(filename);

            frm.ShowDialog();
        }
    }
}
