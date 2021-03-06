using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Infrastructure.Notifications.Email 
{
     public class MailKitEmailService : IEmailService
    {
        private MimeMessage mail { get; set; }
        private string host { get; set; }
        private int port { get; set; }
        private string userName { get; set; }
        private string password { get; set; }

        public MailKitEmailService(string fromName, string fromAddress, string host, int port, string userName, string password)
        {
            mail = new MimeMessage();
            mail.From.Add(new MailboxAddress(fromName, fromAddress));
            this.host = host;
            this.port = port;
            this.userName = userName;
            this.password = password;
        }
        
        public async Task SendEmailAsync(string email, string name, string subject, string message, bool isBodyHtml)
        {
            mail.To.Add(new MailboxAddress(name, email));
            mail.Subject = subject;
            if (isBodyHtml)
            {
                mail.Body = new TextPart("html") { Text = message };
            }
            else
            {
                mail.Body = new TextPart("plain") { Text = message };
            }
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(host, port, false);
                    await client.AuthenticateAsync(userName, password);
                    await client.SendAsync(mail);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
 }
