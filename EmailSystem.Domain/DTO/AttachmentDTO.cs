namespace EmailSystem.Domain.DTO;

public class AttachmentDTO
{
    [Required]
    public required byte[] Data { get; set; }

    [Required]
    [MaxLength(100)]
    public required string ContentType { get; set; }

    [Required]
    [MaxLength(255)]
    public required string FileName { get; set; }
}
