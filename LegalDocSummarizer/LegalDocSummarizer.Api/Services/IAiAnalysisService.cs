using LegalDocSummarizer.Api.Models;

namespace LegalDocSummarizer.Api.Services
{
    public interface IAiAnalysisService
    {
        Task<DocumentSummaryResult> AnalyzeDocumentAsync(string documentText, string fileName);
    }
}