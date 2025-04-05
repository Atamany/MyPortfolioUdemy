using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var deger = db.Abouts.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About ab)
        {
            var deger = db.Abouts.Find(ab.AboutId);
            deger.Title = ab.Title;
            deger.SubDescription = ab.SubDescription;
            deger.Details = ab.Details;
            db.SaveChanges();
            return RedirectToAction("Index", "Stats");
        }
    }
}
