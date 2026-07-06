using System.Text;
using System.Text.Json;
using LegalDocSummarizer.Api.Models;

namespace LegalDocSummarizer.Api.Services
{
    public class AiAnalysisService : IAiAnalysisService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AiAnalysisService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<DocumentSummaryResult> AnalyzeDocumentAsync(string documentText, string fileName)
        {
            var apiKey = _configuration["Gemini:ApiKey"];

            var truncatedText = documentText.Length > 12000
                ? documentText[..12000]
                : documentText;

            var prompt = $@"
You are a legal assistant AI. Analyze the following legal document and respond ONLY in valid JSON
with this exact structure, no extra text, no markdown, no code fences:

{{
  ""summary"": ""a 3-4 sentence plain-English summary"",
  ""keyClauses"": [""clause 1"", ""clause 2""],
  ""riskFlags"": [""risk 1"", ""risk 2""]
}}

Document:
{truncatedText}
";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.3
                }
            };

            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
{
    var errorBody = await response.Content.ReadAsStringAsync();
    throw new Exception($"Gemini API error ({(int)response.StatusCode}): {errorBody}");
}

            var responseBody = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseBody);

            var aiMessageContent = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString() ?? "{}";

            aiMessageContent = aiMessageContent.Trim();
            if (aiMessageContent.StartsWith("```"))
            {
                aiMessageContent = aiMessageContent
                    .Replace("```json", "")
                    .Replace("```", "")
                    .Trim();
            }

            var parsed = JsonSerializer.Deserialize<JsonElement>(aiMessageContent);

            return new DocumentSummaryResult
            {
                FileName = fileName,
                Summary = parsed.TryGetProperty("summary", out var s) ? s.GetString() ?? "" : "",
                KeyClauses = parsed.TryGetProperty("keyClauses", out var kc)
                    ? kc.EnumerateArray().Select(x => x.GetString() ?? "").ToList()
                    : new List<string>(),
                RiskFlags = parsed.TryGetProperty("riskFlags", out var rf)
                    ? rf.EnumerateArray().Select(x => x.GetString() ?? "").ToList()
                    : new List<string>()
            };
        }
    }
}
