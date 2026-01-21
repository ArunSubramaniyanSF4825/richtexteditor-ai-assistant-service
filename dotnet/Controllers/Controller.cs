using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using WebApplication2.Service;
namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AIController: ControllerBase {
    private readonly AIService _service;

    public AIController(AIService service)
    {
        _service = service;
    }

    [HttpPost("Stream")]
    public async Task Stream()
    {
        await _service.StreamResponseAsync(Request, Response);
    }
}