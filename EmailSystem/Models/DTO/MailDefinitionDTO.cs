namespace EmailSystem.Models.DTO
{
    public class MailDefinitionDTO
    {
        [Required]
        public MailDefinitionCoreDTO MailDefinitionCore { get; set; }

        public string TenantName { get; set; }

        [MaxLength(100)]
        public string EmailTemplateName { get; set; }

        // Ako vam je potrebno, možete poslati i ViewModel kao JSON objekat
        public object ViewModel { get; set; }

        public bool SendBox { get; set; }

        public List<AttachmentDTO> Attachments { get; set; }
    }
}
