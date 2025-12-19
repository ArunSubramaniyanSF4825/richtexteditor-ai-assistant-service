using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
namespace WebApplication2.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class Controller: ControllerBase {
        private readonly Service _service;
        public Controller(Service service)
        {
            _service=service;
        }
        [HttpPost("Stream")]
        public async Task Stream()
        {
            await _service.StreamResponseAsync(Request, Response);
        }
    }
}