using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Core.Models.ViewModels;
using ISEnglish.Services.BL;
using ISEnglishMVC.Contracts.Words;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ISEnglishMVC.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class WordsController : Controller
    {

        private readonly IWordsService _wordsService;
        public WordsController(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WordsResponse>>> Index()
        {
            var words = await _wordsService.GetAllWords();

            var response = words.Select(b => new WordsResponse(b.Id, b.RusTitle, b.EngTitle, b.Transcription, b.CategoryName));
            ViewBag.Words = response;
            return View();
        }

        [HttpPost]

        public async Task<ActionResult<Guid>> Index([FromForm] WordViewModel model)
        {
            var wordResult = Word.Create(Guid.NewGuid(), model.RusTitle, model.EngTitle, $"[{model.Transcription}]", "Category");

            if (wordResult.IsFailure)
            {
                return BadRequest(wordResult.Error);
            }
            var wordId = await _wordsService.CreateWord(wordResult.Value);
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
