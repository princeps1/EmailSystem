namespace EmailSystem.Contracts;
public interface IEmailService
{
    public Task PosaljiEmailAsync(string subject, string toEmail, string username, string message);
}
