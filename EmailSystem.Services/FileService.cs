using EmailSystem.Contracts;
using EmailSystem.Domain.Entities;
using Newtonsoft.Json;

namespace EmailSystem.Services;

public class FileService : IFileService
{
    public string ProcessFile(Stream content)
    {
        try
        {
            if (content == null || content.Length == 0)
            {
                return "Nema fajla";
            }

            int errorCount = 0;
            int warningCount = 0;
            int infoCount = 0;
            int dbgCount = 0;

            using (var reader = new StreamReader(content))
            {
                string line;
                while ((line = reader.ReadLine()!) != null)
                {
                    if (line.Contains("\"Level\":\"Error\""))
                        errorCount++;
                    else if (line.Contains("\"Level\":\"Warning\""))
                        warningCount++;
                    else if (line.Contains("\"Level\":\"Information\""))
                        infoCount++;
                    else if (line.Contains("\"Level\":\"Debug\""))
                        dbgCount++;
                }
            }
            return 
                $"Broj ERROR logova: {errorCount}\n" +
                $"Broj WARNING logova: {warningCount}\n" +
                $"Broj INFORMATION logova: {infoCount}\n" +
                $"Broj DEBUG logova: {dbgCount}"
                ;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public List<KeyValuePair<string, int>> ProcessFileAsString(Stream content, string? returnOnlyThisLevel)
    {
        var logs = new List<Root>();


        using (var reader = new StreamReader(content))
        {
            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    var logEntry = JsonConvert.DeserializeObject<Root>(line);
                    if (logEntry != null)
                    {
                        logs.Add(logEntry);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Greska prilikom deserializacije linije: {ex.Message}");
                }
            }
        }
        int infoCount = logs.Count(l => l.Level.Equals("Information"));
        int debugCount = logs.Count(l => l.Level.Equals("Debug"));
        int warningCount = logs.Count(l => l.Level.Equals("Warning"));
        int errorCount = logs.Count(l => l.Level.Equals("Error"));

        var result = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("Information", infoCount),
            new KeyValuePair<string, int>("Debug", debugCount),
            new KeyValuePair<string, int>("Warning", warningCount),
            new KeyValuePair<string, int>("Error", errorCount)
        };


        if (!string.IsNullOrEmpty(returnOnlyThisLevel))
        {
            result = result
                .Where(r => r.Key.Contains(returnOnlyThisLevel))
                .ToList();
        }

        return result;


    }
}
