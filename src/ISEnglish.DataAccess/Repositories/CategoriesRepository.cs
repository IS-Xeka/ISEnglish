using ISEnglish.DataAccess.Entities;
using ISEnglish.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Repositories
{
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly ISEnglishDbContext _context;

        public CategoriesRepository(ISEnglishDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Get()
        {
            var categoryEntities = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            var categories = categoryEntities
                .Select(b => Category.Create(b.Id, b.Name, b.Description).category)
                .ToList();

            return categories;
        }

        public async Task<Guid> Create(Category category)
        {
            var categoryEntity = new CategoryEntity()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();

            return categoryEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description)
        {
            await _context.Categories.Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Description, b => description));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Categories.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
