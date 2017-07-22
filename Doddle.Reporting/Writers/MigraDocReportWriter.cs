using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;

namespace Doddle.Reporting.Writers
{
    public class MigraDocReportWriter : IReportWriter
    {
        public MigraDocReportWriter()
        {
           
        }

        public bool Landscape { get; set; }

        protected virtual void DefineStyles(Document document)
        {
            document.DefaultPageSetup.Orientation = (this.Landscape ? Orientation.Landscape : Orientation.Portrait);

            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);
        }



        protected virtual Document CreateDocument(Report report)
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "CodeZone Pdf Writer";
            document.Info.Subject = "CodeZone Pdf Writer";
            document.Info.Author = "CodeZone";

            DefineStyles(document);

            DefineContentSection(document, report);
            DefineTables(document, report);


            return document;
        }

        protected virtual void DefineTables(Document document, Report report)
        {
            ReportRowCollection rptrows = report.GetRows();
            int rowCount = rptrows.Count;
            if (rowCount <= 1) return;

            Table table = new Table();
            table.Format.Alignment = ParagraphAlignment.Center;
            table.Borders.Width = 0.75;


            ReportRow headerRow = rptrows[0];
            int columnCount = 0;
            foreach (RowField field in headerRow.Fields)
            {
                columnCount++;
            }


            Unit columnWidth = 100;
            PageSetup pageSetup = document.DefaultPageSetup;
            if (Landscape)
            {
                columnWidth = (pageSetup.PageHeight - pageSetup.TopMargin - pageSetup.BottomMargin) / columnCount;
            }
            else
            {
                columnWidth = (pageSetup.PageWidth - pageSetup.LeftMargin - pageSetup.RightMargin) / columnCount;
            }


            foreach (RowField field in headerRow.Fields)
            {
                table.AddColumn(columnWidth);
            }

            int columnIndex = 0;
            Row row = table.AddRow();
            Cell cell = null;
            row.Shading.Color = Colors.PaleGoldenrod;
            foreach (RowField field in headerRow.Fields)
            {
                cell = row.Cells[columnIndex++];
                cell.AddParagraph(field.HeaderText);
            }

            for (int rowIndex = 1; rowIndex < rowCount; ++rowIndex)
            {
                ReportRow rptrow = rptrows[rowIndex];
                row = table.AddRow();

                if (rptrow.RowType == ReportRowType.DataRow)
                {
                    columnIndex = 0;
                    foreach (RowField field in rptrow.Fields)
                    {
                        cell = row.Cells[columnIndex++];
                        cell.AddParagraph(rptrow.GetFormattedValue(field));
                    }
                }
            }

            document.LastSection.Add(table);
        }



        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        private void DefineContentSection(Document document, Report report)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;
            section.PageSetup.Orientation = (this.Landscape ? Orientation.Landscape : Orientation.Portrait);

            HeaderFooter header = section.Headers.Primary;
            header.AddParagraph(report.TextFields.Footer);

            header = section.Headers.EvenPage;
            header.AddParagraph(report.TextFields.Footer);

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Color = Colors.DarkBlue;
            paragraph.Format.Font.Size = 14;
            paragraph.AddText(report.TextFields.Title);

            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText("");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Color = Colors.DarkBlue;
            paragraph.AddText(report.TextFields.SubTitle);

            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText("");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.Format.Font.Bold = true;
            paragraph.AddText(report.TextFields.Header);

            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText("");
        }




        private bool GetBooleanValue(object input)
        {
            if (input == null)
                return false;

            try
            {
                return Convert.ToBoolean(input);
            }
            catch
            {
                if (input.ToString() == "Yes")
                    return true;

                else
                    return false;
            }
        }

        public virtual void WriteReport(Report report, Stream destination)
        {

        }

        public virtual void AppendReport(Report source, Report destination)
        {

        }

    }
}
