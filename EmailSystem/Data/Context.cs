namespace EmailSystem.Data;

public class Context : DbContext
{
    public DbSet<MailDefinition> MailDefinitions { get; set; }
    public DbSet<MailDefinitionCore> MailDefinitionCores { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
}
