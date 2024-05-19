using ISEnglish.Controllers;
using ISEnglish.Domain.Core.Models;
using ISEnglish.Domain.Core.Models.ViewModels;
using ISEnglish.Services.BL;
using ISEnglishMVC.Contracts.Users;
using ISEnglishMVC.Contracts.Words;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace ISEnglishMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.IsUniqueUser(model.UserName))
                {
                    await _userService.Register(model.UserName, model.Email, model.Password);
                    return View();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid register attempt");
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
     
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tokenResult = await _userService.Login(model.Email, model.Password);
                if (tokenResult.IsFailure)
                {
                    ModelState.AddModelError(string.Empty, tokenResult.Error);
                    return View(model);
                }
                else
                {
                    Response.Cookies.Append("ts-cookies", tokenResult.Value);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            return View(model);
           
        }

        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("ts-cookies");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var words = await _userService.GetAllUsers();

            var response = words.Select(b => new UserResponse(b.Id, b.UserName, b.Email, b.PasswordHash));

            return Ok(response);

        }

    //     public IActionResult<bool> IsLogin(){
    //         bool result = false;
    //         System.Console.WriteLine(Response.Cookies.ToString);
    //     }
    }
}
