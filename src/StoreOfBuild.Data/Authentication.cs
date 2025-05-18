using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain;
using Microsoft.EntityFrameworkCore.Design;

namespace StoreOfBuild.Data
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public Authentication(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
                return result.Succeeded;
            }
            catch
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}