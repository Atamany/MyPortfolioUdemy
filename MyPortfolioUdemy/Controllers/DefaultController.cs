using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = db.Portfolios.Count();
            ViewBag.v2 = db.Testimonials.Count();
            ViewBag.v3 = db.Skills.Count();
            ViewBag.v4 = db.Messages.Count();

            return View();
        }
    }
}
