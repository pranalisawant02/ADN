namespace LegalDocSummarizer.Api.Services
{
    public interface IDocumentTextExtractor
    {
        Task<string> ExtractTextAsync(IFormFile file);
    }
}