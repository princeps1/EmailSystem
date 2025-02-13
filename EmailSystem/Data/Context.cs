
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailSystem.Data;

public class Context : DbContext
{
    public DbSet<MailDefinition> MailDefinitions { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MailDefinition>()
            .OwnsOne(m => m.MailDefinitionCore);

        modelBuilder.Entity<MailDefinition>()
            .HasMany(m => m.Attachments)
            .WithOne(a => a.MailDefinition)
            .HasPrincipalKey(m => m.ID);

        // Dodavanje inline convertera za property 'ViewModel' koristeći JSON serijalizaciju
        var converter = new ValueConverter<object, string>(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
            v => JsonSerializer.Deserialize<object>(v, (JsonSerializerOptions)null)
        );

        modelBuilder.Entity<MailDefinition>()
            .Property(e => e.ViewModel)
            .HasConversion(converter);
    }




}
