using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = db.Skills.ToList();
            return View(values);
        }
    }
}
