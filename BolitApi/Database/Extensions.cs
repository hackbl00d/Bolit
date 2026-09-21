using System.Text.Json;
using BolitApi.Dtos;

namespace BolitApi.Database;

public class Extensions
{
    public void SeedDictionaryEntries(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<BolitDbContext>();

        context.Database.EnsureCreated();
        
        string path = @"/mount/Projects/JSONToSQL/it-extract.jsonl";
           
        // JsonDocument json = JsonDocument.Parse(path);
        StreamReader reader = new StreamReader(path);
        string line;
        
        while ((line = reader.ReadLine()) != null)
        {
            var entry = JsonSerializer.Deserialize<DictionaryEntryDto>(line);
            entry.Translations.Where(a => a.LangCode == "en" || a.LangCode == "bg");
            context.Add(entry);
        }
    }
}