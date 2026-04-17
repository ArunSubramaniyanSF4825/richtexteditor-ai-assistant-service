# EJ2 Rich Text Editor AI Assistant Service

## Overview

Dual-platform backend service supporting Node.js and .NET Core for intelligent text generation and streaming capabilities in the EJ2 Rich Text Editor.

## Prerequisites

- **Node.js**: v24+, npm, TypeScript
- **\.NET**: Core 8.0+, Visual Studio
- **Common**: OpenAI API key, Git, Postman/cURL for testing

## Quick Start

### Node.js

```bash
cd node
npm install
npm run serve
```

### \.NET Core

```bash
cd dotnet
dotnet restore
dotnet run
```

## Configuration

Environment variables:
```bash
API_KEY=your_openai_api_key
DEPLOYMENT_NAME=your_model_name
END_POINT=https://your_endpoint.openai.azure.com/
```

## API Endpoint

**POST** `/api/stream` - AI-generated streaming responses

## Features

- Real-time response streaming from OpenAI API
- Express-based Node.js service with TypeScript support
- ASP.NET Core Web API with Swagger and CORS
- Syncfusion Rich Text Editor integration
- Environment-based configuration for security

## Services

- **Node.js** - [Details](./node/README.md)
- **\.NET Core** - [Details](./dotnet/README.md)
