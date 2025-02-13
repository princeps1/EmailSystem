

public class Attachment
{
    [Key]
    public int ID { get; set; }

    [Required]
    public byte[] Data { get; set; }

    [Required]
    [MaxLength(100)]
    public string ContentType { get; set; }

    [Required]
    [MaxLength(255)]
    public string FileName { get; set; }

 
    public MailDefinition MailDefinition { get; set; }
}
