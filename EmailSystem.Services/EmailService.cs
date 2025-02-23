using EmailSystem.Contracts;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSystem.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task PosaljiEmailAsync(string subject,string toEmail,string username,string message)
    {
        var apiKey = _configuration["SendGridApiKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("matejajovic2002@gmail.com", "Princepsdoo");
        var to = new EmailAddress(toEmail, "Example User");
        var plainTextContent = message;
        var htmlContent = "";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}
