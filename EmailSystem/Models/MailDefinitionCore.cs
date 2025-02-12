namespace EmailSystem.Models;

public class MailDefinitionCore
{
    public string From { get; set; }
    public string To { get; set; }
    public string CC { get; set; }
    public string BCC { get; set; }

    [EmailAddress]
    //[Required]
    public string ReplyTo { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Subject { get; set; }

    public List<Attachment> Attachments { get; set; }
    public string ContentHTML { get; set; }
    public string ContentText { get; set; }
}
