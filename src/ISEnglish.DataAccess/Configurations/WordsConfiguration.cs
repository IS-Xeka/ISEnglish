using ISEnglish.DataAccess.Entities;
using ISEnglish.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISEnglish.DataAccess.Configurations
{
    internal class WordsConfiguration : IEntityTypeConfiguration<WordEntity>
    {
        public void Configure(EntityTypeBuilder<WordEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.RusTitle)
                .IsRequired()
                .HasMaxLength(Word.MAX_LENGTH);

            builder.Property(b => b.EngTitle)
                .IsRequired()
                .HasMaxLength(Word.MAX_LENGTH);
        }
    }
}
