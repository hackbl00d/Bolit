using System.IO.Compression;
using System.Text.Json;
using Backend.Api.Dtos;
using Backend.Api.Mappers;
using Backend.Database;

namespace Backend.Api.Extensions;

public class Extensions
{
    public void SeedDictionaryEntries(IServiceProvider serviceProvider, 
        DictionaryEntryMapper  mapper)
    {
        using var scope = serviceProvider.CreateAsyncScope();
        using var context = scope.ServiceProvider.GetRequiredService<BackendDbContext>();
        string sourceFile = "it-extract.jsonl.gz";
        string destinationFile = "it-extract.jsonl";

        using (FileStream compressedFileStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (FileStream outputFileStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
        using (GZipStream decompressionStream = new GZipStream(compressedFileStream, CompressionMode.Decompress))
        {
            decompressionStream.CopyTo(outputFileStream);
        }
        
        string path = @"../it-extract.jsonl";
           
        StreamReader reader = new StreamReader(path);
        string? line;

        int counter = 0;
        
        while ((line = reader.ReadLine()) != null)
        {
            if (counter >= 500)
            {
                counter = 0;
                context.SaveChangesAsync();
            }
            
            DictionaryEntryDto? entry = JsonSerializer.Deserialize<DictionaryEntryDto>(line);
            if (entry == null) continue;
            if (entry.Translations != null)
            {
                entry.Translations.Where(a => a.LangCode == "en" || a.LangCode == "bg");
            }

            context.Entries.Add(mapper.ToEntity(entry));

            counter++;
        }
        
        context.SaveChanges();
    }
}