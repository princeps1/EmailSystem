using EmailSystem.Contracts;
using EmailSystem.Data;
using EmailSystem.Domain.DTO;
using EmailSystem.Domain.Entities;

namespace EmailSystem.Services;

public class EmailRepository : IEmailRepository
{
    private readonly Context _context;

    public EmailRepository(Context context)
    {
        _context = context;
    }
    public async Task SnimiAsync(MailDefinition mailDefinition)
    {
        _context.MailDefinitions.Add(mailDefinition);
        await _context.SaveChangesAsync();
    }
}
