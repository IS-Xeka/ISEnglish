using ISEnglish.Domain.Core.Models;

namespace ISEnglish.Services.BL
{
    public interface ITextsService
    {
        Task<Guid> CreateText(Text text);
        Task<Guid> DeleteText(Guid id);
        Task<List<Text>> GetAllTexts();
        Task<Text> GetById(Guid id);
        Task<Guid> UpdateText(Guid id, string name, string content);
    }
}