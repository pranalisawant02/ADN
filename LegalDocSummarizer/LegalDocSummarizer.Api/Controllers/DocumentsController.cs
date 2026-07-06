using Microsoft.AspNetCore.Mvc;
using LegalDocSummarizer.Api.Models;
using LegalDocSummarizer.Api.Services;

namespace LegalDocSummarizer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentTextExtractor _textExtractor;
        private readonly IAiAnalysisService _aiAnalysisService;
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(
            IDocumentTextExtractor textExtractor,
            IAiAnalysisService aiAnalysisService,
            ILogger<DocumentsController> logger)
        {
            _textExtractor = textExtractor;
            _aiAnalysisService = aiAnalysisService;
            _logger = logger;
        }

        [HttpPost("analyze")]
        [RequestSizeLimit(10_000_000)] // 10 MB limit
        public async Task<ActionResult<DocumentSummaryResult>> AnalyzeDocument(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a valid file.");
            }

            var allowedExtensions = new[] { ".pdf", ".docx", ".txt" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest($"File type '{extension}' is not supported. Please upload PDF, DOCX, or TXT.");
            }

            try
            {
                _logger.LogInformation("Processing file: {FileName}", file.FileName);

                var extractedText = await _textExtractor.ExtractTextAsync(file);

                if (string.IsNullOrWhiteSpace(extractedText))
                {
                    return BadRequest("Could not extract any text from the uploaded file.");
                }

                var result = await _aiAnalysisService.AnalyzeDocumentAsync(extractedText, file.FileName);

                return Ok(result);
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing document {FileName}", file.FileName);
                return StatusCode(500, "An error occurred while processing the document.");
            }
        }
    }
}