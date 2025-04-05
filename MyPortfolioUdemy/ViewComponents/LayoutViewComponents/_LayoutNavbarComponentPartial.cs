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
                var AccountImage = db.Accounts
                    .Where(x => x.AccountID == accountId)
                    .Select(x => x.AccountImageUrl)
                    .FirstOrDefault();
                ViewBag.AccountName = AccountName;
                ViewBag.AccountImage = AccountImage;
            }
            else
            {
                ViewBag.AccountImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrBQBC8A_xwJz4xJPVizRRea9xZLrjF2zB2Q&s";
                ViewBag.AccountName = "Misafir";
            }
            return View();
        }
    }
}
