using ISEnglish.Domain.Core.Models;

namespace ISEnglish.DataAccess.Repositories
{
    public interface ICategoriesRepository
    {
        Task<Guid> Create(Category category);
        Task<Guid> Delete(Guid id);
        Task<List<Category>> Get();
        Task<Guid> Update(Guid id, string name, string description);
    }
}