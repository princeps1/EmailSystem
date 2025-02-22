namespace EmailSystem.Contracts;
public interface IFileService
{
    string ProcessFile(Stream content);
    List<KeyValuePair<string, int>> ProcessFileAsString(Stream fileStream,string returnOnlyThisLevel);
}
