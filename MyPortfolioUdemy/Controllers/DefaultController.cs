using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [AllowAnonymous]
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
        [HttpPost]
        public IActionResult Index(Message msg)
        {
            msg.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            msg.isRead = false;
            db.Messages.Add(msg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
