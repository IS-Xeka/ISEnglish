using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Core.Models.ViewModels;
using ISEnglish.Services.BL;
using ISEnglishMVC.Contracts.Words;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ISEnglishMVC.Controllers
{
    public class WordsController : Controller
    {


        private readonly IWordsService _wordsService;
        public WordsController(IWordsService wordsService)
        {
            _wordsService = wordsService;

        }

        [HttpGet]
        public async Task<ActionResult<List<WordsResponse>>> Index(string? search)
        {
            var words = await _wordsService.GetAllWords();
            if (!string.IsNullOrWhiteSpace(search))
            {
                words = words.Where(b => (b.RusTitle.ToLower().Contains(search.ToLower()) ||
                                        b.EngTitle.ToLower().Contains(search.ToLower()))).ToList();
            }

            var response = words.Select(b => new WordsResponse(b.Id, b.RusTitle, b.EngTitle, b.Transcription, b.CategoryName));
            ViewBag.Words = response;
            return View();
        }

        [HttpPost("CreateWord")]

        public async Task<ActionResult> CreateWord(WordViewModel model)
        {
            if(ModelState.IsValid){
                var wordResult = Word.Create(Guid.NewGuid(), model.RusTitle, model.EngTitle, $"[{model.Transcription}]", "Category");
                if (wordResult.IsFailure)
                {
                    return BadRequest(wordResult.Error);
                }
                var wordId = await _wordsService.CreateWord(wordResult.Value);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("DeleteWord")]

        public async Task<ActionResult<Guid>> DeleteWord(Guid id)
        {
            var result = await _wordsService.DeleteWord(id);
            return RedirectToAction("Index");
        }

    }
}
