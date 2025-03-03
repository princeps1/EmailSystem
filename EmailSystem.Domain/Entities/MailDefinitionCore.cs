namespace EmailSystem.Domain.Entities;

public class MailDefinitionCore
{
    [Required]
    [EmailAddress]
    public string? From { get; set; }

    [Required]
    public required string To { get; set; }

    public string? CC { get; set; }

    public string? BCC { get; set; }

    [EmailAddress]
    public string? ReplyTo { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string Subject { get; set; }

    public string? ContentHTML { get; set; }
    public string? ContentText { get; set; }
}