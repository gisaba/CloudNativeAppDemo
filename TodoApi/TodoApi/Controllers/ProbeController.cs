using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbeController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("isAlive")]
        public IActionResult isAlive()
        {
            return Ok("Todo API DEMO Version 1.0.0 Hostname:" + Dns.GetHostName());
        }
    }
}
