using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Notifications.Email;

namespace Infrastructure.Notifications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            string fromName = "";
            string fromAddress = "";
            string host = "";
            int port = 587;
            string userName = "";
            string password = "";
            //services.AddScoped<IEmailService, SmtpClientEmailService>(options => new SmtpClientEmailService(
            //    fromName,
            //    fromAddress,
            //    host,
            //    port,
            //    userName,
            //    password
            //    ));
            services.AddScoped<IEmailService, MailKitEmailService>(options => new MailKitEmailService(
                fromName,
                fromAddress,
                host,
                port,
                userName,
                password
                ));
            return services;
        }
    }
}
