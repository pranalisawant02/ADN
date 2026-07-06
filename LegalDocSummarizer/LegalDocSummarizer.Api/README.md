# ⚖️ Legal Document Summarizer & Clause Extractor

An AI-powered ASP.NET Core Web API that analyzes legal documents — extracting plain-English summaries, key clauses, and risk flags using Google's Gemini AI. Built to explore how AI capabilities can be integrated into enterprise .NET applications, with a focus on the legal tech domain.

---

## 📋 Overview

Legal contracts are dense and time-consuming to review manually. This project automates the first pass: upload a document, and the API returns a structured breakdown of what it says, which clauses matter most, and what risks to watch out for.

**Pipeline:** Upload document → Extract text → Send to AI for analysis → Return structured JSON (summary, key clauses, risk flags)

---

## ✨ Features

- 📄 Supports **PDF, DOCX, and TXT** file uploads
- 🤖 AI-generated **plain-English summaries** of legal documents
- 🔑 Automatic **key clause extraction**
- ⚠️ **Risk flag detection** (e.g., auto-renewal traps, liability caps, unilateral termination rights)
- 📚 Interactive **Swagger/OpenAPI** documentation for testing endpoints
- 🖥️ Lightweight built-in **HTML test client** — no separate frontend needed
- 🔒 Secure API key handling via **.NET User Secrets**

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Backend Framework | ASP.NET Core Web API (.NET 10) |
| Language | C# |
| AI Provider | Google Gemini API (`gemini-2.5-flash`) |
| PDF Parsing | UglyToad.PdfPig |
| DOCX Parsing | DocumentFormat.OpenXml |
| API Documentation | Swashbuckle (Swagger/OpenAPI) |
| Frontend (test client) | HTML, CSS, vanilla JavaScript |
| Secrets Management | .NET User Secrets |

---

## 🏗️ Architecture

The project follows a lightweight layered architecture for separation of concerns:

```
LegalDocSummarizer.Api/
├── Controllers/        → Handles HTTP requests/responses only
│   └── DocumentsController.cs
├── Services/            → Business logic (text extraction, AI calls)
│   ├── IDocumentTextExtractor.cs
│   ├── DocumentTextExtractor.cs
│   ├── IAiAnalysisService.cs
│   └── AiAnalysisService.cs
├── Models/              → Data Transfer Objects (DTOs)
│   ├── DocumentSummaryResult.cs
│   └── AiAnalysisRequest.cs
├── wwwroot/             → Static HTML test client
│   └── index.html
└── Program.cs           → App configuration & DI registration
```

**Key design decisions:**
- All services are defined behind **interfaces** and registered via **Dependency Injection**, so the AI provider can be swapped (this project originally used OpenAI, then switched to Gemini) without touching the Controller.
- AI responses are constrained via **structured output prompting** — the model is instructed to return only valid JSON in a fixed schema, avoiding fragile text parsing.

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- A free [Google Gemini API key](https://aistudio.google.com/apikey)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/<your-username>/LegalDocSummarizer.git
   cd LegalDocSummarizer/LegalDocSummarizer.Api
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Add your Gemini API key** (stored securely, never committed to source control)
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "Gemini:ApiKey" "your-gemini-api-key-here"
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Test it out**
   - Swagger UI: `http://localhost:<port>/swagger`
   - HTML test client: `http://localhost:<port>/index.html`

---

## 📡 API Reference

### `POST /api/documents/analyze`

Uploads a document and returns AI-generated analysis.

**Request:** `multipart/form-data`
| Field | Type | Description |
|---|---|---|
| `file` | File | PDF, DOCX, or TXT (max 10MB) |

**Response:** `200 OK`
```json
{
  "fileName": "sample_contract.txt",
  "summary": "A 3-4 sentence plain-English summary of the document.",
  "keyClauses": [
    "The agreement automatically renews for successive 12-month terms unless 30 days' notice is provided."
  ],
  "riskFlags": [
    "Automatic renewal clause places the onus on the Client to actively prevent extension."
  ],
  "processedAt": "2026-07-05T11:33:05.4968931Z"
}
```

**Error responses:**
| Code | Reason |
|---|---|
| `400 Bad Request` | Missing file, empty file, or unsupported file type |
| `500 Internal Server Error` | AI processing failure |

---

## 🧠 What I Learned

- Designing REST APIs with proper separation of concerns (Controllers–Services–Models)
- Using Dependency Injection and interfaces to keep AI provider integration swappable
- Prompt engineering for structured, parseable AI outputs
- Secure secrets management in ASP.NET Core
- Debugging real-world API integration issues (rate limits, quota errors, model deprecation) by inspecting full error responses rather than relying on status codes alone

---

## 🔮 Future Improvements

- [ ] Persist upload history in a SQL database
- [ ] Add user authentication (JWT)
- [ ] Support chunking + map-reduce summarization for very long documents
- [ ] Add automated unit/integration tests
- [ ] Add retry logic with exponential backoff for AI API calls
- [ ] Deploy to Azure App Service

---

## ⚠️ Disclaimer

This tool provides AI-assisted document analysis for informational purposes only and does not constitute legal advice. Always have important legal documents reviewed by a qualified professional.

---

## 📄 License

This project is open-source and available for educational/portfolio purposes.
