using System.IO.Compression;
using System.Text.Json;
using Backend.Api.Dtos;
using Backend.Api.Mappers;
using Backend.Database;

namespace Backend.Api.Extensions;

public static class Extensions
{
    public static void SeedDictionaryEntries(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateAsyncScope();
        using var context = scope.ServiceProvider.GetRequiredService<BackendDbContext>();
        var mapper = scope.ServiceProvider.GetRequiredService<DictionaryEntryMapper>();

        var dataFile = "./it-extract.jsonl";
        
        if (!File.Exists(dataFile))
        {
            string sourceFile = "./it-extract.jsonl.gz";

            using FileStream compressedFileStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using FileStream outputFileStream = new FileStream(dataFile, FileMode.Create, FileAccess.Write);
            using GZipStream decompressionStream = new GZipStream(compressedFileStream, CompressionMode.Decompress);
            decompressionStream.CopyTo(outputFileStream);
        }
           
        StreamReader reader = new StreamReader(dataFile);
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