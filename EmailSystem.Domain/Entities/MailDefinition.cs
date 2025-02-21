namespace EmailSystem.Domain.Entities;

public class MailDefinition
{
    [Key]
    public int ID { get; set; }


    [Required]
    public required MailDefinitionCore MailDefinitionCore { get; set; }

    public required string TenantName { get; set; }

    [MaxLength(100)]
    public string? EmailTemplateName { get; set; }

    public object? ViewModel { get; set; }

    public bool? SendBox { get; set; } = false;

    public List<Attachment>? Attachments { get; set; }
}
