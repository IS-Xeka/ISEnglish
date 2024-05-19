using ISEnglish.DataAccess.Repositories;
using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.Services.BL
{
    public class TextsService : ITextsService
    {
        private readonly ITextsRepository _textsRepository;
        public TextsService(ITextsRepository textsRepository)
        {
            _textsRepository = textsRepository;
        }

        public async Task<List<Text>> GetAllTexts()
        {
            return await _textsRepository.Get();
        }

        public async Task<Text> GetById(Guid id)
        {
            return await _textsRepository.GetById(id);
        }

        public async Task<Guid> CreateText(Text text)
        {
            return await _textsRepository.Create(text);
        }

        public async Task<Guid> UpdateText(Guid id, string name, string content)
        {
            return await _textsRepository.Update(id, name, content);
        }

        public async Task<Guid> DeleteText(Guid id)
        {
            return await _textsRepository.Delete(id);
        }
    }
}
