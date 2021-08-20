using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Notifications.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _email;

        public HomeController(ILogger<HomeController> logger, IEmailService email)
        {
            _logger = logger;
            _email = email;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await _email.SendEmailAsync("user@mail.com", "User Name", $"{Guid.NewGuid()}", $"<h1>{DateTime.Now}</h1>", true);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
