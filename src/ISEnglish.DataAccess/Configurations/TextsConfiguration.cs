using ISEnglish.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Configurations
{
    internal class TextsConfiguration : IEntityTypeConfiguration<TextEntity>
    {
        public void Configure(EntityTypeBuilder<TextEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Content)
                .IsRequired();
        }
    }
}
