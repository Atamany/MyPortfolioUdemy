using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace MyPortfolioUdemy.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Account acc)
        {
            var account = db.Accounts.FirstOrDefault(x => x.AccountName == acc.AccountName);
            if (account == null || account.AccountPassword != acc.AccountPassword)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            else
            {
                SetCookie("AccountID", account.AccountID);
                return RedirectToAction("Index", "Stats");
            }
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AccountID");

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
