using System.Net.Mail;

namespace EmailSystem.Services.Implementations
{
    public class EmailService
    {
        private readonly IEmailFactory _emailFactory;

        public EmailService(IEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;
        }

        public async Task PosaljiEmailAsync(string subject, string toEmail, string username, string message)
        {
            var sender = _emailFactory.CreateEmailService();
            await sender.PosaljiEmailAsync( subject, toEmail, username, message);
        }
    }

}
