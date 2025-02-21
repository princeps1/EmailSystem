namespace EmailSystem.Domain.Entities;

public class Attachment
{
    [Key]
    public int ID { get; set; }

    [Required]
    public required byte[] Data { get; set; }

    [Required]
    [MaxLength(100)]
    public required string ContentType { get; set; }

    [Required]
    [MaxLength(255)]
    public required string FileName { get; set; }

 
    public required MailDefinition MailDefinition { get; set; }
}
