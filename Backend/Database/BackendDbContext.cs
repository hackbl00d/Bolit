using Backend.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class BackendDbContext(DbContextOptions<BackendDbContext> options) : DbContext(options)
{
    public DbSet<Entry> Entries { get; set; }

    public DbSet<Translation> Translations { get; set; }

    public DbSet<Synonym> Synonyms { get; set; }

    public DbSet<Proverb> Proverbs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DefineRelations(modelBuilder);
    }

    private static void DefineRelations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entry>(entity =>
        {
            entity.HasKey(e => e.EntryId);

            entity.Property(e => e.Word)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(e => e.LangCode)
                .IsRequired()
                .HasMaxLength(20);
            entity
                .Property(e => e.Lang)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(e => e.Pos)
                .IsRequired()
                .HasMaxLength(100);
            entity
                .Property(e => e.PosTitle)
                .IsRequired()
                .HasMaxLength(200);
            entity
                .Property(e => e.Categories)
                .HasMaxLength(200);

            entity
                .HasMany(e => e.Synonyms)
                .WithOne(s => s.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.Senses)
                .WithOne(s => s.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.Translations)
                .WithOne(t => t.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.DerivedWords)
                .WithOne(d => d.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.RelatedWords)
                .WithOne(r => r.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.Proverbs)
                .WithOne(p => p.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.Hyphenations)
                .WithOne(h => h.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.Sounds)
                .WithOne(s => s.Entry)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.Forms)
                .WithOne(f => f.Entry)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Sense>(entity =>
        {
            entity.HasKey(s => s.SenseId);

            entity
                .Property(s => s.Glosses)
                .IsRequired()
                .HasMaxLength(200);

            entity
                .Property(s => s.RawTags)
                .HasMaxLength(200);

            entity
                .OwnsMany(s => s.Examples)
                .WithOwner(e => e.Sense);
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(t => t.TranslationId);

            entity
                .Property(t => t.Word)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(t => t.LangCode)
                .IsRequired()
                .HasMaxLength(20);
            entity
                .Property(t => t.Lang)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(t => t.Sense)
                .IsRequired()
                .HasMaxLength(200);
            entity
                .Property(t => t.Tags)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Synonym>(entity =>
        {
            entity.HasKey(s => s.SynonymId);

            entity
                .Property(s => s.Word)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(s => s.RawTags)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<RelatedWord>(entity =>
        {
            entity.HasKey(wr => wr.EntryId);
        });

        modelBuilder.Entity<DerivedWord>(entity =>
        {
            entity.HasKey(wr => wr.EntryId);
        });

        modelBuilder.Entity<WordRef>(entity =>
        {
            entity.HasNoKey();

            entity
                .Property(wr => wr.Word)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(wr => wr.Tags)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Proverb>(entity =>
        {
            entity.HasKey(p => p.ProverbId);

            entity
                .Property(t => t.Phrase)
                .IsRequired()
                .HasMaxLength(50);
            entity
                .Property(t => t.Sense)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Sound>(entity =>
        {
            entity.HasKey(s => s.SoundId);

            entity
                .Property(s => s.Ipa)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Hyphenation>(entity =>
        {
            entity.HasKey(h => h.HyphenationId);

            entity
                .Property(h => h.Parts)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(f => f.FormId);

            entity
                .Property(f => f.Tags)
                .IsRequired()
                .HasMaxLength(200);
            entity
                .Property(f => f.Source)
                .IsRequired()
                .HasMaxLength(200);
            entity
                .Property(f => f.Text)
                .IsRequired()
                .HasMaxLength(100);
            entity
                .Property(f => f.RawTags)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Example>(entity =>
        {
            entity.HasKey(e => e.ExampleId);
            
            entity
                .Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(100);
            
            entity
                .Property(e => e.Translation)
                .IsRequired()
                .HasMaxLength(100);
            
            entity
                .Property(e => e.Reference)
                .IsRequired()
                .HasMaxLength(200);

            entity
                .Property(e => e.BoldTextOffsets)
                .HasMaxLength(50)
                .HasColumnType("json");
        });
    }
}