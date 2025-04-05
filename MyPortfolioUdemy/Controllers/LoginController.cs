using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace MyPortfolioUdemy.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var account = db.Accounts.FirstOrDefault(x => x.AccountName == username);
            if (account == null || account.AccountPassword != password)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            else
            {
                var claims = new List<Claim>{new Claim(ClaimTypes.Name, username)};
                SetCookie("AccountID", account.AccountID);
                var identity = new ClaimsIdentity(claims, "AccountID");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AccountID", principal);

                return RedirectToAction("Index", "Stats");
            }
        }
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("AccountID");
            await HttpContext.SignOutAsync("AccountID");
            return RedirectToAction("Index", "Login");
        }

        private void SetCookie(string key, int value, int? expireTime = null)
        {
            var option = new CookieOptions
            {
                Expires = expireTime.HasValue ? DateTime.Now.AddMinutes(expireTime.Value) : DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append(key, value.ToString(), option);
        }
    }
}
