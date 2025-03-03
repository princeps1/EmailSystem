namespace EmailSystem.Services.Implementations
{
    public class EmailFactory : IEmailFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public EmailFactory(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public IEmailService CreateEmailService()
        {
            var providerName = _configuration["Mailer:Type"];
            if (Enum.TryParse<EmailProvider>(providerName, out var provider))
            {
                switch (provider)
                {
                    case EmailProvider.SendGrid:
                        return _serviceProvider.GetRequiredService<SendGridEmailService>();
                    case EmailProvider.MailTrap:
                        return _serviceProvider.GetRequiredService<MailTrapEmailService>();
                    default:
                        throw new NotSupportedException("Nepodrzani email provider.");
                }
            }
            throw new Exception("Email provider nije ispravno konfiguriran.");
        }
    }
}
