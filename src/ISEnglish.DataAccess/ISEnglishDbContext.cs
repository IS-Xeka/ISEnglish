using ISEnglish.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISEnglish.DataAccess
{
    public class ISEnglishDbContext : DbContext
    {
        public ISEnglishDbContext(DbContextOptions<ISEnglishDbContext> options)
            : base(options) { }

        public DbSet<WordEntity> Words { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
