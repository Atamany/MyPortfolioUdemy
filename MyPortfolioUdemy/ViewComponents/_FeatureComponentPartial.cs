using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = db.Features.ToList();
            return View(values);
        }
    }
}
