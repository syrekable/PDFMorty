using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace PDFMorty.PDF
{
    class PDFCreator
    {
        public PDFCreator(string filename)
        {
            Document pdf = CreateDocument();
            pdf.UseCmykColor = true;
            const bool unicode = false;
            //dunno where to get PdfFontEmbedding from, it is explained nowhere
            //const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);

            pdfRenderer.Document = pdf;
            pdfRenderer.RenderDocument();
            //TODO: welp, here I can save it to a stream, whatever that means.
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        private Document CreateDocument()
        {
            Document document = new Document();
            /*
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);
            paragraph.AddFormattedText("Hello World!", TextFormat.Bold);
            */
            return document;
        }
    }
}
