using Backend.Api.Dtos;
using Backend.Database.Entities;
using Riok.Mapperly.Abstractions;

namespace Backend.Api.Mappers;

[Mapper]
public partial class DictionaryEntryMapper
{
    [MapperIgnoreTarget(nameof(Entry.EntryId))]
    public partial Entry ToEntity(DictionaryEntryDto dto);

    [MapperIgnoreTarget(nameof(Synonym.EntryId))]
    [MapperIgnoreTarget(nameof(Synonym.Entry))]
    [MapperIgnoreTarget(nameof(Synonym.SynonymId))]
    public partial Synonym ToSynonymEntity(SynonymDto dto);

    [MapperIgnoreTarget(nameof(Form.EntryId))]
    [MapperIgnoreTarget(nameof(Form.Entry))]
    [MapperIgnoreTarget(nameof(Form.FormId))]
    public partial Form ToFormEntity(FormDto dto);
    
    [MapperIgnoreTarget(nameof(Hyphenation.EntryId))]
    [MapperIgnoreTarget(nameof(Hyphenation.Entry))]
    [MapperIgnoreTarget(nameof(Hyphenation.HyphenationId))]
    public partial Hyphenation ToHyphenationEntity(HyphenationDto dto);
    
    [MapperIgnoreTarget(nameof(Example.ExampleId))]
    [MapperIgnoreTarget(nameof(Example.SenseId))]
    [MapperIgnoreTarget(nameof(Example.Sense))]
    public partial Example ToExampleEntity(ExampleDto dto);
    
    [MapperIgnoreTarget(nameof(Proverb.EntryId))]
    [MapperIgnoreTarget(nameof(Proverb.Entry))]
    [MapperIgnoreTarget(nameof(Proverb.ProverbId))]
    public partial Proverb ToProverbEntity(ProverbDto dto);

    [MapperIgnoreTarget(nameof(RelatedWord.EntryId))]
    [MapperIgnoreTarget(nameof(RelatedWord.Entry))]
    [MapperIgnoreTarget(nameof(RelatedWord.RelatedWordId))]
    public partial RelatedWord ToRelatedWordEntity(RelatedWordDto dto);
    
    [MapperIgnoreTarget(nameof(DerivedWord.EntryId))]
    [MapperIgnoreTarget(nameof(DerivedWord.Entry))]
    [MapperIgnoreTarget(nameof(DerivedWord.DerivedWordId))]
    public partial DerivedWord ToDerivedWordEntity(DerivedWordDto dto);
    
    [MapperIgnoreTarget(nameof(Translation.EntryId))]
    [MapperIgnoreTarget(nameof(Translation.Entry))]
    [MapperIgnoreTarget(nameof(Translation.TranslationId))]
    public partial Translation ToDerivedWordEntity(TranslationDto dto);
    
    [MapperIgnoreTarget(nameof(Sound.EntryId))]
    [MapperIgnoreTarget(nameof(Sound.SoundId))]
    [MapperIgnoreTarget(nameof(Sound.Entry))]
    public partial Sound ToDerivedWordEntity(SoundDto dto);
    
    [MapperIgnoreTarget(nameof(Sense.EntryId))]
    [MapperIgnoreTarget(nameof(Sense.Entry))]
    [MapperIgnoreTarget(nameof(Sense.SenseId))]
    public partial Sense ToDerivedWordEntity(SenseDto dto);
}
