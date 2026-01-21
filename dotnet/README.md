## AI Streaming Assistant Service

A lightweight An ASP.NET Core service that streams AI-generated responses using the **OpenAI** SDK.

### Tech Stack

- **Platform**: ASP.NET Core
- **UI Component**: Syncfusion Rich Text Editor
- **AI SDK**: OpenAI (via REST API)
- **Language**: C#

### What It Does

* Exposes a `POST /api/stream` endpoint
* Accepts a user message
* Streams AI-generated text back to the client in real time
---

## Setup & Run

### 1. Create Project

```bash
Use Visual Studio:

File → New → Project → ASP.NET Core Web API
Framework: Latest .NET
Click Create
```

### 2. Install Dependencies

Install packages via NuGet:

- **Microsoft.Extensions.AI**
- **Microsoft.Extensions.AI.OpenAI**
- **Azure.AI.OpenAI**


### Program.cs Configuration

```bash
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;

string AzureApiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "Your-Api-Key";
string AzureDeploymentName = Environment.GetEnvironmentVariable("DEPLOYMENT_NAME") ?? "Your-Model-Name";
string AzureEndpoint = Environment.GetEnvironmentVariable("END_POINT") ?? "https://your-azure-openai.openai.azure.com/";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(AzureEndpoint),
     new ApiKeyCredential(AzureApiKey)
);
IChatClient AIChatClient = azureOpenAIClient.GetChatClient(AzureDeploymentName).AsIChatClient();
```

### 3. Run in Development Mode

```bash
Press Ctrl+F5 (Windows) or ⌘+F5 (macOS) to run the app.
```

### 4. Test the API

Send a `POST` request to:

```
http://localhost:3000/api/stream
```

**Request Body:**

```json
{
  "message": "Hello, how can you help me?"
}
```
