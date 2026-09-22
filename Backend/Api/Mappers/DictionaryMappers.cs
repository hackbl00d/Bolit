using Backend.Api.Dtos;
using Backend.Database.Entities;
using Riok.Mapperly.Abstractions;

namespace Backend.Api.Mappers;

[Mapper]
public partial class DictionaryEntryMapper
{
    [MapperIgnoreTarget(nameof(Database.Entities.WordRef.EntryId))]
    private partial Database.Entities.WordRef ToEntity(Dtos.WordRef source);

    public partial Entry ToEntity(DictionaryEntryDto dto);
    
    public partial DictionaryEntryDto ToDto(Entry entry);
}
