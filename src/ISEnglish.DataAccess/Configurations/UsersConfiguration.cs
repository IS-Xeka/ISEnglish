using ISEnglish.DataAccess.Entities;
using ISEnglish.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Configurations
{
    internal class UsersConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserName)
                .IsRequired();

            builder.Property(b => b.PasswordHash)
                .IsRequired();

            builder.Property(b => b.Email)
                .IsRequired();
        }
    }
}
