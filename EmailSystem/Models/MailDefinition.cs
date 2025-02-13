using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmailSystem.Models
{
    public class MailDefinition
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public MailDefinitionCore MailDefinitionCore { get; set; }

        public string TenantName { get; set; }

        [MaxLength(100)]
        public string EmailTemplateName { get; set; }

        public object ViewModel { get; set; }

        public bool SendBox { get; set; }

        public List<Attachment>? Attachments { get; set; }
    }
}
