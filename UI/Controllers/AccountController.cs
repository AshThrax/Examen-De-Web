using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Models;
using Microsoft.AspNetCore.Identity;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
      
        public async Task Login(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        //
        /// <summary>
        /// return a profile page only when the user is logged 
        /// </summary>
        /// <returns> nothing</returns>
        [Authorize]
        public IActionResult Profile()
        {
           
            var User = BuildUser();
            return View(User);                  
        }

        //create
        private UserProfile BuildUser() 
        {
            var user = new UserProfile()
            {
                UserName = User.Identity.Name,
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                UserId = User.Claims.FirstOrDefault(c => c.Type == "User")?.Value
            };
            return user;
        }
    }
}
