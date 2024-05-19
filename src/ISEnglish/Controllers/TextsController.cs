using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Core.Models.ViewModels;
using ISEnglish.Services.BL;
using ISEnglishMVC.Contracts.Texts;
using ISEnglishMVC.Contracts.Words;
using Microsoft.AspNetCore.Mvc;

namespace ISEnglishMVC.Controllers
{
    public class TextsController : Controller
    {
        private readonly ITextsService _textsService;
        public TextsController(ITextsService textsService)
        {
            _textsService = textsService;
        }
        [HttpGet]
        public async Task<ActionResult> Index(Guid id)
        {
            var texts = await _textsService.GetAllTexts();
            if(id != Guid.Empty)
            {
                var text = await _textsService.GetById(id);
                ViewBag.Text = text;
            }
            var response = texts.Select(b => new TextsResponse(b.Id, b.Name, b.Content));
            ViewBag.Texts = response;
            return View();
        }

        [HttpPost("CreateText")]

        public async Task<ActionResult> CreateText(TextViewModel model)
        {
            if (ModelState.IsValid)
            {
                var textResult = Text.Create(Guid.NewGuid(), model.Name, model.Content);
                if (textResult.IsFailure)
                {
                    return BadRequest(textResult.Error);
                }
                var wordId = await _textsService.CreateText(textResult.Value);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("DeleteText")]

        public async Task<ActionResult<Guid>> DeleteText(Guid id)
        {
            var result = await _textsService.DeleteText(id);
            return RedirectToAction("Index");
        }


    }
}
