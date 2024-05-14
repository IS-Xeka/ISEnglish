using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Interfaces.Repositories;

namespace ISEnglish.Services.BL
{
    public class WordsService : IWordsService
    {
        private readonly IWordsRepository _wordsRepository;
        public WordsService(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public async Task<List<Word>> GetAllWords()
        {
            return await _wordsRepository.Get();
        }

        public async Task<Guid> CreateWord(Word word)
        {
            return await _wordsRepository.Create(word);
        }

        public async Task<Guid> UpdateWord(Guid id, string rusTitle, string engTitle, string transcription, string categoryName)
        {
            return await _wordsRepository.Update(id, rusTitle, engTitle, transcription, categoryName);
        }

        public async Task<Guid> DeleteWord(Guid id)
        {
            return await _wordsRepository.Delete(id);
        }
    }
}
