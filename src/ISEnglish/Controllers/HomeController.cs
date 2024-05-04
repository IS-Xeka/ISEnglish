using ISEnglish.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISEnglish.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly (Word, String) _word;

        public HomeController(ILogger<HomeController> logger)
        {
            _word = Word.Create(Guid.Empty, "f", "f", "f", "f");
            _logger = logger;
        }

        public IActionResult Index()
        {
            Console.WriteLine(_word.Item2);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
