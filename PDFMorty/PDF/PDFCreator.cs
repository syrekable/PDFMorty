using System.Collections.Generic;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace PDFMorty.PDF
{
    public class PDFCreator
    {
        const short ALIGNMENT = 100;

        public PDFCreator(string filename, List<PDFMorty.Entities.Character> characters)
        {
            Document document = new Document();

            Section section = document.AddSection();
            section.Headers.Primary.AddParagraph($"Printing all {characters.Count} results");

            foreach (var character in characters)
            {
                Paragraph header = section.AddParagraph();
                header.AddFormattedText($"{character.name}");
                header.Format.Font.Size = 20;
                header.Format.Font.Color = Colors.Black;
                header.Format.SpaceBefore = "0.5cm";

                section.AddParagraph($"status:{character.status, ALIGNMENT}");
                section.AddParagraph($"species:{character.species, ALIGNMENT}");
                section.AddParagraph($"gender:{character.gender, ALIGNMENT}");
                section.AddParagraph($"origin:{character.origin, ALIGNMENT}");
                section.AddParagraph($"last seen at:{character.location, ALIGNMENT}");
                section.AddParagraph($"played in {character.numberOfEpisoded,ALIGNMENT} episodes");
            }

            SaveAndPresentDocument(filename, document);
        }

        public PDFCreator(string filename, List<PDFMorty.Entities.Location> locations)
        {
            Document document = new Document();

            Section section = document.AddSection();
            section.Headers.Primary.AddParagraph($"Printing all {locations.Count} results");

            foreach (var location in locations)
            {
                Paragraph header = section.AddParagraph();
                header.AddFormattedText($"{location.name}");
                header.Format.Font.Size = 20;
                header.Format.Font.Color = Colors.Black;
                header.Format.SpaceBefore = "0.5cm";

                section.AddParagraph($"type:{location.type,ALIGNMENT}");
                section.AddParagraph($"dimension:{location.dimension,ALIGNMENT}");
                section.AddParagraph($"# of residents:{location.numberOfResidents,ALIGNMENT}");
            }

            SaveAndPresentDocument(filename, document);
        }

        private void SaveAndPresentDocument(string filename, Document document)
        {
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }
    }
}
