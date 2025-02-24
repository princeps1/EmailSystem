using Microsoft.Extensions.Configuration;
using System.Text;

namespace EmailSystem.Services.Implementations
{
    public class MailTrapEmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiToken;

        public MailTrapEmailService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiToken = configuration["ApiToken"]!; 
        }

        public async Task PosaljiEmailAsync(string subject, string toEmail, string username, string message)
        {
            var emailData = new
            {
                from = new { email = "hello@example.com", name = "Mailtrap Test" },
                to = new[] { new { email = toEmail } },
                subject = subject,
                text = message,
                category = "Integration Test"
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(emailData), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiToken}"); 

            var response = await _httpClient.PostAsync("https://sandbox.api.mailtrap.io/api/send/3483653", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to send email: {error}");
            }
        }
    }
}
