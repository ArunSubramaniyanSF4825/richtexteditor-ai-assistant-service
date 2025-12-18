## AI Streaming Assistant Service

A lightweight Node.js + Express service that streams AI-generated responses using the **OpenAI** SDK.

### Tech Stack

* **Node.js:** v24
* **Framework:** Express
* **AI SDK:** `openai`
* **Language:** TypeScript

### What It Does

* Exposes a `POST /api/stream` endpoint
* Accepts a user message
* Streams AI-generated text back to the client in real time

---

## Setup & Run

### 1. Install Dependencies

```bash
npm install
```

### 2. Configure OpenAI API Key

Replace `YOUR_API_KEY` in `server.ts` with your OpenAI API key
*(or preferably load it from an environment variable)*

### 3. Run in Development Mode

```bash
npm run dev
```

### 4. Build & Run for Production

```bash
npm run serve
```

### 5. Test the API

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
