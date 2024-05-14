using ISEnglish.Domain.Core.Models;
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
        public async Task<ActionResult<List<WordsResponse>>> GetWords()
        {
            var words = await _wordsService.GetAllWords();

            var response = words.Select(b => new WordsResponse(b.Id, b.RusTitle, b.EngTitle, b.Transcription, b.CategoryName));

            return Ok(response);

        }

        [HttpPost]

        public async Task<ActionResult<Guid>> CreateWord([FromBody] WordsRequest request)
        {
            var wordResult = Word.Create(Guid.NewGuid(), request.RusTitle, request.EngTitle, request.Transcription, request.CategoryName);

            if (wordResult.IsFailure)
            {
                return BadRequest(wordResult.Error);
            }
            var wordId = await _wordsService.CreateWord(wordResult.Value);
            return Ok(wordId);
        }

        [HttpDelete]

        public async Task<ActionResult<Guid>> DeleteWord(Guid id)
        {
            var result = await _wordsService.DeleteWord(id);
            return Ok(result);
        }

    }
}
