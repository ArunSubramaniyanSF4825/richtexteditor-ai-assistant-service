using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string AzureApiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "Your-Api-Key";

string AzureDeploymentName = Environment.GetEnvironmentVariable("DEPLOYMENT_NAME") ?? "Your-Model-Name";

string AzureEndpoint = Environment.GetEnvironmentVariable("END_POINT") ?? "https://your-azure-openai.openai.azure.com/";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
    new Uri(AzureEndpoint),
    new ApiKeyCredential(AzureApiKey));

IChatClient AIChatClient = azureOpenAIClient.GetChatClient(AzureDeploymentName).AsIChatClient();

builder.Services.AddSingleton<IChatClient>(AIChatClient);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7234",
                "http://localhost:5500",
                "http://127.0.0.1:5500"    // ← this is the one you need now
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

app.UseCors("Dev");        // ← IMPORTANT: This line was missing in the right place
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
