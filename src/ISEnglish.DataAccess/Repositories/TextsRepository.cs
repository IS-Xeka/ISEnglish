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
    public class TextsRepository : ITextsRepository
    {
        private readonly ISEnglishDbContext _context;

        public TextsRepository(ISEnglishDbContext context)
        {
            _context = context;
        }

        public async Task<List<Text>> Get()
        {
            var textEntity = await _context.Texts
                .AsNoTracking()
                .ToListAsync();

            var texts = textEntity
                .Select(b => Text.Create(b.Id, b.Name, b.Content).Value)
                .ToList();

            return texts;
        }

        public async Task<Text> GetById(Guid id)
        {
            var textEntity = await _context.Texts
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);


            var textResult = Text.Create(textEntity.Id, textEntity.Name, textEntity.Content);
            if (textResult.IsFailure)
            {
                throw new Exception();
            }

            return textResult.Value;

        }

        public async Task<Guid> Create(Text text)
        {
            var textEntity = new TextEntity()
            {
                Id = text.Id,
                Name = text.Name,
                Content = text.Content
            };

            await _context.Texts.AddAsync(textEntity);
            await _context.SaveChangesAsync();

            return textEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string content)
        {
            await _context.Texts.Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Content, b => content));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Texts.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
