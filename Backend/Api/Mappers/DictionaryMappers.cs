using Backend.Api.Dtos;
using Backend.Database.Entities;
using Riok.Mapperly.Abstractions;

namespace Backend.Api.Mappers;

[Mapper]
public partial class DictionaryEntryMapper
{
    public partial Entry ToEntity(DictionaryEntryDto dto);
    
    public partial DictionaryEntryDto ToDto(Entry entry);
}
