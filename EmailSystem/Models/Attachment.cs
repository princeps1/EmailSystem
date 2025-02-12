namespace EmailSystem.Models
{
    public class Attachment
    {
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }

    }
}
