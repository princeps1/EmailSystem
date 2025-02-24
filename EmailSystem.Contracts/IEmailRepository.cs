using EmailSystem.Domain.DTO;
using EmailSystem.Domain.Entities;

namespace EmailSystem.Contracts;

public interface IEmailRepository
{
    public Task SnimiAsync(MailDefinition mailDefinition);

}
