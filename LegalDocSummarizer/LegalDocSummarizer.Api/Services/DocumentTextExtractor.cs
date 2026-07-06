using UglyToad.PdfPig;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;

namespace LegalDocSummarizer.Api.Services
{
    public class DocumentTextExtractor : IDocumentTextExtractor
    {
        public async Task<string> ExtractTextAsync(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return extension switch
            {
                ".pdf" => ExtractFromPdf(memoryStream),
                ".docx" => ExtractFromDocx(memoryStream),
                ".txt" => await ExtractFromTxt(memoryStream),
                _ => throw new NotSupportedException($"File type '{extension}' is not supported.")
            };
        }

        private string ExtractFromPdf(Stream stream)
        {
            var text = new StringBuilder();
            using var document = PdfDocument.Open(stream);
            foreach (var page in document.GetPages())
            {
                text.AppendLine(page.Text);
            }
            return text.ToString();
        }

        private string ExtractFromDocx(Stream stream)
        {
            var text = new StringBuilder();
            using var wordDoc = WordprocessingDocument.Open(stream, false);
            var body = wordDoc.MainDocumentPart?.Document?.Body;

            if (body != null)
            {
                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    text.AppendLine(paragraph.InnerText);
                }
            }
            return text.ToString();
        }

        private async Task<string> ExtractFromTxt(Stream stream)
        {
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
}