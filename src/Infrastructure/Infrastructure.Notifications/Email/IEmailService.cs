using System.Threading.Tasks;

namespace Infrastructure.Notifications.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string name, string subject, string message, bool isBodyHtml);
    }
}
