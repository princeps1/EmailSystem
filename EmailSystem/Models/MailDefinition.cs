namespace EmailSystem.Models;

public class MailDefinition
{
    public MailDefinitionCore MailDefinitionCore { get; set; }
    public string TenantName { get; set; }
    public string EmailTemplateName { get; set; }
    public object ViewModel { get; set; }
    public bool SendBox { get; set; }
}
