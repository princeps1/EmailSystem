namespace EmailSystem.Services.Implementations;

public class SendGridEmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public SendGridEmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task PosaljiEmailAsync(string subject, string toEmail, string username, string message)
    {
        var apiKey = _configuration["Mailer:Setup:ApiKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(_configuration["Mailer:Setup:FromEmail"], _configuration["Mailer:Setup:FromName"]);
        var to = new EmailAddress(toEmail);
        var plainTextContent = message;
        var htmlContent = "";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }


}
