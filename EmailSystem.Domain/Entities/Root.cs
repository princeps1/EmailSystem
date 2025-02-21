namespace EmailSystem.Domain.Entities;

public class Root
{
    public DateTime Timestamp { get; set; }
    public required string Level { get; set; }
    public required string MessageTemplate { get; set; }
}
