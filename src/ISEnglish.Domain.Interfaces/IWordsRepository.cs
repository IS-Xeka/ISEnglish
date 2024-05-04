using ISEnglish.Domain.Core.Models;

namespace ISEnglish.DataAccess.Repositories
{
    public interface IWordsRepository
    {
        Task<Guid> Create(Word word);
        Task<Guid> Delete(Guid id);
        Task<List<Word>> Get();
        Task<Guid> Update(Guid id, string rusTitle, string engTitle, string transcription, string categoryName);
    }
}