using Infrastructure.Notifications;
using Infrastructure.Notifications.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var _email = host.Services.GetService<IEmailService>();

            await _email.SendEmailAsync("user@mail.com", "User Name", $"{Guid.NewGuid()}", $"<h1>{DateTime.Now}</h1>", true);
        }
        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureServices((_, services) => services.AddNotifications());       
    }
}