using ISEnglish.Domain.Core.Models;

namespace ISEnglish.DataAccess.Repositories
{
    public interface ITextsRepository
    {
        Task<Guid> Create(Text text);
        Task<Text> GetById(Guid id);
        Task<Guid> Delete(Guid id);
        Task<List<Text>> Get();
        Task<Guid> Update(Guid id, string name, string content);
    }
}