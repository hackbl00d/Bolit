using BolitApi.Database.Entities;
using BolitApi.Dtos;
using Riok.Mapperly.Abstractions;

namespace BolitApi.Mappers;

[Mapper]
public partial class EntryMapper
{
    public partial Entry ToDto(DictionaryEntryDto entry);
}