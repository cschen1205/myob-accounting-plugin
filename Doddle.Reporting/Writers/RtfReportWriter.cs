using System;
using System.Text;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel;
using MigraDoc.RtfRendering;

namespace Doddle.Reporting.Writers
{
    public class RtfReportWriter : MigraDocReportWriter
    {
        public RtfReportWriter()
        {
           
        }

        public virtual void WriteReport(Report report, string filename)
        {
            Document doc = CreateDocument(report);

            RtfDocumentRenderer rtfRenderer = new RtfDocumentRenderer();


            rtfRenderer.Render(doc, filename, null);
        }

        
    }
}