using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly IAuthentication _authenticate;

        public AccountController(ILogger<AccountController> logger, IAuthentication authenticate)
        {
            _logger = logger;
            _authenticate = authenticate;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authenticate.Authenticate(loginDto.Login, loginDto.Password);

            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                return View(loginDto);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}