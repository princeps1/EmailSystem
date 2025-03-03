using Microsoft.Extensions.Configuration;
using System.Text;

namespace EmailSystem.Services.Implementations
{
    public class MailTrapEmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MailTrapEmailService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task PosaljiEmailAsync(string subject, string toEmail, string username, string message)
        {
            var emailData = new
            {
                from = new { email = _configuration["Mailer:Setup:FromEmail"], name = _configuration["Mailer:Setup:FromName"] },
                to = new[] { new { email = toEmail } },
                subject = subject,
                text = message
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(emailData), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["Mailer:Setup:ApiToken"]}");

            var response = await _httpClient.PostAsync(_configuration["Mailer:Setup:Url"], jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to send email: {error}");
            }
        }
    }
}
