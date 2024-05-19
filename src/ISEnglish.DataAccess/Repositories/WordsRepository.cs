using ISEnglish.DataAccess.Entities;
using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Core.Models.ViewModels;
using ISEnglish.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Repositories
{
    public class WordsRepository : IWordsRepository
    {
        private readonly ISEnglishDbContext _context;

        public WordsRepository(ISEnglishDbContext context)
        {
            _context = context;
        }
        public async Task<List<Word>> Get()
        {
            var wordEntities = await _context.Words
                .AsNoTracking()
                .ToListAsync();

            var words = wordEntities
                .Select(b => Word.Create(b.Id, b.RusTitle, b.EngTitle, b.Transcription, b.CategoryName).Value)
                .ToList();

            return words;
        }

        public async Task<Guid> Create(Word word)
        {
            var wordEntity = new WordEntity()
            {
                Id = word.Id,
                RusTitle = word.RusTitle,
                EngTitle = word.EngTitle,
                Transcription = word.Transcription,
                CategoryName = word.CategoryName
            };

            await _context.Words.AddAsync(wordEntity);
            await _context.SaveChangesAsync();

            return wordEntity.Id;
        }


        public async Task<Guid> Update(Guid id, string rusTitle, string engTitle, string transcription, string categoryName)
        {
            await _context.Words.Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.RusTitle, b => rusTitle)
                    .SetProperty(b => b.EngTitle, b => engTitle)
                    .SetProperty(b => b.Transcription, b => transcription)
                    .SetProperty(b => b.CategoryName, b => categoryName));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Words.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
