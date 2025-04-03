using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _SocialMediaComponentPartial : ViewComponent
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = db.SocialMedias.ToList();
            return View(values);
        }
    }
}
