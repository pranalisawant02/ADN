namespace LegalDocSummarizer.Api.Models
{
    // This represents the final response we send back to the client
    public class DocumentSummaryResult
    {
        public string FileName { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public List<string> KeyClauses { get; set; } = new();
        public List<string> RiskFlags { get; set; } = new();
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
    }
}