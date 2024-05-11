using ISEnglish.Domain.Core.Models;

namespace ISEnglish.Services.BL
{
    public interface IWordsService
    {
        Task<Guid> CreateWord(Word word);
        Task<Guid> DeleteWord(Guid id);
        Task<List<Word>> GetAllWords();
        Task<Guid> UpdateWord(Guid id, string rusTitle, string engTitle, string transcription, string categoryName);
    }
}