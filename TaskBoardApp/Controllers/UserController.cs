using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskBoardApp.Data.Entities;
using TaskBoardApp.Models.User;

namespace TaskBoardApp.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> _userManager)
        {
            this.userManager = _userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }
    }
}
