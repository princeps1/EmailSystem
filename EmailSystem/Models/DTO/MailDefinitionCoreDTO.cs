namespace EmailSystem.Models.DTO
{
    public class MailDefinitionCoreDTO
    {
        [Required]
        [EmailAddress]
        public string From { get; set; }

        [Required]
        [EmailAddress]
        public string To { get; set; }

        [EmailAddress]
        public string CC { get; set; }

        [EmailAddress]
        public string BCC { get; set; }

        [EmailAddress]
        public string ReplyTo { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Subject { get; set; }

        public string ContentHTML { get; set; }
        public string ContentText { get; set; }
    }
}
