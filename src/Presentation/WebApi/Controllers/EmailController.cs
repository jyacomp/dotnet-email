using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Notifications.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IEmailService _email;

        public EmailController(ILogger<EmailController> logger, IEmailService email)
        {
            _logger = logger;
            _email = email;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            await _email.SendEmailAsync("user@mail.com", "User Name", $"{Guid.NewGuid()}", $"<h1>{DateTime.Now}</h1>", true);
            return Ok();
        }
    }
}
