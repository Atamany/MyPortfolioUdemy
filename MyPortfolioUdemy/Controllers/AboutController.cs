using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var degerler = db.Abouts.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(About ab)
        {
            db.Abouts.Add(ab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            var deger = db.Abouts.Find(id);
            db.Abouts.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
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
            return RedirectToAction("Index");
        }
    }
}
