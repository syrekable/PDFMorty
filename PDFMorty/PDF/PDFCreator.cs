using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
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
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = pdf;
            pdfRenderer.RenderDocument();
            //TODO: welp, here I can save it to a stream, whatever that means.
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        private Document CreateDocument()
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Color.FromCmyk(100, 30, 20, 50);
            paragraph.AddFormattedText("Hello World!", TextFormat.Bold);
            return document;
        }

        /// <summary>
        /// Defines the styles used in the document.
        /// </summary>
        public static void DefineStyles(Document document)
        {
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

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }
    }
}
