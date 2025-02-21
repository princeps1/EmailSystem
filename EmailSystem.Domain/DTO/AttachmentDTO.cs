namespace EmailSystem.Domain.DTO;

public class AttachmentDTO
{
    [Required]
    public byte[] Data { get; set; }

    [Required]
    [MaxLength(100)]
    public string ContentType { get; set; }

    [Required]
    [MaxLength(255)]
    public string FileName { get; set; }
}
