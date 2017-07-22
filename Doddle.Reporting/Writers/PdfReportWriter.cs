using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace Doddle.Reporting.Writers
{
    public class PdfReportWriter : MigraDocReportWriter
    {
        public PdfReportWriter()
        {
           
        }

        public virtual void WriteReport(Report report, string filename)
        {
            Document doc = CreateDocument(report);

            const bool unicode = false;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);
            pdfRenderer.Document = doc;

            pdfRenderer.RenderDocument();

            pdfRenderer.PdfDocument.Save(filename);
            
        }

        
    }
}