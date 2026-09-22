using Backend.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class BackendDbContext : DbContext
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

            entity.Property(e => e.Word).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LangCode).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Lang).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Pos).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PosTitle).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Categories).HasMaxLength(50);
            
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
            
            
        });

        modelBuilder.Entity<Sense>(entity =>
        {
            entity.HasKey(s => s.SenseId);

            entity.Property(s => s.Glosses).HasMaxLength(100);
            entity.Property(s => s.RawTags).HasMaxLength(100);
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(t => t.TranslationId);
            
            entity.Property(t => t.Word).IsRequired().HasMaxLength(50);
            entity.Property(t => t.LangCode).IsRequired().HasMaxLength(10);
            entity.Property(t => t.Lang).IsRequired().HasMaxLength(20);
            entity.Property(t => t.Sense).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Tags).HasMaxLength(100);
        });

        modelBuilder.Entity<Synonym>(entity =>
        {
            entity.HasKey(s => s.SynonymId);
            
            entity.Property(s => s.Word).IsRequired().HasMaxLength(50);
            entity.Property(s => s.RawTags).HasMaxLength(100);
        });

        modelBuilder.Entity<WordRef>(entity =>
        {
            entity.HasKey(wr => wr.EntryId);
            
            entity.Property(wr => wr.Word).IsRequired().HasMaxLength(50);
            entity.Property(wr => wr.Tags).HasMaxLength(100);
        });

        modelBuilder.Entity<Proverb>(entity =>
        {
            entity.HasKey(p => p.ProverbId);
            
            entity.Property(t => t.Phrase).IsRequired().HasMaxLength(50);
            entity.Property(t => t.Sense).IsRequired().HasMaxLength(100);
        });
    }
}