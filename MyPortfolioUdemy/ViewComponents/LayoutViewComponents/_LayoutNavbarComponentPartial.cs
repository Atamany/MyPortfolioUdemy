using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            if (Request.Cookies["AccountID"] != null)
            {
                string id = Request.Cookies["AccountID"];
                var accountId = int.Parse(id);
                var AccountName = db.Accounts
                    .Where(x => x.AccountID == accountId)
                    .Select(x => x.AccountName)
                    .FirstOrDefault();
                ViewBag.AccountName = AccountName;
            }
            else
            {
                ViewBag.AccountName = "Misafir";
            }
            return View();
        }
    }
}
