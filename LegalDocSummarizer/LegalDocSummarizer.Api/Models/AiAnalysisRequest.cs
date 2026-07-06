namespace LegalDocSummarizer.Api.Models
{
    // This is what we send TO the AI service internally (not exposed via API)
    public class AiAnalysisRequest
    {
        public string DocumentText { get; set; } = string.Empty;
    }
}