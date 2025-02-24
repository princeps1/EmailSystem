namespace EmailSystem.Services.Contracts;

public interface IEmailFactory
{
    IEmailService CreateEmailService();
}
