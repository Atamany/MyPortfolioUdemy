using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string OldPassword, string NewPassword, string NewPassword2)
        {
            string id = Request.Cookies["AccountID"];
            var accountId = int.Parse(id);
            var account = db.Accounts.Find(accountId);
            if (NewPassword == NewPassword2)
            {
                if (OldPassword == account.AccountPassword)
                {
                    account.AccountPassword = NewPassword;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Eski şifre hatalı.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Yeni şifreler uyuşmuyor.";
                return View();
            }
        }
    }
}
